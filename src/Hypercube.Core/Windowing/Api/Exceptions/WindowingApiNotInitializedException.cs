namespace Hypercube.Core.Windowing.Api.Exceptions;

[EngineInternal]
public sealed class WindowingApiNotInitializedException : Exception
{
    public WindowingApiNotInitializedException()
        : base("Windowing Api is not initialized. Please initialize before executing commands or raising events.")
    {
        
    }
}