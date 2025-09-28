using System.Text;
using SchemaX_CodeGen.CodeGen;

namespace SchemaX_CodeGen
{
    class Program
    {
        static void Main(string[] args)
        {
            EmitterRunner.ProjectName = args[0];
            var inputDir = $"/home/jbroiles/RiderProjects/SchemaX_CodeGen/Schemas/{EmitterRunner.ProjectName}/";
            var outputDir = $"/home/jbroiles/RiderProjects/SchemaX_CodeGen/Generated/{EmitterRunner.ProjectName}/";
            var emitEnumsAndPointers = true;
            var emitStructs = true;
            var emitTemplates = true;
            var runTests = false;

            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);
            
            var schemaFiles = Directory.GetFiles(inputDir, "*.capnp.txt");

            if (schemaFiles.Length == 0)
            {
                Console.WriteLine("⚠️  No schema files found in input directory.");
                return;
            }
            
            var combinedText = string.Join(Environment.NewLine, schemaFiles.Select(File.ReadAllText));
            
            Console.WriteLine($"🔍 Parsing {schemaFiles.Length} schema files into unified model...");
            
            var (structs, enums) = Parser.ParseText(combinedText);

            if ((structs == null || structs.Count == 0) && (enums == null || enums.Count == 0))
            {
                Console.WriteLine("⚠️  No structs or enums found.");
                return;
            }

            Printer.Print(structs);
            if (emitStructs) EmitterRunner.Run(structs, enums, outputDir);
            if (emitTemplates) TemplateEmitter.EmitTemplates(structs, outputDir);
            Console.WriteLine("✅ Emitted RequestTemplates.cs");


            if (emitEnumsAndPointers && enums?.Count > 0)
            {
                var allEnumCode = new StringBuilder();
                allEnumCode.AppendLine($"namespace SchemaX_CodeGen.Generated.{EmitterRunner.ProjectName};");
                allEnumCode.AppendLine();

                foreach (var e in enums)
                {
                    allEnumCode.AppendLine(EnumEmitter.EmitEnum(e));
                    allEnumCode.AppendLine();
                }

                var enumFile = Path.Combine(outputDir, "Enums.cs");
                File.WriteAllText(enumFile, allEnumCode.ToString());
                Console.WriteLine($"✅ Wrote all enums to {Path.GetFileName(enumFile)}");
            }
            

            if (runTests)
            {
                Console.WriteLine("Running manual testing programs");
                //var tests = new TestEncodeHelpers();
                //var tests = new TestDecodeHelpers();
                //var tests = new TestRequestTemplates();

                //tests.Run();
            }
            Console.WriteLine("🏁 Done.");
        }
    }
}
