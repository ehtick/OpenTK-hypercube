﻿using Hypercube.Core.Utilities.Events;

namespace Hypercube.Core.Execution;

public interface IRuntimeLoop
{
    ISubscribableOrderedActions<FrameEventArgs> Actions { get; }
    
    bool Running { get; }
    void Run();
    void Shutdown();
}