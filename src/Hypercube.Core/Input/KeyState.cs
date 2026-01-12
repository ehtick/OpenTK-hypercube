namespace Hypercube.Core.Input;

public enum KeyState
{
    /// <summary>
    /// The key was released.
    /// </summary>
    Released,
    
    /// <summary>
    /// The key was pressed.
    /// </summary>
    Pressed,

    /// <summary>
    /// The key was held down until it repeated.
    /// </summary>
    Held 
}
