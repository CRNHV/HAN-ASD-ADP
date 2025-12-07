using ADP.Lib.AdpMinHeap;
using ADP.Lib.AdpPriorityQueue;
using System;
using System.Collections.Generic;
using System.Text;

namespace ADP.Lib.Tests;

public class PriorityQueueTests
{
    [Theory]
    [InlineData(new int[] { 20, 15, 7, 10, 3, 5 })]
    [InlineData(new int[] { 115, 100, 51, 41, 16, 31, 13 })]
    public void ShouldAlwaysGetMinPriorityValue(int[] input)
    {
        PriorityQueue<int> list = new PriorityQueue<int>();

        foreach (var item in input.Select((value, index) => new { value, index }))
        {
            list.Push(item.value, item.index);
        }

        foreach (var item in input)
        {
            var minVal = list.Pop();

            Assert.Equal(item, minVal);
        }
    }
}
