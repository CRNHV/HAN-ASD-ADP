using ADP.Lib.Sorting;

namespace ADP.Lib.Tests;

public class SortingTests
{
    private static ISortingAlgorithm insertionSort = new InsertionSort();
    private static ISortingAlgorithm mergeSort = new MergeSort();
    private static ISortingAlgorithm quickSort = new QuickSort();

    private static readonly Dictionary<string, ISortingAlgorithm> algorithms = new()
    {
        { "InsertionSort", insertionSort },
        { "MergeSort", mergeSort },
        { "QuickSort", mergeSort }
    };

    [Theory]
    [InlineData("InsertionSort", 50_000)]
    [InlineData("MergeSort", 10_000_000)]
    [InlineData("QuickSort", 10_000_000)]
    public void ShouldSortRandomArray(string sortingAlgorithm, int itemsToSort)
    {
        var rand = new Random();
        var input = Enumerable.Range(0, itemsToSort)
            .Select(_ => rand.Next(0, int.MaxValue))
            .ToArray();

        var sortingAlgo = algorithms[sortingAlgorithm];
        sortingAlgo.Sort(input);

        var correctlySorted = input.Order();
        Assert.Equal(correctlySorted, input);
    }
}
