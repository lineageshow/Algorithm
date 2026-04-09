namespace Algorithm;

public class KthLargestElementInAnArray
{
    public int FindKthLargestWithPriorityQueue(int[] nums, int k)
    {
        var minHeap = new PriorityQueue<int, int>();
        for (var i = 0; i < nums.Length; i++)
        {
            minHeap.Enqueue(i, nums[i]);
            if (minHeap.Count > k)
            {
                minHeap.Dequeue();
            }
        }
        
        var result = minHeap.Count > 0 ? minHeap.Dequeue() : 0;
        return nums[result];
    }
}