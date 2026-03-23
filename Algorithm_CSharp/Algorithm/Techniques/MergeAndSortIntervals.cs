public class MergeAndSortIntervals
{
    /*
Merge and Sort Intervals
Given an array of intervals [startTime, endTime], merge all overlapping intervals and return a sorted array of non-overlapping intervals.

Example

Input

intervals = [[1, 3], [2, 6], [8, 10], [15, 18]]
Output

[[1, 6], [8, 10], [15, 18]]
Explanation

- Step 1: Sort intervals by start time (already sorted). 
- Step 2: Initialize merged list with first interval [1,3]. 
- Step 3: Compare [2,6] with last merged [1,3]. They overlap (2 ≤ 3), so merge into [1,6]. Step 4: Compare [8,10] with last merged [1,6]. No overlap (8 > 6), append [8,10]. 
- Step 5: Compare [15,18] with last merged [8,10]. No overlap (15 > 10), append [15,18]. 

Result: [[1,6],[8,10],[15,18]].
Input Format

The first line contains an integer denoting the number of intervals.
The second line contains an integer denoting the length of individual interval array.
Each of the next N lines contains two space-separated integers startTime and endTime
Intervals may be provided in any order; duplicates and fully contained intervals are allowed.
Example

4
2
1 3
2 6
8 10
15 18
here, 4 is the number of intervals, 2 is the length of individual interval array, followed by the intervals.

Constraints

0 <= intervals.length <= 100000
intervals[i].length == 2 for all 0 <= i < intervals.length
0 <= intervals[i][0] < intervals[i][1] <= 10^9 for all 0 <= i < intervals.length
Output Format

Return a 2D array of two space-separated integers start and end, representing the merged intervals sorted by increasing start time.
Sample Input 0

0
0
Sample Input 1

1
2
5 10
Sample Output 1

5 10
     */

    /// <summary>
    /// 合併所有重疊的區間，並依 start 排序回傳。
    /// 解法：先排序（OrderBy）→ 逐一比對與合併。
    /// </summary>
    public static List<List<int>> MergeHighDefinitionIntervals(List<List<int>> intervals)
    {
        // 邊界：空陣列直接回傳
        if (intervals == null || intervals.Count == 0)
            return new List<List<int>>();

        // Step 1：依 start 排序（start 相同可依 end 排序，非必要）
        var sorted = intervals.OrderBy(x => x[0]).ToList();

        var result = new List<List<int>>();
        result.Add(new List<int> { sorted[0][0], sorted[0][1] });

        // Step 2：遍歷剩餘區間，與 result 的最後一個比對
        for (int i = 1; i < sorted.Count; i++)
        {
            var curr = sorted[i];
            var last = result[^1]; // result 的最後一個區間

            // 重疊條件：curr.start <= last.end
            // 例：[1,6] 與 [2,8] → 2 <= 6，重疊，合併為 [1,8]
            if (curr[0] <= last[1])
            {
                // 合併：end 取兩者較大值
                last[1] = Math.Max(last[1], curr[1]);
            }
            else
            {
                // 不重疊：curr.start > last.end，直接加入新區間
                result.Add(new List<int> { curr[0], curr[1] });
            }
        }

        return result;
    }

    /// <summary>
    /// 合併所有重疊的區間（使用自行實作的 QuickSort，不使用 OrderBy）。
    /// </summary>
    public static List<List<int>> MergeHighDefinitionIntervalsWithManualSort(List<List<int>> intervals)
    {
        if (intervals == null || intervals.Count == 0)
            return new List<List<int>>();

        // 複製一份後，以 QuickSort 依 start 排序
        var sorted = new List<List<int>>();
        foreach (var interval in intervals)
            sorted.Add(new List<int> { interval[0], interval[1] });

        QuickSortByStart(sorted, 0, sorted.Count - 1);

        var result = new List<List<int>>();
        result.Add(new List<int> { sorted[0][0], sorted[0][1] });

        for (int i = 1; i < sorted.Count; i++)
        {
            var curr = sorted[i];
            var last = result[^1];

            if (curr[0] <= last[1])
                last[1] = Math.Max(last[1], curr[1]);
            else
                result.Add(new List<int> { curr[0], curr[1] });
        }

        return result;
    }

    /// <summary>
    /// 對區間列表依 start 做 QuickSort（原地排序）。
    /// </summary>
    private static void QuickSortByStart(List<List<int>> intervals, int left, int right)
    {
        if (left >= right) return;

        int pivotIndex = Partition(intervals, left, right);
        QuickSortByStart(intervals, left, pivotIndex - 1);
        QuickSortByStart(intervals, pivotIndex + 1, right);
    }

    /// <summary>
    /// Partition：以 right 為 pivot，將較小者放左側，較大者放右側。
    /// 比較準則：intervals[i][0]（start）
    /// </summary>
    private static int Partition(List<List<int>> intervals, int left, int right)
    {
        var pivot = intervals[right][0];
        int i = left - 1;

        for (int j = left; j < right; j++)
        {
            if (intervals[j][0] <= pivot)
            {
                i++;
                (intervals[i], intervals[j]) = (intervals[j], intervals[i]);
            }
        }
        (intervals[i + 1], intervals[right]) = (intervals[right], intervals[i + 1]);
        return i + 1;
    }
}
