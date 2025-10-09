

using System.Text.RegularExpressions;

namespace SchemaX_CodeGen.CodeGen;

public static class EmitterRunner
{
    public static string ProjectName { get; set; }
    
    public static void Run(List<StructMeta> structs, List<EnumMeta> enums, string outputDir)
    {
        string code;
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
        code = sb.ToString();
        // 🔹 Cleanup pass before writing to file
        // code = Regex.Replace(code, @"\(\s*ushort\s*\)\s*\(\s*ushort\s*\)", "(ushort)");
        // code = Regex.Replace(code, @"\(\s*ulong\s*\)\s*\(\s*ulong\s*\)", "(ulong)");
        // code = Regex.Replace(code, @"\(\s*uint\s*\)\s*\(\s*uint\s*\)", "(uint)");
        // code = Regex.Replace(code, @"\(\s*long\s*\)\s*\(\s*long\s*\)", "(long)");
        // code = Regex.Replace(code, @"\(\s*int\s*\)\s*\(\s*int\s*\)", "(int)");
        // code = Regex.Replace(code, @"\s{2,}", " ");   // collapse extra spaces
        // code = Regex.Replace(code, @"\(\s+", "(");    // trim inside parens
        // code = Regex.Replace(code, @"\s+\)", ")");    // trim before ')'
        // code = Regex.Replace(code, @"\(\(([^()]+)\)\)", "($1)"); // flatten ((...))

        var filePath = Path.Combine(outputDir, "EncodeStructs.cs");
        File.WriteAllText(filePath, code);

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
        code = sb.ToString();
        // 🔹 Cleanup pass before writing to file
        // code = Regex.Replace(code, @"\(\s*ushort\s*\)\s*\(\s*ushort\s*\)", "(ushort)");
        // code = Regex.Replace(code, @"\(\s*ulong\s*\)\s*\(\s*ulong\s*\)", "(ulong)");
        // code = Regex.Replace(code, @"\(\s*uint\s*\)\s*\(\s*uint\s*\)", "(uint)");
        // code = Regex.Replace(code, @"\(\s*long\s*\)\s*\(\s*long\s*\)", "(long)");
        // code = Regex.Replace(code, @"\(\s*int\s*\)\s*\(\s*int\s*\)", "(int)");
        // code = Regex.Replace(code, @"\s{2,}", " ");   // collapse extra spaces
        // code = Regex.Replace(code, @"\(\s+", "(");    // trim inside parens
        // code = Regex.Replace(code, @"\s+\)", ")");    // trim before ')'
        // code = Regex.Replace(code, @"\(\(([^()]+)\)\)", "($1)"); // flatten ((...))
        filePath = Path.Combine(outputDir, "DecodeStructs.cs");
        File.WriteAllText(filePath, code);

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
        code = sb.ToString();
        filePath = Path.Combine(outputDir, "Dts.cs");
        File.WriteAllText(filePath, code);
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
        code = sb.ToString();
        filePath = Path.Combine(outputDir, "DtsFactory.cs");
        File.WriteAllText(filePath, code);
        Console.WriteLine($"✅ Wrote MessageFactory.cs with {structs.Count} FromDecoder methods");
        
    }
}