namespace Hypercube.Core.Graphics.Texturing;

[IdStruct(typeof(uint?))]
public readonly partial struct TextureHandle
{
    public static readonly TextureHandle Zero = new(0);
    
    public bool HasValue => Value.HasValue;
}
