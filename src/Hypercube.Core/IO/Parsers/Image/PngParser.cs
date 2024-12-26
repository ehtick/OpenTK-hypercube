using System.IO.Compression;
using System.Text;

namespace Hypercube.Core.IO.Parsers.Image;

public static class PngParser
{
    public static void LoadData(Stream stream)
    {
        using var binaryReader = new BinaryReader(stream, new UTF8Encoding(), true);
        LoadData(binaryReader);
    }
    
    public static void LoadData(BinaryReader reader)
    {
        // Проверка заголовка PNG (89 50 4E 47 0D 0A 1A 0A)
        if (reader.ReadByte() != 0x89 || reader.ReadByte() != 0x50 || reader.ReadByte() != 0x4E ||
            reader.ReadByte() != 0x47 || reader.ReadByte() != 0x0D || reader.ReadByte() != 0x0A ||
            reader.ReadByte() != 0x1A || reader.ReadByte() != 0x0A)
        {
            throw new Exception("Это не PNG файл.");
        }

        int width = 0, height = 0, channels = 0;
        byte[] imageData = null;

        // Чтение чанков
        while (reader.BaseStream.Position < reader.BaseStream.Length)
        {
            // Чтение длины блока
            int blockLength = reader.ReadInt32();

            // Чтение типа блока (например, IHDR, IDAT)
            byte[] blockType = reader.ReadBytes(4);

            // Обработка блока IHDR (заголовок изображения)
            if (IsBlockType(blockType, "IHDR"))
            {
                width = reader.ReadInt32();
                height = reader.ReadInt32();
                channels = reader.ReadByte() == 6 ? 4 : 3; // PNG с альфа-каналом или без
                reader.BaseStream.Seek(4, SeekOrigin.Current); // Пропускаем CRC
            }

            // Обработка блока IDAT (данные изображения)
            if (IsBlockType(blockType, "IDAT"))
            {
                byte[] compressedData = reader.ReadBytes(blockLength);

                // Разжимаем данные с использованием Deflate
                using (MemoryStream ms = new MemoryStream(compressedData))
                using (DeflateStream deflateStream = new DeflateStream(ms, CompressionMode.Decompress))
                {
                    using (MemoryStream decompressedStream = new MemoryStream())
                    {
                        deflateStream.CopyTo(decompressedStream);
                        imageData = decompressedStream.ToArray();
                    }
                }
                reader.BaseStream.Seek(4, SeekOrigin.Current); // Пропускаем CRC
            }

            // Переход к следующему блоку
            reader.BaseStream.Seek(blockLength + 4, SeekOrigin.Current); // Пропускаем данные блока и CRC
        }

        if (imageData == null)
        {
            throw new Exception("Не удалось загрузить изображение.");
        }

        // Декодируем фильтрацию строк и собираем пиксели
        ImageData imgData = DecodePngImage(imageData, width, height, channels);

        Console.WriteLine($"Ширина: {imgData.Width}, Высота: {imgData.Height}, Каналы: {imgData.Channels}");
        Console.WriteLine($"Размер изображения в байтах: {imgData.Data.Length}");
    }
    
    private static bool IsBlockType(byte[] blockType, string type)
    {
        byte[] typeBytes = Encoding.ASCII.GetBytes(type);
        for (int i = 0; i < 4; i++)
        {
            if (blockType[i] != typeBytes[i])
                return false;
        }
        return true;
    }

    private static ImageData DecodePngImage(byte[] data, int width, int height, int channels)
    {
        int rowSize = width * channels;
        byte[] imageData = new byte[width * height * channels];
        int dataOffset = 0;
        int index = 0;

        // Применяем фильтрацию строк (напрямую без сложных фильтров, для простоты)
        for (int y = 0; y < height; y++)
        {
            // Применяем фильтрацию строки
            byte filterType = data[dataOffset++]; // Первый байт — тип фильтра
            for (int x = 0; x < rowSize; x++)
            {
                byte byteVal = data[dataOffset++];
                imageData[index++] = byteVal;
            }
        }

        return new ImageData
        {
            Data = imageData,
            Width = width,
            Height = height,
            Channels = channels
        };
    }
}

public struct ImageData
{
    public byte[] Data;    // Данные изображения (пиксели)
    public int Width;      // Ширина изображения
    public int Height;     // Высота изображения
    public int Channels;   // Количество каналов (например, 3 для RGB, 4 для RGBA)
}