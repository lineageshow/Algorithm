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

        // Sorting each string in the array
        var sortedStrs = strs.Select(s => string.Concat(s.OrderBy(c => c))).ToArray();
        // Grouping the strings by the sorted string
        var dict = new Dictionary<string, List<string>>();
        for (int i = 0; i < sortedStrs.Length; i++)
        {
            if (!dict.TryAdd(sortedStrs[i], new List<string> { strs[i] }))
                dict[sortedStrs[i]].Add(strs[i]);
        }
        return dict.Values.ToList<IList<string>>();
        
    }

}