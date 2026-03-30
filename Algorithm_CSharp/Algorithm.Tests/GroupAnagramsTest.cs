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
}