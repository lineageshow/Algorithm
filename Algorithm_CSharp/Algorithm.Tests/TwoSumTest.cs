using FluentAssertions;
using NUnit.Framework;

namespace Algorithm.Tests;

[TestFixture]
[TestOf(typeof(TwoSum))]
public class TwoSumTest
{
    [TestCase(new int[] { 2, 7, 11, 15 }, 9, new [] {0,1})]
    [TestCase(new int[] { 3,2,4 }, 6, new [] {1, 2})]
    [TestCase(new int[] { 3,3 }, 6, new [] {0, 1})]
    public void TwoSum_WithBruteForce(int[] nums, int target, int[] expected)
    {
        var sut = new TwoSum();

        var result = sut.TwoSumWithBruteForce(nums, target);
        result.Should().BeEquivalentTo(expected);
    }

    [TestCase(new int[] { 2, 7, 11, 15 }, 9, new [] {0,1})]
    [TestCase(new int[] { 3,2,4 }, 6, new [] {1, 2})]
    [TestCase(new int[] { 3,3 }, 6, new [] {0, 1})]
    public void TwoSum_WithTwoPointers(int[] nums, int target, int[] expected)
    {
        var sut = new TwoSum();

        var result = sut.TwoSumWithTwoPointers(nums, target);
        result.Should().BeEquivalentTo(expected);
    }
}