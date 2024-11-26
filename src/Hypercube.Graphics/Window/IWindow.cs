using Hypercube.Mathematics.Vectors;

namespace Hypercube.Graphics.Window;

public interface IWindow
{
    string Title { get; set; }
    
    Vector2i Position { get; set; }
    Vector2i Size { get; set; }
    
    float Opacity { get; set; }
    bool IsVisible { get; set; }
    
    void Show();
    void Hide();
    void Focus();
    void RequestAttention();
    void SwapBuffers();
    void Close();
}