using System;
using System.Collections.Generic;
using System.Text;

namespace ADP.Lib.Sorting;

public class QuickSort : ISortingAlgorithm
{
    public void Sort<T>(IList<T> arr) where T : IComparable<T>
    {
        int left = 0;
        int right = arr.Count - 1;

        if (left < right)
        {
            int pivot = Partition(arr, left, right);

            if (pivot > 1)
            {
                Quick_Sort(arr, left, pivot - 1);
            }
            if (pivot + 1 < right)
            {
                Quick_Sort(arr, pivot + 1, right);
            }
        }
    }

    private static void Quick_Sort<T>(IList<T> arr, int left, int right) where T : IComparable<T>
    {
        if (left < right)
        {
            int pivot = Partition(arr, left, right);

            if (pivot > 1)
            {
                Quick_Sort(arr, left, pivot - 1);
            }
            if (pivot + 1 < right)
            {
                Quick_Sort(arr, pivot + 1, right);
            }
        }
    }

    private static int Partition<T>(IList<T> arr, int left, int right) where T : IComparable<T>
    {
        var pivot = arr[left];

        while (true)
        {
            while (arr[left].CompareTo(pivot) < 0)
            {
                left++;
            }

            while (arr[left].CompareTo(pivot) > 0)
            {
                right--;
            }

            if (left < right)
            {
                if (arr[left].CompareTo(arr[right]) == 0)
                    return right;

                var temp = arr[left];
                arr[left] = arr[right];
                arr[right] = temp;
            }
            else
            {
                return right;
            }
        }
    }
}
