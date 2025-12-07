using ADP.Lib.AdpMinHeap;

namespace ADP.Lib.AdpPriorityQueue;

public class PriorityQueue<T> where T : IComparable<T>
{
    private readonly MinHeap<QueueItem<T>> _minHeap = new MinHeap<QueueItem<T>>();

    public int Count => _minHeap.Count;
    public bool IsReadOnly => false;

    public T Pop()
    {
        var result = this._minHeap.RemoveMin();
        return result.Data;
    }

    public void Push(T item, int priority)
    {
        var queueItem = new QueueItem<T>()
        {
            Data = item,
            Priority = priority
        };
        this._minHeap.Add(queueItem);
    }

    public void Clear()
    {
        this._minHeap.Clear();
    }
}
