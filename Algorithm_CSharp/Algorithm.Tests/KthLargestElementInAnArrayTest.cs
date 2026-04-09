using Algorithm;
using FluentAssertions;
using NUnit.Framework;

namespace Algorithm.Tests;

[TestFixture]
[TestOf(typeof(KthLargestElementInAnArray))]
public class KthLargestElementInAnArrayTest
{

    [TestCase(new int[] { 3,2,1,5,6,4}, 2,   5)]
    [TestCase(new int[] { 3,2,3,1,2,4,5,5,6}, 4,   4)]
    public void KthLargestElementInAnArrayTest_WithPrioriQueue(int[] nums, int k,  int expected)
    {
        var sut = new KthLargestElementInAnArray();
        var result = sut.FindKthLargestWithPriorityQueue(nums, k);
        result.Should().Be(expected);
    }
}