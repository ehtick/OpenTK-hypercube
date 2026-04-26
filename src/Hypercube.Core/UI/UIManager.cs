using Hypercube.Core.Execution.LifeCycle;
using Hypercube.Core.Graphics.Patching;
using Hypercube.Core.Input;
using Hypercube.Core.Input.Handler;
using Hypercube.Core.UI.Elements;
using Hypercube.Core.Windowing.Manager;
using Hypercube.Mathematics;
using Hypercube.Mathematics.Shapes;
using Hypercube.Utilities.Dependencies;
using Hypercube.Utilities.Debugging.Logger;

namespace Hypercube.Core.UI;

public sealed class UIManager : IUIManager, IPostInject
{
    [PublicAPI] public readonly IDependenciesContainer DependenciesContainer;
    [PublicAPI] public readonly UIPatch Patch;

    [Dependency] private readonly IRuntimeLoop _runtimeLoop = null!;
    [Dependency] private readonly IPatchManager _patchManager = null!;
    [Dependency] private readonly IInputHandler _inputHandler = null!;
    [Dependency] private readonly IWindowingManager _windowingManager = null!;
    [Dependency] private readonly ILogger _logger = null!;

    public WindowRoot Root { get; }

    public void OnPostInject()
    {
        _patchManager.AddPatch(Patch);
        _runtimeLoop.Actions.Add(OnUpdate, EngineUpdatePriority.UIUpdate);
    }

    public UIManager(IDependenciesContainer dependenciesContainer)
    {
        DependenciesContainer = new DependenciesContainer(dependenciesContainer);
        Patch = new UIPatch(this);

        Root = new WindowRoot();
        Root.SetDependencies(DependenciesContainer);
    }

    public void AddElement(Element element)
    {
        Root.AddChild(element);
    }

    public void RemoveElement(Element element)
    {
        Root.RemoveChild(element);
    }

    public void Arrange()
    {
        var window = _windowingManager.MainWindow;
        var rect = new Rect2(0, 0, window.Size.X, window.Size.Y);
        
        Root.Arrange(rect);
    }

    private void OnUpdate(FrameEventArgs args)
    {
        Root.Update(args);
    }
}
