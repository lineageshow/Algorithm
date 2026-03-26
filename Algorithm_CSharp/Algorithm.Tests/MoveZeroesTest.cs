using FluentAssertions;
using NUnit.Framework;

namespace Algorithm.Tests;

[TestFixture]
[TestOf(typeof(MoveZeroes))]
public class MoveZeroesTest
{
    [TestCase(new[] { 0, 1, 0, 3, 12 }, new[] { 1, 3, 12, 0, 0 })]
    [TestCase(new[] { 0 }, new[] { 0 })]
    [TestCase(new[] { 1, 2, 3 }, new[] { 1, 2, 3 })]
    [TestCase(new[] { 0, 0, 0 }, new[] { 0, 0, 0 })]
    [TestCase(new[] { 1 }, new[] { 1 })]
    [TestCase(new[] { 0, 0, 1 }, new[] { 1, 0, 0 })]
    [TestCase(new[] { 4, 0, 5, 0, 3 }, new[] { 4, 5, 3, 0, 0 })]
    public void MoveZeroesWithTwoPointers_Test(int[] nums, int[] expected)
    {
        var sut = new MoveZeroes();

        sut.MoveZeroesWithTwoPointers(nums);

        nums.Should().Equal(expected);
    }
}
