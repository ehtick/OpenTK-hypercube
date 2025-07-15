namespace Hypercube.Core.Graphics.Windowing.Manager.Exceptions;

/// <summary>
/// The exception that is thrown when a component is accessed before the windowing system is properly initialized.
/// </summary>
public sealed class WindowingNotInitializedException : Exception
{
    public WindowingNotInitializedException()
        : base($"Windowing system is not initialized. Call {nameof(IWindowManager.Init)} before accessing this member.") { }
}
