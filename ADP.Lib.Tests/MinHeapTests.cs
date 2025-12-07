using ADP.Lib.AdpMinHeap;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADP.Lib.Tests;

public class MinHeapTests
{
    [Theory]
    [InlineData(new int[] { 20, 15, 7, 10, 3, 5 })]
    [InlineData(new int[] { 115, 100, 51, 41, 16, 31, 13 })]
    public void ShouldAlwaysGetMinValue(int[] input)
    {
        MinHeap<int> list = new MinHeap<int>();

        foreach (var item in input)
        {
            list.Add(item);
        }

        var sorted = input.Order();

        foreach (var item in sorted)
        {
            var minVal = list.RemoveMin();

            Assert.Equal(item, minVal);
        }
    }

    [Theory]
    [InlineData(new int[] { 20, 15, 7, 10, 3, 5 }, 15)]
    [InlineData(new int[] { 115, 100, 51, 41, 16, 31, 13 }, 51)]
    public void RemoveShouldReorderTree(int[] input, int toRemove)
    {
        MinHeap<int> list = new MinHeap<int>();

        foreach (var item in input)
        {
            list.Add(item);
        }

        list.Remove(toRemove);

        var sorted = input.Order();

        foreach (var item in sorted)
        {
            if (item == toRemove)
            {
                continue;
            }

            var minVal = list.RemoveMin();

            Assert.Equal(item, minVal);
        }
    }
}
