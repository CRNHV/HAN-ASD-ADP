using System;
using System.Collections.Generic;
using System.Text;

namespace ADP.Lib.Sorting;

public interface ISortingAlgorithm
{
    public void Sort<T>(IList<T> list) where T : IComparable<T>;
}
