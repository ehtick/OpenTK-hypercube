using Hypercube.Graphics.Fonts;
using Hypercube.Mathematics.Shapes;
using Hypercube.Mathematics.Vectors;
using Hypercube.Resources;
using Hypercube.Resources.FileSystems;
using Hypercube.Resources.Loaders;
using StbImageSharp;

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
        const int size = 32;
        
        var stream = fileSystem.OpenRead(path);
        using var memory = new MemoryStream();
        stream.CopyTo(memory);
        var fontData = memory.ToArray();

        
        var fontStream = FontAtlasGenerator.Generate(fontData, out var glyphs, size);
        var result = ImageResult.FromStream(fontStream, ColorComponents.RedGreenBlueAlpha);
        var texture = new Texture(new Vector2i(result.Width, result.Height), result.Data, (int) ColorComponents.RedGreenBlueAlpha, Box2.UV);
        
        return new Font(texture, glyphs, size);
    }
}