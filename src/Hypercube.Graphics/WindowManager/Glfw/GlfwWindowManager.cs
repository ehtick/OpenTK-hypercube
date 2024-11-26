using System.Runtime.InteropServices;
using Hypercube.Graphics.Api.Glfw;
using Hypercube.Graphics.Texturing;
using Hypercube.Graphics.Window;
using Hypercube.Graphics.Windowing;
using Hypercube.Mathematics.Vectors;

namespace Hypercube.Graphics.WindowManager.Glfw;

public sealed unsafe class GlfwWindowManager : IWindowManager
{
    private Thread? _thread;

    private bool Initialized => _thread is not null;
    
    public bool Init()
    {
        if (Initialized)
            throw new Exception();
        
        if (GlfwNative.glfwInit() == GlfwNative.False)
            return false;

        _thread = Thread.CurrentThread;
        return true;
    }

    public void Terminate()
    {
        if (!Initialized)
            throw new Exception();
        
        GlfwNative.glfwTerminate();
        _thread = null;
    }

    public void PollEvents()
    {
        GlfwNative.glfwPollEvents();
    }

    public void EnterWindowLoop()
    {
        while (true)
        {
            GlfwNative.glfwPollEvents();
            // Implement custom logic for breaking this loop as needed
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