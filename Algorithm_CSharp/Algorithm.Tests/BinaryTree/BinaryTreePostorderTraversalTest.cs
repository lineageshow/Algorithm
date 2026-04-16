using Algorithm.Graph;
using Algorithm.Tests.Graph;
using FluentAssertions;
using NUnit.Framework;

namespace Algorithm.Tests.BinaryTree;

[TestFixture]
[TestOf(typeof(BinaryTreePostorderTraversal))]
public class BinaryTreePostorderTraversalTest
{

    [Test]
    public void PostorderTraversalWithRecursive_Test_Example1()
    {
        var sut = new BinaryTreePostorderTraversal();
        var result = sut.PostorderTraversalWithRecursive(ExampleNodes.ExampleNode1());
        result.Should().BeEquivalentTo(new int[] { 3, 2, 1 }, options => options.WithStrictOrdering());
    }
    
    [Test]
    public void PostorderTraversalWithRecursive_Test_Example2()
    {
        var sut = new BinaryTreePostorderTraversal();
        var result = sut.PostorderTraversalWithRecursive(ExampleNodes.ExampleNode2());
        result.Should().BeEquivalentTo(new int[] { }, options => options.WithStrictOrdering());
    }
    [Test]
    public void PostorderTraversalWithRecursive_Test_Example3()
    {
        var sut = new BinaryTreePostorderTraversal();
        var result = sut.PostorderTraversalWithRecursive(ExampleNodes.ExampleNode3());
        result.Should().BeEquivalentTo(new int[] {1 }, options => options.WithStrictOrdering());
    }
    [Test]
    public void PostorderTraversalWithRecursive_Test_Example4()
    {
        var sut = new BinaryTreePostorderTraversal();
        var result = sut.PostorderTraversalWithRecursive(ExampleNodes.ExampleNode4());
        result.Should().BeEquivalentTo(new int[] {4,6,7,5,2,9,8,3,1 }, options => options.WithStrictOrdering());
    }
    [Test]
    public void PostorderTraversalWithStack_Test_Example1()
    {
        var sut = new BinaryTreePostorderTraversal();
        var result = sut.PostorderTraversalWithStack(ExampleNodes.ExampleNode1());
        result.Should().BeEquivalentTo(new int[] { 3, 2, 1 }, options => options.WithStrictOrdering());
    }
    
    [Test]
    public void PostorderTraversalWithStack_Test_Example2()
    {
        var sut = new BinaryTreePostorderTraversal();
        var result = sut.PostorderTraversalWithStack(ExampleNodes.ExampleNode2());
        result.Should().BeEquivalentTo(new int[] { }, options => options.WithStrictOrdering());
    }
    [Test]
    public void PostorderTraversalWithStack_Test_Example3()
    {
        var sut = new BinaryTreePostorderTraversal();
        var result = sut.PostorderTraversalWithStack(ExampleNodes.ExampleNode3());
        result.Should().BeEquivalentTo(new int[] {1 }, options => options.WithStrictOrdering());
    }
    [Test]
    public void PostorderTraversalWithStack_Test_Example4()
    {
        var sut = new BinaryTreePostorderTraversal();
        var result = sut.PostorderTraversalWithStack(ExampleNodes.ExampleNode4());
        result.Should().BeEquivalentTo(new int[] {4,6,7,5,2,9,8,3,1 }, options => options.WithStrictOrdering());
    }

}