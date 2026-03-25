using System.Collections;

namespace Algorithm;

public class ContainsDuplicate
{
    /*
217. Contains Duplicate
Easy Topics 

Given an integer array nums, return true if any value appears at least twice in the array, and return false if every element is distinct.

Example 1:

Input: nums = [1,2,3,1]

Output: true

Explanation:

The element 1 occurs at the indices 0 and 3.

Example 2:

Input: nums = [1,2,3,4]

Output: false

Explanation:

All elements are distinct.

Example 3:

Input: nums = [1,1,1,3,3,4,3,2,4,2]

Output: true

Constraints:

1 <= nums.length <= 105
-109 <= nums[i] <= 109
     */
    public bool ContainsDuplicateWithHashTable(int[] nums)
    {
        var hashTable = new Hashtable();
        for (int i = 0; i < nums.Length ; i++)
        {
            if (hashTable.ContainsKey(nums[i]))
            {
                return true;
            }

            hashTable.Add(nums[i], i);
        }
        return false;
    }

    public bool ContainsDuplicateWithHashSet(int[] nums)
    {
        var hashSet = new HashSet<int>();
        for (int i = 0; i < nums.Length ; i++)
        {
            if (hashSet.Contains(nums[i]))
            {
                return true;
            }
            hashSet.Add(nums[i]);
        }
        return false;
    }

    public bool ContainsDuplicateWithSort(int[] nums)
    {
        Array.Sort(nums);
        for (int i = 0; i < nums.Length - 1; i++)
        {
            if (nums[i] == nums[i + 1])
            {
                return true;
            }
        }
        return false;
    }
    public bool ContainsDuplicateWithInsertionSort(int[] nums)
    {
        int n = nums.Length;
       for (int i = 1; i < n; i++) {
            int current = nums[i];
            int j = i - 1;

            while (j >= 0 && nums[j] > current) {
                nums[j + 1] = nums[j];
                j--; 
            }
            if (j >= 0 && nums[j] == current) 
                return true;
            nums[j + 1] = current;
       }
       return false;
    }
}