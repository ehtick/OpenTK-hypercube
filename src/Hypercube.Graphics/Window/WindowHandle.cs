namespace Hypercube.Graphics.Window;

public sealed class WindowHandle
{
    public readonly nint Handle;

    public unsafe nint* Pointer
    {
        get
        {
            fixed (nint* handle = &Handle)
            {
                return handle;
            }
        }
    }
    
    public WindowHandle(nint handle)
    {
        Handle = handle;
    }

    public static explicit operator nint(WindowHandle windowHandle)
    {
        return windowHandle.Handle;
    }
    
    public static unsafe explicit operator nint*(WindowHandle windowHandle)
    {
        return windowHandle.Pointer;
    }
}