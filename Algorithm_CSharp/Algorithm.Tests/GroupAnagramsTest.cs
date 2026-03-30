using FluentAssertions;
using NUnit.Framework;

namespace Algorithm.Tests;

[TestFixture]
[TestOf(typeof(GroupAnagrams))]
public class GroupAnagramsTest
{

    [Test]
    public void GroupAnagramsWithDictionary_Test()
    {
        var sut =  new GroupAnagrams();
        var result = sut.GroupAnagramsWithDictionary(new[] { "eat", "tea", "tan", "ate", "nat", "bat" });
        result.Should().BeEquivalentTo(new[] { new[] { "eat", "tea", "ate" }, new[] { "tan", "nat" }, new[] { "bat" } });
        
    }

    [Test]
    public void GroupAnagramsWithCharacterCount_Test()
    {
        var sut = new GroupAnagrams();
        var result = sut.GroupAnagramsWithCharacterCount(new[] { "eat", "tea", "tan", "ate", "nat", "bat" });
        result.Should().BeEquivalentTo(new[] { new[] { "eat", "tea", "ate" }, new[] { "tan", "nat" }, new[] { "bat" } });
    }

    [Test]
    public void GroupAnagramsWithCharacterCount_EmptyString_Test()
    {
        var sut = new GroupAnagrams();
        var result = sut.GroupAnagramsWithCharacterCount(new[] { "" });
        result.Should().BeEquivalentTo(new[] { new[] { "" } });
    }

    [Test]
    public void GroupAnagramsWithCharacterCount_SingleString_Test()
    {
        var sut = new GroupAnagrams();
        var result = sut.GroupAnagramsWithCharacterCount(new[] { "a" });
        result.Should().BeEquivalentTo(new[] { new[] { "a" } });
    }
}