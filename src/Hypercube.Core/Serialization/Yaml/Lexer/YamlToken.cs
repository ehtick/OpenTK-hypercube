namespace Hypercube.Core.Serialization.Yaml.Lexer;

public ref struct YamlToken
{
    public YamlTokenType Type;
    public ReadOnlySpan<char> Value;
}
