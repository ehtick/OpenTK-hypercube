using System.Globalization;
using Hypercube.Graphics.Resources;
using Hypercube.Mathematics.Vectors;

namespace Hypercube.Graphics.Models;

public static class ModelObjLoader
{
    public static Model Load(Stream stream)
    {
        using var reader = new StreamReader(stream);
     
        var culture = CultureInfo.InvariantCulture;
        
        var tempVertices = new List<Vector3>();
        var tempNormals = new List<Vector3>();
        var tempUVs = new List<Vector2>();
        var tempIndices = new List<(int v, int vt, int vn)>();
        
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#")) continue;

            var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            switch (parts[0])
            {
                case "v":
                    tempVertices.Add(new Vector3(
                        float.Parse(parts[1], culture),
                        float.Parse(parts[2], culture),
                        float.Parse(parts[3], culture)
                    ));
                    break;

                case "vt":
                    tempUVs.Add(new Vector2(
                        float.Parse(parts[1], culture),
                        float.Parse(parts[2], culture)
                    ));
                    break;

                case "vn":
                    tempNormals.Add(new Vector3(
                        float.Parse(parts[1], culture),
                        float.Parse(parts[2], culture),
                        float.Parse(parts[3], culture)
                    ));
                    break;

                case "f":
                    for (var i = 1; i < parts.Length; i++)
                    {
                        var indices = parts[i].Split('/');
                        var v = int.Parse(indices[0]) - 1;
                        var vt = indices.Length > 1 && indices[1] != "" ? int.Parse(indices[1]) - 1 : -1;
                        var vn = indices.Length > 2 ? int.Parse(indices[2]) - 1 : -1;
                        tempIndices.Add((v, vt, vn));
                    }
                    break;
            }
        }
        
        return new Model(
            tempVertices.ToArray(),
            tempNormals.ToArray(),
            tempUVs.ToArray(),
            tempIndices.ToArray()
        );
    }
}