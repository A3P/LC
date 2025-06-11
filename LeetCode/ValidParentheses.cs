using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Solution
{
    public bool IsValid(string s)
    {
        Stack<string> stack = new Stack<string>();
        foreach (char c in s)
        {
            if (c == '(')
            {
                stack.Push("(");
            }
            else if (c == ')')
            {
                if (stack.Count == 0 || stack.Pop() != "(")
                {
                    return false;
                }
            }
            else if (c == '[')
            {
                stack.Push("[");

            }
            else if (c == ']')
            {
                if (stack.Count == 0 || stack.Pop() != "[")
                {
                    return false;
                }
            }
            else if (c == '{')
            {
                stack.Push("{");

            }
            else if (c == '}')
            {
                if (stack.Count == 0 || stack.Pop() != "{")
                {
                    return false;
                }
            }
        }
        if (stack.Count == 0)
        {
            return true;
        }
        return false;
    }
}
