using Algorithm;
using Algorithm.Graph;
using FluentAssertions;
using NUnit.Framework;

namespace Algorithm.Tests;

[TestFixture]
[TestOf(typeof(KthSmallestElementInABST))]
public class KthSmallestElementInABSTTest
{

    [Test]
    public void KthSmallestElementInABST_Test()
    {
        var sut = new KthSmallestElementInABST();

        var result = sut.KthSmallest(new TreeNode(3, new TreeNode(1, null, new TreeNode(2)), new TreeNode(4)), 1);
        result.Should().Be(1);
    }
    [Test]
    public void KthSmallestElementInABST_Test2()
    {
        var sut = new KthSmallestElementInABST();

        var result = sut.KthSmallest(new TreeNode(5, new TreeNode(3, new TreeNode(2, new TreeNode(1), null), new TreeNode(4)), new TreeNode(6)), 3);
        result.Should().Be(3);
    }

    [Test]
    public void KthSmallestFollowUp_Test()
    {
        var sut = new KthSmallestElementInABST();
        var root = new TreeNode(3, new TreeNode(1, null, new TreeNode(2)), new TreeNode(4));
        var augmentedRoot = KthSmallestElementInABST.AugmentedTreeNode.ConvertFromTreeNode(root);

        var result = sut.KthSmallestFollowUp(augmentedRoot, 1);
        result.Should().Be(1);
    }

    [Test]
    public void KthSmallestFollowUp_Test2()
    {
        var sut = new KthSmallestElementInABST();
        var root = new TreeNode(5, new TreeNode(3, new TreeNode(2, new TreeNode(1), null), new TreeNode(4)), new TreeNode(6));
        var augmentedRoot = KthSmallestElementInABST.AugmentedTreeNode.ConvertFromTreeNode(root);

        var result = sut.KthSmallestFollowUp(augmentedRoot, 3);
        result.Should().Be(3);
    }
}