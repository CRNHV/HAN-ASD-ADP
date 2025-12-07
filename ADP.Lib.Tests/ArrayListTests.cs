using ADP.Lib.AdpArrayList;

namespace ADP.Lib.Tests;

public class ArrayListTests
{
    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, 5)]
    [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }, 20)]
    public void CountShouldMatch(int[] items, int count)
    {
        ArrayList<int> list = new ArrayList<int>();

        for (int i = 0; i < items.Length; i++)
        {
            list.Add(items[i]);
        }

        Assert.Equal(count, list.Count);
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4, 5 }, 5)]
    [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }, 20)]
    public void CountShouldMatchAfterRemove(int[] items, int count)
    {
        ArrayList<int> list = new ArrayList<int>();

        for (int i = 0; i < items.Length; i++)
        {
            list.Add(items[i]);
        }

        list.Remove(2);

        Assert.Equal(count - 1, list.Count);
    }

    [Theory]
    [InlineData(new int[] { 1, 2, 3, 4, 5 })]
    [InlineData(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 })]
    public void CountShouldMatchAfterRemoveAll(int[] items)
    {
        ArrayList<int> list = new ArrayList<int>();

        for (int i = 0; i < items.Length; i++)
        {
            list.Add(items[i]);
        }

        for (int i = 0; i < items.Length; i++)
        {
            list.Remove(items[i]);
        }

        Assert.Equal(0, list.Count);
    }
}
