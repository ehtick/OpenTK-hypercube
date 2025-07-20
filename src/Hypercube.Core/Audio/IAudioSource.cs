﻿using Hypercube.Core.Audio.Manager;

namespace Hypercube.Core.Audio;

/// <summary>
/// Source created from <see cref="AudioStream"/>,
/// its implementation is the responsibility of the current
/// <see cref="IAudioManager"/> implementation.
/// </summary>
public interface IAudioSource : IDisposable
{
    IAudioGroup? Group { get; }
    
    bool Playing { get; }
    bool Stopped { get; }
    bool Paused { get; }
    
    bool Looping { get; set; }
    float Pitch { get; set; }
    float Gain { get; set; }
    
    void Start();
    void Stop();
    void Restart();
    void Pause();
}