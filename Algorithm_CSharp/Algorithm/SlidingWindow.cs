/*
 239. Sliding Window Maximum
Hard
Topics
premium lock icon
Companies
Hint
You are given an array of integers nums, there is a sliding window of size k which is moving from the very left of the array to the very right. You can only see the k numbers in the window. Each time the sliding window moves right by one position.

Return the max sliding window.



Example 1:

Input: nums = [1,3,-1,-3,5,3,6,7], k = 3
Output: [3,3,5,5,6,7]
Explanation:
Window position                Max
---------------               -----
[1  3  -1] -3  5  3  6  7       3
 1 [3  -1  -3] 5  3  6  7       3
 1  3 [-1  -3  5] 3  6  7       5
 1  3  -1 [-3  5  3] 6  7       5
 1  3  -1  -3 [5  3  6] 7       6
 1  3  -1  -3  5 [3  6  7]      7
 
 get maximum value from the subarray, length is k
 6 times
Example 2:

Input: nums = [1], k = 1
Output: [1]


Constraints:

1 <= nums.length <= 10^5
-10^4 <= nums[i] <= 10^4
1 <= k <= nums.length
 */
public class SlidingWindow
{
    /// <summary>
    /// Monotonic Deque 解法 - 時間 O(n)，空間 O(k)
    /// </summary>
    public static int[] MaxSlidingWindowDeque(int[] nums, int k)
    {
        var result = new int[nums.Length - k + 1];
        var deque = new LinkedList<int>(); // 存的是「索引」，不是值

        for (int i = 0; i < nums.Length; i++)
        {
            // 1. 移除超出視窗範圍的索引（視窗左界是 i - k + 1）
            while (deque.Count > 0 && deque.First!.Value < i - k + 1)
                deque.RemoveFirst();

            // 2. 維持單調遞減：從後方移除所有比 nums[i] 小的索引
            //    這些元素不可能再成為後續視窗的最大值
            while (deque.Count > 0 && nums[deque.Last!.Value] <= nums[i])
                deque.RemoveLast();

            deque.AddLast(i);

            // 3. 視窗形成後，deque 前端即為當前視窗最大值
            if (i >= k - 1)
                result[i - k + 1] = nums[deque.First!.Value];
        }

        return result;
    }

    public static int[] MaxSlidingWindow(int[] nums, int k)
    {
        //[1, 3, -1, -3, 5, 3, 6, 7], 3
        var left = 0;
        var right =  k - 1;
        var result = new int[nums.Length - k + 1];
        
        while (right <= nums.Length - 1)
        {
            int maxinum = nums[left];    
            for (int i = left; i <= right ; i++)
            {
                if (nums[i] > maxinum)
                {
                    maxinum = nums[i];
                }
            }

            result[left] = maxinum;
            left++;
            right++;
        }

        return result;
    }
}