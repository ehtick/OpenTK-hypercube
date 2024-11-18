using System.Collections.Frozen;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.RegularExpressions;
using Hypercube.Generators.Class;
using Microsoft.CodeAnalysis;

namespace Hypercube.Generators.Graphics.GLFW;

[Generator]
[SuppressMessage("ReSharper", "InconsistentNaming")]
public sealed class GLFWEnumGenerator : Generator
{
    private readonly FrozenDictionary<string, string[]> AllowedEnums = new Dictionary<string, string[]>
    {
        { 
            "ErrorCode",
            [
                "GLFW_NO_ERROR",
                "GLFW_NOT_INITIALIZED",
                "GLFW_NO_CURRENT_CONTEXT",
                "GLFW_INVALID_ENUM",
                "GLFW_INVALID_VALUE",
                "GLFW_OUT_OF_MEMORY",
                "GLFW_API_UNAVAILABLE",
                "GLFW_VERSION_UNAVAILABLE",
                "GLFW_PLATFORM_ERROR",
                "GLFW_FORMAT_UNAVAILABLE",
                "GLFW_NO_WINDOW_CONTEXT",
                "GLFW_CURSOR_UNAVAILABLE",
                "GLFW_FEATURE_UNAVAILABLE",
                "GLFW_FEATURE_UNIMPLEMENTED",
                "GLFW_PLATFORM_UNAVAILABLE"
            ]
        }
    }.ToFrozenDictionary();
    
    protected override GeneratorOptions[] Options =>
    [
        new GeneratorOptions
        {
            Usings = [
                "System",
                "System.Runtime.InteropServices"
            ],
            Namespace = "Hypercube.Graphics.API.GLFW.Enums",
            Name = "ErrorCode",
            FileName = "ErrorCode",
            Path = "",
            File = "glfw3.h",
            Modifiers = "public",
            Type = "enum"
        }
    ];
    
    protected override void GenerateContent(GeneratorExecutionContext context, StringBuilder result, GeneratorOptions options, string fileContent)
    {
        var lines = fileContent.Split(NewLineSeparators, StringSplitOptions.RemoveEmptyEntries);

        foreach (var line in lines)
        {
            var match = Regex.Match(line, @"^#define\s+(GLFW_\w+)\s+(.+)");
            if (!match.Success)
                continue;
            
            var name = match.Groups[1].Value;
            var value = match.Groups[2].Value;

            if (AllowedEnums.TryGetValue(options.Name, out var allowed))
            {
                GenerateAllowed(result, name, value, allowed);
                continue;
            }
        }
    }
    
    private void GenerateAllowed(StringBuilder result, string name, string value, string[] allowed)
    {
        if (!allowed.Contains(name))
            return;

        var handledName = HandleName(name);
        result.AppendLine($"    {handledName} = {value},");
    }
    
    private string HandleName(string name)
    {
        const string prefix = "GLFW_";
        if (name.StartsWith(prefix))
            name = name[prefix.Length..];

        if (Regex.IsMatch(name, @"^-?\d+(\.\d+)?$"))
            name = $"Digit{name}";

        return UpperSnakeCaseToPascalCase(name);
    }
}