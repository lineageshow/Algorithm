using Algorithm;
using FluentAssertions;
using NUnit.Framework;

namespace Algorithm.Tests;

[TestFixture]
[TestOf(typeof(ValidAnagram))]
public class ValidAnagramTest
{
    [TestCase("anagram", "nagaram", true)]
    [TestCase("rat", "car", false)]
    [TestCase("a", "a", true)]
    [TestCase("a", "b", false)]
    [TestCase("ab", "a", false)]
    [TestCase("", "", true)]
    public void IsAnagramWithBruteForce_Test(string s, string t, bool expected)
    {
        var sut = new ValidAnagram();

        var result = sut.IsAnagramWithBruteForce(s, t);
        result.Should().Be(expected);
    }

    [TestCase("anagram", "nagaram", true)]
    [TestCase("rat", "car", false)]
    [TestCase("a", "a", true)]
    [TestCase("a", "b", false)]
    [TestCase("ab", "a", false)]
    [TestCase("", "", true)]
    public void IsAnagramWithFrequencyCount_Test(string s, string t, bool expected)
    {
        var sut = new ValidAnagram();

        var result = sut.IsAnagramWithFrequencyCount(s, t);
        result.Should().Be(expected);
    }

    [TestCase("anagram", "nagaram", true)]
    [TestCase("rat", "car", false)]
    [TestCase("a", "a", true)]
    [TestCase("a", "b", false)]
    [TestCase("ab", "a", false)]
    [TestCase("", "", true)]
    public void IsAnagramWithDictionary_Test(string s, string t, bool expected)
    {
        var sut = new ValidAnagram();

        var result = sut.IsAnagramWithDictionary(s, t);
        result.Should().Be(expected);
    }
}
