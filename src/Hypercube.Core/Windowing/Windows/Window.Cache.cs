namespace Hypercube.Core.Windowing.Windows;

public sealed partial class Window
{
    // I think it is worth explaining.
    // When the engine is running in thread mode for window processing
    // we need to send a request to get a response,
    // which in asynchronous operation
    // will mean that we need to wait for a shuffle.
    // This is either asynchronous code where we don't want it,
    // or freezing the main thread,
    // which is what I was trying to avoid
    
    // So I just do hashing,
    // we subscribe to update the window parameters,
    // some of which I specifically call at the point of creation.
    // Yes, in fact we do not update immediately,
    // but we avoid synchronization problems.
    // There are no such problems at all,
    // when stream processing is turned off.
    
    // (And yes, we can't use _glfw.GetWindowSize since technically GLFW is in a different thread)
    
    private string _cachedTitle = string.Empty;
    private Vector2i _cachedSize = Vector2i.Zero;
    private Vector2i _cachedFramebufferSize = Vector2i.Zero;
    private Vector2i _cachedPosition = Vector2i.Zero;
}
