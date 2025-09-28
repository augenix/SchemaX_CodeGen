using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SchemaX_CodeGen.CodeGen
{
    public static class Extractor
    {
        private static readonly Dictionary<string,string> Overrides = new(StringComparer.OrdinalIgnoreCase)
        {
            { "FeedApiReject", "Control" }
        };

        public static StructMeta FromWriterClass(ClassDeclarationSyntax writerClass)
        {
            var parentClass = writerClass.Parent as ClassDeclarationSyntax;
            
            if (ShouldSkipAsEnvelopeUnion(writerClass))
            {
                var name = (writerClass.Parent as ClassDeclarationSyntax)?.Identifier.Text ?? "unknown";
                Console.WriteLine($"[Extractor] Skipping envelope union: {name}");
                return null;
            }
            
            var meta = new StructMeta
            {
                Name = parentClass?.Identifier.Text ?? "Unknown",
                DataWords = 0,
                PointerWords = 0,
                Fields = new List<FieldMeta>(),
                IsUnion = false,
            };

            // Parse SetStruct(x, y) from constructor to get layout info
            var ctor = writerClass.Members
                .OfType<ConstructorDeclarationSyntax>()
                .FirstOrDefault();

            if (ctor != null)
            {
                foreach (var expr in ctor.DescendantNodes().OfType<InvocationExpressionSyntax>())
                {
                    if (expr.Expression is MemberAccessExpressionSyntax member &&
                        member.Name.Identifier.Text == "SetStruct")
                    {
                        var args = expr.ArgumentList.Arguments;
                        if (args.Count == 2 &&
                            int.TryParse(args[0].ToString(), out var dataWords) &&
                            int.TryParse(args[1].ToString(), out var pointerWords))
                        {
                            meta.DataWords = dataWords;
                            meta.PointerWords = pointerWords;
                        }
                    }
                }
            }

            // Parse fields and detect layout info from setter expressions
            foreach (var prop in writerClass.Members.OfType<PropertyDeclarationSyntax>())
            {
                var field = new FieldMeta
                {
                    Name = prop.Identifier.Text,
                    TypeRaw = prop.Type.ToString(),
                    Type = NormalizeType(NormalizeListType(prop.Type.ToString()))
                };
                if (field.Type == "WHICH" && parentClass != null)
                {
                    field.Type = parentClass.Identifier.Text + "Kind";
                }

                var setter = prop.AccessorList?.Accessors
                    .FirstOrDefault(a => a.Kind() == SyntaxKind.SetAccessorDeclaration);

                if (setter != null)
                {
                    foreach (var expr in setter.DescendantNodes().OfType<InvocationExpressionSyntax>())
                    {
                        string? methodName = expr.Expression switch
                        {
                            IdentifierNameSyntax id => id.Identifier.Text,
                            MemberAccessExpressionSyntax member => member.Name.Identifier.Text,
                            _ => null
                        };

                        if (methodName is not null)
                        {
                            var args = expr.ArgumentList.Arguments;

                            if (methodName == "WriteData" && args.Count >= 1)
                            {
                                if (int.TryParse(args[0].ToString().TrimEnd('U', 'L'), out int bitOffset))
                                {
                                    field.BitOffset = bitOffset;
                                }
                            }
                            else if ((methodName.StartsWith("Write") || methodName == "Link") && args.Count >= 1)
                            {
                                if (int.TryParse(args[0].ToString().TrimEnd('U', 'L'), out int pointerIndex))
                                {
                                    field.PointerIndex = pointerIndex;
                                }
                            }
                        }
                    }
                }

                // Identify pointer-to-struct fields (non-list, non-string)
                if (field.PointerIndex.HasValue)
                {
                    if (!field.Type.StartsWith("PrimitiveList<") &&
                        field.Type != "TextList" &&
                        !field.Type.StartsWith("StructList<") &&
                        field.Type != "string")
                    {
                        field.IsPointerStruct = true;
                    }
                }

                meta.Fields.Add(field);
            }
            // Heuristic: mark only request/control messages as template targets
            ClassifyMessage(meta);

            return meta;
        }

        private static void ClassifyMessage(StructMeta meta)
        {
            if (Overrides.TryGetValue(meta.Name, out var forced))
            {
                ApplyForced(meta, forced);
                return;
            }

            var n = meta.Name.TrimEnd(';');
            if (n == "CmeFuturesDefinitionRequest") Console.WriteLine($"[Extractor] found {n}");

            if ((n.StartsWith("CmeFeedClient") && !n.EndsWith("Response"))
                || (n.Contains("Request") && !n.EndsWith("Response"))
                || (n.StartsWith("FeedApi") && !n.EndsWith("Response") && !n.EndsWith("Reject"))
                || n.EndsWith("Request") || n.Contains("Command"))
            {
                meta.IsRequest = true;
                return;
            }
            meta.IsResponse = true;
        }

        private static void ApplyForced(StructMeta meta, string kind)
        {
            meta.IsRequest = meta.IsResponse; 

            switch (kind)
            {
                case "Request": meta.IsRequest = true; break;
                case "Response": meta.IsResponse = true; break;
            }
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

            if (type == "ListOfTextSerializer")
                return "TextList";

            return type;
        }

        private static string NormalizeType(string type)
        {
            if (type == "string")
                return "string";

            if (type.IndexOf('<') >= 0)
                return type;

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
            if (type.EndsWith(".WRITER"))
                return type[..^7];
            if (type.EndsWith(".READER"))
                return type[..^7];
            return type;
        }

        /*private static bool IsUnionWriter(ClassDeclarationSyntax writerClass)
        {
            if (writerClass.Parent is not ClassDeclarationSyntax parentClass)
                return false;

            // Only skip if the parent struct name ends with "Update" and has a WHICH enum
            return parentClass.Identifier.Text.EndsWith("Update")
                   && parentClass.Members.OfType<EnumDeclarationSyntax>()
                       .Any(e => e.Identifier.Text == "WHICH");
        }*/
        
        private static bool IsUnionWriter(ClassDeclarationSyntax writerClass)
        {
            if (writerClass.Parent is not ClassDeclarationSyntax parentClass)
                return false;

            // union indicator: parent has a WHICH/Which enum
            bool hasWhichEnum =
                parentClass.Members
                    .OfType<EnumDeclarationSyntax>()
                    .Any(e => e.Identifier.Text.Equals("WHICH", StringComparison.OrdinalIgnoreCase) ||
                              e.Identifier.Text.Equals("Which", StringComparison.OrdinalIgnoreCase));

            // union indicator: WRITER has a property named Which (Cap’n Proto C# generator pattern)
            bool hasWhichProperty =
                writerClass.Members
                    .OfType<PropertyDeclarationSyntax>()
                    .Any(p => p.Identifier.Text.Equals("Which", StringComparison.OrdinalIgnoreCase));

            return hasWhichEnum || hasWhichProperty;
        }

        private static bool ShouldSkipAsEnvelopeUnion(ClassDeclarationSyntax writerClass)
        {
            if (writerClass.Parent is not ClassDeclarationSyntax parentClass)
                return false;

            // must have Which discriminant
            bool hasWhichEnum =
                parentClass.Members.OfType<EnumDeclarationSyntax>()
                    .Any(e => e.Identifier.Text.Equals("WHICH", StringComparison.OrdinalIgnoreCase));
            if (!hasWhichEnum) return false;

            // collect properties other than the discriminant
            var props = writerClass.Members.OfType<PropertyDeclarationSyntax>()
                .Where(p => !p.Identifier.Text.Equals("Which", StringComparison.OrdinalIgnoreCase))
                .ToArray();

            // if there are no props we treat as non-envelope
            if (props.Length == 0) return false;

            // classify property types
            bool allWriterProps = props.All(p => GetUnqualifiedTypeName(p.Type).EndsWith("WRITER", StringComparison.Ordinal));

            // skip if everything is a writer (envelope union)
            return allWriterProps;
        }

        private static string GetUnqualifiedTypeName(TypeSyntax t)
        {
            return t switch
            {
                QualifiedNameSyntax q => q.Right.Identifier.Text,
                IdentifierNameSyntax i => i.Identifier.Text,
                GenericNameSyntax g    => g.Identifier.Text,
                PredefinedTypeSyntax p => p.Keyword.Text,
                _                      => t.ToString()
            };
        }


    }
}
