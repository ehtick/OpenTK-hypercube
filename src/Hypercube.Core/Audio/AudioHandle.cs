namespace Hypercube.Core.Audio;

public readonly struct AudioHandle : IEquatable<AudioHandle>
{
    public static readonly AudioHandle Zero = new(0);

    private readonly uint _value;

    public AudioHandle(uint value)
    {
        _value = value;
    }

    public bool Equals(AudioHandle other)
    {
        return _value == other._value;
    }

    public override bool Equals(object? obj)
    {
        return obj is AudioHandle id && Equals(id);
    }

    public override string ToString()
    {
        return _value.ToString();
    }

    public override int GetHashCode()
    {
        return _value.GetHashCode();
    }

    public static bool operator ==(AudioHandle a, AudioHandle b)
    {
        return a.Equals(b);
    }

    public static bool operator !=(AudioHandle a, AudioHandle b)
    {
        return !a.Equals(b);
    }

    public static implicit operator uint(AudioHandle id)
    {
        return id._value;
    }
}
