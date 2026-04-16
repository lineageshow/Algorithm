using Algorithm.Graph;
using FluentAssertions;
using NUnit.Framework;

namespace Algorithm.Tests.Graph;

[TestFixture]
[TestOf(typeof(BinaryTreePreorderTraversal))]
public class BinaryTreePreorderTraversalTest
{
    [Test]
    public void PreorderTraversalWithRecursive_Test_Sample1()
    {
        var sut = new BinaryTreePreorderTraversal();
        var result = sut.PreorderTraversalWithRecursive(ExampleNodes.ExampleNode1());
        result.Should().BeEquivalentTo(new int[] { 1, 2, 3 }, options => options.WithStrictOrdering());
    }

    [Test]
    public void PreorderTraversalWithStack_Test_Sample1()
    {
        var sut = new BinaryTreePreorderTraversal();
        var result = sut.PreorderTraversalWithStack(ExampleNodes.ExampleNode1());
        result.Should().BeEquivalentTo(new int[] { 1, 2, 3 }, options => options.WithStrictOrdering());

    }

    [Test]
    public void PreorderTraversalWithRecursive_Test_Sample2()
    {
        var sut = new BinaryTreePreorderTraversal();
        var result = sut.PreorderTraversalWithRecursive(ExampleNodes.ExampleNode2());
        result.Should().BeEquivalentTo(new int[] { }, options => options.WithStrictOrdering());
    }
    [Test]
    public void PreorderTraversalWithStack_Test_Sample2()
    {
        var sut = new BinaryTreePreorderTraversal();
        var result = sut.PreorderTraversalWithStack(ExampleNodes.ExampleNode2());
        result.Should().BeEquivalentTo(new int[] { }, options => options.WithStrictOrdering());
    }

    [Test]
    public void PreorderTraversalWithRecursive_Test_Sample3()
    {
        var sut = new BinaryTreePreorderTraversal();
        var result = sut.PreorderTraversalWithRecursive(ExampleNodes.ExampleNode3());
        result.Should().BeEquivalentTo(new int[] { 1 }, options => options.WithStrictOrdering());
    }
    [Test]
    public void PreorderTraversalWithStack_Test_Sample3()
    {
        var sut = new BinaryTreePreorderTraversal();
        var result = sut.PreorderTraversalWithStack(ExampleNodes.ExampleNode3());
        result.Should().BeEquivalentTo(new int[] { 1 }, options => options.WithStrictOrdering());
    }

    [Test]
    public void PreorderTraversalWithRecursive_Test_Sample4()
    {
        var sut = new BinaryTreePreorderTraversal();
        var result = sut.PreorderTraversalWithRecursive(ExampleNodes.ExampleNode4());
        result.Should()
            .BeEquivalentTo(new int[] { 1, 2, 4, 5, 6, 7, 3, 8, 9 }, options => options.WithStrictOrdering());
    }
    [Test]
    public void PreorderTraversalWithStack_Test_Sample4()
    {
        var sut = new BinaryTreePreorderTraversal();
        var result = sut.PreorderTraversalWithStack(ExampleNodes.ExampleNode4());
        result.Should()
            .BeEquivalentTo(new int[] { 1, 2, 4, 5, 6, 7, 3, 8, 9 }, options => options.WithStrictOrdering());
    }
}