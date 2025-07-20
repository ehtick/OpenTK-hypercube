using Hypercube.Core.Audio.Manager;

namespace Hypercube.Core.Audio.Exceptions;

public sealed class AudioManagerNotInitializedException : Exception
{
    public AudioManagerNotInitializedException()
        : base($"Audio system is not initialized. Call {nameof(IAudioManager.Init)} before accessing this member.") { }
}
