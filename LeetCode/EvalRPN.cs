using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Solution
{
    public int EvalRPN(string[] tokens)
    {
        Stack<string> stack = new Stack<string>();
        int var1;
        int var2;
        foreach (string token in tokens)
        {
            switch (token)
            {
                case "+":
                    stack.Push( (Int32.Parse(stack.Pop()) + Int32.Parse(stack.Pop())).ToString() ); 
                    break;
                case "-":
                    var1 = Int32.Parse(stack.Pop());
                    var2 = Int32.Parse(stack.Pop());
                    stack.Push((var2 - var1).ToString());
                    break;
                case "*":
                    var1 = Int32.Parse(stack.Pop());
                    var2 = Int32.Parse(stack.Pop());
                    stack.Push((var2 * var1).ToString());
                    break;
                case "/":
                    var1 = Int32.Parse(stack.Pop());
                    var2 = Int32.Parse(stack.Pop());
                    stack.Push((var2 / var1).ToString());
                    break;
                default:
                    stack.Push(token);
                    break;
            }
        }
        return Int32.Parse(stack.Pop());
    }
}
