using System.Collections.Frozen;
using System.Diagnostics.CodeAnalysis;

namespace Hypercube.Generators.Graphics.GLFW;

[SuppressMessage("ReSharper", "StringLiteralTypo")]
public class GlfwTypeMapping
{
    public static readonly FrozenDictionary<string, string> NameMapping = new Dictionary<string, string>
    {
        // Callbacks
        { "Glproc", "GLProcess" },
        { "Vkproc", "VKProcess" },
        { "Windowpos", "WindowPosition" },
        { "Windowsize", "WindowSize" },
        { "Windowclose", "WindowClose" },
        { "Windowrefresh", "WindowRefresh" },
        { "Windowfocus", "WindowFocus" },
        { "Windowiconify", "WindowIconify" },
        { "Windowmaximize", "WindowMaximize" },
        { "Framebuffersize", "FrameBufferSize" },
        { "Windowcontentscale", "WindowContentScale" },
        { "Mousebutton", "MouseButton" },
        { "Cursorpos", "CursorPosition" },
        { "Cursorenter", "CursorEnter" },
        { "Charmods", "CharModification" },
    }.ToFrozenDictionary();
    
    public static readonly FrozenDictionary<string, string> TypeMapping = new Dictionary<string, string>
    {
        { "void", "void"},
        { "bool", "bool" },
        { "byte", "byte" },
        { "short", "short" },
        { "unsigned short", "ushort" },
        { "int", "int" },
        { "unsigned int", "uint" },
        { "long", "long" },
        { "unsigned long", "long" },
        // TODO: long long 
        { "float", "float" },
        { "double", "double" },
        { "long double", "decimal" },
        // We don't use char,
        // because C# allocates 2 bytes for its storage instead of 1 as in C++,
        // which will break us the reference transmission
        { "char", "byte" }, // { "char", "char" },
        // TODO: wchar_t, std::string, std::wstring
        { "size_t", "nuint" },
        // Structs
        { "GLFWwindow", "nint" },
        { "GLFWmonitor", "nint" },
        { "GLFWvidmode", "nint" },
        { "VkResult", "int" },
        // Callbacks
        { "GLFWglproc", "GLFWCallbacks.GLProcess" },
        { "GLFWvkproc", "GLFWCallbacks.VKProcess" },
        { "GLFWallocatefun", "GLFWCallbacks.Allocate" },
        { "GLFWreallocatefun", "GLFWCallbacks.Reallocate" },
        { "GLFWdeallocatefun", "GLFWCallbacks.Deallocate" },
        { "GLFWerrorfun", "GLFWCallbacks.Error" },
        { "GLFWwindowposfun", "GLFWCallbacks.WindowPosition" },
        { "GLFWwindowsizefun", "GLFWCallbacks.WindowSize" },
        { "GLFWwindowclosefun", "GLFWCallbacks.WindowClose" },
        { "GLFWwindowrefreshfun", "GLFWCallbacks.WindowRefresh" },
        { "GLFWwindowfocusfun", "GLFWCallbacks.WindowFocus" },
        { "GLFWwindowiconifyfun", "GLFWCallbacks.WindowIconify" },
        { "GLFWwindowmaximizefun", "GLFWCallbacks.WindowMaximize" },
        { "GLFWframebuffersizefun", "GLFWCallbacks.FrameBufferSize" },
        { "GLFWwindowcontentscalefun", "GLFWCallbacks.WindowContentScale" },
        { "GLFWmousebuttonfun", "GLFWCallbacks.MouseButton" },
        { "GLFWcursorposfun", "GLFWCallbacks.CursorPosition" },
        { "GLFWcursorenterfun", "GLFWCallbacks.CursorEnter" },
        { "GLFWscrollfun", "GLFWCallbacks.Scroll" },
        { "GLFWkeyfun", "GLFWCallbacks.Key" },
        { "GLFWcharfun", "GLFWCallbacks.Char" },
        { "GLFWcharmodsfun", "GLFWCallbacks.CharModification" },
        { "GLFWdropfun", "GLFWCallbacks.Drop" },
        { "GLFWmonitorfun", "GLFWCallbacks.Monitor" },
        { "GLFWjoystickfun", "GLFWCallbacks.Joystick" }
    }.ToFrozenDictionary();
    
    public static readonly FrozenDictionary<string, string> KeywordMapping = new Dictionary<string, string>
    {
        { "params", "@params" },
        { "string", "@string" },
        { "object", "@object" },
        { "event", "@event" },
        { "ref", "@ref" }
    }.ToFrozenDictionary();
}