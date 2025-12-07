using System.Collections;

namespace ADP.Lib.AdpArrayList;

public class ArrayList<T> : ICollection<T> where T : IComparable<T>
{
    // https://docs.oracle.com/javase/8/docs/api/java/util/ArrayList.html
    // Java also sets it as 10, so it must be good. 
    protected T[] Items = new T[10];
    private int _size = 0;

    public int Count => _size;

    public bool IsReadOnly => false;

    public virtual void Add(T item)
    {
        if (_size == Items.Length)
        {
            // Recently I saw a github post from a facebook team saying 1.5 is optimal
            // It's arbitrary anyway, so let's go with it.
            double newSize = Items.Length * 1.5;
            T[] newArray = new T[(int)newSize];
            for (int i = 0; i < Items.Length; i++)
            {
                newArray[i] = Items[i];
            }
            Items = newArray;
        }

        Items[_size] = item;
        _size++;
    }

    public void Clear()
    {
        // Easier than actually removing the items :) 
        Items = new T[_size];
    }

    public bool Contains(T item)
    {
        for (int i = 0; i < _size; i++)
        {
            if (Items[i].CompareTo(item) == 0)
                return true;
        }

        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        ArgumentNullException.ThrowIfNull(array);
        ArgumentOutOfRangeException.ThrowIfNegative(arrayIndex);

        for (int i = 0; i < _size; i++)
        {
            var destIndex = i + arrayIndex;

            if (destIndex >= array.Length)
                throw new ArgumentException("Destination array too small.");

            array[destIndex] = Items[i];
        }
    }

    public bool Remove(T item)
    {
        for (int i = 0; i < _size; i++)
        {
            if (Items[i].CompareTo(item) == 0)
            {
                // If only we could check for nulls on retrieving items and not have remove be O(n2) 
                for (int j = i; j < _size - 1; j++)
                    Items[j] = Items[j + 1];

                Items[_size - 1] = default!;
                _size--;
                return true;
            }
        }

        return false;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < Items.Length; i++)
        {
            yield return Items[i];
        }
    }
}
