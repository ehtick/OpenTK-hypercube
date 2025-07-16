using System.Collections;

namespace Hypercube.Core.Utilities.Events;

public sealed class OrderedActions<T> : IEnumerable<Action<T>>, ISubscribableOrderedActions<T>
{
    private readonly List<Entry> _entries = [];

    public int Count => _entries.Count;

    public void Add(Action<T> action, int? priority = null)
    {
        var newEntry = new Entry(action, priority);

        // Insert with preserving the order in ascending order of priority
        var inserted = false;
        for (var index = 0; index < _entries.Count; index++)
        {
            var current = _entries[index];

            if (current.Priority is null && priority is not null)
            {
                _entries.Insert(index, newEntry);
                inserted = true;
                break;
            }

            if (current.Priority is null || priority is null || priority >= current.Priority)
                continue;
            
            _entries.Insert(index, newEntry);
            inserted = true;
            break;
        }

        if (!inserted)
            _entries.Add(newEntry);
    }

    public bool Remove(Action<T> action)
    {
        for (var i = 0; i < _entries.Count; i++)
        {
            if (_entries[i].Action != action)
                continue;
            
            _entries.RemoveAt(i);
            return true;
        }
        
        return false;
    }

    public void Clear()
    {
        _entries.Clear();
    }

    public void InvokeAll(T arg)
    {
        for (var i = 0; i < _entries.Count; i++)
        {
            _entries[i].Action(arg);
        }
    }

    public IEnumerator<Action<T>> GetEnumerator()
    {
        foreach (var entry in _entries)
        {
            yield return entry.Action;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private readonly struct Entry
    {
        public readonly Action<T> Action;
        public readonly int? Priority;

        public Entry(Action<T> action, int? priority)
        {
            Action = action;
            Priority = priority;
        }
    }
}
