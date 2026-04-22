using System.Collections.Generic;
using Algorithm.Graph;

namespace Algorithm.Tests.Graph;

public class ExampleNodes
{
    public static TreeNode ExampleNode1()
    {
        //[1,null,2,3]
        return new TreeNode(1, null,
            new TreeNode(2, new TreeNode(3), null));
    }

    public static TreeNode ExampleNode2()
    {
        //[]
        return null;
    }

    public static TreeNode ExampleNode3()
    {
        //[1]
        return new TreeNode(1);
    }
    public static TreeNode ExampleNode4()
    {
        //[1,2,3,4,5,null,8,null,null,6,7,9]
        return new TreeNode(1,
            new TreeNode(2, new TreeNode(4), new TreeNode(5, new TreeNode(6), new TreeNode(7))),
            new TreeNode(3, null, new TreeNode(8, new TreeNode(9), null))
        );
    }

    public static TreeNode BinarySearchTreeBuilder(int?[] preorder)
    {
        return BinarySearchTreeBuilderWithRecursion(preorder, 0, preorder.Length - 1);
    }

    private static TreeNode BinarySearchTreeBuilderWithRecursion(int?[] preorder, int start, int end)
    {
        if (start > end || preorder[start] == null)
            return null;

        var node = new TreeNode(preorder[start].Value);
        int split = start + 1;
        while (split <= end && preorder[split] < node.val)
        {
            split++;
        }

        node.left = BinarySearchTreeBuilderWithRecursion(preorder, start + 1, split - 1);
        node.right = BinarySearchTreeBuilderWithRecursion(preorder, split, end);

        return node;
    }

    public static TreeNode BinaryTreeNodeBuilder(int?[] preorder)
    {
        // Create root node
        var queue = new Queue<TreeNode>();
        if (preorder[0] == null)
            return null;
        var root = new TreeNode(preorder[0].Value);
        queue.Enqueue(root);
        
        var i = 1;  
        while (i < preorder.Length)
        {
            var current = queue.Dequeue();
            
            // Handle left tree
            if (i < preorder.Length && preorder[i].HasValue)
            {
                current.left = new TreeNode(preorder[i].Value);
                queue.Enqueue(current.left);
            }
            i++;
            
            // Handle right tree
            if (i  < preorder.Length && preorder[i].HasValue)
            {
                current.right = new TreeNode(preorder[i].Value);
                queue.Enqueue(current.right);
            }
            i++;
        }
        return root;
    }
    

}