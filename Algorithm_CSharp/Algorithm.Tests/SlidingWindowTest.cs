using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Algorithm.Tests;

[TestFixture]
[TestOf(typeof(SlidingWindow))]
public class SlidingWindowTest
{

    [TestCase(new int[] { 1, 3, -1, -3, 5, 3, 6, 7 }, 3, new int[] { 3, 3, 5, 5, 6, 7 })]
    [TestCase(new int[] { 1 }, 1, new int[] { 1 })]
    [TestCase(new int[] { 1, -1 }, 1, new int[] { 1, -1 })]
    public void MaxSlidingWindow(int[] nums, int k, int[] expected)
    {
        SlidingWindow.MaxSlidingWindow(nums, k).Should().BeEquivalentTo(expected);
        SlidingWindow.MaxSlidingWindowDeque(nums, k).Should().BeEquivalentTo(expected);
    }
}