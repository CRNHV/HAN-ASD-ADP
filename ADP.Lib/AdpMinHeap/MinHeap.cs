using ADP.Lib.AdpArrayList;

namespace ADP.Lib.AdpMinHeap;

public class MinHeap<T> where T : IComparable<T>
{
    private readonly List<T> Items = new List<T>();

    public int Count => this.Items.Count;

    public void Add(T item)
    {
        Items.Add(item);

        var index = this.Items.Count - 1;

        while (index > 0 && this.Items[(index - 1) / 2].CompareTo(this.Items[index]) > 0)
        {
            // Swap
            var temp = this.Items[index];

            this.Items[index] = this.Items[(index - 1) / 2];
            this.Items[(index - 1) / 2] = temp;

            index = (index - 1) / 2;
        }
    }

    public bool Remove(T value)
    {
        // Find the index of the element to be deleted
        int index = -1;
        for (int i = 0; i < this.Items.Count; i++)
        {
            if (this.Items[i].CompareTo(value) == 0)
            {
                index = i;
                break;
            }
        }

        if (index == -1)
        {
            return false;
        }

        this.Items[index] = this.Items[this.Items.Count - 1];

        this.Items.RemoveAt(this.Items.Count - 1);

        while (true)
        {
            int left_child = 2 * index + 1;
            int right_child = 2 * index + 2;
            int smallest = index;

            if (left_child < this.Items.Count && this.Items[left_child].CompareTo(this.Items[smallest]) < 0)
            {
                smallest = left_child;
            }
            if (right_child < this.Items.Count && this.Items[right_child].CompareTo(this.Items[smallest]) < 0)
            {
                smallest = right_child;
            }

            if (smallest != index)
            {
                var temp = this.Items[index];
                this.Items[index] = this.Items[smallest];
                this.Items[smallest] = temp;
                index = smallest;
            }
            else
            {
                break;
            }
        }

        return true;
    }

    public T RemoveMin()
    {
        if (this.Items.Count == 0)
        {
            throw new InvalidOperationException("Heap is empty");
        }
        var min = this.Items[0];
        this.Items[0] = this.Items[this.Items.Count - 1];
        this.Items.RemoveAt(this.Items.Count - 1);
        var index = 0;
        while (true)
        {
            var leftChildIndex = 2 * index + 1;
            var rightChildIndex = 2 * index + 2;
            var smallestIndex = index;
            if (leftChildIndex < this.Items.Count && this.Items[leftChildIndex].CompareTo(this.Items[smallestIndex]) < 0)
            {
                smallestIndex = leftChildIndex;
            }
            if (rightChildIndex < this.Items.Count && this.Items[rightChildIndex].CompareTo(this.Items[smallestIndex]) < 0)
            {
                smallestIndex = rightChildIndex;
            }
            if (smallestIndex == index)
            {
                break;
            }
            // Swap
            var temp = this.Items[index];
            this.Items[index] = this.Items[smallestIndex];
            this.Items[smallestIndex] = temp;
            index = smallestIndex;
        }
        return min;
    }

    public void Clear()
    {
        this.Items.Clear();
    }

    public bool Contains(T item)
    {
        return this.Items.Contains(item);
    }

    public T[] AsArray => this.Items.ToArray();
}
