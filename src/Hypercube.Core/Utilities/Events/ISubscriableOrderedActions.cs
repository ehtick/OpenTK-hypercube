namespace Hypercube.Core.Utilities.Events;

public interface ISubscribableOrderedActions<T>
{
    void Add(Action<T> action, int? priority = null);
}