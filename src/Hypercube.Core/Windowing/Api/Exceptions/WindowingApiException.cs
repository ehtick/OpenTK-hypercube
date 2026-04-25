namespace Hypercube.Core.Windowing.Api.Exceptions;

[EngineInternal]
public abstract class WindowingApiException : Exception
{
    protected WindowingApiException(string? message) : base(message)
    {
    }
}
