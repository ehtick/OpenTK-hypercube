namespace Hypercube.Core.Windowing.Api.Exceptions;

[EngineInternal]
public sealed class WindowingApiInitializationException : Exception
{
    public WindowingApiInitializationException() : base("A critical error occurred during API initialization.")
    {
    }
}