namespace Algorithm.Search;

public class BinarySearch
{
    public int Search(int[] nums, int target)
    {
        var left = 0;
        var right = nums.Length - 1;
        var mid = (left + right) / 2;
        while (target != nums[mid] && left <= right)
        {
            Console.WriteLine($"left:{left} right:{right} mid:{mid}");
            if (target < nums[mid])
            {
                right = mid - 1;
            }
            else // target > nums[mid]
            {
                left = mid + 1;
            }

            mid = (left + right) / 2;
        }

        return left > right ? -1 : mid;
    }
}