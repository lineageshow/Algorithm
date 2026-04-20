using Algorithm.Graph;

namespace Algorithm;

public class KthSmallestElementInABST
{
    /*
230. Kth Smallest Element in a BST
Medium Topics: Tree, Depth-First Search, Binary Search Tree, Binary Tree

Given the root of a binary search tree, and an integer k, return the kth smallest value (1-indexed) of all the values of the nodes in the tree.

Example 1:

Input: root = [3,1,4,null,2], k = 1
Output: 1

Example 2:

Input: root = [5,3,6,2,4,null,null,1], k = 3
Output: 3

Constraints:

The number of nodes in the tree is n.
1 <= k <= n <= 10^4
0 <= Node.val <= 10^4

Follow up: If the BST is modified often (i.e., we can do insert and delete operations) and you need to find the kth smallest frequently, how would you optimize?
     */
    public int KthSmallest(TreeNode root, int k)
    {
        var list = new List<int>();
        Recursive(root, list);
        return list[k - 1];
    }

    private void Recursive(TreeNode root, List<int> list)
    {
        if (root == null)
            return;

        Recursive(root.left, list);
        list.Add(root.val);
        Recursive(root.right, list);
    }

    // ==========================================================
    // Follow up 最佳解法：Augmented BST (增加輔助資訊的二元搜尋樹)
    // ==========================================================
    // 在真實的應用場景中，如果我們能修改資料結構，
    // 我們會在每一個節點額外紀錄「以它為根的子樹中，總共有多少個節點 (NodeCount)」。
    // 有了這個資訊，不管樹被如何頻繁的新增、刪除，尋找第 k 小的元素只需 O(H) (H為樹高) 的時間。

    // 步驟 1: 定義一個包含了節點數量的樹結構
    public class AugmentedTreeNode
    {
        public int Val;
        public int NodeCount; // 紀錄「自己」加上「左右子樹」的總節點數
        public AugmentedTreeNode Left;
        public AugmentedTreeNode Right;

        public AugmentedTreeNode(int val)
        {
            Val = val;
            NodeCount = 1; // 預設節點被建立時，包含自己，總數為 1
        }

        // 遞迴將標準的 TreeNode 轉換成 AugmentedTreeNode 並且由下往上算出 NodeCount
        public static AugmentedTreeNode ConvertFromTreeNode(TreeNode root)
        {
            if (root == null)
                return null;

            var augmentedNode = new AugmentedTreeNode(root.val);
            augmentedNode.Left = ConvertFromTreeNode(root.left);
            augmentedNode.Right = ConvertFromTreeNode(root.right);

            // 當前節點的 NodeCount = 左子樹總和 + 右子樹總和 + 1 (自己)
            int leftCount = augmentedNode.Left != null ? augmentedNode.Left.NodeCount : 0;
            int rightCount = augmentedNode.Right != null ? augmentedNode.Right.NodeCount : 0;
            augmentedNode.NodeCount = leftCount + rightCount + 1;

            return augmentedNode;
        }
    }

    // 步驟 2: 實作 O(H) 的尋找邏輯
    public int KthSmallestFollowUp(AugmentedTreeNode root, int k)
    {
        while (root != null)
        {
            // 取得當前節點「左子樹」的節點總人數。如果沒有左子樹，人數就是 0
            int leftCount = root.Left != null ? root.Left.NodeCount : 0;

            if (k == leftCount + 1)
            {
                // 狀況 A：左邊剛好有 k-1 個人在排隊（都比我小），
                // 那麼我自己就是第 k 小的人，找到答案了！
                return root.Val;
            }
            else if (k <= leftCount)
            {
                // 狀況 B：左邊排隊的人數 >= k 個，
                // 代表答案在左子樹裡面。我們移到左子樹，繼續找第 k 個。
                root = root.Left;
            }
            else
            {
                // 狀況 C：除了左子樹的所有人，加上我自己，還是沒湊齊 k 個人。
                // 這代表答案在右子樹裡！
                // 既然我們往右走，那就不用管左子樹跟現在這個節點了，
                // 在接下來的路途中，我們要找的名次必須「扣掉」我們已經跳過的人數 (leftCount + 1)。
                root = root.Right;
                k = k - (leftCount + 1);
            }
        }
        
        return -1; // Tree 是空的，或 k 值不合理找不到時。
    }
}