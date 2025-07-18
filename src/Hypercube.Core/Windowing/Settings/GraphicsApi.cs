namespace Hypercube.Core.Windowing.Settings;

public readonly struct ApiSettings
{
    public ContextApi Api { get; init; }
    public ContextProfile Profile { get; init; }
    public ContextFlags Flags { get; init; }
    public Version Version { get; init; }

    public bool DebugFlag => Flags.HasFlag(ContextFlags.Debug);
    public bool ForwardCompatibleFlag => Flags.HasFlag(ContextFlags.ForwardCompatible);

    public static implicit operator ContextApi(ApiSettings settings)
    {
        return settings.Api;
    }
    
    public static implicit operator ContextProfile(ApiSettings settings)
    {
        return settings.Profile;
    }
    
    public static implicit operator Version(ApiSettings settings)
    {
        return settings.Version;
    }
}