using System.Diagnostics.CodeAnalysis;
using Silk.NET.OpenAL;

namespace Hypercube.Core.Audio.Api.Realisations.OpenAl;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public static class ALExtension
{
    public static bool GetSourceProperty(this AL al, uint source, SourceBoolean param)
    {
        al.GetSourceProperty(source, param, out var value);
        return value;
    }
    
    public static float GetSourceProperty(this AL al, uint source, SourceFloat param)
    {
        al.GetSourceProperty(source, param, out var value);
        return value;
    }
    
    public static int GetSourceProperty(this AL al, uint source, GetSourceInteger param)
    {
        al.GetSourceProperty(source, param, out var value);
        return value;
    }
}