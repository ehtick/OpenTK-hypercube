using System.Runtime.CompilerServices;

namespace Hypercube.Core.Input;

[PublicAPI]
public readonly ref struct MouseButtonChangedArgs
{
    public readonly MouseButton Button;
    public readonly KeyState State;
    public readonly KeyModifiers Modifiers;
    
    public bool Shift
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (Modifiers & KeyModifiers.Shift) != 0;
    }

    public bool Control
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (Modifiers & KeyModifiers.Control) != 0;
    }

    public bool Alt
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (Modifiers & KeyModifiers.Alt) != 0;
    }

    public bool Super
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (Modifiers & KeyModifiers.Super) != 0;
    }

    public bool CapsLock
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (Modifiers & KeyModifiers.CapsLock) != 0;
    }

    public bool NumLock
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => (Modifiers & KeyModifiers.NumLock) != 0;
    }

    public MouseButtonChangedArgs(MouseButton button, KeyState state, KeyModifiers modifiers)
    {
        Button = button;
        State = state;
        Modifiers = modifiers;
    }
}
