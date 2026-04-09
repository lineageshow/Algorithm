using System.Collections.Generic;
using Algorithm;
using FluentAssertions;
using NUnit.Framework;

namespace Algorithm.Tests;

[TestFixture]
[TestOf(typeof(ReverseLinkedList))]
public class ReverseLinkedListTest
{
    private static ReverseLinkedList.ListNode? ToList(params int[] values)
    {
        var dummy = new ReverseLinkedList.ListNode(-1);
        var n = dummy;
        foreach (var v in values)
        {
            n.next = new ReverseLinkedList.ListNode(v);
            n = n.next;
        }

        return dummy.next;
    }

    private static int[] ToArray(ReverseLinkedList.ListNode? head)
    {
        var list = new List<int>();
        while (head != null)
        {
            list.Add(head.val);
            head = head.next;
        }

        return list.ToArray();
    }

    [TestCase(new int[0], new int[0])]
    [TestCase(new[] { 1 }, new[] { 1 })]
    [TestCase(new[] { 1, 2 }, new[] { 2, 1 })]
    [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 5, 4, 3, 2, 1 })]
    public void ReverseList_Iterative_ReturnsReversedValues(int[] input, int[] expected)
    {
        var sut = new ReverseLinkedList();

        var result = sut.ReverseList(ToList(input));

        ToArray(result).Should().Equal(expected);
    }

    [TestCase(new int[0], new int[0])]
    [TestCase(new[] { 1 }, new[] { 1 })]
    [TestCase(new[] { 1, 2 }, new[] { 2, 1 })]
    [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 5, 4, 3, 2, 1 })]
    public void ReverseListRecursive_ReturnsReversedValues(int[] input, int[] expected)
    {
        var sut = new ReverseLinkedList();

        var result = sut.ReverseListRecursive(ToList(input));

        ToArray(result).Should().Equal(expected);
    }

    [Test]
    public void ReverseList_IterativeAndRecursive_ProduceSameSequence()
    {
        var sut = new ReverseLinkedList();
        var input = new[] { 3, 1, 4, 1, 5 };

        var iterative = ToArray(sut.ReverseList(ToList(input)));
        var recursive = ToArray(sut.ReverseListRecursive(ToList(input)));

        iterative.Should().Equal(recursive).And.Equal(new[] { 5, 1, 4, 1, 3 });
    }
}
