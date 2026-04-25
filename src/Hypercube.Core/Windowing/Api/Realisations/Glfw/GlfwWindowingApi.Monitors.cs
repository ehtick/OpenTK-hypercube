using Hypercube.Core.Windowing.Api.Realisations.Glfw.Utilities.Extensions;
using Hypercube.Core.Windowing.Monitors;

// Silk redefine for reduce type/namespace collisions
using SilkMonitor = Silk.NET.GLFW.Monitor;

namespace Hypercube.Core.Windowing.Api.Realisations.Glfw;

public sealed unsafe partial class GlfwWindowingApi
{
   protected override IReadOnlyCollection<MonitorInstance> InternalGetMonitorInstances()
   {
      var list = _glfw.GetMonitors(out var count);
      if (list is null || count == 0)
         return [];
      
      var result = new MonitorInstance[count];
      for (var i = 0; i < count; i++)
      {
         var ptr = list[i];

         var handle = new MonitorHandle((nint) ptr);
         var settings = GetMonitorSettings(ptr);
         
         result[i] = new MonitorInstance(handle, settings);
      }
      
      return result;
   }

   private MonitorCreateSettings GetMonitorSettings(SilkMonitor* monitor)
   {
      return new MonitorCreateSettings
      {
         Name = _glfw.GetMonitorName(monitor),
         Primary = _glfw.GetPrimaryMonitor() == monitor,
         
         Position = _glfw.GetMonitorPos(monitor),
         PhysicalSize = _glfw.GetMonitorPhysicalSize(monitor),
         Dpi = _glfw.GetMonitorDpi(monitor),
         
         ContentScale = _glfw.GetMonitorContentScale(monitor),
         WorkArea = _glfw.GetMonitorWorkArea(monitor),
         
         CurrentVideoMode = _glfw.GetMonitorVideoMode(monitor),
         VideoModes = _glfw.GetMonitorVideoModes(monitor)
      };
   }
}
