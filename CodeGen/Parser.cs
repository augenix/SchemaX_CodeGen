using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SchemaX_CodeGen.CodeGen
{
    public static class Parser
    {
        public static (List<StructMeta> Structs, List<EnumMeta> Enums) ParseRoot(CompilationUnitSyntax root)
        {
            var structResults = new List<StructMeta>();
            var enumResults = new List<EnumMeta>();

            // Extract enums
            foreach (var enumDecl in root.DescendantNodes().OfType<EnumDeclarationSyntax>())
            {
                var enumName = enumDecl.Identifier.Text;

                // Special case: unions always generate an enum called "WHICH".
                // We need to disambiguate them by prefixing the parent class name.
                if (enumName == "WHICH")
                {
                    if (enumDecl.Parent is ClassDeclarationSyntax parent)
                    {
                        enumName = parent.Identifier.Text + "Kind";
                    }
                }

                var enumMeta = new EnumMeta
                {
                    Name = enumName,
                    UnderlyingType = enumDecl.BaseList?.Types.FirstOrDefault()?.ToString() ?? "ushort",
                    Members = enumDecl.Members.Select(m => new EnumMemberMeta
                    {
                        Name = m.Identifier.Text,
                        Value = m.EqualsValue?.Value.ToString()
                    }).ToList()
                };

                enumResults.Add(enumMeta);
            }


            var knownEnumNames = new HashSet<string>(enumResults.Select(e => e.Name));
            
            // Extract structs from nested WRITER classes
            foreach (var parentClass in root.DescendantNodes().OfType<ClassDeclarationSyntax>())
            {
                // Skip pure container classes that only hold nested classes (like unions)
                if (parentClass.Members.All(m => m is ClassDeclarationSyntax))
                    continue;

                foreach (var nested in parentClass.Members.OfType<ClassDeclarationSyntax>())
                {
                    if (nested.Identifier.Text == "WRITER")
                    {
                        // Pass structMap into Extractor for flattenable chain detection
                        var meta = Extractor.FromWriterClass(nested);
                        if (meta != null)
                        {
                            // Build usedEnums list
                            var usedEnums = new HashSet<string>(
                                meta.Fields.Where(f => knownEnumNames.Contains(f.Type))
                                    .Select(f => f.Type));

                            meta.UsedEnums = usedEnums;
                            structResults.Add(meta);
                        }
                    }
                }
            }

            
            // Infer child structs from usage in pointer fields
            var nameToMeta = structResults.ToDictionary(s => s.Name);
            foreach (var meta in structResults)
            {
                foreach (var field in meta.Fields)
                {
                    if (field.IsPointerStruct && nameToMeta.ContainsKey(field.Type))
                    {
                        nameToMeta[field.Type].IsChildStruct = true;
                    }
                }
            }


            // Identify types used in pointer fields (likely child structs)
            var pointerFieldTypes = structResults
                .SelectMany(s => s.Fields)
                .Where(f => f.PointerIndex.HasValue)
                .Select(f =>
                {
                    var t = f.Type;
                    if (t.StartsWith("StructList<"))
                        return t.Substring("StructList<".Length).TrimEnd('>');
                    return t;
                })
                .ToHashSet();

            // Mark each struct: requires ref struct if not used as a pointer target
            foreach (var meta in structResults)
            {
                meta.RequiresRefStruct = !pointerFieldTypes.Contains(meta.Name);
            }
            // Assign numeric UnionTag to any struct whose name matches a value in a known union enum
            foreach (var meta in structResults)
            {
                foreach (var enumMeta in enumResults)
                {
                    if (!(enumMeta.Name.EndsWith("ClassKind") ||
                        enumMeta.Name.EndsWith("Kind") ||
                        enumMeta.Name.EndsWith("Tag")))
                        continue;
                    var expectedTag = char.ToLowerInvariant(meta.Name[0]) + meta.Name.Substring(1);
                    var index = enumMeta.Members.FindIndex(m => m.Name == expectedTag);
                    if (index >= 0)
                    {
                        meta.UnionTag = index;
                        break;
                    }

                }
            }
            
            return (structResults, enumResults);
        }

        private static bool IsFieldBlittable(string type, Dictionary<string, StructMeta> structMap)
        {
            switch (type)
            {
                case "bool":
                case "byte":
                case "sbyte":
                case "short":
                case "ushort":
                case "int":
                case "uint":
                case "long":
                case "ulong":
                case "float":
                case "double":
                case "char":
                case "FixedAscii32":
                    return true;
            }

            if (type.StartsWith("PrimitiveList<") ||
                type.StartsWith("TextList") ||
                type.StartsWith("StructList<") ||
                type == "string" ||
                type == "TextList")
                return false;

            if (structMap.TryGetValue(type, out var meta))
                return meta.Fields.All(f =>
                    !f.PointerIndex.HasValue &&
                    IsFieldBlittable(f.Type, structMap));

            return false;
        }
        public static (List<StructMeta> Structs,  List<EnumMeta> Enums) ParseText(string text)
        {
            var tree = CSharpSyntaxTree.ParseText(text);
            var root = tree.GetCompilationUnitRoot();
            return ParseRoot(root);
        }
        public static (List<StructMeta> Structs, List<EnumMeta> Enums) ParseFile(string path)
        {
            var text = File.ReadAllText(path);
            var tree = CSharpSyntaxTree.ParseText(text);
            var root = tree.GetCompilationUnitRoot();
            return ParseRoot(root);
        }

    }
}
