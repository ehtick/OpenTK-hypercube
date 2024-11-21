using System.Runtime.InteropServices;
using Hypercube.Graphics.Api.Glfw;
using Hypercube.Graphics.Api.Glfw.Enums;

namespace Hypercube.Graphics.Windowing;

public unsafe class GlfwWindowing : IWindowing
{
    public Thread? CurrentThread { get; private set; }
    
    public bool Init()
    {
        if (GlfwNative.glfwInit() == GlfwNative.False)
            return false;

        CurrentThread = Thread.CurrentThread;
        return true;
    }

    public void Shutdown()
    {
        if (CurrentThread is null)
            return;

        CurrentThread = null;
        GlfwNative.glfwTerminate();
    }

    public bool TryWindowCreate(WindowSettings settings)
    {
        
        GlfwNative.glfwWindowHint((int) WindowHintClientApi.ClientApi, (int) ClientApi.NoApi);
        
        GlfwNative.glfwWindowHint((int) WindowHintInt.RedBits, 8);
        GlfwNative.glfwWindowHint((int) WindowHintInt.GreenBits, 8);
        GlfwNative.glfwWindowHint((int) WindowHintInt.BlueBits, 8);
        GlfwNative.glfwWindowHint((int) WindowHintInt.RefreshRate, -1);

        var title = (byte*) Marshal.StringToCoTaskMemUTF8(settings.Title);
        var monitor = nint.Zero;
        var share = nint.Zero;
        
        var window = GlfwNative.glfwCreateWindow(
            settings.Size.X, 
            settings.Size.Y,
            title,
            &monitor,
            &share);

        return true;
    }

    public void WindowDestroy()
    {
        throw new NotImplementedException();
    }

    public void WindowSetTitle()
    {
        throw new NotImplementedException();
    }

    public void WindowSetMonitor()
    {
        throw new NotImplementedException();
    }

    public void WindowSetOpacity()
    {
        throw new NotImplementedException();
    }

    public void WindowRequestAttention()
    {
        throw new NotImplementedException();
    }
}