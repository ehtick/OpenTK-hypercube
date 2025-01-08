namespace Hypercube.Graphics.Windowing.Api.Exceptions;

public sealed class WindowingApiInvalidThreadException : Exception
{
    public WindowingApiInvalidThreadException(string method) :
        base($"{method} cannot be called from the same thread where the windowing api operates. This will cause a deadlock.")
    {
        
    }
}