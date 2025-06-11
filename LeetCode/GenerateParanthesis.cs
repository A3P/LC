using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Solution
{
    public IList<string> GenerateParenthesis(int n)
    {
        Stack<char> stack = new Stack<char>();
        return AddValidParenthesis(n, "", stack);
    }

    public IList<string> AddValidParenthesis(int n, string s, Stack<char> stack) 
    {
        int stringCount = s.Length;
        IList<string> list = new List<string>();
        Console.WriteLine($"At level {s}, with stackCount {stack.Count}");
        if(s.Length == n*2)
        {
            Console.WriteLine($"RETURN {s}");
            return new List<string> {s};
        }

        if(stack.Count < (n*2) - s.Length)
        {
            Stack<char> openStack = new Stack<char>(stack);
            openStack.Push('(');
            String openString = s + "(";
            list = list.Concat(AddValidParenthesis(n, openString, openStack)).ToList<string>();
        }
        if(stack.Count > 0){
            Stack<char> closeStack = new Stack<char>(stack);
            closeStack.Pop();
            String closeString = s + ")";
            list = list.Concat(AddValidParenthesis(n, closeString, closeStack)).ToList<string>();
        }
        return list;
    }
}