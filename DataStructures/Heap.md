# Heap（堆積／二元堆）資料結構詳解

> **延伸閱讀**：以堆為基礎的 **原地排序** 步驟與分析，請見 [Heap Sort 演算法詳解](../Sort/HeapSort.md)。

---

## 一、定義與特性

**Heap（通常指 Binary Heap，二元堆）** 是一種 **完全二元樹** 結構，常用 **陣列** 儲存，並滿足 **堆積性質**：

| 類型 | 性質 |
|------|------|
| **Min-Heap** | 每個節點的值 ≤ 其子節點的值（根為最小值） |
| **Max-Heap** | 每個節點的值 ≥ 其子節點的值（根為最大值） |

**Priority Queue（優先佇列）** 是抽象資料型別；實務上常以 Min-Heap 或 Max-Heap 實作，使「取出最高／低優先度」為 O(log n)。

### C# 程式碼範例（Min-Heap / Max-Heap / PriorityQueue）

以下示範用「二元堆 + 動態陣列」手刻一個泛型 Heap；透過傳入 `IComparer<T>` 來決定是 Min-Heap 或 Max-Heap。

```csharp
using System;
using System.Collections.Generic;

public sealed class BinaryHeap<T>
{
    private readonly List<T> _data = new();
    private readonly IComparer<T> _comparer;

    public BinaryHeap(IComparer<T>? comparer = null)
        => _comparer = comparer ?? Comparer<T>.Default;

    public int Count => _data.Count;

    public void Push(T value)
    {
        _data.Add(value);
        SiftUp(_data.Count - 1);
    }

    public T Peek()
    {
        if (_data.Count == 0) throw new InvalidOperationException("Heap is empty.");
        return _data[0];
    }

    public T Pop()
    {
        if (_data.Count == 0) throw new InvalidOperationException("Heap is empty.");
        T root = _data[0];

        int last = _data.Count - 1;
        _data[0] = _data[last];
        _data.RemoveAt(last);

        if (_data.Count > 0) SiftDown(0);
        return root;
    }

    private void SiftUp(int i)
    {
        while (i > 0)
        {
            int p = (i - 1) / 2;
            if (_comparer.Compare(_data[i], _data[p]) >= 0) break;
            (_data[i], _data[p]) = (_data[p], _data[i]);
            i = p;
        }
    }

    private void SiftDown(int i)
    {
        int n = _data.Count;
        while (true)
        {
            int l = i * 2 + 1;
            if (l >= n) break;
            int r = l + 1;

            int best = (r < n && _comparer.Compare(_data[r], _data[l]) < 0) ? r : l;
            if (_comparer.Compare(_data[best], _data[i]) >= 0) break;

            (_data[i], _data[best]) = (_data[best], _data[i]);
            i = best;
        }
    }
}
```

**Min-Heap 用法**（根最小）：

```csharp
var minHeap = new BinaryHeap<int>(); // Comparer<int>.Default => min-heap
minHeap.Push(5);
minHeap.Push(2);
minHeap.Push(9);
Console.WriteLine(minHeap.Peek()); // 2
Console.WriteLine(minHeap.Pop());  // 2
```

**Max-Heap 用法**（根最大）：把 comparer 反過來即可。

```csharp
var maxHeap = new BinaryHeap<int>(Comparer<int>.Create((a, b) => b.CompareTo(a)));
maxHeap.Push(5);
maxHeap.Push(2);
maxHeap.Push(9);
Console.WriteLine(maxHeap.Peek()); // 9
Console.WriteLine(maxHeap.Pop());  // 9
```

**.NET 內建 `PriorityQueue<TElement, TPriority>`**（預設是「priority 越小越先出隊」＝ min-heap 行為）：

```csharp
using System;
using System.Collections.Generic;

// Min-priority queue：priority 越小越先出隊
var pq = new PriorityQueue<string, int>();
pq.Enqueue("low", 10);
pq.Enqueue("high", 1);
Console.WriteLine(pq.Dequeue()); // "high"

// Max-priority queue（常見技巧：把 priority 取負號或反向映射）
var maxPq = new PriorityQueue<string, int>();
maxPq.Enqueue("low", -10);
maxPq.Enqueue("high", -1);
Console.WriteLine(maxPq.Dequeue()); // "low"（因為 -10 < -1）
```

---

## 補充：如何 Build / Insert / Delete，以及 Heap Sort

