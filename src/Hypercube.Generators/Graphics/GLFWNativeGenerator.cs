using System.Collections.Frozen;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis;

namespace Hypercube.Generators.Graphics;

[Generator]
public sealed class GLFWativeGenerator : HeaderClassGenerator
{
    protected override FrozenDictionary<string, string> KeywordMapping { get; set; } = new Dictionary<string, string>
    {
        { "params", "@params" },
        { "string", "@string" },
        { "object", "@object" },
        { "ref", "@ref" }
    }.ToFrozenDictionary();
        
    protected override FrozenDictionary<string, string> TypeMapping { get; set; } = new Dictionary<string, string>
    {
        { "int", "int" },
        { "void", "void" },
        { "char", "byte" },
        { "GLFWwindow", "nint" },
        { "GLFWmonitor", "nint" },
        { "GLFWvidmode", "nint" },
        { "GLFWkeyfun", "nint" },
        { "GLFWmousebuttonfun", "nint" },
        { "VkResult", "int" }
    }.ToFrozenDictionary();
        
    protected override string[] Header =>
    [
        "This class is auto-generated",
        "Source: glfw3.h"
    ];

    protected override string[] Usings =>
    [
        "System",
        "System.Runtime.InteropServices"
    ];

    protected override string Dll => "glfw3.dll";
    protected override string Namespace => "Hypercube.Graphics.API";
    protected override string Name => "GLFWNative";
    protected override string Path => "";
    protected override string Source => "glfw3.h";
    protected override string Modifiers => "public static unsafe";

    protected override void GenerateContent(GeneratorExecutionContext context, StringBuilder result, string source)
    {
        var lines = source.Split(NewLineSeparators, StringSplitOptions.RemoveEmptyEntries);

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
        var parametersConverted = ConvertParametersToCSharp(parameters);
            
        result.AppendLine($"    /// <remarks>");
        result.AppendLine($"    /// <c>");
        result.AppendLine($"    /// {line}");
        result.AppendLine($"    /// </c>");
        result.AppendLine($"    /// </remarks>");
        result.AppendLine($"    [DllImport(\"{Dll}\")]");
        result.AppendLine($"    public static extern {HandlePointerTypes(returnType)} {functionName}({parametersConverted});");
        result.AppendLine();
    }
}