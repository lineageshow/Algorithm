public class Recursion
{
    /*
     * You are given two non-empty linked lists representing two non-negative integers. The digits are stored in reverse order, and each of their nodes contains a single digit. Add the two numbers and return the sum as a linked list.

You may assume the two numbers do not contain any leading zero, except the number 0 itself.

 

Example 1:


Input: l1 = [2,4,3], l2 = [5,6,4]
Output: [7,0,8]
Explanation: 342 + 465 = 807.
Example 2:

Input: l1 = [0], l2 = [0]
Output: [0]
Example 3:

Input: l1 = [9,9,9,9,9,9,9], l2 = [9,9,9,9]
Output: [8,9,9,9,0,0,0,1]
 

Constraints:

The number of nodes in each linked list is in the range [1, 100].
0 <= Node.val <= 9
It is guaranteed that the list represents a number that does not have leading zeros.
     */
    /// <summary>
    /// 迭代解法 - 使用 dummy head 與 while 迴圈
    /// </summary>
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var r = new ListNode(-1);
        var n = r;
        int carry = 0;
        while (carry > 0 || l1 != null || l2 != null)
        {
            var v = (l1?.val ?? 0) + (l2?.val ?? 0) + carry;
            carry = (int)(v / 10);
            n = n.next = new ListNode(v % 10);
            l1 = l1?.next;
            l2 = l2?.next;
        }
        return r.next!;
    }

    /// <summary>
    /// 遞迴解法 - 每次處理一位，遞迴處理剩餘部分
    /// </summary>
    public ListNode AddTwoNumbersRecursive(ListNode l1, ListNode l2)
    {
        return AddTwoNumbersRecursive(l1, l2, 0)!;
    }

    private static ListNode? AddTwoNumbersRecursive(ListNode? l1, ListNode? l2, int carry)
    {
        if (l1 == null && l2 == null && carry == 0)
            return null;

        var v = (l1?.val ?? 0) + (l2?.val ?? 0) + carry;
        var next = AddTwoNumbersRecursive(l1?.next, l2?.next, v / 10);
        return new ListNode(v % 10, next);
    }

    public class ListNode
    {
        public int val;
        public ListNode? next;

        public ListNode(int val = 0, ListNode? next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

}

public class MergeSort
{
    /// <summary>
    /// Given an array of integers nums, sort the array in ascending order and return it.
    /// You must solve the problem without using any built-in functions in O(nlog(n)) time complexity and with the smallest space complexity possible.
    /// Example 1:

    /// Input: nums = [5,2,3,1]
    /// Output: [1,2,3,5]
    /// Explanation: After sorting the array, the positions of some numbers are not changed (for example, 2 and 3), while the positions of other numbers are changed (for example, 1 and 5).
    /// Example 2:

    /// Input: nums = [5,1,1,2,0,0]
    /// Output: [0,0,1,1,2,5]
    /// Explanation: Note that the values of nums are not necessarily unique.

    /// Constraints:
    /// 1 <= nums.length <= 5 * 104
    /// -5 * 104 <= nums[i] <= 5 * 104
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