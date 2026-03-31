using System.Collections.Generic;
using Algorithm;
using FluentAssertions;
using NUnit.Framework;

namespace Algorithm.Tests;

[TestFixture]
[TestOf(typeof(CountNumberPairs))]
public class CountNumberPairsTest
{

    [Test]
    public void CountAffordablePairsWithSlidingWindow_Test()
    {
        var sut =  new CountNumberPairs();
        var result = sut.CountAffordablePairsWithSlidingWindow(new List<int>
            { 1, 2, 3, 4, 5 }, 7);
        result.Should().Be(8);
    }
}