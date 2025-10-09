using Hypercube.Core.Execution.LifeCycle;
using Hypercube.Core.UI.Elements;
using Hypercube.Core.Windowing;
using Hypercube.Core.Windowing.Manager;
using Hypercube.Utilities.Dependencies;

namespace Hypercube.Core.UI;

public class UIManager : IUIManager
{
    [Dependency] private readonly IWindowManager _windowManager = default!;
    [Dependency] private readonly IRuntimeLoop _runtimeLoop = default!;

    private readonly Dictionary<IWindow, WindowRoot> _windowRoots = [];
    
    public UIManager()
    {
        _windowManager.OnWindowCreated += OnWindowCreated;
    }

    public WindowRoot GetRoot(IWindow window)
    {
        return _windowRoots[window];
    }
    
    private void OnWindowCreated(IWindow window)
    {
        _windowRoots[window] = new WindowRoot();
    }
}