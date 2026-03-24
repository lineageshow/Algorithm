namespace Algorithm.Sort;

public class QuickSort
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
        if (nums.Length <= 1)
        {
            return nums;
        }

        Sort(nums, 0, nums.Length - 1);
        return nums;
    }

    private static void Sort(int[] nums, int left, int right)
    {
        if (left >= right)
        {
            return;
        }

        int pivotIndex = Partition(nums, left, right);
        Sort(nums, left, pivotIndex - 1);
        Sort(nums, pivotIndex + 1, right);
    }

    /// <summary>Lomuto partition; pivot is always the last element in the current range (<c>nums[right]</c>).</summary>
    private static int Partition(int[] nums, int left, int right)
    {
        int pivot = nums[right];
        int i = left;
        for (int j = left; j < right; j++)
        {
            if (nums[j] <= pivot)
            {
                (nums[i], nums[j]) = (nums[j], nums[i]);
                i++;
            }
        }

        (nums[i], nums[right]) = (nums[right], nums[i]);
        return i;
    }

    private static void Swap(int[] nums, int i, int j)
    {
        if (i == j)
        {
            return;
        }

        (nums[i], nums[j]) = (nums[j], nums[i]);
        // int temp = nums[i];
        // nums[i] = nums[j];
        // nums[j] = temp;
    }


    public int[] SortArrayMine(int[] nums)
    {
        if (nums.Length <= 1)
            return nums;

        MineSort(nums, 0, nums.Length - 1);
        return nums;


    }

    private static void MineSort(int[] nums, int left, int right)
    {
        if (left >= right)
        {
            return;
        }
        int randomIndex = Random.Shared.Next(left, right + 1);
        (nums[randomIndex], nums[right]) = (nums[right], nums[randomIndex]);
        var pivot = nums[right];

        var pivotIndex = left;
        for (int i = left; i < right; i++)
        {
            if (nums[i] <= pivot)
            {
                (nums[i], nums[pivotIndex]) = (nums[pivotIndex], nums[i]);
                pivotIndex++; // pivotIndex 為左邊陣列最後一個index + 1
            }
        }
        
        //swap pivot
        if (pivotIndex != right)
        {
            (nums[pivotIndex], nums[right]) = (nums[right], nums[pivotIndex]);    
        }
        
        
        // nums, left, j
        MineSort(nums, left, pivotIndex - 1);
        
        // nums, j, right
        MineSort(nums, pivotIndex + 1, right);
    }
}
