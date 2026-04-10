using System;
using Algorithm.Search;
using FluentAssertions;
using NUnit.Framework;

namespace Algorithm.Tests.Search;

[TestFixture]
[TestOf(typeof(BinarySearch))]
public class BinarySearchTest
{

    [TestCase(new []{-1,0,3,5,9,12}, 9, 4)]
    [TestCase(new []{-1,0,3,5,9,12}, 2, -1)]
    public void SearchTest(int[] nums, int target, int expected)
    {
        var sut = new BinarySearch();
        int actual = sut.Search(nums, target);
        actual.Should().Be(expected);
    }

    [Test]
    public void Test()
    {
        var i = 1;
        var result = (i + 0) / 2;
        Console.WriteLine(result);
        Assert.Pass();
    }
}