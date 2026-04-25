namespace Hypercube.Core.Windowing.Api.Exceptions;

[EngineInternal]
public sealed class WindowingApiInitializationException : WindowingApiException
{
    public WindowingApiInitializationException() : base("A critical error occurred during API initialization.")
    {
    }
}