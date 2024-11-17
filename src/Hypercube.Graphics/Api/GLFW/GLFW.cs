using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Hypercube.Graphics.API;

namespace Hypercube.Graphics.Api.GLFW;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public static unsafe class GLFW
{
    public static bool Init()
    {
        return GLFWNative.glfwInit() == GLFWNative.True;
    }
    
    public static void Terminate()
    {
        GLFWNative.glfwTerminate();
    }

    public static void InitHint(int hint, int value)
    {
        GLFWNative.glfwInitHint(hint, value);
    }

    public static void InitAllocator(nint* allocator)
    {
        GLFWNative.glfwInitAllocator(allocator);
    }
    
    public static void InitVulkanLoader(nint loader)
    {
        GLFWNative.glfwInitVulkanLoader(loader);
    }

    public static Version GetVersion()
    {
        var major = 0;
        var minor = 0;
        var revision = 0;
        
        GLFWNative.glfwGetVersion(&major, &minor, &revision);

        return new Version(major, minor, revision);
    }

    /*
    public static string GetVersionString()
    {
        return Marshal.PtrToStringUTF8((nint) GLFWNative.glfwGetVersionString()) ?? string.Empty;
    }

    /// <remarks>
    /// <c>
    /// GLFWAPI int glfwGetError(const char** description);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern int GetError(byte** description);

    /// <remarks>
    /// <c>
    /// GLFWAPI GLFWerrorfun glfwSetErrorCallback(GLFWerrorfun callback);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern nint glfwSetErrorCallback(nint callback);

    /// <remarks>
    /// <c>
    /// GLFWAPI int glfwGetPlatform(void);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern int glfwGetPlatform();

    /// <remarks>
    /// <c>
    /// GLFWAPI int glfwPlatformSupported(int platform);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern int glfwPlatformSupported(int platform);

    /// <remarks>
    /// <c>
    /// GLFWAPI GLFWmonitor** glfwGetMonitors(int* count);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern nint glfwGetMonitors(int* count);

    /// <remarks>
    /// <c>
    /// GLFWAPI GLFWmonitor* glfwGetPrimaryMonitor(void);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern nint glfwGetPrimaryMonitor();

    /// <remarks>
    /// <c>
    /// GLFWAPI void glfwGetMonitorPos(GLFWmonitor* monitor, int* xpos, int* ypos);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern void glfwGetMonitorPos(nint* monitor, int* xpos, int* ypos);

    /// <remarks>
    /// <c>
    /// GLFWAPI void glfwGetMonitorWorkarea(GLFWmonitor* monitor, int* xpos, int* ypos, int* width, int* height);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern void glfwGetMonitorWorkarea(nint* monitor, int* xpos, int* ypos, int* width, int* height);

    /// <remarks>
    /// <c>
    /// GLFWAPI void glfwGetMonitorPhysicalSize(GLFWmonitor* monitor, int* widthMM, int* heightMM);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern void glfwGetMonitorPhysicalSize(nint* monitor, int* widthMM, int* heightMM);

    /// <remarks>
    /// <c>
    /// GLFWAPI void glfwGetMonitorContentScale(GLFWmonitor* monitor, float* xscale, float* yscale);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern void glfwGetMonitorContentScale(nint* monitor, nint* xscale, nint* yscale);

    /// <remarks>
    /// <c>
    /// GLFWAPI const char* glfwGetMonitorName(GLFWmonitor* monitor);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern nint glfwGetMonitorName(nint* monitor);

    /// <remarks>
    /// <c>
    /// GLFWAPI void glfwSetMonitorUserPointer(GLFWmonitor* monitor, void* pointer);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern void glfwSetMonitorUserPointer(nint* monitor, void* pointer);

    /// <remarks>
    /// <c>
    /// GLFWAPI void* glfwGetMonitorUserPointer(GLFWmonitor* monitor);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern nint glfwGetMonitorUserPointer(nint* monitor);

    /// <remarks>
    /// <c>
    /// GLFWAPI GLFWmonitorfun glfwSetMonitorCallback(GLFWmonitorfun callback);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern nint glfwSetMonitorCallback(nint callback);

    /// <remarks>
    /// <c>
    /// GLFWAPI const GLFWvidmode* glfwGetVideoModes(GLFWmonitor* monitor, int* count);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern nint glfwGetVideoModes(nint* monitor, int* count);

    /// <remarks>
    /// <c>
    /// GLFWAPI const GLFWvidmode* glfwGetVideoMode(GLFWmonitor* monitor);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern nint glfwGetVideoMode(nint* monitor);

    /// <remarks>
    /// <c>
    /// GLFWAPI void glfwSetGamma(GLFWmonitor* monitor, float gamma);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern void glfwSetGamma(nint* monitor, nint gamma);

    /// <remarks>
    /// <c>
    /// GLFWAPI const GLFWgammaramp* glfwGetGammaRamp(GLFWmonitor* monitor);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern nint glfwGetGammaRamp(nint* monitor);

    /// <remarks>
    /// <c>
    /// GLFWAPI void glfwSetGammaRamp(GLFWmonitor* monitor, const GLFWgammaramp* ramp);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern void glfwSetGammaRamp(nint* monitor, nint* ramp);

    /// <remarks>
    /// <c>
    /// GLFWAPI void glfwDefaultWindowHints(void);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern void glfwDefaultWindowHints();

    /// <remarks>
    /// <c>
    /// GLFWAPI void glfwWindowHint(int hint, int value);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern void glfwWindowHint(int hint, int value);

    /// <remarks>
    /// <c>
    /// GLFWAPI void glfwWindowHintString(int hint, const char* value);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern void glfwWindowHintString(int hint, byte* value);

    /// <remarks>
    /// <c>
    /// GLFWAPI GLFWwindow* glfwCreateWindow(int width, int height, const char* title, GLFWmonitor* monitor, GLFWwindow* share);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern nint glfwCreateWindow(int width, int height, byte* title, nint* monitor, nint* share);

    /// <remarks>
    /// <c>
    /// GLFWAPI void glfwDestroyWindow(GLFWwindow* window);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern void glfwDestroyWindow(nint* window);

    /// <remarks>
    /// <c>
    /// GLFWAPI int glfwWindowShouldClose(GLFWwindow* window);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern int glfwWindowShouldClose(nint* window);

    /// <remarks>
    /// <c>
    /// GLFWAPI void glfwSetWindowShouldClose(GLFWwindow* window, int value);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern void glfwSetWindowShouldClose(nint* window, int value);

    /// <remarks>
    /// <c>
    /// GLFWAPI const char* glfwGetWindowTitle(GLFWwindow* window);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern nint glfwGetWindowTitle(nint* window);

    /// <remarks>
    /// <c>
    /// GLFWAPI void glfwSetWindowTitle(GLFWwindow* window, const char* title);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern void glfwSetWindowTitle(nint* window, byte* title);

    /// <remarks>
    /// <c>
    /// GLFWAPI void glfwSetWindowIcon(GLFWwindow* window, int count, const GLFWimage* images);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern void glfwSetWindowIcon(nint* window, int count, nint* images);

    /// <remarks>
    /// <c>
    /// GLFWAPI void glfwGetWindowPos(GLFWwindow* window, int* xpos, int* ypos);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern void glfwGetWindowPos(nint* window, int* xpos, int* ypos);

    /// <remarks>
    /// <c>
    /// GLFWAPI void glfwSetWindowPos(GLFWwindow* window, int xpos, int ypos);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern void glfwSetWindowPos(nint* window, int xpos, int ypos);

    /// <remarks>
    /// <c>
    /// GLFWAPI void glfwGetWindowSize(GLFWwindow* window, int* width, int* height);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern void glfwGetWindowSize(nint* window, int* width, int* height);

    /// <remarks>
    /// <c>
    /// GLFWAPI void glfwSetWindowSizeLimits(GLFWwindow* window, int minwidth, int minheight, int maxwidth, int maxheight);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern void glfwSetWindowSizeLimits(nint* window, int minwidth, int minheight, int maxwidth, int maxheight);

    /// <remarks>
    /// <c>
    /// GLFWAPI void glfwSetWindowAspectRatio(GLFWwindow* window, int numer, int denom);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern void glfwSetWindowAspectRatio(nint* window, int numer, int denom);

    /// <remarks>
    /// <c>
    /// GLFWAPI void glfwSetWindowSize(GLFWwindow* window, int width, int height);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern void glfwSetWindowSize(nint* window, int width, int height);

    /// <remarks>
    /// <c>
    /// GLFWAPI void glfwGetFramebufferSize(GLFWwindow* window, int* width, int* height);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern void glfwGetFramebufferSize(nint* window, int* width, int* height);

    /// <remarks>
    /// <c>
    /// GLFWAPI void glfwGetWindowFrameSize(GLFWwindow* window, int* left, int* top, int* right, int* bottom);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern void glfwGetWindowFrameSize(nint* window, int* left, int* top, int* right, int* bottom);

    /// <remarks>
    /// <c>
    /// GLFWAPI void glfwGetWindowContentScale(GLFWwindow* window, float* xscale, float* yscale);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern void glfwGetWindowContentScale(nint* window, nint* xscale, nint* yscale);

    /// <remarks>
    /// <c>
    /// GLFWAPI float glfwGetWindowOpacity(GLFWwindow* window);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern nint glfwGetWindowOpacity(nint* window);

    /// <remarks>
    /// <c>
    /// GLFWAPI void glfwSetWindowOpacity(GLFWwindow* window, float opacity);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern void glfwSetWindowOpacity(nint* window, nint opacity);

    /// <remarks>
    /// <c>
    /// GLFWAPI void glfwIconifyWindow(GLFWwindow* window);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern void glfwIconifyWindow(nint* window);

    /// <remarks>
    /// <c>
    /// GLFWAPI void glfwRestoreWindow(GLFWwindow* window);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern void glfwRestoreWindow(nint* window);

    /// <remarks>
    /// <c>
    /// GLFWAPI void glfwMaximizeWindow(GLFWwindow* window);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern void glfwMaximizeWindow(nint* window);

    /// <remarks>
    /// <c>
    /// GLFWAPI void glfwShowWindow(GLFWwindow* window);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern void glfwShowWindow(nint* window);

    /// <remarks>
    /// <c>
    /// GLFWAPI void glfwHideWindow(GLFWwindow* window);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern void glfwHideWindow(nint* window);

    /// <remarks>
    /// <c>
    /// GLFWAPI void glfwFocusWindow(GLFWwindow* window);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern void glfwFocusWindow(nint* window);

    /// <remarks>
    /// <c>
    /// GLFWAPI void glfwRequestWindowAttention(GLFWwindow* window);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern void glfwRequestWindowAttention(nint* window);

    /// <remarks>
    /// <c>
    /// GLFWAPI GLFWmonitor* glfwGetWindowMonitor(GLFWwindow* window);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern nint glfwGetWindowMonitor(nint* window);

    /// <remarks>
    /// <c>
    /// GLFWAPI void glfwSetWindowMonitor(GLFWwindow* window, GLFWmonitor* monitor, int xpos, int ypos, int width, int height, int refreshRate);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern void glfwSetWindowMonitor(nint* window, nint* monitor, int xpos, int ypos, int width, int height, int refreshRate);

    /// <remarks>
    /// <c>
    /// GLFWAPI int glfwGetWindowAttrib(GLFWwindow* window, int attrib);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern int glfwGetWindowAttrib(nint* window, int attrib);

    /// <remarks>
    /// <c>
    /// GLFWAPI void glfwSetWindowAttrib(GLFWwindow* window, int attrib, int value);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern void glfwSetWindowAttrib(nint* window, int attrib, int value);

    /// <remarks>
    /// <c>
    /// GLFWAPI void glfwSetWindowUserPointer(GLFWwindow* window, void* pointer);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern void glfwSetWindowUserPointer(nint* window, void* pointer);

    /// <remarks>
    /// <c>
    /// GLFWAPI void* glfwGetWindowUserPointer(GLFWwindow* window);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern nint glfwGetWindowUserPointer(nint* window);

    /// <remarks>
    /// <c>
    /// GLFWAPI GLFWwindowposfun glfwSetWindowPosCallback(GLFWwindow* window, GLFWwindowposfun callback);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern nint glfwSetWindowPosCallback(nint* window, nint callback);

    /// <remarks>
    /// <c>
    /// GLFWAPI GLFWwindowsizefun glfwSetWindowSizeCallback(GLFWwindow* window, GLFWwindowsizefun callback);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern nint glfwSetWindowSizeCallback(nint* window, nint callback);

    /// <remarks>
    /// <c>
    /// GLFWAPI GLFWwindowclosefun glfwSetWindowCloseCallback(GLFWwindow* window, GLFWwindowclosefun callback);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern nint glfwSetWindowCloseCallback(nint* window, nint callback);

    /// <remarks>
    /// <c>
    /// GLFWAPI GLFWwindowrefreshfun glfwSetWindowRefreshCallback(GLFWwindow* window, GLFWwindowrefreshfun callback);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern nint glfwSetWindowRefreshCallback(nint* window, nint callback);

    /// <remarks>
    /// <c>
    /// GLFWAPI GLFWwindowfocusfun glfwSetWindowFocusCallback(GLFWwindow* window, GLFWwindowfocusfun callback);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern nint glfwSetWindowFocusCallback(nint* window, nint callback);

    /// <remarks>
    /// <c>
    /// GLFWAPI GLFWwindowiconifyfun glfwSetWindowIconifyCallback(GLFWwindow* window, GLFWwindowiconifyfun callback);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern nint glfwSetWindowIconifyCallback(nint* window, nint callback);

    /// <remarks>
    /// <c>
    /// GLFWAPI GLFWwindowmaximizefun glfwSetWindowMaximizeCallback(GLFWwindow* window, GLFWwindowmaximizefun callback);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern nint glfwSetWindowMaximizeCallback(nint* window, nint callback);

    /// <remarks>
    /// <c>
    /// GLFWAPI GLFWframebuffersizefun glfwSetFramebufferSizeCallback(GLFWwindow* window, GLFWframebuffersizefun callback);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern nint glfwSetFramebufferSizeCallback(nint* window, nint callback);

    /// <remarks>
    /// <c>
    /// GLFWAPI GLFWwindowcontentscalefun glfwSetWindowContentScaleCallback(GLFWwindow* window, GLFWwindowcontentscalefun callback);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern nint glfwSetWindowContentScaleCallback(nint* window, nint callback);

    /// <remarks>
    /// <c>
    /// GLFWAPI void glfwPollEvents(void);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern void glfwPollEvents();

    /// <remarks>
    /// <c>
    /// GLFWAPI void glfwWaitEvents(void);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern void glfwWaitEvents();

    /// <remarks>
    /// <c>
    /// GLFWAPI void glfwWaitEventsTimeout(double timeout);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern void glfwWaitEventsTimeout(nint timeout);

    /// <remarks>
    /// <c>
    /// GLFWAPI void glfwPostEmptyEvent(void);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern void glfwPostEmptyEvent();

    /// <remarks>
    /// <c>
    /// GLFWAPI int glfwGetInputMode(GLFWwindow* window, int mode);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern int glfwGetInputMode(nint* window, int mode);

    /// <remarks>
    /// <c>
    /// GLFWAPI void glfwSetInputMode(GLFWwindow* window, int mode, int value);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern void glfwSetInputMode(nint* window, int mode, int value);

    /// <remarks>
    /// <c>
    /// GLFWAPI int glfwRawMouseMotionSupported(void);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern int glfwRawMouseMotionSupported();

    /// <remarks>
    /// <c>
    /// GLFWAPI const char* glfwGetKeyName(int key, int scancode);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern nint glfwGetKeyName(int key, int scancode);

    /// <remarks>
    /// <c>
    /// GLFWAPI int glfwGetKeyScancode(int key);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern int glfwGetKeyScancode(int key);

    /// <remarks>
    /// <c>
    /// GLFWAPI int glfwGetKey(GLFWwindow* window, int key);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern int glfwGetKey(nint* window, int key);

    /// <remarks>
    /// <c>
    /// GLFWAPI int glfwGetMouseButton(GLFWwindow* window, int button);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern int glfwGetMouseButton(nint* window, int button);

    /// <remarks>
    /// <c>
    /// GLFWAPI void glfwGetCursorPos(GLFWwindow* window, double* xpos, double* ypos);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern void glfwGetCursorPos(nint* window, nint* xpos, nint* ypos);

    /// <remarks>
    /// <c>
    /// GLFWAPI void glfwSetCursorPos(GLFWwindow* window, double xpos, double ypos);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern void glfwSetCursorPos(nint* window, nint xpos, nint ypos);

    /// <remarks>
    /// <c>
    /// GLFWAPI GLFWcursor* glfwCreateCursor(const GLFWimage* image, int xhot, int yhot);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern nint glfwCreateCursor(nint* image, int xhot, int yhot);

    /// <remarks>
    /// <c>
    /// GLFWAPI GLFWcursor* glfwCreateStandardCursor(int shape);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern nint glfwCreateStandardCursor(int shape);

    /// <remarks>
    /// <c>
    /// GLFWAPI void glfwDestroyCursor(GLFWcursor* cursor);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern void glfwDestroyCursor(nint* cursor);

    /// <remarks>
    /// <c>
    /// GLFWAPI void glfwSetCursor(GLFWwindow* window, GLFWcursor* cursor);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern void glfwSetCursor(nint* window, nint* cursor);

    /// <remarks>
    /// <c>
    /// GLFWAPI GLFWkeyfun glfwSetKeyCallback(GLFWwindow* window, GLFWkeyfun callback);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern nint glfwSetKeyCallback(nint* window, nint callback);

    /// <remarks>
    /// <c>
    /// GLFWAPI GLFWcharfun glfwSetCharCallback(GLFWwindow* window, GLFWcharfun callback);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern nint glfwSetCharCallback(nint* window, nint callback);

    /// <remarks>
    /// <c>
    /// GLFWAPI GLFWcharmodsfun glfwSetCharModsCallback(GLFWwindow* window, GLFWcharmodsfun callback);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern nint glfwSetCharModsCallback(nint* window, nint callback);

    /// <remarks>
    /// <c>
    /// GLFWAPI GLFWmousebuttonfun glfwSetMouseButtonCallback(GLFWwindow* window, GLFWmousebuttonfun callback);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern nint glfwSetMouseButtonCallback(nint* window, nint callback);

    /// <remarks>
    /// <c>
    /// GLFWAPI GLFWcursorposfun glfwSetCursorPosCallback(GLFWwindow* window, GLFWcursorposfun callback);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern nint glfwSetCursorPosCallback(nint* window, nint callback);

    /// <remarks>
    /// <c>
    /// GLFWAPI GLFWcursorenterfun glfwSetCursorEnterCallback(GLFWwindow* window, GLFWcursorenterfun callback);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern nint glfwSetCursorEnterCallback(nint* window, nint callback);

    /// <remarks>
    /// <c>
    /// GLFWAPI GLFWscrollfun glfwSetScrollCallback(GLFWwindow* window, GLFWscrollfun callback);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern nint glfwSetScrollCallback(nint* window, nint callback);

    /// <remarks>
    /// <c>
    /// GLFWAPI GLFWdropfun glfwSetDropCallback(GLFWwindow* window, GLFWdropfun callback);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern nint glfwSetDropCallback(nint* window, nint callback);

    /// <remarks>
    /// <c>
    /// GLFWAPI int glfwJoystickPresent(int jid);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern int glfwJoystickPresent(int jid);

    /// <remarks>
    /// <c>
    /// GLFWAPI const float* glfwGetJoystickAxes(int jid, int* count);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern nint glfwGetJoystickAxes(int jid, int* count);

    /// <remarks>
    /// <c>
    /// GLFWAPI const unsigned char* glfwGetJoystickButtons(int jid, int* count);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern nint glfwGetJoystickButtons(int jid, int* count);

    /// <remarks>
    /// <c>
    /// GLFWAPI const unsigned char* glfwGetJoystickHats(int jid, int* count);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern nint glfwGetJoystickHats(int jid, int* count);

    /// <remarks>
    /// <c>
    /// GLFWAPI const char* glfwGetJoystickName(int jid);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern nint glfwGetJoystickName(int jid);

    /// <remarks>
    /// <c>
    /// GLFWAPI const char* glfwGetJoystickGUID(int jid);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern nint glfwGetJoystickGUID(int jid);

    /// <remarks>
    /// <c>
    /// GLFWAPI void glfwSetJoystickUserPointer(int jid, void* pointer);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern void glfwSetJoystickUserPointer(int jid, void* pointer);

    /// <remarks>
    /// <c>
    /// GLFWAPI void* glfwGetJoystickUserPointer(int jid);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern nint glfwGetJoystickUserPointer(int jid);

    /// <remarks>
    /// <c>
    /// GLFWAPI int glfwJoystickIsGamepad(int jid);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern int glfwJoystickIsGamepad(int jid);

    /// <remarks>
    /// <c>
    /// GLFWAPI GLFWjoystickfun glfwSetJoystickCallback(GLFWjoystickfun callback);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern nint glfwSetJoystickCallback(nint callback);

    /// <remarks>
    /// <c>
    /// GLFWAPI int glfwUpdateGamepadMappings(const char* string);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern int glfwUpdateGamepadMappings(byte* @string);

    /// <remarks>
    /// <c>
    /// GLFWAPI const char* glfwGetGamepadName(int jid);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern nint glfwGetGamepadName(int jid);

    /// <remarks>
    /// <c>
    /// GLFWAPI int glfwGetGamepadState(int jid, GLFWgamepadstate* state);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern int glfwGetGamepadState(int jid, nint* state);

    /// <remarks>
    /// <c>
    /// GLFWAPI void glfwSetClipboardString(GLFWwindow* window, const char* string);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern void glfwSetClipboardString(nint* window, byte* @string);

    /// <remarks>
    /// <c>
    /// GLFWAPI const char* glfwGetClipboardString(GLFWwindow* window);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern nint glfwGetClipboardString(nint* window);

    /// <remarks>
    /// <c>
    /// GLFWAPI double glfwGetTime(void);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern nint glfwGetTime();

    /// <remarks>
    /// <c>
    /// GLFWAPI void glfwSetTime(double time);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern void glfwSetTime(nint time);

    /// <remarks>
    /// <c>
    /// GLFWAPI uint64_t glfwGetTimerValue(void);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern nint glfwGetTimerValue();

    /// <remarks>
    /// <c>
    /// GLFWAPI uint64_t glfwGetTimerFrequency(void);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern nint glfwGetTimerFrequency();

    /// <remarks>
    /// <c>
    /// GLFWAPI void glfwMakeContextCurrent(GLFWwindow* window);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern void glfwMakeContextCurrent(nint* window);

    /// <remarks>
    /// <c>
    /// GLFWAPI GLFWwindow* glfwGetCurrentContext(void);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern nint glfwGetCurrentContext();

    /// <remarks>
    /// <c>
    /// GLFWAPI void glfwSwapBuffers(GLFWwindow* window);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern void glfwSwapBuffers(nint* window);

    /// <remarks>
    /// <c>
    /// GLFWAPI void glfwSwapInterval(int interval);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern void glfwSwapInterval(int interval);

    /// <remarks>
    /// <c>
    /// GLFWAPI int glfwExtensionSupported(const char* extension);
    /// </c>
    /// </remarks>
    [DllImport("glfw3.dll")]
    public static extern int glfwExtensionSupported(byte* extension);
    
    public static extern nint glfwGetProcAddress(byte* procname);
    
    public static extern int glfwVulkanSupported();
    
    public static extern nint glfwGetRequiredInstanceExtensions(nint* count);
    
    public static extern nint glfwGetInstanceProcAddress(nint instance, byte* procname);

    public static extern int glfwGetPhysicalDevicePresentationSupport(nint instance, nint device, nint queuefamily);

    public static extern int glfwCreateWindowSurface(nint instance, nint* window, nint* allocator, nint* surface);
    */
}