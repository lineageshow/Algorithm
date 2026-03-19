# Hash Table 演算法詳解

## 一、什麼是 Hash Table？

**Hash Table（雜湊表）** 是一種以鍵值對（key-value）儲存資料的資料結構，透過雜湊函數將鍵映射到陣列索引，實現 O(1) 平均時間的查詢、插入與刪除。  
核心想法是：用**空間換時間**，以額外儲存換取快速存取，適合需要頻繁「是否存在」「出現次數」等查詢的場景。

---

## 二、演算法原理

### 基本概念

1. **雜湊函數**：將 key 轉成陣列索引 `hash(key) % capacity`。
2. **碰撞處理**：不同 key 可能映射到同一索引，常用鏈結法（Chaining）或開放定址法（Open Addressing）。
3. **負載因子**：`元素數 / 容量`，過高時需擴容以維持效能。
4. **平均 O(1)**：理想情況下查詢、插入、刪除皆為 O(1)，最壞 O(n)（大量碰撞）。

### 常見變體

| 變體 | 說明 | 典型應用 |
|------|------|----------|
| **Set** | 只存 key，不存 value | 去重、存在性檢查 |
| **Map / Dictionary** | 存 key-value 對 | 計數、索引映射 |
| **計數 Map** | value 為出現次數 | 字元頻率、多數元素 |
| **前綴和 + Hash** | 儲存前綴和對應的索引 | 子陣列和為 k |

### 執行步驟（以兩數之和為例）

1. 建立 Hash Map，key 為陣列值，value 為索引。
2. 遍歷陣列，對每個 `arr[i]` 計算 `complement = target - arr[i]`。
3. 若 `complement` 在 Map 中，回傳 `[map[complement], i]`。
4. 否則將 `(arr[i], i)` 加入 Map。
5. 遍歷完無解則回傳空。

### 範例：兩數之和

陣列 `[2, 7, 11, 15]`，目標 9：

- `i=0`：complement=7，Map 空 → 加入 (2, 0)
- `i=1`：complement=2，Map 中有 2 → 回傳 `[0, 1]`

---

## 三、使用情境

適合以下情境：

| 情境 | 說明 |
|------|------|
| 快速查詢 | 需 O(1) 判斷元素是否存在 |
| 計數統計 | 記錄元素出現次數 |
| 索引映射 | 需由值反查索引 |
| 去重 | 快速判斷是否已見過 |
| 無需排序 | 不要求資料有序，Hash 即可 |

### 常見題型

1. **LeetCode 1**: Two Sum
2. **LeetCode 49**: Group Anagrams
3. **LeetCode 128**: Longest Consecutive Sequence
4. **LeetCode 136**: Single Number（可用 XOR，Hash 亦可）
5. **LeetCode 169**: Majority Element（可 Hash 計數）
6. **LeetCode 202**: Happy Number
7. **LeetCode 217**: Contains Duplicate
8. **LeetCode 242**: Valid Anagram
9. **LeetCode 347**: Top K Frequent Elements
10. **LeetCode 383**: Ransom Note
11. **LeetCode 560**: Subarray Sum Equals K（前綴和 + Hash）

---

## 四、時間複雜度

- **查詢、插入、刪除**：O(1) 平均，O(n) 最壞（大量碰撞）。
- **遍歷所有元素**：O(n)。
- **兩數之和等單遍歷**：O(n)。
- **前綴和 + Hash**：O(n)。

---

## 五、空間複雜度

- **空間複雜度**：O(n)
- 需額外儲存 n 個鍵值對（或 n 個 key，若為 Set）。
- 以空間換時間，是 Hash 的典型取捨。

---

## 六、與其他技巧的比較

| 技巧 | 時間複雜度 | 空間複雜度 | 適用條件 |
|------|------------|------------|----------|
| Hash Table | O(n) | O(n) | 快速查詢、計數、無需排序 |
| 暴力搜尋 | O(n²) | O(1) | 小規模、無更好方法 |
| Two Pointers | O(n) | O(1) | 有序陣列、配對 |
| 滑動窗口 | O(n) | O(1) | 連續子陣列/子字串 |
| 二分搜尋 | O(log n) | O(1) | 單一目標、有序 |

---

## 七、總結

Hash Table 以 O(n) 空間換取 O(1) 平均查詢，是處理「存在性」「計數」「索引映射」等問題的利器。兩數之和、字元計數、前綴和子陣列等題型皆可善用 Hash。若資料已排序且可雙指標解，可考慮用雙指標省下 O(n) 空間。
