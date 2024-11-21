using System.Collections.Frozen;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.RegularExpressions;
using Hypercube.Generators.Class;
using Microsoft.CodeAnalysis;

namespace Hypercube.Generators.Graphics.GLFW;

[Generator]
[SuppressMessage("ReSharper", "InconsistentNaming")]
public sealed class GlfwNativeGenerator : HeaderGenerator
{
    protected override FrozenDictionary<string, string> KeywordMapping { get; set; } = GlfwTypeMapping.KeywordMapping;
    protected override FrozenDictionary<string, string> TypeMapping { get; set; } = GlfwTypeMapping.TypeMapping;

    protected override string Dll => "glfw3.dll";

    protected override GeneratorOptions[] Options =>
    [
        new GeneratorOptions
        {
            Usings = [
              "System",
              "System.Runtime.InteropServices"
            ],
            Namespace = "Hypercube.Graphics.Api.Glfw",
            Name = "GlfwNative",
            FileName = "GlfwNative",
            Path = "",
            File = "glfw3.h",
            Modifiers = "public static unsafe",
            Type = "class"
        },
    ];
    
    protected override void GenerateContent(GeneratorExecutionContext context, StringBuilder result, GeneratorOptions options, string fileContent)
    {
        var lines = fileContent.Split(NewLineSeparators, StringSplitOptions.RemoveEmptyEntries);

        result.AppendLine("    public const int True = 1;");
        result.AppendLine("    public const int False = 0;");
        
        foreach (var line in lines)
        {
            TryGenerateFunction(context, result, line);
        }
    }

    private void TryGenerateFunction(GeneratorExecutionContext context, StringBuilder result, string line)
    {
        var match = Regex.Match(line, @"^(GLFWAPI|extern)\s+([\w\s\*]+)\s+(\w+)\s*\(([^)]*)\);");
        if (!match.Success)
            return;

        var returnType = match.Groups[2].Value;
        var functionName = match.Groups[3].Value;
        var parameters = match.Groups[4].Value;
        var parametersConverted = HandleParameters(parameters);
        
        result.AppendLine();
        result.AppendLine($"    /// <remarks>");
        result.AppendLine($"    /// <c>");
        result.AppendLine($"    /// {line}");
        result.AppendLine($"    /// </c>");
        result.AppendLine($"    /// </remarks>");
        result.AppendLine($"    [DllImport(\"{Dll}\")]");
        result.AppendLine($"    public static extern {HandlePointerTypes(returnType)} {functionName}({parametersConverted});");
    }
}