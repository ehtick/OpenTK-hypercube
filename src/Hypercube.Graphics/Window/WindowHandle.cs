namespace Hypercube.Graphics.Window;

public sealed class WindowHandle
{
    public readonly nint Handle;

    public WindowHandle(nint handle)
    {
        Handle = handle;
    }

    public static explicit operator nint(WindowHandle windowHandle)
    {
        return windowHandle.Handle;
    }
}