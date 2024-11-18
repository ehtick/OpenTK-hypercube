using System.Collections.Frozen;
using System.Text;
using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace Hypercube.Generators.Class;

[PublicAPI]
public abstract class HeaderGenerator : Generator
{
    protected virtual FrozenDictionary<string, string> KeywordMapping { get; set; } = new Dictionary<string, string>().ToFrozenDictionary();
    protected virtual FrozenDictionary<string, string> TypeMapping { get; set; } = new Dictionary<string, string>().ToFrozenDictionary();
    protected abstract string Dll { get; }

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