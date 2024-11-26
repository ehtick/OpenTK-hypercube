using System.Text;
using System.Text.RegularExpressions;
using Hypercube.Generators.Class;
using Microsoft.CodeAnalysis;

namespace Hypercube.Generators.Graphics.GLFW.Enums;

[Generator]
public class GlfwEnumsGenerator : Generator<GlfwEnumGeneratorOptions>
{
    protected override GlfwEnumGeneratorOptions[] Options =>
    [
        new GlfwEnumGeneratorOptions
        {
            Name = "ErrorCode",
            Names =
            {
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
            }
        },
        new GlfwEnumGeneratorOptions
        {
            Name = "WindowHintInt",
            Names =
            {
                "GLFW_POSITION_X",
                "GLFW_POSITION_Y",
                "GLFW_RED_BITS",
                "GLFW_GREEN_BITS",
                "GLFW_BLUE_BITS",
                "GLFW_ALPHA_BITS",
                "GLFW_DEPTH_BITS",
                "GLFW_STENCIL_BITS",
                "GLFW_ACCUM_RED_BITS",
                "GLFW_ACCUM_GREEN_BITS",
                "GLFW_ACCUM_BLUE_BITS",
                "GLFW_ACCUM_ALPHA_BITS",
                "GLFW_AUX_BUFFERS",
                "GLFW_STEREO",
                "GLFW_SAMPLES",
                "GLFW_SRGB_CAPABLE",
                "GLFW_REFRESH_RATE"
            }
        },
        new GlfwEnumGeneratorOptions
        {
            Name = "WindowHintString",
            Names =
            {
                "GLFW_COCOA_FRAME_NAME",   
                "GLFW_X11_CLASS_NAME",   
                "GLFW_X11_INSTANCE_NAME",
                "GLFW_WAYLAND_APP_ID"
            }
        },
        new GlfwEnumGeneratorOptions
        {
            Name = "WindowHintClientApi",
            Names =
            {
                "GLFW_CLIENT_API"
            }
        },
        new GlfwEnumGeneratorOptions
        {
            Name = "ClientApi",
            Names =
            {
                "GLFW_NO_API",
                "GLFW_OPENGL_API",
                "GLFW_OPENGL_ES_API"
            }
        }
    ];
    
    protected override void GenerateContent(GeneratorExecutionContext context, StringBuilder result, GlfwEnumGeneratorOptions options, string fileContent)
    {
        var lines = fileContent.Split(NewLineSeparators, StringSplitOptions.RemoveEmptyEntries);
        var renames = new Dictionary<string, string>();
        
        foreach (var line in lines)
        {
            var match = Regex.Match(line, @"^#define\s+(GLFW_\w+)\s+(.+)");
            if (!match.Success)
                continue;
            
            var name = match.Groups[1].Value;
            var value = match.Groups[2].Value;
            
            if (!options.Names.Contains(name))
                continue;
            
            var handledName = HandleName(options, name);
            
            renames.Add(name, handledName);
            
            if (renames.TryGetValue(value, out var newValue))
                value = newValue;
            
            result.AppendLine($"    {handledName} = {value},");
        }
    }

    private string HandleName(GlfwEnumGeneratorOptions options, string name)
    {
        const string prefix = "GLFW_";
        if (name.StartsWith(prefix))
            name = name[prefix.Length..];
        
        return UpperSnakeCaseToPascalCase(name);
    }
}

public sealed class GlfwEnumGeneratorOptions : GeneratorOptions
{
    public override string[] Usings { get; init; } = [
        "System",
        "System.Runtime.InteropServices"
    ];
        
    public override string Namespace { get; init; } = "Hypercube.Graphics.Api.Glfw.Enums";
    public override string Path { get; init; } = "";
    public override string File { get; init; } = "glfw3.h";
    public override string Modifiers { get; init; } = "public";
    public override string Type { get; init; } = "enum";
    public List<string> Names { get; init; } = [];
}