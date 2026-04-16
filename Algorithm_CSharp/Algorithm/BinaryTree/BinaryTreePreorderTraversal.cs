namespace Algorithm.Graph;

public class BinaryTreePreorderTraversal
{
    
    /*
144. Binary Tree Preorder Traversal
Easy Topics:Stack, Tree, DFS, Binary Tree
Given the root of a binary tree, return the preorder traversal of its nodes' values.

Example 1:
  1
   \
    2
   /
  3 

Input: root = [1,null,2,3]

Output: [1,2,3]

Explanation:



Example 2:

Input: root = [1,2,3,4,5,null,8,null,null,6,7,9]

Output: [1,2,4,5,6,7,3,8,9]

Explanation:



Example 3:


Input: root = []

Output: []

Example 4:
  1
  
Input: root = [1]

Output: [1]

 

Constraints:

The number of nodes in the tree is in the range [0, 100].
-100 <= Node.val <= 100
 

Follow up: Recursive solution is trivial, could you do it iteratively?
     */
    public IList<int> PreorderTraversalWithRecursive(TreeNode root)
    {
        if (root == null)
            return  new List<int>();
        
        var result = new List<int>();
        Recursive(root, result);

        return result;
    }

    private void Recursive(TreeNode root, List<int> result)
    {
        if (root == null)
            return;

        result.Add(root.val);
        Recursive(root.left, result);
        Recursive(root.right, result);
    }
    /// <summary>
    /// node -> left -> right
    /// </summary>
    /// <param name="root"></param>
    /// <returns></returns>
    public IList<int> PreorderTraversalWithStack(TreeNode root)
    {
        if (root == null)
            return  new List<int>();
        
        var result = new List<int>();
        var stack = new Stack<TreeNode>();
        stack.Push(root);
        while (stack.Count > 0)
        {
            var current = stack.Pop();
            result.Add(current.val);
            if (current.right != null)
                stack.Push(current.right);
            if (current.left != null)
                stack.Push(current.left);
        }
        return result;
    }

}