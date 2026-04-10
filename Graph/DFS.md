# DFS 演算法詳解

## 一、什麼是 DFS？

**DFS（Depth-First Search，深度優先搜尋）** 是一種圖與樹的遍歷演算法，從起點開始**一路深入**到底，再回溯嘗試其他分支。  
核心想法是：使用**堆疊（Stack）**或**遞迴**實現「先處理當前節點，再處理其鄰居」，沿著一條路徑走到底再回溯，適合**路徑搜尋**、**連通分量**、**拓撲排序**、**回溯**等問題。

---

## 二、演算法原理

### 基本概念

1. **堆疊或遞迴**：LIFO（後進先出），實現「深入優先」。
2. **已訪問標記**：避免重複訪問，通常用 `visited` 集合或陣列。
3. **回溯**：探索完一條路徑後返回，嘗試其他分支。
4. **遞迴實作**：DFS 與遞迴天然契合，程式碼簡潔。

### 常見變體

| 變體 | 說明 | 典型應用 |
|------|------|----------|
| **遞迴 DFS** | 用函數呼叫堆疊 | 樹遍歷、簡單圖遍歷 |
| **迭代 DFS** | 用顯式 Stack | 避免堆疊溢位、需手動控制 |
| **前序/中序/後序** | 樹的遍歷順序 | 二元樹前中後序 |
| **回溯** | 嘗試 → 遞迴 → 撤銷 | 全排列、子集、N 皇后 |

### 執行步驟（遞迴版）

1. 若當前節點為空或已訪問，回傳。
2. 標記當前節點為已訪問，處理當前節點（如加入結果）。
3. 對當前節點的每個未訪問鄰居，遞迴呼叫 DFS。
4. 若需回溯（如找所有路徑），在遞迴返回後撤銷「已訪問」標記。

### 執行步驟（迭代版）

1. 將起點壓入堆疊。
2. 若堆疊非空，彈出頂端節點 `cur`。
3. 若 `cur` 未訪問，標記為已訪問，處理 `cur`。
4. 將 `cur` 的未訪問鄰居壓入堆疊。
5. 重複步驟 2～4 直到堆疊為空。

### 範例：二元樹前序遍歷的完整過程

```text
      1
     / \
    2   3
   / \
  4   5
```

- 前序（根→左→右）：`1` → `2` → `4` → `5` → `3`
- 結果：`[1, 2, 4, 5, 3]`

#### 🛠 遞迴版完整執行過程（利用系統呼叫堆疊 Call Stack）
1. **呼叫 `DFS(1)`**: 訪問 `1` (Result: `[1]`)，接著呼叫左子節點 `DFS(2)`。
2. **呼叫 `DFS(2)`**: 訪問 `2` (Result: `[1, 2]`)，接著呼叫左子節點 `DFS(4)`。
3. **呼叫 `DFS(4)`**: 訪問 `4` (Result: `[1, 2, 4]`)，`4` 無子節點，**退回**到 `DFS(2)`。
4. **回到 `DFS(2)`**: 左邊走完了，換走右邊，呼叫右子節點 `DFS(5)`。
5. **呼叫 `DFS(5)`**: 訪問 `5` (Result: `[1, 2, 4, 5]`)，`5` 無子節點，**退回**到 `DFS(2)`。
6. **回到 `DFS(2)`**: 左右兩邊皆走完任務結束，**退回**到最初的 `DFS(1)`。
7. **回到 `DFS(1)`**: 左邊走完了，換走右邊，呼叫右子節點 `DFS(3)`。
8. **呼叫 `DFS(3)`**: 訪問 `3` (Result: `[1, 2, 4, 5, 3]`)，`3` 無子節點，**退回**到 `DFS(1)`。
9. **回到 `DFS(1)`**: 全部走完，程式結束。

#### 🛠 迭代版完整執行過程（手動控制 Stack）
> 💡 技巧：為了保持前序「根→左→右」的打出順序，壓入 Stack 時必須**「先壓右、再壓左」**，這樣彈出時才會先處理左邊 (因為 Stack 是後進先出 LIFO)。

1. **初始狀態**：Stack = `[1]`，Result = `[]`
2. **彈出 `1`** (並訪問)：(Result: `[1]`)
   - 壓入右邊 `3`，再壓入左邊 `2`。
   - 此時 Stack = `[3, 2]`
3. **彈出 `2`** (並訪問)：(Result: `[1, 2]`)
   - 壓入右邊 `5`，再壓入左邊 `4`。
   - 此時 Stack = `[3, 5, 4]`
