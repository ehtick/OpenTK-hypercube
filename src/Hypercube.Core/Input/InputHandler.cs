using Hypercube.Core.Graphics.Windowing.Api;
using Hypercube.Core.Graphics.Windowing.Manager;
using Hypercube.Utilities.Dependencies;
using Hypercube.Utilities.Extensions;

namespace Hypercube.Core.Input;

[UsedImplicitly]
public sealed class InputHandler : IInputHandler, IPostInject
{
    [Dependency] private readonly IWindowManager _window = default!;

    private Dictionary<nint, Keys> _key = new();
    
    private IWindowingApi _windowingApi => _window.Api;
    
    public void PostInject()
    {
        _windowingApi.OnWindowKey += OnKeyUpdate;
        _windowingApi.OnWindowMouseButton += OnMouseButtonUpdate;
    }

    public void Update()
    {
        foreach (var (_, keys) in _key)
        {
            keys.Held.Clear();
            keys.Released.Clear();
        }
    }
    
    public bool IsKeyState(nint window, Key key, KeyState state)
    {
        return _key.TryGetValue(window, out var keys) && keys[state].Contains(key);
    }
    
    public bool IsKeyHeld(nint window, Key key)
    {
        return IsKeyState(window, key, KeyState.Held);
    }

    public bool IsKeyPressed(nint window, Key key)
    {
        return IsKeyState(window, key, KeyState.Pressed);
    }

    public bool IsKeyReleased(nint window, Key key)
    {
        return IsKeyState(window, key, KeyState.Pressed);
    }

    public bool IsKeyState(Key key, KeyState state)
    {
        return IsKeyState(_windowingApi.ContextCurrent, key, state);
    }

    public bool IsKeyHeld(Key key)
    {
        return IsKeyState(key, KeyState.Held);
    }

    public bool IsKeyPressed(Key key)
    {
        return IsKeyState(key, KeyState.Pressed);
    }

    public bool IsKeyReleased(Key key)
    {
        return IsKeyState(key, KeyState.Pressed);
    }
    
    private void OnKeyUpdate(nint window, KeyStateChangedArgs state)
    {
        var keys = _key.GetOrInstantiate(window);
        switch (state.State)
        {
            // Legacy shit, maybe will eat many ram and cpu
            // We made many shit because fucking Key rollover: https://en.wikipedia.org/wiki/Key_rollover
            case KeyState.Pressed:
                keys.Held.Add(state.Key);
                keys.Pressed.Add(state.Key);
                break;
            
            case KeyState.Released:
                keys.Held.Remove(state.Key);
                keys.Released.Add(state.Key);
                break;
            
            case KeyState.Held:
                break;
            
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
    }

    private void OnMouseButtonUpdate(nint window, MouseButtonChangedArgs state)
    {
        
    }
    
    private readonly struct Keys
    {
        public readonly List<Key> Released = [];
        public readonly List<Key> Pressed = [];
        public readonly List<Key> Held = [];

        public List<Key> this[KeyState state] =>
            state switch
            {
                KeyState.Released => Released,
                KeyState.Pressed => Pressed,
                KeyState.Held => Held,
                _ => throw new ArgumentOutOfRangeException(nameof(state), state, null)
            };

        public Keys()
        {
        }
    }
}