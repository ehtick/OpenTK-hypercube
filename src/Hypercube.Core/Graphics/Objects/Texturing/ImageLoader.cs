using Hypercube.Mathematics.Shapes;
using StbImageSharp;

namespace Hypercube.Core.Graphics.Objects.Texturing;

[PublicAPI]
public static class ImageLoader
{
    public static Image LoadFile(string path)
    {
        using var stream = File.OpenRead(path);
        return LoadStream(stream);
    }

    public static Image LoadStream(Stream stream)
    {
        var result = ImageResult.FromStream(stream, ColorComponents.RedGreenBlueAlpha);
        return new Image(result.Data, new Vector2i(result.Width, result.Height), 4, Rect2.UV);
    }
}