4. **彈出 `4`** (並訪問)：(Result: `[1, 2, 4]`)
   - 沒小孩可以壓入。
   - 此時 Stack = `[3, 5]`
5. **彈出 `5`** (並訪問)：(Result: `[1, 2, 4, 5]`)
   - 沒小孩可以壓入。
   - 此時 Stack = `[3]`
6. **彈出 `3`** (並訪問)：(Result: `[1, 2, 4, 5, 3]`)
   - 沒小孩可以壓入。
   - 此時 Stack = `[]`
7. Stack 為空，程式結束。

#### 📝 C# 實作程式碼

```csharp
public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class DFS_Example {
    // ======== 遞迴版 ========
    public IList<int> PreorderTraversalRecursive(TreeNode root) {
        List<int> result = new List<int>();
        DFS(root, result);
        return result;
    }

    private void DFS(TreeNode node, List<int> result) {
        if (node == null) return;
        
        result.Add(node.val);      // 根 (處理當前節點)
        DFS(node.left, result);    // 左
        DFS(node.right, result);   // 右
    }

    // ======== 迭代版 ========
    public IList<int> PreorderTraversalIterative(TreeNode root) {
        List<int> result = new List<int>();
        if (root == null) return result;

        Stack<TreeNode> stack = new Stack<TreeNode>();
        stack.Push(root);

        while (stack.Count > 0) {
            TreeNode node = stack.Pop();
            result.Add(node.val);  // 根 (處理當前節點)

            // 先壓入右邊，這樣彈出時才會晚處理 (LIFO 特性)
            if (node.right != null) {
                stack.Push(node.right);
            }
            // 再壓入左邊，這樣彈出時就會先處理
            if (node.left != null) {
                stack.Push(node.left);
            }
        }

        return result;
    }
}
```

---

## 三、使用情境

適合以下情境：

| 情境 | 說明 |
|------|------|
| 路徑搜尋 | 是否存在路徑、所有路徑 |
| 連通分量 | 圖的連通塊、島嶼數量 |
| 拓撲排序 | 有向無環圖的拓撲序 |
| 樹的遍歷 | 前序、中序、後序 |
| 回溯 | 全排列、子集、組合、N 皇后 |
| 環偵測 | 有向圖/無向圖的環 |

### 常見題型

1. **LeetCode 94**: Binary Tree Inorder Traversal
2. **LeetCode 98**: Validate Binary Search Tree
3. **LeetCode 101**: Symmetric Tree
4. **LeetCode 104**: Maximum Depth of Binary Tree
5. **LeetCode 112**: Path Sum
6. **LeetCode 113**: Path Sum II
7. **LeetCode 200**: Number of Islands
8. **LeetCode 207**: Course Schedule（拓撲排序）
9. **LeetCode 236**: Lowest Common Ancestor of a Binary Tree
10. **LeetCode 297**: Serialize and Deserialize Binary Tree
11. **LeetCode 46**: Permutations（回溯）
12. **LeetCode 79**: Word Search（回溯）

---

## 四、時間複雜度

- **時間複雜度**：O(V + E)
  - V：節點數（頂點數）
  - E：邊數
- 每個節點最多訪問一次，每條邊最多檢查一次。
- 二元樹：O(n)，n 為節點數。
- 回溯（全排列）：O(n!)，每個排列訪問一次。

---

## 五、空間複雜度

- **空間複雜度**：O(V) 或 O(h)
  - 遞迴堆疊深度：最壞 O(V)（鏈狀圖），樹則為 O(h)，h 為樹高。
  - `visited` 陣列/集合：O(V)。
  - 迭代版顯式 Stack：O(V)。

---

## 六、與其他技巧的比較

| 技巧 | 時間複雜度 | 空間複雜度 | 適用條件 |
|------|------------|------------|----------|
| DFS | O(V + E) | O(V) 堆疊 | 路徑、連通分量、回溯 |
| BFS | O(V + E) | O(V) 佇列 | 最短路徑、層級遍歷 |
| 遞迴 | 依問題而定 | O(深度) | 樹、回溯 |
| 回溯 | O(2^n)～O(n!) | O(n) | 枚舉、組合、排列 |

---

## 七、總結

DFS 沿著路徑一路深入再回溯，適合路徑搜尋、連通分量、拓撲排序與回溯問題。可用遞迴或迭代（顯式 Stack）實作，遞迴較簡潔但需注意堆疊深度。與 BFS 的選擇：需**最短路徑**或**層級順序**用 BFS；需**路徑存在**、**所有路徑**或**回溯**用 DFS。
