using System.Text;
using Silk.NET.OpenAL;

namespace Hypercube.Core.Audio.Api.Realisations.OpenAl;

public partial class OpenAlAudioApi
{
    public override string Info
    {
        get
        {
            var builder = new StringBuilder();
            
            builder.Append("Vendor: ");
            builder.AppendLine(_al.GetStateProperty(StateString.Vendor));
            
            builder.Append("Renderer: ");
            builder.AppendLine(_al.GetStateProperty(StateString.Renderer));
            
            builder.Append("Version: ");
            builder.AppendLine(_al.GetStateProperty(StateString.Version));
            
            builder.Append("Extensions: ");
            builder.AppendLine(_al.GetStateProperty(StateString.Extensions));
            
            builder.Append("Capturing: ");
            builder.AppendLine($"{_captureExtension is not null}");

            builder.Append("Enumerating: ");
            builder.AppendLine($"{_enumerationExtension is not null}");
            
            builder.Append("Devices: ");
            builder.Append($"{string.Join(", ", DeviceSpecifiers)}");
            
            return builder.ToString();
        }
    }
}