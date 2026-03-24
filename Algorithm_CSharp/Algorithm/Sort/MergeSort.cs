namespace Algorithm.Sort;

public class MergeSort
{
    /// <summary>
    /// 912. Sort an Array
    ///Medium
    ///    Topics
    ///premium lock icon
    ///    Companies
    ///Given an array of integers nums, sort the array in ascending order and return it.
    ///
    ///    You must solve the problem without using any built-in functions in O(nlog(n)) time complexity and with the smallest space complexity possible.
    ///
    ///    Example 1:
    ///
    ///Input: nums = [5,2,3,1]
    ///Output: [1,2,3,5]
    ///Explanation: After sorting the array, the positions of some numbers are not changed (for example, 2 and 3), while the positions of other numbers are changed (for example, 1 and 5).
    ///Example 2:
    ///
    ///Input: nums = [5,1,1,2,0,0]
    ///Output: [0,0,1,1,2,5]
    ///Explanation: Note that the values of nums are not necessarily unique.
    ///
    ///    Constraints:
    ///1 <= nums.length <= 5 * 104
    ///-5 * 104 <= nums[i] <= 5 * 104
    /// </summary>
    /// <param name="nums"></param>
    /// <returns></returns>
    public int[] SortArray(int[] nums) 
    {
        if (nums.Length > 1)
        {
            var mid = nums.Length / 2;
            var leftArr = nums.Take(mid).ToArray();
            var rightArr = nums.Skip(mid).ToArray();

            SortArray(leftArr);
            SortArray(rightArr);

            var rightIndex = 0;
            var leftIndex = 0;
            var mergedIndex = 0;

            while (rightIndex < rightArr[rightIndex] && leftIndex < leftArr[leftIndex])
            {
                if (rightArr[rightIndex] < leftArr[leftIndex])
                {
                    
                }
            }

        }

        return nums;

    }

}