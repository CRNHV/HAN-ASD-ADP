namespace ADP.Lib.AdpLinkedList;

public class Node<T> where T : IComparable<T>
{
    public Node<T>? Next { get; set; }
    public required T Data { get; set; }

    public void AddToNextNode(Node<T> newNode)
    {
        if (this.Next == null)
        {
            this.Next = newNode;
        }
        else
        {
            this.Next.AddToNextNode(newNode);
        }
    }
}
