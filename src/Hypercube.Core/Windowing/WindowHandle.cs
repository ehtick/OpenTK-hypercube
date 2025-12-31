namespace Hypercube.Core.Windowing;

[IdStruct(typeof(nint))]
public readonly partial struct WindowHandle
{
    public static readonly WindowHandle Zero = new(nint.Zero);
}