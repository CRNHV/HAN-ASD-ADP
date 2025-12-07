using System;
using System.Collections.Generic;
using System.Text;

namespace ADP.Lib.AdpPriorityQueue;

public class QueueItem<T> : IComparable<QueueItem<T>>
{
    public required int Priority { get; init; }

    public required T Data { get; init; }

    public int CompareTo(QueueItem<T>? other)
    {
        if (other == null)
            return -1;

        if (this.Priority == other.Priority)
        {
            return 0;
        }
        else if (this.Priority > other.Priority)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }
}
