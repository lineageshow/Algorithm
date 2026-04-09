using Algorithm;
using FluentAssertions;
using NUnit.Framework;

namespace Algorithm.Tests;

[TestFixture]
[TestOf(typeof(LinkedListCycle))]
public class LinkedListCycleTest
{
    private static LinkedListCycle.ListNode? BuildList(int[] values, int pos)
    {
        if (values.Length == 0) return null;

        var nodes = new LinkedListCycle.ListNode[values.Length];
        for (int i = 0; i < values.Length; i++)
            nodes[i] = new LinkedListCycle.ListNode(values[i]);

        for (int i = 0; i < values.Length - 1; i++)
            nodes[i].next = nodes[i + 1];

        if (pos >= 0)
            nodes[^1].next = nodes[pos];

        return nodes[0];
    }

    [Test]
    public void HasCycle_Example1_CycleAtPos1_ReturnsTrue()
    {
        var head = BuildList([3, 2, 0, -4], pos: 1);

        new LinkedListCycle().HasCycle(head).Should().BeTrue();
    }

    [Test]
    public void HasCycle_Example2_CycleAtPos0_ReturnsTrue()
    {
        var head = BuildList([1, 2], pos: 0);

        new LinkedListCycle().HasCycle(head).Should().BeTrue();
    }

    [Test]
    public void HasCycle_Example3_SingleNodeNoCycle_ReturnsFalse()
    {
        var head = BuildList([1], pos: -1);

        new LinkedListCycle().HasCycle(head).Should().BeFalse();
    }

    [Test]
    public void HasCycle_EmptyList_ReturnsFalse()
    {
        new LinkedListCycle().HasCycle(null).Should().BeFalse();
    }

    [Test]
    public void HasCycle_MultipleNodesNoCycle_ReturnsFalse()
    {
        var head = BuildList([1, 2, 3, 4, 5], pos: -1);

        new LinkedListCycle().HasCycle(head).Should().BeFalse();
    }

    [Test]
    public void HasCycle_SingleNodePointsToItself_ReturnsTrue()
    {
        var head = BuildList([1], pos: 0);

        new LinkedListCycle().HasCycle(head).Should().BeTrue();
    }

    [Test]
    public void HasCycle_CycleAtTail_ReturnsTrue()
    {
        var head = BuildList([1, 2, 3, 4, 5], pos: 4);

        new LinkedListCycle().HasCycle(head).Should().BeTrue();
    }

    [Test]
    public void HasCycle_CycleInMiddle_ReturnsTrue()
    {
        var head = BuildList([1, 2, 3, 4, 5], pos: 2);

        new LinkedListCycle().HasCycle(head).Should().BeTrue();
    }
}
