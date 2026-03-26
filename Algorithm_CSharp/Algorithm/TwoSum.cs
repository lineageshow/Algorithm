namespace Algorithm;

public class TwoSum
{
    /*
Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.

You may assume that each input would have exactly one solution, and you may not use the same element twice.

You can return the answer in any order.

 

Example 1:

Input: nums = [2,7,11,15], target = 9
Output: [0,1]
Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
Example 2:

Input: nums = [3,2,4], target = 6
Output: [1,2]
Example 3:

Input: nums = [3,3], target = 6
Output: [0,1]
 

Constraints:

2 <= nums.length <= 104
-109 <= nums[i] <= 109
-109 <= target <= 109
Only one valid answer exists.
 

Follow-up: Can you come up with an algorithm that is less than O(n2) time complexity?
     */
    
    public int[] TwoSumWithBruteForce(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                {
                    return [i, j];
                }
            }
        }

        return [];
    }

    public int[] TwoSumWithTwoPointers(int[] nums, int target)
    {
        var indexed = nums
            .Select((value, i) => (value, i))
            .OrderBy(x => x.value)
            .ToArray();

        int left = 0;
        int right = indexed.Length - 1;

        while (left < right)
        {
            int sum = indexed[left].value + indexed[right].value;
            if (sum == target)
            {
                return [indexed[left].i, indexed[right].i];
            }
            else if (sum < target)
            {
                left++;
            }
            else
            {
                right--;
            }
        }
        return [];
    }
    
    
}