namespace Hypercube.Core.Serialization.Yaml.Lexer;

public ref struct YamlLexer
{
    private readonly ReadOnlySpan<char> _source;
    private int _position;

    private char Current => _source[_position];
    
    public YamlLexer(ReadOnlySpan<char> yaml)
    {
        _source = yaml;
    }

    public bool TryReadNext(out YamlToken token)
    {
        SkipWhitespace();

        if (_position >= _source.Length)
        {
            token = new YamlToken { Type = YamlTokenType.Eof };
            return false;
        }
        
        switch (Current)
        {
            case ':':
                _position++;
                token = new YamlToken { Type = YamlTokenType.Colon, Value = ":" };
                return true;
            case '-':
                _position++;
                token = new YamlToken { Type = YamlTokenType.Dash, Value = "-" };
                return true;
        }

        // Simple scalar lexing (no quoting for now)
        var start = _position;
        while (_position < _source.Length && _source[_position] != '\n' && _source[_position] != ':' && _source[_position] != '-')
            _position++;

        var value = _source.Slice(start, _position - start).Trim();
        token = new YamlToken { Type = YamlTokenType.Scalar, Value = value };
        return true;
    }

    private void SkipWhitespace()
    {
        while (_position < _source.Length && char.IsWhiteSpace(_source[_position]) && _source[_position] != '\n')
            _position++;
    }
}
