using Hypercube.Graphics.Windowing.Settings;
using Hypercube.Mathematics.Vectors;

namespace Hypercube.Graphics.Windowing.Api;

public abstract unsafe partial class WindowingApi
{
    /// <summary>
    /// Basic form of the command for accessing the API internals.
    /// </summary>
    private interface ICommand;

    /// <summary>
    /// A variation of the <see cref="ICommand"/>
    /// for synchronized access to the API internals.
    /// </summary>
    private interface ICommandSync : ICommand
    {
        TaskCompletionSource Task { get; }
    }

    /// <summary>
    /// A variation of the <see cref="ICommand"/>
    /// for synchronized access to the API internals,
    /// with a certain result.
    /// </summary>
    private interface ICommandSync<TResult> : ICommand
    {
        TaskCompletionSource<TResult> Task { get; }
    }

    private readonly record struct CommandTerminate
        : ICommand;

    private readonly record struct CommandWindowSetTitle(nint Window, string Title)
        : ICommand;

    private readonly record struct CommandWindowSetPosition(nint Window, Vector2i Position)
        : ICommand;

    private readonly record struct CommandWindowSetSize(nint Window, Vector2i Size)
        : ICommand;

    private readonly record struct CommandWindowCreate(WindowCreateSettings Settings)
        : ICommand;
    
    private readonly record struct CommandWindowCreateSync(WindowCreateSettings Settings, TaskCompletionSource<nint> Tcs)
        : ICommandSync<nint>
    {
        public TaskCompletionSource<nint> Task => Tcs;
    }
}