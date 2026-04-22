namespace Algorithm.Graph;

public class BinaryTreeLevelOrderTraversal
{
    /*
102. Binary Tree Level Order Traversal
Topic:Tree, BFS, Binary Tree
Given the root of a binary tree, return the level order traversal of its nodes' values. (i.e., from left to right, level by level).

Example 1:


Input: root = [3,9,20,null,null,15,7]
Output: [[3],[9,20],[15,7]]
Example 2:

Input: root = [1]
Output: [[1]]
Example 3:

Input: root = []
Output: []
 

Constraints:

The number of nodes in the tree is in the range [0, 2000].
-1000 <= Node.val <= 1000
 

     */

    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        if (root == null)
            return new List<IList<int>>();
        
        var result = new List<IList<int>>();
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        
        while (queue.Count > 0)
        {
            int size = queue.Count;
            var levelList = new List<int>();
            for (int i = 0; i < size; i++)
            {
                var node = queue.Dequeue();
                levelList.Add(node.val);

                if (node.left != null)
                    queue.Enqueue(node.left);

                if (node.right != null)
                    queue.Enqueue(node.right);
            }
            
            result.Add(levelList);
        }
        return result;
    }
}