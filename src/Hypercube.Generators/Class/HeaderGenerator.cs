using System.Collections.Frozen;
using System.Text;
using System.Text.RegularExpressions;
using Hypercube.Generators.Class.Data;
using JetBrains.Annotations;
using Type = Hypercube.Generators.Class.Data.Type;

namespace Hypercube.Generators.Class;

[PublicAPI]
public abstract partial class HeaderGenerator : Generator
{
    protected virtual FrozenDictionary<string, string> KeywordMapping { get; set; } = new Dictionary<string, string>().ToFrozenDictionary();
    protected virtual FrozenDictionary<string, string> TypeMapping { get; set; } = new Dictionary<string, string>().ToFrozenDictionary();
    protected abstract string Dll { get; }

    protected Regex ArrayRegex = new(@"\[\d*\]");
    
    protected List<Variable> HandleArguments(string arguments)
    {
        if (string.IsNullOrWhiteSpace(arguments) || arguments == "void")
            return [];

        var @params = arguments.Split(',');
        var result = new List<Variable>();

        foreach (var param in @params)
        {
            var variable = new Variable();
            
            // Remove all const from types
            // Because const don't work same in C#
            var parts = param
                .Replace("const", "")
                .Trim()
                .Split(' ')
                .ToList();

            variable.Type.Name = parts[0];
            
            // Type like "unsigned int"
            if (parts.Count > 2)
            {
                variable.Type.Name += $" {parts[1]}";
                parts.RemoveAt(1);
            }
            
            // Handling param type
            variable.Name = parts.Count > 1 ? parts[1] : "param";
            
            if (ArrayRegex.IsMatch(variable.Name))
            {
                variable.Type.Array = true;
                variable.Name = ArrayRegex.Replace(variable.Name, "");
            }
            
            variable.Name = HandleReservedKeywords(variable.Name);
        
            // Handling pointer types
            variable.Type.PointerLevel = variable.Type.Name.Count(c => c == '*');
            
            if (variable.Type.PointerLevel > 0)
                variable.Type.Name = variable.Type.Name.Replace("*", "");
        
            variable.Type.Name = HandleTypes(variable.Type.Name);
            result.Add(variable);
        }

        return result;
    }
    
    protected virtual Type HandleType(string source)
    {
        var type = new Type();
        
        type.Name = source;
        type.PointerLevel = source.Count(c => c == '*');
        
        if (type.PointerLevel > 0)
            type.Name = type.Name.Replace("*", "");

        type.Array = type.Name.EndsWith("[]");
        if (type.Array)
            type.Name = type.Name[..^2];
        
        type.Name = HandleTypes(type.Name);
        
        return type;
    }

    
    protected string HandleParameters(string parameters)
    {
        if (string.IsNullOrWhiteSpace(parameters) || parameters.Trim() == "void")
            return string.Empty;

        var @params = parameters.Split(',');
        var result = new StringBuilder();

        foreach (var param in @params)
        {
            var parts = param
                .Replace("const", "")
                .Trim()
                .Split(' ').ToList();
            
            var type = parts[0];

            // type like "unsigned int codepoint"
            if (parts.Count > 2)
            {
                type += $" {parts[1]}";
                parts.RemoveAt(1);
            }
            
            var name = parts.Count > 1 ? parts[1] : "param";

            if (Regex.IsMatch(name, @"\[\d*\]"))
            {
                type += "[]";
                name = Regex.Replace(name, @"\[\d*\]", "");
            }
            
            var handledName = HandleReservedKeywords(name);
            var handledType = HandlePointerTypes(type);
                
            result.Append($"{handledType} {handledName}, ");
        }

        return result.ToString().TrimEnd(',', ' ');
    }

    protected virtual string HandleTypes(string type)
    {
        type = type.Replace("const", "").Trim();
        return TypeMapping.GetValueOrDefault(type, "nint");
    }
    
    protected virtual string HandlePointerTypes(string type)
    {
        var pointerLevel = type.Count(c => c == '*');
        if (pointerLevel > 0)
            type = type.Replace("*", "");

        var isArray = type.EndsWith("[]");
        if (isArray)
            type = type[..^2];
        
        var handledType = HandleTypes(type);

        if (pointerLevel != 0)
            handledType += string.Concat(Enumerable.Repeat("*", pointerLevel));

        if (isArray)
            handledType += "[]";
        
        return handledType;
    }
    
    protected virtual string HandleReservedKeywords(string name)
    {
        return KeywordMapping.GetValueOrDefault(name, name);
    }
}