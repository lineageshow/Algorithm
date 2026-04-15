using FluentAssertions;
using NUnit.Framework;
using Algorithm.Graph;
using static Algorithm.Graph.BinaryTreeInorderTraversal;

namespace Algorithm.Tests.Graph;

[TestFixture]
[TestOf(typeof(BinaryTreeInorderTraversal))]
public class BinaryTreeInorderTraversalTest
{
    [Test]
    public void Test_Example1()
    {
        // root = [1,null,2,3]
        var root = new TreeNode(1, null, new TreeNode(2, new TreeNode(3), null));
        var sut = new BinaryTreeInorderTraversal();
        
        var result = sut.InorderTraversalWithRecursive(root);
        
        result.Should().BeEquivalentTo(new int[] { 1, 3, 2 }, options => options.WithStrictOrdering());
    }
    [Test]
    public void InorderTraversalWithStack_Test_Example1()
    {
        // root = [1,null,2,3]
        var root = new TreeNode(1, null, new TreeNode(2, new TreeNode(3), null));
        var sut = new BinaryTreeInorderTraversal();
        
        var result = sut.InorderTraversalWithStack(root);
        
        result.Should().BeEquivalentTo(new int[] { 1, 3, 2 }, options => options.WithStrictOrdering());
    }

    [Test]
    public void Test_Example2()
    {
        // root = []
        TreeNode root = null;
        var sut = new BinaryTreeInorderTraversal();
        
        var result = sut.InorderTraversalWithRecursive(root);
        
        result.Should().BeEquivalentTo(new int[] { }, options => options.WithStrictOrdering());
    }
    [Test]
    public void InorderTraversalWithStack_Test_Example2()
    {
        // root = []
        TreeNode root = null;
        var sut = new BinaryTreeInorderTraversal();
        
        var result = sut.InorderTraversalWithStack(root);
        
        result.Should().BeEquivalentTo(new int[] { }, options => options.WithStrictOrdering());
    }

    [Test]
    public void Test_Example3()
    {
        var root = new TreeNode(1);
        var sut = new BinaryTreeInorderTraversal();
        
        var result = sut.InorderTraversalWithRecursive(root);
        
        result.Should().BeEquivalentTo(new int[] { 1 }, options => options.WithStrictOrdering());
    }

    [Test]
    public void InorderTraversalWithStack_Test_Example3()
    {
        TreeNode root = new TreeNode(1);
        var sut = new  BinaryTreeInorderTraversal();
        var result = sut.InorderTraversalWithStack(root);
        result.Should().BeEquivalentTo(new int[] { 1 }, options => options.WithStrictOrdering());

    }
}
