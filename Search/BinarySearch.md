# Binary Search 演算法詳解

## 一、什麼是 Binary Search？

**Binary Search（二分搜尋）** 是一種在**有序**資料中快速尋找目標的演算法，每次將搜尋範圍對半縮小，直到找到目標或範圍為空。  
核心想法是：利用**有序性**與**單調性**，每次排除一半的候選解，在 O(log n) 內完成搜尋，遠優於線性掃描的 O(n)。

---

## 二、演算法原理

### 基本概念

1. **前提**：資料必須有序（或具單調性），才能判斷目標在左半或右半。
2. **對半縮小**：比較中間元素與目標，決定往左或往右繼續搜尋。
3. **終止條件**：找到目標，或 `left > right`（範圍為空）。
4. **邊界處理**：`mid` 的計算與 `left`、`right` 的更新方式會影響是否有死循環或漏解，需小心實作。

### 常見變體

| 變體 | 說明 | 典型應用 |
|------|------|----------|
| **標準二分** | 找目標值是否存在 | 有序陣列搜尋 |
| **找左邊界** | 找第一個 ≥ target 的位置 | Lower Bound |
| **找右邊界** | 找最後一個 ≤ target 的位置 | Upper Bound |
| **答案二分** | 對「答案值」二分，檢查可行性 | 最小化最大值、最大化最小值 |
| **旋轉陣列** | 在旋轉有序陣列中搜尋 | 搜尋旋轉排序陣列 |

### 執行步驟（標準二分）

1. 初始化 `left = 0`，`right = n - 1`。
2. 若 `left <= right`，計算 `mid = left + (right - left) / 2`（避免溢位）。
3. 若 `arr[mid] == target`，回傳 `mid`。
4. 若 `arr[mid] < target`，則 `left = mid + 1`。
5. 若 `arr[mid] > target`，則 `right = mid - 1`。
6. 若 `left > right`，回傳 -1（未找到）。

### 範例：有序陣列搜尋

陣列 `[1, 3, 5, 7, 9]`，目標 5：

- `left=0, right=4`，`mid=2`，`arr[2]=5` → 找到，回傳 2

陣列 `[1, 3, 5, 7, 9]`，目標 4：

- `left=0, right=4`，`mid=2`，`5>4` → `right=1`
- `left=0, right=1`，`mid=0`，`1<4` → `left=1`
- `left=1, right=1`，`mid=1`，`3<4` → `left=2`
- `left>right` → 未找到，回傳 -1

---

## 三、使用情境

適合以下情境：

| 情境 | 說明 |
|------|------|
| 有序陣列搜尋 | 找目標值、找邊界 |
| 答案具單調性 | 可對答案值二分，檢查可行性 |
| 最小化/最大化 | 如「最小的滿足條件的 x」 |
| 旋轉陣列 | 部分有序仍可二分 |
| 搜尋空間大 | 線性掃描太慢，二分可降為 O(log n) |

### 常見題型

1. **LeetCode 35**: Search Insert Position
2. **LeetCode 34**: Find First and Last Position of Element in Sorted Array
3. **LeetCode 69**: Sqrt(x)
4. **LeetCode 74**: Search a 2D Matrix
5. **LeetCode 153**: Find Minimum in Rotated Sorted Array
6. **LeetCode 154**: Find Minimum in Rotated Sorted Array II
7. **LeetCode 162**: Find Peak Element
8. **LeetCode 167**: Two Sum II（可二分，但雙指標更簡潔）
9. **LeetCode 209**: Minimum Size Subarray Sum（可搭配滑動窗口或答案二分）
10. **LeetCode 875**: Koko Eating Bananas（答案二分）
11. **LeetCode 1011**: Capacity To Ship Packages Within D Days（答案二分）

---

## 四、時間複雜度

- **時間複雜度**：O(log n)
- 每次將搜尋範圍減半，最多 log n 次迭代。
- 若對答案值二分，且每次檢查為 O(n)，則總時間為 O(n log range)。

---

## 五、空間複雜度

- **空間複雜度**：O(1)（迭代實作）
- 僅使用 `left`、`right`、`mid` 等變數。
- 若用遞迴實作，堆疊深度 O(log n)，空間 O(log n)。

---

## 六、與其他技巧的比較

| 技巧 | 時間複雜度 | 空間複雜度 | 適用條件 |
|------|------------|------------|----------|
| 二分搜尋 | O(log n) | O(1) | 有序、單調、單一目標 |
| 暴力搜尋 | O(n) | O(1) | 線性掃描 |
| Two Pointers | O(n) | O(1) | 配對、有序陣列 |
| Hash Table | O(n) | O(n) | 快速查詢、無需有序 |
| 滑動窗口 | O(n) | O(1) | 連續子陣列 |

---

## 七、總結

Binary Search 在有序或具單調性的資料上可達 O(log n) 搜尋，是高效解題的基礎技巧。除標準「找目標」外，找左/右邊界、對答案值二分（答案二分）也是常見變體。實作時需注意 `mid` 計算與邊界更新，避免死循環與漏解。
