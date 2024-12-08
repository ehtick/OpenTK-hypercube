using System.Threading.Channels;

namespace Hypercube.Core.Utilities.Threads;

/// <summary>
/// ThreadBridge is designed to pass events between threads
/// using a strongly typed, blocking channel mechanism.
/// </summary>
public class ThreadBridge<T> where T : notnull
{
    private ChannelWriter<T> Writer { get; }
    private ChannelReader<T> Reader { get; }

    /// <summary>
    /// Initializes a new instance of the ThreadBridge.
    /// </summary>
    public ThreadBridge(BoundedChannelOptions options)
    {
        var channel = Channel.CreateBounded<T>(options);
        Writer = channel.Writer;
        Reader = channel.Reader;
    }

    public ThreadBridge(UnboundedChannelOptions options)
    {
        var channel = Channel.CreateUnbounded<T>(options);
        Writer = channel.Writer;
        Reader = channel.Reader;
    }

    /// <summary>
    /// Publishes an event to the bridge.
    /// </summary>
    /// <param name="eventMessage">The event to publish.</param>
    public bool Raise(T eventMessage)
    {
        return Writer.TryWrite(eventMessage);
    }

    /// <summary>
    /// Subscribes to events of the specified type.
    /// Blocks until an event is available.
    /// </summary>
    /// <typeparam name="T">The type of event to subscribe to.</typeparam>
    /// <returns>An enumerable that yields events of the specified type.</returns>
    public IEnumerable<T> Process()
    {
        while (Reader.TryRead(out var eventMessage) && eventMessage is { } typedEvent)
        {
            yield return typedEvent;
        }
    }

    public void CompleteWrite()
    {
        Writer.Complete();
    }
}