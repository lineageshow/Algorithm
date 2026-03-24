using Algorithm.Sort;
using FluentAssertions;
using NUnit.Framework;

namespace Algorithm.Tests;

[TestFixture]
[TestOf(typeof(QuickSort))]
public class QuickSortTest
{
    [Test]
    public void SortArrayMine_ThreeElements_SortsAscending()
    {
        var nums = new[] { 110, 100, 0 };
        var sut = new QuickSort();

        var result = sut.SortArrayMine(nums);

        result.Should().BeSameAs(nums);
        result.Should().Equal(0, 100, 110);
    }
}
