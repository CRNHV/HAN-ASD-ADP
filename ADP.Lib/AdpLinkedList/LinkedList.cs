using System.Collections;

namespace ADP.Lib.AdpLinkedList;

public class LinkedList<T> : ICollection<T> where T : IComparable<T>
{
    private Node<T>? Head { get; set; }

    public int Count
    {
        get
        {
            int c = 0;
            Node<T>? current = Head;

            while (current != null)
            {
                c++;
                current = current.Next;
            }

            return c;
        }
    }

    public bool IsReadOnly => false;

    public void Add(T item)
    {
        var newNode = new Node<T>() { Data = item };

        if (this.Head == null)
        {
            this.Head = newNode;
        }
        else
        {
            Head.AddToNextNode(newNode);
        }
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public bool Contains(T item)
    {
        var nextNode = Head;
        while (nextNode != null)
        {
            if (nextNode.Data.CompareTo(item) == 0)
            {
                return true;
            }
            nextNode = nextNode.Next;
        }

        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        ArgumentNullException.ThrowIfNull(array);
        ArgumentOutOfRangeException.ThrowIfNegative(arrayIndex);

        Node<T>? current = Head;
        int i = arrayIndex;

        while (current != null)
        {
            if (i >= array.Length)
                throw new ArgumentException("Destination array too small.");

            array[i] = current.Data;
            current = current.Next;
            i++;
        }
    }

    public bool Remove(T item)
    {
        Node<T>? previousNode = null;
        var currentNode = this.Head;
        if (currentNode == null)
            return true;

        while (currentNode != null)
        {
            if (currentNode.Data.CompareTo(item) == 0)
            {
                if (previousNode == null)
                {
                    this.Head = currentNode.Next;
                }
                else
                {
                    previousNode.Next = currentNode.Next;
                }

                return true;
            }

            previousNode = currentNode;
            currentNode = currentNode.Next;
        }

        return false;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<T> GetEnumerator()
    {
        Node<T>? current = Head;

        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }
}