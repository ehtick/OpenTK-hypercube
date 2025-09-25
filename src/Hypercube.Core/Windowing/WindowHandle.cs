namespace Hypercube.Core.Windowing;

public readonly struct WindowHandle : IEquatable<WindowHandle>
{
    public static readonly WindowHandle Zero = new(nint.Zero);
    
    private readonly nint _value;

    public WindowHandle(nint value)
    {
        _value = value;
    }

    public bool Equals(WindowHandle other)
    {
        return _value == other._value;
    }

    public override bool Equals(object? obj)
    {
        return obj is WindowHandle other && Equals(other);
    }

    public override int GetHashCode()
    {
        return _value.GetHashCode();
    }
    
    public static bool operator ==(WindowHandle left, WindowHandle right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(WindowHandle left, WindowHandle right)
    {
        return !left.Equals(right);
    }

    public static implicit operator nint(WindowHandle handle)
    {
        return handle._value;
    }
}