namespace Hypercube.Core.Windowing.Api.Settings;

[Flags]
public enum ContextFlags
{
    None = 0,
    Debug = 1 << 0,
    ForwardCompatible = 1 << 1,
}
