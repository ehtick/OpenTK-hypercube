using System.Collections.Frozen;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.RegularExpressions;
using Hypercube.Generators.Class;
using Microsoft.CodeAnalysis;

namespace Hypercube.Generators.Graphics.GLFW;

[Generator]
[SuppressMessage("ReSharper", "InconsistentNaming")]
public class GLFWCallbacksGenerator : HeaderGenerator
{
    protected override FrozenDictionary<string, string> KeywordMapping { get; set; } = GLFWTypeMapping.KeywordMapping;
    protected override FrozenDictionary<string, string> TypeMapping { get; set; } = GLFWTypeMapping.TypeMapping;
    private FrozenDictionary<string, string> NameMapping { get; set; } = GLFWTypeMapping.NameMapping;
    
    protected override string Dll => "glfw3.dll";

    protected override GeneratorOptions[] Options =>
    [
        new GeneratorOptions
        {
            Usings = [
                "System",
                "System.Runtime.InteropServices"
            ],
            Namespace = "Hypercube.Graphics.API.GLFW",
            Name = "GLFWCallbacks",
            FileName = "GLFWCallbacks",
            Path = "",
            File = "glfw3.h",
            Modifiers = "public static unsafe",
            Type = "class"
        },
    ];
    
    protected override void GenerateContent(GeneratorExecutionContext context, StringBuilder result, GeneratorOptions options, string fileContent)
    {
        var lines = fileContent.Split(NewLineSeparators, StringSplitOptions.RemoveEmptyEntries);
        
        foreach (var line in lines)
        {
            TryGenerateFunction(context, result, line);
        }
    }

    private void TryGenerateFunction(GeneratorExecutionContext context, StringBuilder result, string line)
    {
        var match = Regex.Match(line, @"typedef\s+([\w\s\*]+)\s*\(\*\s*(\w+)\s*\)\s*\((.*?)\);");
        if (!match.Success)
            return;

        var returnType = match.Groups[1].Value;
        var functionName = match.Groups[2].Value;
        var parameters = match.Groups[3].Value;

        var handledReturnType = HandlePointerTypes(returnType);
        var handledName = HandleName(functionName);
        var parametersConverted = HandleParameters(parameters);
        
        result.AppendLine();
        result.AppendLine($"    /// <remarks>");
        result.AppendLine($"    /// <c>");
        result.AppendLine($"    /// {line}");
        result.AppendLine($"    /// </c>");
        result.AppendLine($"    /// </remarks>");
        result.AppendLine($"    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]");
        result.AppendLine($"    public delegate {handledReturnType} {handledName}({parametersConverted});");
    }

    private string HandleName(string name)
    {
        const string glfwPrefix = "GLFW";
        if (name.StartsWith(glfwPrefix))
            name = name[glfwPrefix.Length..];

        const string functionPostfix = "fun";
        if (name.EndsWith(functionPostfix))
            name = name[..^functionPostfix.Length];

        if (char.IsLower(name[0]))
            name = $"{char.ToUpper(name[0])}{name[1..]}";

        return NameMapping.GetValueOrDefault(name, name);
    }
}