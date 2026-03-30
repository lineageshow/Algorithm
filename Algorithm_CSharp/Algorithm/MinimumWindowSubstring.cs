namespace Algorithm;

public class MinimumWindowSubstring
{
    /*
     *
76. Minimum Window Substring
Hard Topics:Hash Table,String,Sliding Window

Hint

Given two strings s and t of lengths m and n respectively, return the minimum window substring of s such that every character 
in t (including duplicates) is included in the window. If there is no such substring, return the empty string "".

The testcases will be generated such that the answer is unique.

Example 1:
Input: s = "ADOBECODEBANC", t = "ABC"
Output: "BANC"
Explanation: The minimum window substring "BANC" includes 'A', 'B', and 'C' from string t.

Example 2:
Input: s = "a", t = "a"
Output: "a"
Explanation: The entire string s is the minimum window.

Example 3:
Input: s = "a", t = "aa"
Output: ""
Explanation: Both 'a's from t must be included in the window.
Since the largest window of s only has one 'a', return empty string.
 

Constraints:

m == s.length
n == t.length
1 <= m, n <= 105
s and t consist of uppercase and lowercase English letters.
 

Follow up: Could you find an algorithm that runs in O(m + n) time?

     */
    public string MinWindowWithSlidingWindow(string s, string t) 
    {
        if (t.Length > s.Length)
        {
            return "";
        }

        var dictT = new Dictionary<char, int>();
        foreach (var chr in t)
        {
            if (!dictT.TryAdd(chr, 1))
            {
                dictT[chr]++;
            }
        }

        
        var left = 0;
        var right = 0;
        var dictS = new Dictionary<char, int>();        
        var formed = 0;
        var minWindowStart = 0;
        var minWindowLength = int.MaxValue;
        while (right < s.Length)
        {
            // add s string to dictS
            if (!dictS.TryAdd(s[right], 1))
            {
                dictS[s[right]]++;
            }
            
            if(dictT.TryGetValue(s[right], out var value) && dictS[s[right]] == dictT[s[right]])
            {
                formed++;
            }
            //When dictS covered dictT then do inner loop to move left pointer
            while (formed == dictT.Count)
            {
                // update minimum window size
                if(right - left + 1 < minWindowLength)
                {
                    minWindowStart = left;
                    minWindowLength = right - left + 1;
                }
                if(dictT.TryGetValue(s[left], out var valueT) && dictS[s[left]] == valueT)
                {
                    formed--;
                }
                
                dictS[s[left]]--;
                left++;
            }
            
            right++;
        }
        
        return minWindowLength == int.MaxValue ? "" : s.Substring(minWindowStart, minWindowLength);
    }
}