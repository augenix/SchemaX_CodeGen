

namespace SchemaX_CodeGen.CodeGen;

public static class EmitterRunner
{
    public static string ProjectName { get; set; } 
    public static void Run(List<StructMeta> structs, string outputDir)
    {
        Directory.CreateDirectory(outputDir);

        var sb = new IndentedStringBuilder();
        var projectName = GetProjectName();

        // Emit shared header once
        sb.AppendLine("using System.Runtime.CompilerServices;");
        sb.AppendLine();
        sb.AppendLine($"namespace {projectName}.Generated;");

        foreach (var meta in structs)
        {
            // Struct body
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
        sb.AppendLine($"namespace {projectName}.Generated;");

        foreach (var meta in structs)
        {
            // Struct body
            DecodeStructEmitter.EmitStructs(sb, meta, structs);
            sb.AppendLine();
            
        }

        filePath = Path.Combine(outputDir, "DecodeStructs.cs");
        File.WriteAllText(filePath, sb.ToString());

        Console.WriteLine($"✅ Emitted decode structs to: {filePath}");
        
    }
    
    public static string GetProjectName()
    {
        var dir = new DirectoryInfo(Directory.GetCurrentDirectory());

        while (dir != null)
        {
            var csproj = dir.GetFiles("*.csproj").FirstOrDefault();
            if (csproj != null)
            {
                return Path.GetFileNameWithoutExtension(csproj.Name);
            }
            dir = dir.Parent; // walk upward
        }

        throw new InvalidOperationException("Could not find .csproj in any parent directory.");
    }
}