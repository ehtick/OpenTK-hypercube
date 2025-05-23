using Hypercube.Resources;
using Hypercube.Resources.FileSystems;
using Hypercube.Resources.Loaders;

namespace Hypercube.Graphics.Resources;

public class FontResourceLoader : ResourceLoader<Font>
{
    public override string[] Extensions => ["ttf", "otf"];

    public override bool CanLoad(ResourcePath path, IFileSystem fileSystem)
    {
        return Extensions.Contains(path.Extension, StringComparer.OrdinalIgnoreCase);
    }

    public override Font Load(ResourcePath path, IFileSystem fileSystem)
    {
        var stream = fileSystem.OpenRead(path);
        using var memory = new MemoryStream();
        stream.CopyTo(memory);
        var fontData = memory.ToArray();

        /*
        var bitmap = FontAtlasGenerator.Generate(fontData, out var glyphs);
        var texture = Texture2D.FromBitmap(bitmap);
        return new FontTextureResource(texture, glyphs);
        */
        throw new NotImplementedException();
    }
}