namespace ADP.Lib.Sorting;

public class InsertionSort : ISortingAlgorithm
{
    public void Sort<T>(IList<T> array) where T : IComparable<T>
    {
        int n = array.Count;
        for (int i = 1; i < n; i++)
        {
            T key = array[i];
            int j = i - 1;
            while (j >= 0 && array[j].CompareTo(key) > 0)
            {
                array[j + 1] = array[j];
                j--;
            }
            array[j + 1] = key;
        }
    }
}
