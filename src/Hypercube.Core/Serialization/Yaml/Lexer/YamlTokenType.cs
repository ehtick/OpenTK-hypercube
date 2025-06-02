namespace Hypercube.Core.Serialization.Yaml.Lexer;

public enum YamlTokenType
{
    Key,
    Value,
    SequenceEntry,
    Indent,
    Dedent,
    Scalar,
    Colon,
    Dash,
    Eof
}
