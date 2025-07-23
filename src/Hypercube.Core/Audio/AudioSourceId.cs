namespace Hypercube.Core.Audio;

public readonly struct AudioSourceId : IEquatable<AudioSourceId>
{
    public static readonly AudioSourceId Zero = new(0);

    private readonly uint _value;

    public AudioSourceId(uint value)
    {
        _value = value;
    }

    public bool Equals(AudioSourceId other)
    {
        return _value == other._value;
    }

    public override bool Equals(object? obj)
    {
        return obj is AudioSourceId id && Equals(id);
    }

    public override string ToString()
    {
        return _value.ToString();
    }

    public override int GetHashCode()
    {
        return _value.GetHashCode();
    }

    public static bool operator ==(AudioSourceId a, AudioSourceId b)
    {
        return a.Equals(b);
    }

    public static bool operator !=(AudioSourceId a, AudioSourceId b)
    {
        return !a.Equals(b);
    }

    public static implicit operator uint(AudioSourceId id)
    {
        return id._value;
    }
}
