namespace SchemaX_CodeGen.CodeGen
{
    public static class Printer
    {
        public static void Print(List<StructMeta> structs)
        {
            foreach (var s in structs)
            {
                Console.WriteLine($"✅ Struct: {s.Name}");
                Console.WriteLine($"   - DataWords: {s.DataWords}");
                Console.WriteLine($"   - PointerWords: {s.PointerWords}");

                foreach (var field in s.Fields)
                {
                    if (field.BitOffset is int bit)
                        Console.WriteLine($"     > {field.Name} : {field.Type} [bit offset {bit}]");
                    else if (field.PointerIndex is int ptr)
                        Console.WriteLine($"     > {field.Name} : {field.Type} [pointer index {ptr}]");
                    else
                        Console.WriteLine($"     > {field.Name} : {field.Type}");
                }

                Console.WriteLine();
            }
        }
    }
}