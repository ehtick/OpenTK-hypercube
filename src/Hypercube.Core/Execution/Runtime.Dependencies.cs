using Hypercube.Core.Audio.Manager;
using Hypercube.Core.Ecs;
using Hypercube.Core.Ecs.Core.Systems;
using Hypercube.Core.Execution.LifeCycle;
using Hypercube.Core.Graphics.Patching;
using Hypercube.Core.Graphics.Rendering;
using Hypercube.Core.Graphics.Rendering.Context;
using Hypercube.Core.Graphics.Rendering.Manager;
using Hypercube.Core.Graphics.Viewports;
using Hypercube.Core.Input;
using Hypercube.Core.Resources;
using Hypercube.Core.Windowing.Manager;
using Hypercube.Utilities.Configuration;
using Hypercube.Utilities.Debugging.Logger;

namespace Hypercube.Core.Execution;

public partial class Runtime
{
    private void InitPrimaryDependencies()
    {
        _dependencies.RegisterSingleton<ILogger>(_logger);
        _dependencies.Register<IConfigManager, ConfigManager>();
    }
    
    private void InitDependencies()
    {
        // Core
        _dependencies.Register<IRuntimeLoop, RuntimeLoop>();
        _dependencies.Register<IEntitySystemManager, EntitySystemManager>();

        // Resources
        _dependencies.RegisterSingleton<IResourceManager>(new ResourceManager(container: _dependencies));
        
        // Windowing
        _dependencies.Register<IWindowManager, WindowManager>();
        
        // Graphics
        _dependencies.Register<ICameraManager, CameraManager>();
        _dependencies.Register<IRenderContext, RenderContext>();
        _dependencies.Register<IRenderManager, RenderManager>();
        _dependencies.Register<IPatchManager, PatchManager>();
        _dependencies.Register<IRenderer, Renderer>();
        
        // Audio
        _dependencies.Register<IAudioManager, AudioManager>();

        _dependencies.ResolveAll();
        _dependencies.Inject(this);
    }
    
    private void InitDependentsDependencies()
    {
        // Input
        _dependencies.Register<IInputHandler, InputHandler>();
        _dependencies.ResolveAll();
    }
}