using System.Collections.Generic;
using Algorithm;
using FluentAssertions;
using NUnit.Framework;

namespace Algorithm.Tests;

[TestFixture]
[TestOf(typeof(NextGreaterElementWithPositionOffset))]
public class NextGreaterElementWithPositionOffsetTest
{
    [Test]
    public void FindNextGreaterElementsWithDistance_ExampleFromProblem_ReturnsValueAndIndexDistance()
    {
        var sut = new NextGreaterElementWithPositionOffset();
        var readings = new List<int> { 2, 1, 2, 4, 3 };

        var result = sut.FindNextGreaterElementsWithDistance(readings);

        result.Should().BeEquivalentTo(
            new List<List<int>>
            {
                new() { 4, 3 },
                new() { 2, 1 },
                new() { 4, 1 },
                new() { -1, -1 },
                new() { -1, -1 },
            },
            o => o.WithStrictOrdering());
    }

    [Test]
    public void FindNextGreaterElementsWithDistance_SingleElement_HasNoGreaterToTheRight()
    {
        var sut = new NextGreaterElementWithPositionOffset();

        var result = sut.FindNextGreaterElementsWithDistance(new List<int> { 5 });

        result.Should().BeEquivalentTo(new List<List<int>> { new() { -1, -1 } }, o => o.WithStrictOrdering());
    }

    [Test]
    public void FindNextGreaterElementsWithDistance_EmptyInput_ReturnsEmpty()
    {
        var sut = new NextGreaterElementWithPositionOffset();

        var result = sut.FindNextGreaterElementsWithDistance(new List<int>());

        result.Should().BeEmpty();
    }

    [Test]
    public void FindNextGreaterElementsWithDistance_StrictlyIncreasing_ChainsNextGreater()
    {
        var sut = new NextGreaterElementWithPositionOffset();

        var result = sut.FindNextGreaterElementsWithDistance(new List<int> { 1, 2, 3 });

        result.Should().BeEquivalentTo(
            new List<List<int>>
            {
                new() { 2, 1 },
                new() { 3, 1 },
                new() { -1, -1 },
            },
            o => o.WithStrictOrdering());
    }

    [Test]
    public void FindNextGreaterElementsWithDistance_StrictlyDecreasing_AllMissing()
    {
        var sut = new NextGreaterElementWithPositionOffset();

        var result = sut.FindNextGreaterElementsWithDistance(new List<int> { 3, 2, 1 });

        result.Should().BeEquivalentTo(
            new List<List<int>>
            {
                new() { -1, -1 },
                new() { -1, -1 },
                new() { -1, -1 },
            },
            o => o.WithStrictOrdering());
    }

    [Test]
    public void FindNextGreaterElementsWithDistance_EqualNeighbors_NoNextGreater()
    {
        var sut = new NextGreaterElementWithPositionOffset();

        var result = sut.FindNextGreaterElementsWithDistance(new List<int> { 2, 2, 2 });

        result.Should().BeEquivalentTo(
            new List<List<int>>
            {
                new() { -1, -1 },
                new() { -1, -1 },
                new() { -1, -1 },
            },
            o => o.WithStrictOrdering());
    }

    [Test]
    public void FindNextGreaterElementsWithDistance_NegativeValues_FindsNextGreaterByValue()
    {
        var sut = new NextGreaterElementWithPositionOffset();

        var result = sut.FindNextGreaterElementsWithDistance(new List<int> { -1, 0 });

        result.Should().BeEquivalentTo(
            new List<List<int>>
            {
                new() { 0, 1 },
                new() { -1, -1 },
            },
            o => o.WithStrictOrdering());
    }
}
