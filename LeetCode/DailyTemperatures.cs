using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Solution
{
    public int[] DailyTemperatures(int[] temperatures)
    {
        Stack<int> stack = new Stack<int>();
        int[] answer = new int[temperatures.Length];
        for(int i = temperatures.Length - 1; i >= 0; i--)
        {
            answer[i] = 0;
            int day;
            while(stack.Count > 0)
            {
                day = stack.Pop();
                if(temperatures[day] > temperatures[i])
                {
                    //Console.WriteLine($"Comparing day {i} and setting answer {day - i}");
                    answer[i] = day - i;
                } else if (answer[day] != 0)
                {
                    stack.Push(day + answer[day]);
                    //Console.WriteLine($"Comparing day {i} and pushing {day + answer[day]}");
                }
            }
            stack.Push(i);
            //Console.WriteLine($"pushed day {i}, with answer {answer[i]}");
        }
        return answer;
    }
}