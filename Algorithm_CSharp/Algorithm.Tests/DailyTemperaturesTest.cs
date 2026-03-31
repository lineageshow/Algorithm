using Algorithm;
using FluentAssertions;
using NUnit.Framework;

namespace Algorithm.Tests;

[TestFixture]
[TestOf(typeof(DailyTemperatures))]
public class DailyTemperaturesTest
{
    [TestCase(new[] { 73, 74, 75, 71, 69, 72, 76, 73 }, new[] { 1, 1, 4, 2, 1, 1, 0, 0 })]
    [TestCase(new[] { 30, 40, 50, 60 }, new[] { 1, 1, 1, 0 })]
    [TestCase(new[] { 30, 60, 90 }, new[] { 1, 1, 0 })]
    [TestCase(new[] { 50 }, new[] { 0 })]
    [TestCase(new[] { 30, 30, 30 }, new[] { 0, 0, 0 })]
    public void GetDailyTemperaturesWithStack_ReturnsDaysUntilWarmer(int[] temperatures, int[] expected)
    {
        var sut = new DailyTemperatures();

        var result = sut.GetDailyTemperaturesWithStack(temperatures);

        result.Should().Equal(expected);
    }
}
