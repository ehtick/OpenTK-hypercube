using Hypercube.Core.UI.Elements;

namespace Hypercube.Core.UI;

public interface IUIManager
{
    /// <summary>
    /// Получает корневой UI элемент.
    /// </summary>
    WindowRoot Root { get; }
    
    /// <summary>
    /// Добавляет UI элемент в корень.
    /// </summary>
    void AddElement(Element element);
    
    /// <summary>
    /// Удаляет UI элемент из корня.
    /// </summary>
    void RemoveElement(Element element);
    
    /// <summary>
    /// Обновляет layout всех UI элементов.
    /// </summary>
    void Arrange();
}