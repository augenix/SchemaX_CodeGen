using System.Globalization;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SchemaX_CodeGen.CodeGen
{
    public static class Extractor
    {
        private static readonly Dictionary<string, int> UnionTagMap = new(StringComparer.OrdinalIgnoreCase);

        public static StructMeta FromWriterClass(ClassDeclarationSyntax writerClass)
        {
            var parentClass = writerClass.Parent as ClassDeclarationSyntax;
            if (parentClass == null) return null;

            if (ShouldSkipAsEnvelopeUnion(writerClass))
            {
                BuildUnionTagMap(parentClass, writerClass);
                Console.WriteLine($"[UnionTagMap] for {parentClass.Identifier.Text}:");
                foreach (var kvp in UnionTagMap)
                {
                    Console.WriteLine($"   {kvp.Key} => {kvp.Value}");
                }

                Console.WriteLine($"[Extractor] Skipping envelope union: {parentClass.Identifier.Text}");
                return null;
            }

            BuildUnionTagMap(parentClass, writerClass);

            var meta = new StructMeta
            {
                Name = parentClass.Identifier.Text,
                DataWords = 0,
                PointerWords = 0,
                Fields = new List<FieldMeta>(),
                IsUnion = false,
            };
            // meta.Name is already parentClass.Identifier.Text (the arm struct name)
            if (UnionTagMap.TryGetValue(meta.Name, out var tag))
                meta.UnionTag = tag;

            // optional debug:
            Console.WriteLine($"[UnionTagMap] lookup by struct '{meta.Name}' → tag {meta.UnionTag}");

            var ctor = writerClass.Members.OfType<ConstructorDeclarationSyntax>().FirstOrDefault();
            if (ctor != null)
            {
                foreach (var expr in ctor.DescendantNodes().OfType<InvocationExpressionSyntax>())
                {
                    if (expr.Expression is MemberAccessExpressionSyntax m && m.Name.Identifier.Text == "SetStruct")
                    {
                        var a = expr.ArgumentList.Arguments;
                        if (a.Count == 2 &&
                            int.TryParse(a[0].ToString(), out var dw) &&
                            int.TryParse(a[1].ToString(), out var pw))
                        {
                            meta.DataWords = dw;
                            meta.PointerWords = pw;
                        }
                    }
                }
            }

            foreach (var prop in writerClass.Members.OfType<PropertyDeclarationSyntax>())
            {
                var f = new FieldMeta
                {
                    Name = prop.Identifier.Text,
                    TypeRaw = prop.Type.ToString(),
                    Type = NormalizeType(NormalizeListType(prop.Type.ToString()))
                };

                if (f.Type == "WHICH")
                    f.Type = parentClass.Identifier.Text + "Kind";

                // existing setter parsing
                var setter =
                    prop.AccessorList?.Accessors.FirstOrDefault(a => a.Kind() == SyntaxKind.SetAccessorDeclaration);
                if (setter != null)
                {
                    foreach (var call in setter.DescendantNodes().OfType<InvocationExpressionSyntax>())
                    {
                        string method = call.Expression switch
                        {
                            IdentifierNameSyntax id => id.Identifier.Text,
                            MemberAccessExpressionSyntax ma => ma.Name.Identifier.Text,
                            _ => null
                        };
                        if (method == null) continue;

                        var args = call.ArgumentList.Arguments;
                        if (method == "WriteData" && args.Count >= 1 &&
                            int.TryParse(args[0].ToString().TrimEnd('U', 'L'), out int bit))
                            f.BitOffset = bit;

                        else if ((method.StartsWith("Write") || method == "Link") && args.Count >= 1 &&
                                 int.TryParse(args[0].ToString().TrimEnd('U', 'L'), out int ptr))
                            f.PointerIndex = ptr;
                    }
                }

                // 🔹 NEW: capture default literal from getter for XOR logic
                var getter =
                    prop.AccessorList?.Accessors.FirstOrDefault(a => a.Kind() == SyntaxKind.GetAccessorDeclaration);
                if (getter != null)
                {
                    var readCall = getter.DescendantNodes()
                        .OfType<InvocationExpressionSyntax>()
                        .FirstOrDefault(inv =>
                        {
                            if (inv.Expression is MemberAccessExpressionSyntax ma)
                                return ma.Name.Identifier.Text.StartsWith("ReadData", StringComparison.Ordinal);
                            return false;
                        });

                    if (readCall != null)
                    {
                        var args = readCall.ArgumentList.Arguments;
                        if (args.Count >= 2 && TryParseDefaultLiteral(args[^1].Expression, f.Type, out var def))
                            f.DefaultValue = def;
                        else
                            f.DefaultValue = 0;
                    }
                }

                if (f.PointerIndex.HasValue &&
                    !f.Type.StartsWith("PrimitiveList<") &&
                    f.Type != "TextList" &&
                    !f.Type.StartsWith("StructList<") &&
                    f.Type != "string")
                {
                    f.IsPointerStruct = true;
                }


                meta.Fields.Add(f);
            }

            ClassifyMessage(meta);
            var whichEnumExists = parentClass.Members
                .OfType<EnumDeclarationSyntax>()
                .Any(e => e.Identifier.Text.Equals("WHICH", StringComparison.OrdinalIgnoreCase));

            if (whichEnumExists && meta.Fields.Count > 0)
            {
                // this struct has a WHICH and fields — real struct with embedded union
                meta.IsUnion = true;
            }

            return meta;
        }

        private static void BuildUnionTagMap(ClassDeclarationSyntax parentClass, ClassDeclarationSyntax writerClass)
        {
            var whichEnum = parentClass.Members
                .OfType<EnumDeclarationSyntax>()
                .FirstOrDefault(e => e.Identifier.Text.Equals("WHICH", StringComparison.OrdinalIgnoreCase));
            if (whichEnum == null) return;

            var enumTagMap = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            int cur = -1;
            foreach (var m in whichEnum.Members)
            {
                if (m.EqualsValue?.Value is LiteralExpressionSyntax lit && int.TryParse(lit.Token.ValueText, out var v))
                    cur = v;
                else
                    cur++;
                enumTagMap[m.Identifier.Text] = cur;
            }

            var props = writerClass.Members
                .OfType<PropertyDeclarationSyntax>()
                .Where(p => !p.Identifier.Text.Equals("Which", StringComparison.OrdinalIgnoreCase))
                .ToArray();

            foreach (var p in props)
            {
                var armName = p.Identifier.Text; // property name in WHICH
                if (!enumTagMap.TryGetValue(armName, out var tag))
                    continue;

                // already good:
                UnionTagMap[$"{parentClass.Identifier.Text}.{armName}"] = tag; // Parent.Arm
                UnionTagMap[armName] = tag;                                    // Arm (by property name)

                // 🔹 NEW: also key by the arm's struct type name
                var armStructName = GetArmStructNameFromType(p.Type);          // e.g. "CmeFeedUpdateTrade"
                if (!string.IsNullOrEmpty(armStructName))
                    UnionTagMap[armStructName] = tag;                          // Arm (by struct name)
            }
        }


        private static void ClassifyMessage(StructMeta meta)
        {
            var n = meta.Name.TrimEnd(';');
            if ((n.StartsWith("CmeFeedClient") && !n.EndsWith("Response")) ||
                (n.Contains("Request") && !n.EndsWith("Response")) ||
                (n.StartsWith("FeedApi") && !n.EndsWith("Response") && !n.EndsWith("Reject")) ||
                n.EndsWith("Request") || n.Contains("Command"))
            {
                meta.IsRequest = true;
                return;
            }

            meta.IsResponse = true;
        }

        private static string NormalizeListType(string type)
        {
            if (type.StartsWith("ListOfPrimitivesSerializer<"))
            {
                var inner = type.Substring("ListOfPrimitivesSerializer<".Length).TrimEnd('>');
                inner = StripNamespace(inner);
                return $"PrimitiveList<{inner}>";
            }

            if (type.StartsWith("ListOfStructsSerializer<"))
            {
                var inner = type.Substring("ListOfStructsSerializer<".Length).TrimEnd('>');
                inner = StripWriterReaderSuffix(inner);
                inner = StripNamespace(inner);
                return $"StructList<{inner}>";
            }

            if (type == "ListOfTextSerializer") return "TextList";
            return type;
        }

        private static string NormalizeType(string type)
        {
            if (type == "string") return "string";
            if (type.IndexOf('<') >= 0) return type;
            type = StripWriterReaderSuffix(type);
            type = StripNamespace(type);
            return type;
        }

        private static string StripNamespace(string type)
        {
            var lastDot = type.LastIndexOf('.');
            return lastDot >= 0 ? type[(lastDot + 1)..] : type;
        }

        private static string StripWriterReaderSuffix(string type)
        {
            if (type.EndsWith(".WRITER")) return type[..^7];
            if (type.EndsWith(".READER")) return type[..^7];
            return type;
        }

        private static bool ShouldSkipAsEnvelopeUnion(ClassDeclarationSyntax writerClass)
        {
            if (writerClass.Parent is not ClassDeclarationSyntax parentClass)
                return false;

            bool hasWhichEnum = parentClass.Members
                .OfType<EnumDeclarationSyntax>()
                .Any(e => e.Identifier.Text.Equals("WHICH", StringComparison.OrdinalIgnoreCase));
            if (!hasWhichEnum) return false;

            var props = writerClass.Members.OfType<PropertyDeclarationSyntax>()
                .Where(p => !p.Identifier.Text.Equals("Which", StringComparison.OrdinalIgnoreCase))
                .ToArray();

            bool allWriterProps = props.All(p =>
                GetUnqualifiedTypeName(p.Type).EndsWith("WRITER", StringComparison.Ordinal));
            return allWriterProps;
        }

        private static string GetUnqualifiedTypeName(TypeSyntax t) =>
            t switch
            {
                QualifiedNameSyntax q => q.Right.Identifier.Text,
                IdentifierNameSyntax i => i.Identifier.Text,
                GenericNameSyntax g => g.Identifier.Text,
                PredefinedTypeSyntax p => p.Keyword.Text,
                _ => t.ToString()
            };

        private static bool TryParseDefaultLiteral(ExpressionSyntax expr, string fieldType, out object def)
        {
            def = 0;
            string valText = null;

            if (expr is LiteralExpressionSyntax lit)
            {
                valText = lit.Token.ValueText;
            }
            else if (expr is PrefixUnaryExpressionSyntax unary && unary.OperatorToken.Text == "-" &&
                     unary.Operand is LiteralExpressionSyntax lit2)
            {
                valText = "-" + lit2.Token.ValueText;
            }

            if (valText == null)
                return false;

            switch (fieldType)
            {
                case "Int64":
                    def = long.Parse(valText, CultureInfo.InvariantCulture);
                    return true;
                case "UInt64":
                    def = ulong.Parse(valText, CultureInfo.InvariantCulture);
                    return true;
                case "Int32":
                    def = int.Parse(valText, CultureInfo.InvariantCulture);
                    return true;
                case "UInt32":
                    def = uint.Parse(valText, CultureInfo.InvariantCulture);
                    return true;
                case "Float64":
                    def = double.Parse(valText, CultureInfo.InvariantCulture);
                    return true;
                case "Float32":
                    def = float.Parse(valText, CultureInfo.InvariantCulture);
                    return true;
                case "bool":
                    def = bool.Parse(valText);
                    return true;
                default:
                    def = valText;
                    return true;
            }
        }

        private static string GetArmStructNameFromType(TypeSyntax type)
        {
            // Example: global::CapnpGen.CmeFeedManagerUpdate.GroupStatus.WRITER
            var s = type.ToString();
            if (s.StartsWith("global::", StringComparison.Ordinal))
                s = s.Substring("global::".Length);

            // trim trailing .WRITER/.READER
            int idx = s.LastIndexOf(".WRITER", StringComparison.OrdinalIgnoreCase);
            if (idx < 0)
                idx = s.LastIndexOf(".READER", StringComparison.OrdinalIgnoreCase);
            if (idx >= 0)
                s = s.Substring(0, idx);

            // now take the identifier after the last dot = "GroupStatus"
            int lastDot = s.LastIndexOf('.');
            return lastDot >= 0 ? s[(lastDot + 1)..] : s;
        }
    }

}
