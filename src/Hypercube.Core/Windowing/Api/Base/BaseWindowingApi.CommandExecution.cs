using Hypercube.Core.Windowing.Api.Exceptions;
using Hypercube.Utilities.Threads;

namespace Hypercube.Core.Windowing.Api.Base;

public abstract partial class BaseWindowingApi
{
    // TODO: I can't definitively say by how much (or whether)
    //       switch-case will run faster than overload.
    //       Therefore, I will implement switch-case, in the future
    //       it would be good to make performance
    //       checks for a large number of commands.
    
    private void Process(ICommand command)
    {
        switch (command)
        {
            case CommandTerminate:
                Stop();
                InternalTerminate();
                break;
            
            case CommandWindowSetTitle windowSetTitle:
                InternalWindowSetTitle(windowSetTitle.Window, windowSetTitle.Title);
                Raise(new EventWindowTitle(windowSetTitle.Window, windowSetTitle.Title), windowSetTitle.Thread != Thread);
                break;
            
            case CommandWindowSetPosition windowSetPosition:
                InternalWindowSetPosition(windowSetPosition.Window, windowSetPosition.Position);
                break;
            
            case CommandWindowSetSize windowSetSize:
                InternalWindowSetSize(windowSetSize.Window, windowSetSize.Size);
                break;
            
            case CommandWindowCreate windowCreate:
                InternalWindowCreate(windowCreate.Settings);
                break;
            
            case CommandWindowCreateSync windowCreateSync:
                var window = InternalWindowCreate(windowCreateSync.Settings);
                Raise(new EventSync<nint>(windowCreateSync.Task, window), windowCreateSync.Thread != Thread);
                break;
        }
    }

    private void ProcessCommands(bool single = false)
    {
        if (_commandBridge is null)
            throw new WindowingApiNotInitializedException();
        
        while (_commandBridge.TryRead(out var command))
        {
            Process(command);
            
            if (single)
                break;
        }
    }
    
    /// <summary>
    /// Processes a command by either sending it through a <see cref="ThreadBridge{T}"/> for multithreaded environments
    /// or executing it directly in single-threaded scenarios.
    /// </summary>
    /// <param name="command">The command to be processed.</param>
    private void Execute(ICommand command)
    {
        if (_commandBridge is null)
            throw new WindowingApiNotInitializedException();
        
        // For single-threaded system operation,
        // we don't need to pass the command through the bridge,
        // which is much more logical
        if (Thread.CurrentThread == Thread)
        {
            Process(command);
            return;
        }

        // For multithreaded mode,
        // we need to send the command through the bridge,
        // to be processed in another thread,
        // because the Raise method assumes external access
        // to the internal API
        _commandBridge.Raise(command);
        
        // Since Api expects real commands,
        // and we feed it a virtual one,
        // we need to wake it up to initialize the processing 
        InternalPostEmptyEvent();
    }
}