下面用「陣列表示的二元堆」的角度說明。若陣列為 `a`（0-based）：

- 父節點：`parent(i) = (i - 1) / 2`
- 左子節點：`left(i) = i * 2 + 1`
- 右子節點：`right(i) = i * 2 + 2`

### 1) 要如何 Build Heap（Min / Max）

Build Heap（也常叫 **heapify**）的典型做法是「**自底向上 SiftDown**」：

- 從最後一個非葉節點 `n/2 - 1` 開始，往前一路對每個節點做 `SiftDown`
- 時間複雜度是 **O(n)**（不是 O(n log n)）

下面在前面的 `BinaryHeap<T>` 基礎上，加入「從現有集合建堆」的實作（Min / Max 只差 comparer）：

```csharp
using System;
using System.Collections.Generic;

public sealed class BinaryHeap<T>
{
    private readonly List<T> _data;
    private readonly IComparer<T> _comparer;

    public BinaryHeap(IComparer<T>? comparer = null)
    {
        _data = new List<T>();
        _comparer = comparer ?? Comparer<T>.Default;
    }

    public BinaryHeap(IEnumerable<T> items, IComparer<T>? comparer = null)
    {
        _data = new List<T>(items);
        _comparer = comparer ?? Comparer<T>.Default;
        BuildHeap();
    }

    public int Count => _data.Count;

    private void BuildHeap()
    {
        for (int i = _data.Count / 2 - 1; i >= 0; i--)
            SiftDown(i);
    }

    public void Push(T value)
    {
        _data.Add(value);
        SiftUp(_data.Count - 1);
    }

    public T Peek()
    {
        if (_data.Count == 0) throw new InvalidOperationException("Heap is empty.");
        return _data[0];
    }

    public T Pop()
    {
        if (_data.Count == 0) throw new InvalidOperationException("Heap is empty.");
        T root = _data[0];

        int last = _data.Count - 1;
        _data[0] = _data[last];
        _data.RemoveAt(last);

        if (_data.Count > 0) SiftDown(0);
        return root;
    }

    private void SiftUp(int i)
    {
        while (i > 0)
        {
            int p = (i - 1) / 2;
            if (_comparer.Compare(_data[i], _data[p]) >= 0) break;
            (_data[i], _data[p]) = (_data[p], _data[i]);
            i = p;
        }
    }

    
    private void SiftDown(int i)
    {
        int n = _data.Count;
        while (true)
        {
            int l = i * 2 + 1; // left child node index
            if (l >= n) break; // 沒有左子節點 => i 是葉節點，無法再下沉
            int r = l + 1;      // right child node index（可能不存在）

            // 在左右子節點中，挑出「更應該往上」的那個：
            // - Min-Heap：挑較小的子節點
            // - Max-Heap：若 comparer 反向，這裡仍會挑出「依 comparer 較小」= 實際較大的子節點
            int best = (r < n && _comparer.Compare(_data[r], _data[l]) < 0) ? r : l;

            // 若子節點已不比父節點更優先（依 comparer），堆積性質成立，停止下沉
            if (_comparer.Compare(_data[best], _data[i]) >= 0) break;

            // 父節點與較優先的子節點交換，繼續往下修復
            (_data[i], _data[best]) = (_data[best], _data[i]);
            i = best;
        }
    }
}
```

用法：

```csharp
// Min-Heap build
var minHeap = new BinaryHeap<int>(new[] { 5, 2, 9, 1, 7 });
Console.WriteLine(minHeap.Peek()); // 1

// Max-Heap build（反向 comparer）
var maxHeap = new BinaryHeap<int>(
    new[] { 5, 2, 9, 1, 7 },
    Comparer<int>.Create((a, b) => b.CompareTo(a))
);
Console.WriteLine(maxHeap.Peek()); // 9
```

### 2) Heap 插入元素（Insert / Push）

插入一個元素時：

- 先放到陣列尾端（維持完全二元樹形狀）
- 對新元素做 **SiftUp（上浮）** 直到堆積性質恢復
- 時間：**O(log n)**，空間：O(1) 額外空間

上面的 `Push` 就是插入的標準實作。

### 3) Heap 刪除元素（Delete）

堆常見的刪除有兩種：

- **刪除根（Delete-Min / Delete-Max）**：最常用，對應優先佇列的 `Dequeue`
- **刪除任意元素**：需要知道元素所在位置（index），通常搭配 Map（值→index）才好做

刪除根（上面 `Pop`）的流程：

