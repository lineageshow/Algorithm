# Merge Intervals 演算法詳解

## 一、什麼是 Merge Intervals？

**Merge Intervals（合併區間）** 是一種**貪婪（Greedy）**演算法，用於合併所有重疊的區間並回傳不重疊的區間列表。  
核心想法是：先依 **start** 排序，再**線性掃描**逐一比對，若當前區間與上一個重疊則合併，否則加入結果。屬於「Sort + Greedy」經典模式。

---

## 二、演算法原理

### 基本概念

1. **排序**：依 `interval[0]`（start）升序排序，使可能重疊的區間相鄰。
2. **貪婪合併**：遍歷時只與「結果中最後一個」比對，局部最優即可得全域最優。
3. **重疊條件**：`curr.start <= last.end` 即重疊，合併時 `last.end = max(last.end, curr.end)`。
4. **不重疊**：`curr.start > last.end` 則直接加入新區間。

### 執行步驟

1. 若輸入為空，回傳空列表。
2. 依 start 排序（可用 QuickSort、MergeSort 或內建排序）。
3. 將第一個區間加入 `result`。
4. 從第二個開始遍歷：若與 `result` 最後一個重疊則合併，否則加入。
5. 回傳 `result`。

### 範例

輸入 `[[1, 3], [2, 6], [8, 10], [15, 18]]`：

- 排序後（已有序）：`[[1, 3], [2, 6], [8, 10], [15, 18]]`
- `[1, 3]` → result = `[[1, 3]]`
- `[2, 6]` 與 `[1, 3]` 重疊 → 合併為 `[1, 6]`
- `[8, 10]` 不重疊 → 加入
- `[15, 18]` 不重疊 → 加入
- 結果：`[[1, 6], [8, 10], [15, 18]]`

---

## 三、使用情境

適合以下情境：

| 情境 | 說明 |
|------|------|
| 區間重疊處理 | 會議室、行程表、時間區間 |
| 合併 overlapping 區間 | 區間覆蓋、合併範圍 |
| 需排序的區間問題 | Insert Interval、Non-overlapping 等變體 |

### 常見題型

1. **LeetCode 56**: Merge Intervals
2. **LeetCode 57**: Insert Interval
3. **LeetCode 252**: Meeting Rooms
4. **LeetCode 253**: Meeting Rooms II
5. **LeetCode 435**: Non-overlapping Intervals
6. **LeetCode 986**: Interval List Intersections

---

## 四、時間複雜度

- **時間複雜度**：O(n log n)
  - 排序：O(n log n)（QuickSort / MergeSort）
  - 合併：O(n) 線性掃描

---

## 五、空間複雜度

- **空間複雜度**：O(n)
  - 排序若需複製：O(n)
  - 結果列表：O(n)

---

## 六、與其他技巧的比較

| 技巧 | 時間複雜度 | 適用條件 |
|------|------------|----------|
| Merge Intervals | O(n log n) | 區間重疊合併 |
| Two Pointers | O(n) | 有序陣列配對 |
| 滑動窗口 | O(n) | 連續子陣列 |
| Sort | O(n log n) | 必經步驟 |

---

## 七、總結

Merge Intervals 是「Sort + Greedy」的經典應用，先排序再貪婪合併。排序使可能重疊的區間相鄰，貪婪保證每次與最後一個比對即可。相關題型如 Insert Interval、Meeting Rooms 皆可套用此模式。
