using Hypercube.Mathematics.Vectors;

namespace Hypercube.UnitTests.Mathematics.Angle;

[TestFixture]
public static class AngleTest
{
    private static readonly Dictionary<double, Vector2> ConvertToVectorPairs = new()
    {
        { 0d, Vector2.UnitX },
        { Hypercube.Mathematics.HyperMath.PIOver2, Vector2.UnitY },
        { Hypercube.Mathematics.HyperMath.PIOver4, Vector2.One.Normalized },
        { Hypercube.Mathematics.HyperMath.PI, -Vector2.UnitX },
        { Hypercube.Mathematics.HyperMath.ThreePiOver2, -Vector2.UnitY },
    };

    [Test]
    public static void ConvertToDegrees()
    {
        Assert.Multiple(() =>
        {
            Assert.That(new Hypercube.Mathematics.Angle(Hypercube.Mathematics.HyperMath.PI).Degrees, Is.EqualTo(180d).Within(0.01d));
            Assert.That(new Hypercube.Mathematics.Angle(Hypercube.Mathematics.HyperMath.PIOver2).Degrees, Is.EqualTo(90d).Within(0.01d));
            Assert.That(new Hypercube.Mathematics.Angle(Hypercube.Mathematics.HyperMath.PIOver4).Degrees, Is.EqualTo(45d).Within(0.01d));
            Assert.That(new Hypercube.Mathematics.Angle(Hypercube.Mathematics.HyperMath.PIOver6).Degrees, Is.EqualTo(30d).Within(0.01d));
        });
    }
    
    [Test]
    public static void ConvertFromDegrees()
    {
        Assert.Multiple(() =>
        {
            Assert.That(Hypercube.Mathematics.Angle.FromDegrees(180d), Is.EqualTo(new Hypercube.Mathematics.Angle(Hypercube.Mathematics.HyperMath.PI)));
            Assert.That(Hypercube.Mathematics.Angle.FromDegrees(90d), Is.EqualTo(new Hypercube.Mathematics.Angle(Hypercube.Mathematics.HyperMath.PIOver2)));
            Assert.That(Hypercube.Mathematics.Angle.FromDegrees(45d), Is.EqualTo(new Hypercube.Mathematics.Angle(Hypercube.Mathematics.HyperMath.PIOver4)));
            Assert.That(Hypercube.Mathematics.Angle.FromDegrees(30d), Is.EqualTo(new Hypercube.Mathematics.Angle(Hypercube.Mathematics.HyperMath.PIOver6)));
        });
    }

    [Test]
    public static void ConvertToVector()
    {
        foreach (var (angle, vector) in ConvertToVectorPairs)
        {
            var vectorA = new Hypercube.Mathematics.Angle(angle).Vector.Round(3);
            var vectorB = vector.Round(3);
            
            if (vectorA.Equals(vectorB))
                continue;

            Assert.Fail($"Expected {vectorB}, but was {vectorA}");
        }
    }
}