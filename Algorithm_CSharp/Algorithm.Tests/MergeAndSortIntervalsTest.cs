using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Algorithm.Tests;

[TestFixture]
[TestOf(typeof(MergeAndSortIntervals))]
public class MergeAndSortIntervalsTest
{
    private static List<List<int>> ToIntervals(params (int start, int end)[] pairs)
    {
        var result = new List<List<int>>();
        foreach (var (start, end) in pairs)
            result.Add(new List<int> { start, end });
        return result;
    }

    [Test]
    public void Merge_EmptyInput_ReturnsEmpty()
    {
        var input = new List<List<int>>();
        MergeAndSortIntervals.MergeHighDefinitionIntervals(input).Should().BeEmpty();
        MergeAndSortIntervals.MergeHighDefinitionIntervalsWithManualSort(input).Should().BeEmpty();
    }

    [Test]
    public void Merge_NullInput_ReturnsEmpty()
    {
        MergeAndSortIntervals.MergeHighDefinitionIntervals(null!).Should().BeEmpty();
        MergeAndSortIntervals.MergeHighDefinitionIntervalsWithManualSort(null!).Should().BeEmpty();
    }

    [Test]
    public void Merge_SingleInterval_ReturnsSame()
    {
        var input = ToIntervals((5, 10));
        var expected = ToIntervals((5, 10));
        MergeAndSortIntervals.MergeHighDefinitionIntervals(input).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
        MergeAndSortIntervals.MergeHighDefinitionIntervalsWithManualSort(input).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
    }

    [Test]
    public void Merge_OverlappingIntervals_MergesCorrectly()
    {
        var input = ToIntervals((1, 3), (2, 6), (8, 10), (15, 18));
        var expected = ToIntervals((1, 6), (8, 10), (15, 18));
        MergeAndSortIntervals.MergeHighDefinitionIntervals(input).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
        MergeAndSortIntervals.MergeHighDefinitionIntervalsWithManualSort(input).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
    }

    [Test]
    public void Merge_UnsortedInput_SortsAndMerges()
    {
        var input = ToIntervals((8, 10), (1, 3), (2, 6), (15, 18));
        var expected = ToIntervals((1, 6), (8, 10), (15, 18));
        MergeAndSortIntervals.MergeHighDefinitionIntervals(input).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
        MergeAndSortIntervals.MergeHighDefinitionIntervalsWithManualSort(input).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
    }

    [Test]
    public void Merge_AllOverlapping_ReturnsSingleInterval()
    {
        var input = ToIntervals((1, 4), (2, 5), (3, 6), (5, 8));
        var expected = ToIntervals((1, 8));
        MergeAndSortIntervals.MergeHighDefinitionIntervals(input).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
        MergeAndSortIntervals.MergeHighDefinitionIntervalsWithManualSort(input).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
    }

    [Test]
    public void Merge_NoOverlap_ReturnsAllIntervals()
    {
        var input = ToIntervals((1, 2), (3, 4), (5, 6));
        var expected = ToIntervals((1, 2), (3, 4), (5, 6));
        MergeAndSortIntervals.MergeHighDefinitionIntervals(input).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
        MergeAndSortIntervals.MergeHighDefinitionIntervalsWithManualSort(input).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
    }

    [Test]
    public void Merge_ContainedInterval_MergesCorrectly()
    {
        var input = ToIntervals((1, 10), (2, 5));
        var expected = ToIntervals((1, 10));
        MergeAndSortIntervals.MergeHighDefinitionIntervals(input).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
        MergeAndSortIntervals.MergeHighDefinitionIntervalsWithManualSort(input).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
    }

    [Test]
    public void Merge_AdjacentIntervals_MergesCorrectly()
    {
        var input = ToIntervals((1, 3), (3, 5));
        var expected = ToIntervals((1, 5));
        MergeAndSortIntervals.MergeHighDefinitionIntervals(input).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
        MergeAndSortIntervals.MergeHighDefinitionIntervalsWithManualSort(input).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
    }
}
