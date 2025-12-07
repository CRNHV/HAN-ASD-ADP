using ADP.Lib.AdpArrayList;

namespace ADP.Console;

internal class Program
{
    static void Main(string[] args)
    {
        ArrayList<int> minHeap = new ArrayList<int>();

        minHeap.Add(3);
        minHeap.Add(5);
        minHeap.Add(7);
        minHeap.Add(10);
        minHeap.Add(15);
        minHeap.Add(20);

        System.Console.WriteLine();
    }
}
