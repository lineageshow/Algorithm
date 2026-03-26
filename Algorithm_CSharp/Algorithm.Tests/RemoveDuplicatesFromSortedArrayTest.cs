using System.Linq;
using Algorithm;
using FluentAssertions;
using NUnit.Framework;

namespace Algorithm.Tests;

[TestFixture]
[TestOf(typeof(RemoveDuplicatesFromSortedArray))]
public class RemoveDuplicatesFromSortedArrayTest
{
    [TestCase(new[] { 1, 1, 2 }, 2, new[] { 1, 2 })]
    [TestCase(new[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 }, 5, new[] { 0, 1, 2, 3, 4 })]
    [TestCase(new[] { 1 }, 1, new[] { 1 })]
    [TestCase(new[] { 1, 2, 3 }, 3, new[] { 1, 2, 3 })]
    [TestCase(new[] { -1, -1, 0, 0, 1, 1 }, 3, new[] { -1, 0, 1 })]
    [TestCase(new[] { 1, 1, 1, 1, 1 }, 1, new[] { 1 })]
    public void RemoveDuplicatesWithTwoPointers_Test(int[] nums, int expectedK, int[] expectedNums)
    {
        var sut = new RemoveDuplicatesFromSortedArray();

        var k = sut.RemoveDuplicatesWithTwoPointers(nums);

        k.Should().Be(expectedK);
        nums.Take(k).Should().Equal(expectedNums);
    }
}
