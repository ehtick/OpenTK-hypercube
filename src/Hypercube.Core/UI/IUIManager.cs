using Hypercube.Core.UI.Elements;

namespace Hypercube.Core.UI;

public interface IUIManager
{
    WindowRoot Root { get; }

    void AddElement(Element element);
    
    void RemoveElement(Element element);
    
    void Arrange();
}