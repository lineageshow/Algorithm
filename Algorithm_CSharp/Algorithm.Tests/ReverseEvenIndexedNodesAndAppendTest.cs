using System.Collections.Generic;
using Algorithm;
using FluentAssertions;
using NUnit.Framework;

namespace Algorithm.Tests;

[TestFixture]
[TestOf(typeof(ReverseEvenIndexedNodesAndAppend))]
public class ReverseEvenIndexedNodesAndAppendTest
{
    private static SinglyLinkedListNode? ToList(params int[] values)
    {
        if (values.Length == 0) return null;

        var dummy = new SinglyLinkedListNode(-1);
        var n = dummy;
        foreach (var v in values)
        {
            n.next = new SinglyLinkedListNode(v);
            n = n.next;
        }

        return dummy.next;
    }

    private static int[] ToArray(SinglyLinkedListNode? head)
    {
        var list = new List<int>();
        while (head != null)
        {
            list.Add(head.data);
            head = head.next;
        }

        return list.ToArray();
    }

    [Test]
    public void Example_SixNodes_ReturnsOddThenReversedEven()
    {
        var head = ToList(10, 20, 30, 40, 50, 60);

        var result = ReverseEvenIndexedNodesAndAppend.ExtractAndAppendSponsoredNodes(head!);

        ToArray(result).Should().Equal(20, 40, 60, 50, 30, 10);
    }

    [Test]
    public void Sample0_SingleNode_ReturnsSameNode()
    {
        var head = ToList(42);

        var result = ReverseEvenIndexedNodesAndAppend.ExtractAndAppendSponsoredNodes(head!);

        ToArray(result).Should().Equal(42);
    }

    [Test]
    public void Sample1_TwoNodes_OddFirstThenEven()
    {
        var head = ToList(1, 2);

        var result = ReverseEvenIndexedNodesAndAppend.ExtractAndAppendSponsoredNodes(head!);

        ToArray(result).Should().Equal(2, 1);
    }

    [Test]
    public void ThreeNodes_OddThenReversedEven()
    {
        var head = ToList(1, 2, 3);

        var result = ReverseEvenIndexedNodesAndAppend.ExtractAndAppendSponsoredNodes(head!);

        // odd indices: [2], even indices reversed: [3, 1]
        ToArray(result).Should().Equal(2, 3, 1);
    }

    [Test]
    public void FourNodes_OddThenReversedEven()
    {
        var head = ToList(1, 2, 3, 4);

        var result = ReverseEvenIndexedNodesAndAppend.ExtractAndAppendSponsoredNodes(head!);

        // odd indices: [2, 4], even indices reversed: [3, 1]
        ToArray(result).Should().Equal(2, 4, 3, 1);
    }

    [Test]
    public void FiveNodes_OddThenReversedEven()
    {
        var head = ToList(10, 20, 30, 40, 50);

        var result = ReverseEvenIndexedNodesAndAppend.ExtractAndAppendSponsoredNodes(head!);

        // odd indices: [20, 40], even indices reversed: [50, 30, 10]
        ToArray(result).Should().Equal(20, 40, 50, 30, 10);
    }

    [Test]
    public void AllSameValues_StillSplitsAndReversesByIndex()
    {
        var head = ToList(5, 5, 5, 5);

        var result = ReverseEvenIndexedNodesAndAppend.ExtractAndAppendSponsoredNodes(head!);

        ToArray(result).Should().Equal(5, 5, 5, 5);
    }

    [Test]
    public void NegativeValues_HandledCorrectly()
    {
        var head = ToList(-1, -2, -3);

        var result = ReverseEvenIndexedNodesAndAppend.ExtractAndAppendSponsoredNodes(head!);

        // odd indices: [-2], even indices reversed: [-3, -1]
        ToArray(result).Should().Equal(-2, -3, -1);
    }

    [Test]
    public void SevenNodes_OddThenReversedEven()
    {
        var head = ToList(1, 2, 3, 4, 5, 6, 7);

        var result = ReverseEvenIndexedNodesAndAppend.ExtractAndAppendSponsoredNodes(head!);

        // odd indices: [2, 4, 6], even indices reversed: [7, 5, 3, 1]
        ToArray(result).Should().Equal(2, 4, 6, 7, 5, 3, 1);
    }
}
