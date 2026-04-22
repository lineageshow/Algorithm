using System.Collections.Generic;
using Algorithm.Graph;
using Algorithm.Tests.Graph;
using FluentAssertions;
using NUnit.Framework;

namespace Algorithm.Tests.BinaryTree;

[TestFixture]
[TestOf(typeof(BinaryTreeLevelOrderTraversal))]
public class BinaryTreeLevelOrderTraversalTest
{

    [Test]
    public void LevelOrder_Test1()
    {
        var sut = new BinaryTreeLevelOrderTraversal();
        var result =
            sut.LevelOrder(new TreeNode(1, new TreeNode(2, new TreeNode(4), new TreeNode(5)),
                new TreeNode(3, null, new TreeNode(6))));
        var expected = new List<List<int>>()
        {
            new(){1},
            new(){2,3},
            new(){4,5,6},
        };
        result.Should().BeEquivalentTo(expected);
    }
    [Test]
    public void LevelOrder_Test2()
    {
        var sut = new BinaryTreeLevelOrderTraversal();
        var result = sut.LevelOrder(ExampleNodes.ExampleNode4()); //[1,2,3,4,5,null,8,null,null,6,7,9]
        
        var expected = new List<List<int>>()
        {
            new(){1},
            new(){2, 3},
            new(){4,5,8},
            new(){6,7,9},
        };
        result.Should().BeEquivalentTo(expected);
    }
}