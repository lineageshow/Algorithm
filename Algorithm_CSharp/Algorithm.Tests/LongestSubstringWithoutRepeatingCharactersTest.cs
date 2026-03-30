using Algorithm;
using FluentAssertions;
using NUnit.Framework;

namespace Algorithm.Tests;

[TestFixture]
[TestOf(typeof(LongestSubstringWithoutRepeatingCharacters))]
public class LongestSubstringWithoutRepeatingCharactersTest
{

    [TestCase("abcabcbb", 3)]
    [TestCase("bbbbb", 1)]
    [TestCase("pwwkew", 3)]
    public void LengthOfLongestSubstring_BruteForce_Test(string s, int expectedLength)
    {
        var sut =  new LongestSubstringWithoutRepeatingCharacters();
        var result = sut.LengthOfLongestSubstringBruteForce(s);
        result.Should().Be(expectedLength);
    }

    [TestCase("abcabcbb", 3)]
    [TestCase("bbbbb", 1)]
    [TestCase("pwwkew", 3)]
    public void LengthOfLongestSubstring_SlidingWindow_Test(string s, int expectedLength)
    {
        var sut = new LongestSubstringWithoutRepeatingCharacters();
        var result = sut.LengthOfLongestSubstringSlidingWindow(s);
        result.Should().Be(expectedLength);
    }

    [TestCase("abcabcbb", 3)]
    [TestCase("bbbbb", 1)]
    [TestCase("pwwkew", 3)]
    public void LengthOfLongestSubstring_SlidingWindowLastIndex_Test(string s, int expectedLength)
    {
        var sut = new LongestSubstringWithoutRepeatingCharacters();
        var result = sut.LengthOfLongestSubstringSlidingWindowLastIndex(s);
        result.Should().Be(expectedLength);
    }
}