namespace Algorithm;

public class ReverseEvenIndexedNodesAndAppend
{
    /*
Reverse Even-Indexed Nodes and Append
Given a singly linked list, extract all even-indexed nodes, reverse their order,
and append them to the end of the list in one traversal. Return the head of the modified list.

Example

Input

head = [10, 20, 30, 40, 50, 60]

Output

[20, 40, 60, 50, 30, 10]

Explanation

- Step 1: Extract sponsored nodes at even positions 0, 2, 4 → [10, 30, 50].
- Step 2: Remaining non-sponsored nodes are [20, 40, 60].
- Step 3: Reverse the extracted sponsored list → [50, 30, 10].
- Step 4: Append the reversed list to [20, 40, 60], yielding [20, 40, 60, 50, 30, 10].

Input Format

The first line contains an integer n denoting the length of linked list.
The next n lines contains elements of the linked list.

Example

6
10
20
30
40
50
60

Constraints

Let n be the number of nodes in the list
0 <= n <= 100000
-10^9 <= value of each node <= 10^9
Sponsored nodes are those at even indices: 0, 2, 4, ...
The list may be empty (n = 0)

Output Format

An array representing the values of the modified linked list.

Sample Input 0

1
42

Sample Output 0

42

Sample Input 1

2
1
2

Sample Output 1

2
1
     */

    public static SinglyLinkedListNode ExtractAndAppendSponsoredNodes(SinglyLinkedListNode head)
    {
        var oddDummy = new SinglyLinkedListNode(-1);   // odd 鏈的 dummy head
        var oddTail = oddDummy;
        SinglyLinkedListNode? evenReversed = null;      // even 鏈用頭插法，邊拆邊反轉
        var curr = head;
        var i = 0;
        while (curr != null)
        {
            var next = curr.next;       // 先存下一個，等等要斷鏈
            if (i % 2 == 0)
            {
                // 頭插法 → 自動反轉
                curr.next = evenReversed;
                evenReversed = curr;
            }
            else
            {
                // 接到 odd 鏈尾端
                oddTail.next = curr;
                oddTail = curr;
                oddTail.next = null;    // 斷掉原本的 next
            }
            curr = next;
            i++;
        }
        // odd 鏈尾接上反轉後的 even 鏈
        oddTail.next = evenReversed;
        return oddDummy.next;
        }

}

public class SinglyLinkedListNode
{
    public int data;
    public SinglyLinkedListNode next;

    public SinglyLinkedListNode(int nodeData)
    {
        this.data = nodeData;
        this.next = null;
    }
}