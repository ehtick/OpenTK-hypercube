using Hypercube.Mathematics.Shapes;
using Hypercube.Mathematics.Vectors;
using StbImageWriteSharp;
using StbTrueTypeSharp;

namespace Hypercube.Core.Graphics.Fonts;

public class FontAtlasGenerator
{
    public static unsafe Stream Generate(byte[] fontData, out Dictionary<char, Glyph> glyphs, int fontSize = 32)
    {
        glyphs = [];

        var fontInfo = new StbTrueType.stbtt_fontinfo();
        
        fixed (byte* fontPtr = fontData)
            StbTrueType.stbtt_InitFont(fontInfo, fontPtr, 0);

        var scale = StbTrueType.stbtt_ScaleForPixelHeight(fontInfo, fontSize);

        int ascent, descent, lineGap;
        StbTrueType.stbtt_GetFontVMetrics(fontInfo, &ascent, &descent, &lineGap);
        var baseline = ascent * scale;
        
        const int padding = 2;
        const int firstChar = 32;
        const int lastChar = 126;
        const int charCount = lastChar - firstChar + 1;

        var columns = (int) Math.Ceiling(Math.Sqrt(charCount));
        var cellSize = fontSize + padding;
        var rows = (int) Math.Ceiling(charCount / (float)columns);
        var atlasWidth = columns * cellSize;
        var atlasHeight = rows * cellSize;

        // RGBA image
        var pixelData = new byte[atlasWidth * atlasHeight * 4];
        int x = 0, y = 0;

        for (var c = (char) firstChar; c <= (char) lastChar; c++)
        {
            var glyphIndex = StbTrueType.stbtt_FindGlyphIndex(fontInfo, c);
            int width, height, xOffset, yOffset;
            
            var bitmap = StbTrueType.stbtt_GetGlyphBitmap(
                fontInfo,
                scale,
                scale,
                glyphIndex,
                &width,
                &height,
                &xOffset,
                &yOffset
            );

            // Копируем глиф в RGBA image
            for (var j = 0; j < height; j++)
            {
                for (var i = 0; i < width; i++)
                {
                    var value = bitmap[j * width + i];
                    var dstX = x + i;
                    var dstY = y + j;
                    var dstIndex = (dstY * atlasWidth + dstX) * 4;
                    
                    pixelData[dstIndex + 0] = byte.MaxValue;
                    pixelData[dstIndex + 1] = byte.MaxValue;
                    pixelData[dstIndex + 2] = byte.MaxValue;
                    pixelData[dstIndex + 3] = value;
                }
            }

            StbTrueType.stbtt_FreeBitmap(bitmap, null);

            int advanceWidth, leftSideBearing;
            StbTrueType.stbtt_GetGlyphHMetrics(fontInfo, glyphIndex, &advanceWidth, &leftSideBearing);

            glyphs.Add(c, new Glyph
            {
                Character = c,
                SourceRect = new Rect2(x, y, x + width, y + height),
                Offset = new Vector2(xOffset, baseline - yOffset),
                Advance = advanceWidth * scale
            });

            x += cellSize;
            if (x + cellSize > atlasWidth)
            {
                x = 0;
                y += cellSize;
            }
        }

        var stream = new MemoryStream();
        var writer = new ImageWriter();
        writer.WritePng(pixelData, atlasWidth, atlasHeight, ColorComponents.RedGreenBlueAlpha, stream);
        
        stream.Position = 0;
        return stream;
    }
}