using Algorithm;
using FluentAssertions;
using NUnit.Framework;

namespace Algorithm.Tests;

[TestFixture]
[TestOf(typeof(ValidParentheses))]
public class ValidParenthesesTest
{

    [TestCase("()", true)]
    [TestCase("()[]{}", true)]
    [TestCase("(]", false)]
    [TestCase("([])", true)]
    [TestCase("([)]", false)]
    [TestCase("]", false)]
    public void IsValidWithBruteForce_Test(string s, bool expected)
    {
        var sut =  new ValidParentheses();
        var result = sut.IsValidWithStack(s);
        result.Should().Be(expected);
    }

    [TestCase("()", true)]
    [TestCase("()[]{}", true)]
    [TestCase("(]", false)]
    [TestCase("([])", true)]
    [TestCase("([)]", false)]
    [TestCase("]", false)]
    public void IsValidWithExpectedClosingStack_Test(string s, bool expected)
    {
        var sut = new ValidParentheses();
        sut.IsValidWithExpectedClosingStack(s).Should().Be(expected);
    }
}