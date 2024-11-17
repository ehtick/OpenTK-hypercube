using System.Collections.Frozen;
using System.Text;
using JetBrains.Annotations;

namespace Hypercube.Generators.Class;

[PublicAPI]
public abstract class HeaderGenerator : Generator
{
    protected virtual FrozenDictionary<string, string> KeywordMapping { get; set; } = new Dictionary<string, string>().ToFrozenDictionary();
    protected virtual FrozenDictionary<string, string> TypeMapping { get; set; } = new Dictionary<string, string>().ToFrozenDictionary();
    protected abstract string Dll { get; }

    protected string ConvertParametersToCSharp(string parameters)
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
                .Split(' ');
            
            var type = parts[0];
            var name = parts.Length > 1 ? parts[1] : "param";

            if (name.Contains('*'))
            {
                name = name.Replace("*", "");
                type += "*";
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
        var baseType = HandleTypes(type.Replace("*", "").Trim());

        if (pointerLevel != 0)
            baseType += string.Concat(Enumerable.Repeat("*", pointerLevel));

        return baseType;
    }
    
    protected virtual string HandleReservedKeywords(string name)
    {
        return KeywordMapping.GetValueOrDefault(name, name);
    }
}