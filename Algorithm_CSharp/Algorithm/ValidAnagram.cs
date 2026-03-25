using System.Text;

namespace Algorithm;

public class ValidAnagram
{
    /*
242. Valid Anagram
Solved
Easy
Topics
premium lock icon
Companies
Given two strings s and t, return true if t is an anagram of s, and false otherwise.

 

Example 1:

Input: s = "anagram", t = "nagaram"

Output: true

Example 2:

Input: s = "rat", t = "car"

Output: false

 

Constraints:

1 <= s.length, t.length <= 5 * 104
s and t consist of lowercase English letters.
 

Follow up: What if the inputs contain Unicode characters? How would you adapt your solution to such a case?
     */
    public bool IsAnagramWithBruteForce(string s, string t)
    {
        if (s.Length != t.Length)
        {
            return false;
        }

        var tSB = new StringBuilder(t);
        for (int i = 0; i < s.Length; i++)
        {
            for (int j = 0; j < t.Length; j++)
            {
                if (s[i] == t[j])
                {
                    t = t.Remove(j, 1);
                    break;
                }
            }
        }

        return t.Length == 0;
    }

    public bool IsAnagramWithFrequencyCount(string s, string t)
    {
        if (s.Length != t.Length)
        {
            return false;
        }

        var count = new int[26];
        for (int i = 0; i < s.Length; i++)
        {
            count[s[i] - 'a']++;
            count[t[i] - 'a']--;
        }

        for (int i = 0; i < 26; i++)
        {
            if (count[i] != 0)
            {
                return false;
            }
        }

        return true;
    }

    public bool IsAnagramWithDictionary(string s, string t){
        if (s.Length != t.Length)
            return false;
        
        var dictS = new Dictionary<char, int>();
        var dictT = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++)
        {
            if (!dictS.TryAdd(s[i], 1))
                dictS[s[i]]++;
            if (!dictT.TryAdd(t[i], 1))
                dictT[t[i]]++;
        }
        foreach (var keyValue in dictS)
        {
            if (!dictT.TryGetValue(keyValue.Key, out var v))
                return false;
            if (keyValue.Value != v)
                return false;
        }
        return true;
    }
}