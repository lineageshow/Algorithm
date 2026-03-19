using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Algorithm.Tests;

[TestFixture]
[TestOf(typeof(Recursion))]
public class RecursionTest
{
    private static Recursion.ListNode ToList(params int[] values)
    {
        var dummy = new Recursion.ListNode(-1);
        var n = dummy;
        foreach (var v in values)
        {
            n.next = new Recursion.ListNode(v);
            n = n.next;
        }
        return dummy.next!;
    }

    private static int[] ToArray(Recursion.ListNode? head)
    {
        var list = new List<int>();
        while (head != null)
        {
            list.Add(head.val);
            head = head.next;
        }
        return list.ToArray();
    }

    [TestCase(new[] { 2, 4, 3 }, new[] { 5, 6, 4 }, new[] { 7, 0, 8 })]
    [TestCase(new[] { 0 }, new[] { 0 }, new[] { 0 })]
    [TestCase(new[] { 9, 9, 9, 9, 9, 9, 9 }, new[] { 9, 9, 9, 9 }, new[] { 8, 9, 9, 9, 0, 0, 0, 1 })]
    public void AddTwoNumbers(int[] a, int[] b, int[] expected)
    {
        var l1 = ToList(a);
        var l2 = ToList(b);
        var recursion = new Recursion();

        ToArray(recursion.AddTwoNumbers(l1, l2)).Should().BeEquivalentTo(expected);
        ToArray(recursion.AddTwoNumbersRecursive(l1, l2)).Should().BeEquivalentTo(expected);
    }
}
