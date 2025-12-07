using System;
using System.Collections.Generic;
using System.Text;

namespace ADP.Lib.Sorting;

public class MergeSort : ISortingAlgorithm
{
    public void Sort<T>(IList<T> arr) where T : IComparable<T>
    {
        int left = 0;
        int right = arr.Count - 1;

        if (left < right)
        {
            int middle = left + (right - left) / 2;

            Sort(arr, left, middle);
            Sort(arr, middle + 1, right);
            Merge(arr, left, middle, right);
        }
    }

    private static void Sort<T>(IList<T> arr, int left, int right) where T : IComparable<T>
    {
        if (left < right)
        {
            int middle = left + (right - left) / 2;
            Sort(arr, left, middle);
            Sort(arr, middle + 1, right);
            Merge(arr, left, middle, right);
        }
    }

    private static void Merge<T>(IList<T> array, int left, int middle, int right) where T : IComparable<T>
    {
        // Divide
        int leftSplitLength = middle - left + 1;
        int rightSplitLength = right - middle;

        T[] leftSplit = new T[leftSplitLength];
        T[] rightSplit = new T[rightSplitLength];

        for (int i = 0; i < leftSplitLength; i++)
            leftSplit[i] = array[left + i];

        for (int i = 0; i < rightSplitLength; i++)
            rightSplit[i] = array[middle + 1 + i];

        int index1 = 0, index2 = 0;
        int k = left;

        while (index1 < leftSplitLength && index2 < rightSplitLength)
        {
            array[k++] = leftSplit[index1].CompareTo(rightSplit[index2]) <= 0
                ? leftSplit[index1++]
                : rightSplit[index2++];
        }

        while (index1 < leftSplitLength)
            array[k++] = leftSplit[index1++];

        while (index2 < rightSplitLength)
            array[k++] = rightSplit[index2++];
    }
}
