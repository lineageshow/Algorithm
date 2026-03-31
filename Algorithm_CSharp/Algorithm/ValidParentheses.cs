namespace Algorithm;

public class ValidParentheses
{
    /*
20. Valid Parentheses
Easy Topics:String,Stack
Hint
Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

An input string is valid if:

Open brackets must be closed by the same type of brackets.
Open brackets must be closed in the correct order.
Every close bracket has a corresponding open bracket of the same type.
 
Example 1:

Input: s = "()"

Output: true

Example 2:

Input: s = "()[]{}"

Output: true

Example 3:

Input: s = "(]"

Output: false

Example 4:

Input: s = "([])"

Output: true

Example 5:

Input: s = "([)]"

Output: false

 

Constraints:

1 <= s.length <= 104
s consists of parentheses only '()[]{}'. 
     */
    public bool IsValidWithStack(string s)
    {
        var stack = new Stack<char>();
        foreach (var chr in s)
        {
            if (chr == '(' || chr == '[' || chr == '{')
                stack.Push(chr);
            if (chr == ')' || chr == ']' || chr == '}')
            {
                if (stack.TryPeek(out var peek))
                {
                    if ((peek == '(' && chr == ')') || 
                        (peek == '[' && chr == ']') ||
                        (peek == '{' && chr == '}'))
                        stack.Pop();
                    else
                    {
                        return false;
                    }                    
                }
                else
                {
                    return false;
                }
                
                
            }
        }

        return stack.Count == 0;
    }

    public bool IsValidWithExpectedClosingStack(string s)
    {
        var stack = new Stack<char>();
        foreach (var c in s)
        {
            switch (c)
            {
                case '(':
                    stack.Push(')');
                    break;
                case '[':
                    stack.Push(']');
                    break;
                case '{':
                    stack.Push('}');
                    break;
                case ')':
                case ']':
                case '}':
                    if (!stack.TryPop(out var top) || top != c)
                        return false;
                    break;
            }
        }

        return stack.Count == 0;
    }
}