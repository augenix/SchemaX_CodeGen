

namespace SchemaX_CodeGen.CodeGen;

public static class EmitterRunner
{
    public static string ProjectName { get; set; } 
    public static void Run(List<StructMeta> structs, List<EnumMeta> enums, string outputDir)
    {
        Directory.CreateDirectory(outputDir);
        var knownEnums = new HashSet<string>(enums.Select(e => e.Name));

        var sb = new IndentedStringBuilder();

        // Emit shared header once
        sb.AppendLine("using System.Runtime.CompilerServices;");
        sb.AppendLine();
        sb.AppendLine($"namespace SchemaX_CodeGen.Generated.{ProjectName};");

        foreach (var meta in structs)
        {
            EncodeStructEmitter.EmitStructs(sb, meta, structs);
            sb.AppendLine();
            
        }

        var filePath = Path.Combine(outputDir, "EncodeStructs.cs");
        File.WriteAllText(filePath, sb.ToString());

        Console.WriteLine($"✅ Emitted encode structs to: {filePath}");

        sb = new IndentedStringBuilder();
        // Emit shared header once
        sb.AppendLine("using System.Runtime.CompilerServices;");
        sb.AppendLine();
        sb.AppendLine($"namespace SchemaX_CodeGen.Generated.{ProjectName};");

        foreach (var meta in structs)
        {
            DecodeStructEmitter.EmitStructs(sb, meta, structs);
            sb.AppendLine();
            
        }

        filePath = Path.Combine(outputDir, "DecodeStructs.cs");
        File.WriteAllText(filePath, sb.ToString());

        Console.WriteLine($"✅ Emitted decode structs to: {filePath}");
        
        sb = new IndentedStringBuilder();
        sb.AppendLine("using System;");
        sb.AppendLine("using System.Runtime.InteropServices;");
        sb.AppendLine();
        sb.AppendLine($"namespace SchemaX_CodeGen.Generated.{ProjectName};");
        sb.AppendLine();
        
        DtsEmitter.PrecomputeSizes(structs);

        foreach (var meta in structs.Where(m =>m.IsResponse))
        {
            DtsEmitter.EmitDts(sb, meta, structs);
            sb.AppendLine();
        }

        filePath = Path.Combine(outputDir, "Dts.cs");
        File.WriteAllText(filePath, sb.ToString());
        Console.WriteLine($"✅ Wrote {structs.Count} DTS structs to {filePath}");
        
        sb = new IndentedStringBuilder();
        
        sb.AppendLine("using System.Runtime.CompilerServices;");
        sb.AppendLine();
        sb.AppendLine($"namespace SchemaX_CodeGen.Generated.{EmitterRunner.ProjectName};");
        sb.AppendLine();
        sb.AppendLine("public static class DtsFactory");
        sb.AppendLine("{");
        sb.AppendLine("    private static int count;");
        sb.AppendLine();

        foreach (var meta in structs.Where(m => m.IsResponse))
        {
            DtsFactoryEmitter.EmitFromDecoder(sb, meta, structs);
        }

        sb.AppendLine("}");

        filePath = Path.Combine(outputDir, "DtsFactory.cs");
        File.WriteAllText(filePath, sb.ToString());
        Console.WriteLine($"✅ Wrote MessageFactory.cs with {structs.Count} FromDecoder methods");
        
    }
}