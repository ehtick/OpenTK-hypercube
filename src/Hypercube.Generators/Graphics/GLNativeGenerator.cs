using System.Collections.Frozen;
using System.Text;
using System.Text.RegularExpressions;
using Hypercube.Generators.Class;
using Microsoft.CodeAnalysis;

namespace Hypercube.Generators.Graphics;

[Generator]
public sealed class GLNativeGenerator : HeaderGenerator
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
        { "void", "void" },
        { "GLint", "int" },
        { "GLuint", "uint" },
        { "GLfloat", "float" },
        { "GLdouble", "double" },
        { "GLboolean", "byte" },
        { "GLbyte", "sbyte" },
        { "GLshort", "short" },
        { "GLushort", "ushort" },
        { "GLenum", "uint" },
        { "GLbitfield", "uint" },
        { "GLsizei", "int" },
        { "GLintptr", "nint" },
        { "GLsizeiptr", "nint" }
    }.ToFrozenDictionary();
    
    protected override string Dll => "opengl32.dll";

    protected override GeneratorOptions[] Options =>
    [
        new GeneratorOptions
        {
            Usings = [
                "System",
                "System.Runtime.InteropServices"
            ],
            Namespace = "Hypercube.Graphics.API.GL",
            Name = "GLNative",
            FileName = "GLNative",
            Path = "",
            File = "glcorearb.h",
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
        var match = Regex.Match(line, @"^(GLAPI|extern)\s+(\w+)\s+APIENTRY\s+(\w+)\s*\(([^)]*)\);");
        if (!match.Success)
            return;
        
        var returnType = match.Groups[2].Value;
        var functionName = match.Groups[3].Value;
        var parameters = match.Groups[4].Value;
        var parametersConverted = HandleParameters(parameters);
        
        result.AppendLine($"    /// <remarks>");
        result.AppendLine($"    /// <c>");
        result.AppendLine($"    /// {line}");
        result.AppendLine($"    /// </c>");
        result.AppendLine($"    /// </remarks>");
        result.AppendLine($"    [DllImport(\"{Dll}\")]");
        result.AppendLine($"    public static extern {HandleTypes(returnType)} {functionName}({parametersConverted});");
        result.AppendLine();
    }
}