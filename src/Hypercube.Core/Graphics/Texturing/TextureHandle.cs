namespace Hypercube.Core.Graphics.Texturing;

public readonly struct TextureHandle : IEquatable<TextureHandle>
{
    public static readonly TextureHandle Zero = default;
    
    private readonly uint? _value = null;

    public bool HasValue => _value.HasValue;
    
    public TextureHandle(uint? value)
    {
        _value = value;
    }

    public bool Equals(TextureHandle other)
    {
        return _value == other._value;
    }

    public override bool Equals(object? obj)
    {
        return obj is TextureHandle other && Equals(other);
    }

    public override int GetHashCode()
    {
        return _value.GetHashCode();
    }
    
    public static bool operator ==(TextureHandle a, TextureHandle b)
    {
        return a.Equals(b);
    }

    public static bool operator !=(TextureHandle a, TextureHandle b)
    {
        return !a.Equals(b);
    }

    public static implicit operator uint(TextureHandle handle)
    {
        return handle._value ?? 0;
    }
}