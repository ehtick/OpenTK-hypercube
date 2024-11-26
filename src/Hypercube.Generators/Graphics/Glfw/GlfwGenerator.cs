using System.Collections.Frozen;
using System.Text;
using System.Text.RegularExpressions;
using Hypercube.Generators.Class;
using Hypercube.Generators.Class.Data;
using Microsoft.CodeAnalysis;
using Type = Hypercube.Generators.Class.Data.Type;

namespace Hypercube.Generators.Graphics.GLFW;

[Generator]
public class GlfwGenerator : HeaderGenerator
{
    /// <summary>
    /// Maps specific keywords used in the header file to alternative representations.
    /// </summary>
    protected override FrozenDictionary<string, string> KeywordMapping { get; set; } = GlfwTypeMapping.KeywordMapping;

    /// <summary>
    /// Maps C types in the header file to their C# equivalents.
    /// </summary>
    protected override FrozenDictionary<string, string> TypeMapping { get; set; } = GlfwTypeMapping.TypeMapping;

    /// <summary>
    /// Specifies the dynamic link library to import.
    /// </summary>
    protected override string Dll => "glfw3.dll";

    /// <summary>
    /// Provides generation options such as namespace, class name, and modifiers.
    /// </summary>
    protected override GeneratorOptions[] Options =>
    [
        new GeneratorOptions
        {
            Usings = [
                "System",
                "System.Runtime.InteropServices"
            ],
            Namespace = "Hypercube.Graphics.Api.Glfw",
            Name = "Glfw",
            File = "glfw3.h",
            Modifiers = "public static unsafe",
            Type = "class"
        },
    ];

    /// <summary>
    /// Generates the content of the output file based on the provided header file.
    /// </summary>
    /// <param name="context">Execution context for the generator.</param>
    /// <param name="result">StringBuilder to accumulate the generated code.</param>
    /// <param name="options">Options specifying generation parameters.</param>
    /// <param name="fileContent">Contents of the header file.</param>
    protected override void GenerateContent(GeneratorExecutionContext context, StringBuilder result, GeneratorOptions options, string fileContent)
    {
        var lines = fileContent.Split(NewLineSeparators, StringSplitOptions.RemoveEmptyEntries);

        foreach (var line in lines)
        {
            TryGenerateFunction(result, line);
        }
    }

    /// <summary>
    /// Tries to parse and generate a function definition from a header file line.
    /// </summary>
    /// <param name="result">StringBuilder to append the generated function code.</param>
    /// <param name="line">Line from the header file to parse.</param>
    private void TryGenerateFunction(StringBuilder result, string line)
    {
        var match = Regex.Match(line, @"^(GLFWAPI|extern)\s+([\w\s\*]+)\s+(\w+)\s*\(([^)]*)\);");

        if (!match.Success)
            return;

        var function = new Function
        {
            Name = match.Groups[3].Value,
            ReturnType = HandleType(match.Groups[2].Value),
            Arguments = HandleArguments(match.Groups[4].Value),
        };

        var newName = char.ToUpper(function.Name[4]) + function.Name[5..]; // Remove "glfw" prefix and capitalize first letter

        result.AppendLine();
        result.AppendLine($"    public static {function.ReturnType} {newName}({function.ArgumentsString})");
        result.AppendLine("    {");
        result.AppendLine($"        {(function.ReturnType.ToString() == "void" ? "" : "return ")}GlfwNative.{function.Name}({string.Join(", ", function.Arguments.Select(arg => arg.Name))});");
        result.AppendLine("    }");
    }
}