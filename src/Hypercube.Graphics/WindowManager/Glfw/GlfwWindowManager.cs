using Hypercube.Graphics.Api.Glfw;
using Hypercube.Graphics.Window;

namespace Hypercube.Graphics.WindowManager.Glfw;

public sealed class GlfwWindowManager : IWindowManager
{
    public event Action? OnWindowLoopUpdate;
    
    private Thread? _thread;

    private bool Initialized => _thread is not null;
    
    public bool Init()
    {
        if (Initialized)
            throw new Exception();
        
        if (Api.Glfw.Glfw.Init() == GlfwNative.False)
            return false;

        _thread = Thread.CurrentThread;
        return true;
    }

    public void Terminate()
    {
        if (!Initialized)
            throw new Exception();
        
        Api.Glfw.Glfw.Terminate();
        _thread = null;
    }

    public void PollEvents()
    {
        Api.Glfw.Glfw.PollEvents();
    }

    public void EnterWindowLoop()
    {
        while (true)
        {
            GlfwNative.glfwPollEvents();
            OnWindowLoopUpdate?.Invoke();
        }
    }

    public bool WindowCreate(WindowCreateSettings settings, IWindow? window)
    {
        return false;
        /*
        unsafe
        {
            window = null;

            var contextShare = settings.ContextShare?.Handle ?? nint.Zero;
            var monitorShare = settings.MonitorShare?.Handle ?? nint.Zero;

            var titleBytes = Marshal.StringToHGlobalAnsi(settings.Title);
            try
            {
                var windowPointer = GlfwNative.glfwCreateWindow(settings.Size.X, settings.Size.Y, (byte*) titleBytes, &monitorShare, &contextShare);
                var handle = new WindowHandle((nint) windowPointer);
                
                window = new Window()
            }
            finally
            {
                Marshal.FreeHGlobal(titleBytes);
            }
        }
        */
    }

    public void MakeContextCurrent(WindowHandle? window)
    {
        //GlfwNative.glfwMakeContextCurrent(window?.Handle);
    }

    public nint GetProcAddress(string procName)
    {
        /*
        var nameBytes = Marshal.StringToHGlobalAnsi(procName);
        try
        {
            return GlfwNative.glfwGetProcAddress((byte*)nameBytes);
        }
        finally
        {
            Marshal.FreeHGlobal(nameBytes);
        }
        */

        return nint.Zero;
    }

    public void Dispose()
    {
        Terminate();
    }
}