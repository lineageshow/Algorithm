using Algorithm;
using FluentAssertions;
using NUnit.Framework;

namespace Algorithm.Tests;

[TestFixture]
[TestOf(typeof(MinimumWindowSubstring))]
public class MinimumWindowSubstringTest
{
    [TestCase("ADOBECODEBANC", "ABC", "BANC")]
    [TestCase("a", "a", "a")]
    [TestCase("a", "aa", "")]
    public void MinWindowWithSlidingWindow_LeetCodeExamples_ReturnsExpected(string s, string t, string expected)
    {
        var sut = new MinimumWindowSubstring();
        var result = sut.MinWindowWithSlidingWindow(s, t);
        result.Should().Be(expected);
    }

    [TestCase("abc", "cba", "abc")]
    [TestCase("bba", "ab", "ba")]
    [TestCase("aa", "aa", "aa")]
    public void MinWindowWithSlidingWindow_AdditionalCases_ReturnsExpected(string s, string t, string expected)
    {
        var sut = new MinimumWindowSubstring();
        var result = sut.MinWindowWithSlidingWindow(s, t);
        result.Should().Be(expected);
    }

    [Test]
    public void MinWindowWithSlidingWindow_TLongerThanS_ReturnsEmpty()
    {
        var sut = new MinimumWindowSubstring();
        sut.MinWindowWithSlidingWindow("ab", "abc").Should().Be("");
    }
}
