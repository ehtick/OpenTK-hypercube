using System.Diagnostics.CodeAnalysis;
using Hypercube.Mathematics.Matrices;
using Hypercube.Mathematics.Vectors;

namespace Hypercube.UnitTests.Mathematics.Matrices;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public static class Matrix3x3Test
{
    [Test]
    public static void Enumerator()
    {
        var matrixA = new Matrix3x3(1, 2, 3, 4, 5, 6, 7, 8, 9);
        
        var y = 0;
        foreach (var row in matrixA)
        {
            var x = 0;
            foreach (var value in row)
            {
                Assert.That(value, Is.EqualTo(matrixA[x, y]));
                x++;
            }
            y++;
        }
    }

    [Test]
    public static void MultiplicationVector3()
    {
        var matrixA = new Matrix3x3(1, 2, 3, 4, 5, 6, 7, 8, 9);
        var vectorA = new Vector3(6, 4, 2);
        var vectorB = new Vector3(20, 56, 92);
        
        Assert.That(matrixA * vectorA, Is.EqualTo(vectorB));
    }

    [Test]
    public static void MultiplicationMatrix3x3()
    {
        var matrixA = new Matrix3x3(1, 2, 3, 4, 5, 6, 7, 8, 9);
        var matrixB = new Matrix3x3(1, 2, 1, 2, 4, 6, 7, 2, 5);
        var matrixC = new Matrix3x3(26, 16, 28, 56, 40, 64, 86, 64, 100);
        
        Assert.That(matrixA * matrixB, Is.EqualTo(matrixC));
    }
}