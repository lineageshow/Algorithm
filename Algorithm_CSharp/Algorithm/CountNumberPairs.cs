namespace Algorithm;

public class CountNumberPairs
{
    /*
     *
Count Number Pairs
Given a sorted array of positive integers and a target value, count the number of pairs (i, j) 
where i < j and array[i] + array[j] <= target.

Example

Input:

prices = [1, 2, 3, 4, 5]
budget = 7
Output:

8
Explanation:

We need pairs (i, j) with i < j and prices[i] + prices[j] ≤ 7. List all pairs:

(1, 2) = 3 ≤ 7
(1, 3) = 4 ≤ 7
(1, 4) = 5 ≤ 7
(1, 5) = 6 ≤ 7
(2, 3) = 5 ≤ 7
(2, 4) = 6 ≤ 7
(2, 5) = 7 ≤ 7
(3, 4) = 7 ≤ 7
Pairs like (3,5)=8, (4,5)=9 exceed the budget. Total valid pairs = 8.

Input Format

The input is provided in two lines:

The first line contains two space-separated integers n and budget, where:

0 ≤ n ≤ 1000
1 ≤ budget ≤ 10^9
The second line contains n space-separated integers prices[0], prices[1], ..., prices[n-1], where:

1 ≤ prices[i] ≤ 10^9 for all 0 ≤ i < n
prices is sorted in non-decreasing order
Constraints

0 ≤ prices.length ≤ 1000
1 ≤ prices[i] ≤ 10^9 for all 0 ≤ i < prices.length
prices is sorted in non-decreasing order
1 ≤ budget ≤ 10^9
All inputs are integers
Output Format

Output a single integer representing the total count of unique index pairs (i, j) with 0 ≤ i < j < n such that prices[i] + prices[j] ≤ budget. If n < 2, output 0.

Sample Input 0

0
100
Sample Output 0

0
Sample Input 1

1
5
5
Sample Output 1

0
     */
    
    /// <summary>
    /// cannot resolve the problem
    /// </summary>
    /// <param name="prices"></param>
    /// <param name="budget"></param>
    /// <returns></returns>
    public int CountAffordablePairsWithBruteForce(List<int> prices, int budget)
    {
        var count = 0;
        for (int i = 0; i < prices.Count; i++)
        {
            for (int j = i + 1; j < prices.Count; j++)
            {
                if (prices[i] + prices[j] <= budget)
                {
                    count += 1;
                }
            }
        }

        return count;
    }
  
/*
 *
prices = [1, 2, 3, 4, 5]
budget = 7
Output:
8
1,5|1,4|1,3|1,2|
2,5|2,4|2,3|
--3,5
3,4

(1, 2) = 3 ≤ 7
(1, 3) = 4 ≤ 7
(1, 4) = 5 ≤ 7
(1, 5) = 6 ≤ 7
(2, 3) = 5 ≤ 7
(2, 4) = 6 ≤ 7
(2, 5) = 7 ≤ 7
(3, 4) = 7 ≤ 7
 */
    public int CountAffordablePairsWithSlidingWindow(List<int> prices, int budget)
    {
        if (prices.Count == 0)
        {
            return 0;
        }
        
        var count = 0;
        var left = 0;
        var right = prices.Count - 1;
        while (left < right)
        {
            var price = prices[left] + prices[right];
            if (price > budget)
                right--;
            else
            {
                count = count + right - left;
                left++;
            }
        }
        
        return count;
    }
}