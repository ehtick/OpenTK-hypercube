using System.Runtime.CompilerServices;

namespace Hypercube.Core.Input.Args;

[PublicAPI]
public readonly ref struct KeyChangedArgs
{
    public readonly Key Key;
    public readonly KeyState State;
    public readonly KeyModifiers Modifiers;
    public readonly int ScanCode;
    
    public bool Shift
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Modifiers.HasFlag(KeyModifiers.Shift);
    }
    
    public bool Control
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Modifiers.HasFlag(KeyModifiers.Control);
    }
    
    public bool Alt
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Modifiers.HasFlag(KeyModifiers.Alt);
    }
    
    public bool Super
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Modifiers.HasFlag(KeyModifiers.Super);
    }
    
    public bool CapsLock
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Modifiers.HasFlag(KeyModifiers.CapsLock);
    }
    
    public bool NumLock
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Modifiers.HasFlag(KeyModifiers.NumLock);
    }

    public KeyChangedArgs(Key key, KeyState state, KeyModifiers modifiers, int scanCode)
    {
        Key = key;
        State = state;
        Modifiers = modifiers;
        ScanCode = scanCode;
    }

    public static implicit operator KeyState(KeyChangedArgs args)
    {
        return args.State;
    }
}
