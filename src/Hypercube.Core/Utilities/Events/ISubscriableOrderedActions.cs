namespace Hypercube.Core.Utilities.Events;

public interface ISubscribableOrderedActions<out T>
{
    void Add(Action<T> action, int? priority = null);
}