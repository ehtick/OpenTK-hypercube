namespace Hypercube.Core.Graphics.Windowing;

public sealed unsafe class WindowHandle
{
    public readonly nint* Handle;
    
    public WindowHandle(nint handle)
    {
        Handle = (nint*) handle;
    }
    
    public WindowHandle(nint* handle)
    {
        Handle = handle;
    }
    
    public static explicit operator nint(WindowHandle windowHandle)
    {
        return (nint) windowHandle.Handle;
    }

    public static explicit operator nint*(WindowHandle windowHandle)
    {
        return windowHandle.Handle;
    }
}