namespace Algorithm.Graph;

public class BalanceBinaryTree
{
    public bool IsBalanced(TreeNode root)
    {
        return GetHeightImbalance(root) != -1;
    }

    private int GetHeightImbalance(TreeNode root)
    {
        if (root == null)
            return 0;

        var leftHeight = GetHeightImbalance(root.left);
        var rightHeight = GetHeightImbalance(root.right);

        if (leftHeight == -1 || rightHeight == -1)
        {
            return -1;
        }

        if (Math.Abs(leftHeight - rightHeight) > 1)
            return -1;
        
        return 1 + Math.Max(leftHeight, rightHeight);

    }
}