# Algorithm

演算法學習筆記與實作，包含排序、搜尋、圖遍歷與解題技巧的說明文件，以及 C# 實作範例。

## 目錄結構

```
Algorithm/
├── Sort/           # 排序演算法
├── Search/         # 搜尋演算法
├── Graph/          # 圖演算法
├── Techniques/     # 解題技巧
└── Algorithm_CSharp/   # C# 實作
```

## Sort（排序）

| 演算法 | 時間複雜度 | 空間複雜度 |
|--------|------------|------------|
| [Cyclic Sort](Sort/CyclicSort.md) | O(n) | O(1) |
| [Quick Sort](Sort/QuickSort.md) | O(n log n) 平均 | O(log n) |
| [Merge Sort](Sort/MergeSort.md) | O(n log n) | O(n) |
| [Bubble Sort](Sort/BubbleSort.md) | O(n²) | O(1) |
| [Heap Sort](Sort/HeapSort.md) | O(n log n) | O(1) |

## Search（搜尋）

| 演算法 | 時間複雜度 | 空間複雜度 |
|--------|------------|------------|
| [Binary Search](Search/BinarySearch.md) | O(log n) | O(1) |
| [Hash Table](Search/HashTable.md) | O(n) | O(n) |

## Graph（圖）

| 演算法 | 時間複雜度 | 空間複雜度 |
|--------|------------|------------|
| [BFS](Graph/BFS.md) | O(V + E) | O(V) |
| [DFS](Graph/DFS.md) | O(V + E) | O(V) |

## Techniques（解題技巧）

| 技巧 | 時間複雜度 | 空間複雜度 |
|------|------------|------------|
| [Two Pointers](Techniques/TwoPointers.md) | O(n) | O(1) |
| [Sliding Window](Techniques/SlidingWindow.md) | O(n) | O(1) |
| [Merge Intervals](Techniques/MergeIntervals.md) | O(n log n) | O(n) |
| [Brute Force](Techniques/BruteForce.md) | O(n²)～O(n!) | O(1) |
| [Recursion](Techniques/Recursion.md) | 依問題而定 | O(深度) |

## Algorithm_CSharp

C# 實作專案，使用 .NET 8。

- **SlidingWindow**：滑動窗口實作（含 MaxSlidingWindow）
- **Recursion**：遞迴實作（如 Add Two Numbers）
- **MergeAndSortIntervals**：合併區間（含 OrderBy 版與手寫 QuickSort 版）

### 建置與執行

```bash
cd Algorithm_CSharp
dotnet build
dotnet test
```

## 說明文件格式

每個演算法說明文件包含：

1. 演算法簡介
2. 原理（基本概念、變體、執行步驟、範例）
3. 使用情境與常見 LeetCode 題型
4. 時間複雜度與空間複雜度
5. 與其他技巧的比較
6. 總結
