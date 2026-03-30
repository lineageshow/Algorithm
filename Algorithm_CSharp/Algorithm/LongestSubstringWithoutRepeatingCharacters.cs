namespace Algorithm;

public class LongestSubstringWithoutRepeatingCharacters
{
    /*
     *
3. Longest Substring Without Repeating Characters
Medium Topics:Staff, HashTable String Sliding Window

Hint
Since maximum string size is at most 26, generate and check all possible substrings with length at most 26.

Given a string s, find the length of the longest substring without duplicate characters.

Example 1:

Input: s = "abcabcbb"
Output: 3
Explanation: The answer is "abc", with the length of 3. Note that "bca" and "cab" are also correct answers.
Example 2:

Input: s = "bbbbb"
Output: 1
Explanation: The answer is "b", with the length of 1.
Example 3:

Input: s = "pwwkew"
Output: 3
Explanation: The answer is "wke", with the length of 3.
Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
 

Constraints:

0 <= s.length <= 5 * 104
s consists of English letters, digits, symbols and spaces.
     * 
     */
    public int LengthOfLongestSubstringBruteForce(string s)
    {
        if (s.Length <= 1)
            return s.Length;
        
        var left = 0;
        var count = 0;
        while (left < s.Length)
        {
            var index = left;
            var dict =  new Dictionary<char, int>();
            var maxCountForCurrentWindow = 0;
            // if char is repeated, then left++ else count+=1 
            while (index < s.Length)
            {
                if (!dict.TryAdd(s[index],1))
                {
                    break;
                }

                maxCountForCurrentWindow += 1;
                index++;
            }

            if (count < maxCountForCurrentWindow)
            {
                count = maxCountForCurrentWindow;
            }
            
            left++;
        }
        return count;
    }
    
    
/*
 * abcabcbb
 bca    b
 cab    c
 abc    a
 abc    b
 bc     b
 cb     b
 
 */
    public int LengthOfLongestSubstringSlidingWindow(string s)
    {
        if (s.Length <= 1)
            return s.Length;

        var left = 0;
        var right = 0;
        var result = 0;
        var dict = new  Dictionary<char, int>();
        while (right < s.Length)
        {
            
            if (dict.TryAdd(s[right], right))
            {
                right++;
            }
            else
            {
                dict.Remove(s[left]);
                left++;
            }

            result = Math.Max(result, right - left);
        }

        return result;
    }

    public int LengthOfLongestSubstringSlidingWindowLastIndex(string s)
    {
        if (s.Length <= 1)
            return s.Length;

        var left = 0;
        var right = 0;
        var result = 0;
        var dict = new  Dictionary<char, int>();
        while (right < s.Length)
        {
            
            // index is the last index of the character, 
            // if the character is repeated, then left = max(left, index + 1)
            // then update the last index of the character
            if(dict.TryGetValue(s[right], out var index))
            {
                left = Math.Max(left, index + 1);
            }
            // update the last index of the character
            dict[s[right]] = right;
            right++;
            result = Math.Max(result, right - left);
        }

        return result;
    }
}