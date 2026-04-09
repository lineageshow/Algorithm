namespace Algorithm;

public class ReverseLinkedList
{
    /*
206. Reverse Linked List
Easy Topics: Linked List, Recursion

Given the head of a singly linked list, reverse the list, and return the reversed list.

Example 1:

Input: head = [1,2,3,4,5]
Output: [5,4,3,2,1]

Example 2:

Input: head = [1,2]
Output: [2,1]

Example 3:

Input: head = []
Output: []

Constraints:

The number of nodes in the list is the range [0, 5000].
-5000 <= Node.val <= 5000

Follow-up: A linked list can be reversed either iteratively or recursively. Could you implement both?
     */

    /*
    迭代（iterative）思路：
    一次處理一個節點，把「目前節點」的 next 改指向前一個節點。
    需要三個變數：prev（已反轉區段的新頭前驅）、curr（正在處理的節點）、
    以及先用 next 暫存 curr.next，否則一改指標就會斷鏈找不到後面。

    實作細節：curr 從 head 往尾端走，每輪 next = curr.next → curr.next = prev →
    prev、curr 一起往右移。迴圈結束時 curr 為 null，prev 即為反轉後的頭。
    時間 O(n)、額外空間 O(1)。
     */
    public ListNode? ReverseList(ListNode? head)
    {
        ListNode? prev = null;
        var curr = head;
        while (curr != null)
        {
            var next = curr.next;
            curr.next = prev;
            prev = curr;
            curr = next;
        }

        return prev;
    }

    /*
     遞迴（recursive）思路：
    假設「從 head.next 開始的後半段」已經反轉完成，且回傳值 newHead 是整段反轉後的頭。
    此時 head 仍指向「舊頭」，head.next 是反轉後子鏈的尾；要把 head 接到子鏈後面，
    相當於讓 head.next.next = head，再把 head.next = null（避免循環）。

    實作細節：遞迴基底為 head == null 或 head.next == null（單節點或空）。
    一般情況先 ReverseListRecursive(head.next)，再調整上述兩個指標。
    時間 O(n)、遞迴深度 O(n)，故額外堆疊空間 O(n)。
     */
    public ListNode? ReverseListRecursive(ListNode? head)
    {
        if (head == null || head.next == null)
            return head;

        var newHead = ReverseListRecursive(head.next);
        head.next.next = head;
        head.next = null;
        return newHead;
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
