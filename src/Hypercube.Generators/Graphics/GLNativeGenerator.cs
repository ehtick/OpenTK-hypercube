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
    
    protected override string[] Header =>
    [
        "This class is auto-generated",
        "Source: glcorearb.h"
    ];

    protected override string[] Usings =>
    [
        "System",
        "System.Runtime.InteropServices"   
    ];

    protected override string Dll => "opengl32.dll";
    protected override string Namespace => "Hypercube.Graphics.API";
    protected override string Name => "GLNative";
    protected override string Path => "";
    protected override string Source => "glcorearb.h";
    protected override string Modifiers => "public static unsafe";
    protected override string Type => "class";
    
    protected override void GenerateContent(GeneratorExecutionContext context, StringBuilder result, string source)
    {
        var lines = source.Split(NewLineSeparators, StringSplitOptions.RemoveEmptyEntries);

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
        var parametersConverted = ConvertParametersToCSharp(parameters);
        
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