- 把最後一個元素搬到根
- 對根做 **SiftDown（下沉）**
- 時間：**O(log n)**

若你想支援「刪除任意 index」，概念是把 `i` 和最後一個交換、刪掉最後一個後，視情況做 `SiftUp` 或 `SiftDown`（兩者做其一即可）：

```csharp
// 以「知道 index」為前提的刪除示意（簡化版）
public T RemoveAt(int i)
{
    if (i < 0 || i >= _data.Count) throw new ArgumentOutOfRangeException(nameof(i));
    int last = _data.Count - 1;
    T removed = _data[i];

    _data[i] = _data[last];
    _data.RemoveAt(last);

    if (i < _data.Count)
    {
        // 兩個方向擇一修復即可：先嘗試上浮，不行再下沉
        SiftUp(i);
        SiftDown(i);
    }

    return removed;
}
```

### 4) Heap Sort（堆排序）

Heap Sort 的核心想法：用堆來反覆取出極值（或把極值丟到陣列尾端），達成排序。

- 若用 **Max-Heap**：每次取出最大值放到結果尾端，可得到**升冪**排序
- 若用 **Min-Heap**：每次取出最小值依序取出，可得到**升冪**（但通常要額外陣列收集）

常見教科書版本是「**原地 In-place**」的 Max-Heap Heap Sort：

1. 對陣列建 Max-Heap（O(n)）
2. 重複把 `a[0]`（最大）與 `a[end]` 交換，縮小 heap 範圍後對 `0` 做 sift down（每次 O(log n)）

整體時間：**O(n log n)**，額外空間：**O(1)**（不含遞迴版本 call stack）

以下是 C# 的原地 Heap Sort（升冪，使用 Max-Heap 概念）：

```csharp
using System;

public static class HeapSort
{
    public static void SortAscending(int[] a)
    {
        int n = a.Length;

        // build max-heap
        for (int i = n / 2 - 1; i >= 0; i--)
            SiftDownMax(a, i, n);

        // extract max to the end
        for (int end = n - 1; end > 0; end--)
        {
            (a[0], a[end]) = (a[end], a[0]);
            SiftDownMax(a, 0, end);
        }
    }

    private static void SiftDownMax(int[] a, int i, int n)
    {
        while (true)
        {
            int l = i * 2 + 1;
            if (l >= n) break;
            int r = l + 1;

            int best = (r < n && a[r] > a[l]) ? r : l; // pick larger child
            if (a[best] <= a[i]) break;

            (a[i], a[best]) = (a[best], a[i]);
            i = best;
        }
    }
}
```

---

## 二、核心操作與複雜度

假設堆中有 n 個元素：

| 操作 | 時間 | 說明 |
|------|------|------|
| 插入 | O(log n) | 上浮（bubble up） |
| 刪除極值（根） | O(log n) | 最後一葉換到根再下沉 |
| 檢視極值 | O(1) | 僅看根 |
| 建堆 | O(n) | 自底向上調整（非逐個 insert 的 O(n log n)） |

空間：**O(n)**。

---

## 三、使用情境

| 情境 | 說明 |
|------|------|
| **Top K** | 維護大小為 K 的堆，或對全部元素建堆 |
| **合併 K 個有序串流** | 每步從 K 個頭取最小，可用 min-heap |
| **排程** | 依截止時間或優先權取下一工作 |
| **圖論** | Dijkstra 最短路（邊權非負）常用優先佇列 |
| **與 Map 搭配** | 先 HashMap 計數，再以堆取前 K 個頻率 |

與 [Queue](Queue.md) 的差別：一般佇列是 FIFO；**Priority Queue** 依鍵值順序出隊，二者解題時勿混淆。

---

## 四、適合搭配的演算法與題型

| 類型 | 範例 |
|------|------|
| 排序 | [Heap Sort](../Sort/HeapSort.md) |
| 選擇 | Kth Largest Element、Top K Frequent Elements |
| 合併 | Merge K Sorted Lists |
| 資料流 | 動態中位數（可雙堆） |

與 **Hash Map** 搭配：先用 Map 做頻率統計，再用堆取前 K 名，見 [HashMap](HashMap.md)。

---

## 五、小結

堆適合「動態維護極值」與 **n 很大但只關心前 K 名** 的場景。完整排序流程請對照 [Heap Sort](../Sort/HeapSort.md)；廣度優先走訪請用一般 [Queue](Queue.md)，不必用堆。
