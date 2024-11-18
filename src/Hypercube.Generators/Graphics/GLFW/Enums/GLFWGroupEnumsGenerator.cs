using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.RegularExpressions;
using Hypercube.Generators.Class;
using Microsoft.CodeAnalysis;

namespace Hypercube.Generators.Graphics.GLFW.Enums;

[Generator]
[SuppressMessage("ReSharper", "InconsistentNaming")]
public class GLFWGroupEnumsGenerator : Generator<GLFWGroupEnumGeneratorOptions>
{
    protected override GLFWGroupEnumGeneratorOptions[] Options =>
    [
        new GLFWGroupEnumGeneratorOptions
        {
            Name = "Key",
            FileName = "Key",
            Prefix = "GLFW_KEY_"
        },
        new GLFWGroupEnumGeneratorOptions
        {
            Name = "KeyModifier",
            FileName = "KeyMod",
            Prefix = "GLFW_MOD_"
        },
        new GLFWGroupEnumGeneratorOptions
        {
            Name = "MouseButton",
            FileName = "MouseButton",
            Prefix = "GLFW_MOUSE_BUTTON_",
            FallbackDigitPrefix = "Button"
        },
        new GLFWGroupEnumGeneratorOptions
        {
            Name = "Joystick",
            FileName = "Joystick",
            Prefix = "GLFW_JOYSTICK_",
            FallbackDigitPrefix = "Joystick"
        },
        new GLFWGroupEnumGeneratorOptions
        {
            Name = "JoystickHat",
            FileName = "JoystickHat",
            Prefix = "GLFW_JOYSTICK_",
            FallbackDigitPrefix = "Joystick"
        },
        new GLFWGroupEnumGeneratorOptions
        {
            Name = "GamepadButton",
            FileName = "GamepadButton",
            Prefix = "GLFW_HAT_",
            FallbackDigitPrefix = "Hat"
        },
        new GLFWGroupEnumGeneratorOptions
        {
            Name = "GamepadAxis",
            FileName = "GamepadAxis",
            Prefix = "GLFW_GAMEPAD_AXIS_",
            FallbackDigitPrefix = "Axis"
        },
    ];
    
    protected override void GenerateContent(GeneratorExecutionContext context, StringBuilder result, GLFWGroupEnumGeneratorOptions options, string fileContent)
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
            
            if (!name.StartsWith(options.Prefix))
                continue;
            
            var handledName = HandleName(options, name);
            
            renames.Add(name, handledName);
            
            if (renames.TryGetValue(value, out var newValue))
                value = newValue;
            
            result.AppendLine($"    {handledName} = {value},");
        }
    }

    private string HandleName(GLFWGroupEnumGeneratorOptions options, string name)
    {
        if (name.StartsWith(options.Prefix))
            name = name[options.Prefix.Length..];
        
        const string prefix = "GLFW_";
        if (name.StartsWith(prefix))
            name = name[prefix.Length..];

        if (Regex.IsMatch(name, @"^-?\d+(\.\d+)?$"))
            name = $"{options.FallbackDigitPrefix}{name}";

        return UpperSnakeCaseToPascalCase(name);
    }
}

[SuppressMessage("ReSharper", "InconsistentNaming")]
public sealed class GLFWGroupEnumGeneratorOptions : GeneratorOptions
{
    public override string[] Usings { get; init; } = [
        "System",
        "System.Runtime.InteropServices"
    ];
        
    public override string Namespace { get; init; } = "Hypercube.Graphics.API.GLFW.Enums";
    public override string Path { get; init; } = "";
    public override string File { get; init; } = "glfw3.h";
    public override string Modifiers { get; init; } = "public";
    public override string Type { get; init; } = "enum";

    public string Prefix { get; init; } = string.Empty;
    public string FallbackDigitPrefix { get; init; }= "Digit";
}