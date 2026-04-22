namespace Algorithm.Graph;

public class BinaryTreePostorderTraversal
{
    /*
145. Binary Tree Postorder Traversal
Easy Topics:Stack, Tree, Depth-First Search, Binary Tree

Given the root of a binary tree, return the postorder traversal of its nodes' values.

Example 1:
   1
   \
    2
   /
  3
Input: root = [1,null,2,3]

Output: [3,2,1]

Example 2:

      1
     / \
    2   3
   / \   \
  4   5   8
     / \ /
    6  7 9

Input: root = [1,2,3,4,5,null,8,null,null,6,7,9]

Output: [4,6,7,5,2,9,8,3,1]

Example 3:

Input: root = []

Output: []

Example 4:

   1
Input: root = [1]

Output: [1]

Constraints:

The number of the nodes in the tree is in the range [0, 100].
-100 <= Node.val <= 100


Follow up: Recursive solution is trivial, could you do it iteratively?
     */

    public IList<int> PostorderTraversalWithRecursive(TreeNode root)
    {
        var result = new List<int>();

        if (root == null)
            return result;

        Recursive(root, result);

        return result;
    }

    private void Recursive(TreeNode root, List<int> result)
    {
        if (root == null)
            return;

        Recursive(root.left, result);
        Recursive(root.right, result);
        result.Add(root.val);
    }

    /// <summary>
    /// left -> right -> node
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public IList<int> PostorderTraversalWithStack(TreeNode root)
    {
        var result = new List<int>();

        if (root == null)
        {
            return result;
        }

        var stack = new Stack<TreeNode>();

        stack.Push(root);
        while (stack.Count > 0)
        {
            var node = stack.Peek();
            if (node.left == null && node.right == null)
            {
                stack.Pop();
                result.Add(node.val);
            }

            if (node.right != null)
            {
                stack.Push(node.right);
                node.right = null;
            }

            if (node.left != null)
            {
                stack.Push(node.left);
                node.left = null;
            }
                
        }

        return result;
    }
}