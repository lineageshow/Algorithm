namespace Algorithm;

public class GroupAnagrams
{
    /*
49. Group Anagrams
Medium Topics:Array, Hash Table, String, Sorting

Given an array of strings strs, group the anagrams together. You can return the answer in any order.

Example 1:

Input: strs = ["eat","tea","tan","ate","nat","bat"]

Output: [["bat"],["nat","tan"],["ate","eat","tea"]]

Explanation:

There is no string in strs that can be rearranged to form "bat".
The strings "nat" and "tan" are anagrams as they can be rearranged to form each other.
The strings "ate", "eat", and "tea" are anagrams as they can be rearranged to form each other.
Example 2:

Input: strs = [""]

Output: [[""]]

Example 3:

Input: strs = ["a"]

Output: [["a"]]

Constraints:

1 <= strs.length <= 104
0 <= strs[i].length <= 100
strs[i] consists of lowercase English letters.
     */
    public IList<IList<string>> GroupAnagramsWithDictionary(string[] strs) 
    {
        if (strs.Length == 1)
        {
            return  new List<IList<string>> {strs};
        }
        var result = new List<IList<string>>();
        for (int i = 0; i < strs.Length; i++)
        {
            var tester = strs[i];
            result[i].Add(tester);
            for (int j = 0; j < strs.Length - i + 1; j++)
            {
                if (ValidAnagram(tester, strs[j]))
                {
                    result[i].Add(strs[j]);
                }
            }
        }
        return result;
    }

    private bool ValidAnagram(string s, string t)
    {
        if (s.Length != t.Length)
            return false;
        
        var dictS = new Dictionary<char, int>();
        var dictT = new Dictionary<char, int>();

        for (int i = 0; i < s.Length; i++)
        {
            if (!dictS.TryAdd(s[i], 1))
            {
                dictS[s[i]]++;
            }

            if (!dictT.TryAdd(t[i], 1))
            {
                dictT[t[i]]++;
            }
        }

        foreach (var keyValue in dictS)
        {
            if (dictT.TryGetValue(keyValue.Key,  out var v))
            {
                if (keyValue.Value != v)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        return true;
    }
}