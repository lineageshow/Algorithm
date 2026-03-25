using System.Collections;

namespace Algorithm;

public class TopKFrequentElements
{
    /*
347. Top K Frequent Elements
Medium
Topics
premium lock icon
Companies
Given an integer array nums and an integer k, return the k most frequent elements. You may return the answer in any order.

 

Example 1:

Input: nums = [1,1,1,2,2,3], k = 2

Output: [1,2]

Example 2:

Input: nums = [1], k = 1

Output: [1]

Example 3:

Input: nums = [1,2,1,2,1,2,3,1,3,2], k = 2

Output: [1,2]

 

Constraints:

1 <= nums.length <= 10^5
-10^4 <= nums[i] <= 10^4
k is in the range [1, the number of unique elements in the array].
It is guaranteed that the answer is unique.
 

Follow up: Your algorithm's time complexity must be better than O(n log n), where n is the array's size.
     */
    public int[] TopKFrequent(int[] nums, int k) 
    {
        var dict = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (!dict.TryAdd(nums[i], 1))
                dict[nums[i]]++;
        }
        //use Bucket Sort
        var bucket = new List<int>[nums.Length + 1];
        foreach (var keyValue in dict)
        {
            if (bucket[keyValue.Value] == null)
                bucket[keyValue.Value] = new List<int>();

            bucket[keyValue.Value].Add(keyValue.Key);
        }
        var result = new List<int>();
        for (int i = bucket.Length - 1; i >= 0; i--)
        {
            if (bucket[i] != null)
                result.AddRange(bucket[i]);
        }
        return result.Take(k).ToArray();
    }
}