using Hypercube.Core.Windowing.Windows;

namespace Hypercube.Core.Windowing.Api.Exceptions;

[EngineInternal]
public sealed class WindowingApiWindowCreationException : WindowingApiException
{
    public WindowingApiWindowCreationException(WindowCreateSettings settings, string shareReport, int code, string codeName, string reason)
        : base(
            $"""
             Handled internal exception while creating window
             Code: {codeName} 0x{code:x8} ({code})
             Reason: {reason}
             Settings: {settings}
             Reports:
             
             <Share>
             {shareReport}
          
             """
        )
    {
    }
}