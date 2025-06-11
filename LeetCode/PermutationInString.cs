using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

public class Solution
{
    public bool CheckInclusion(string s1, string s2)
    {
        Dictionary<char, int> dict = new();
        foreach(char c in s1)
        {
            if(dict.ContainsKey(c))
            {
                dict[c] = dict[c] + 1;
            }
            else
            {
                dict[c] = 1;
            }
            //Console.WriteLine($"char {c} at {dict[c]}");
        }

        int pointer1 = 0;
        int pointer2 = 0;
        // if true, move pointer 2 to the right when you find and remove char from dict
        // if false move pointer 1 to the right and if pointer 1 is less than or equal to pointer 2, add char back into dict
        // if pointer 2 is less than move to pointer 1 position
        while(dict.Count > 0 && pointer2  < s2.Length)
        {
            int charCount = 0;
            //Console.WriteLine($"pointer1 {pointer1}, pointer2 {pointer2}");
            if (dict.TryGetValue(s2[pointer2],out charCount))
            {
                if(charCount == 1)
                {
                    dict.Remove(s2[pointer2]);
                } else
                {
                    dict[s2[pointer2]] = charCount - 1;
                }
                pointer2++;
            }
            else if(pointer1 == pointer2)
            {
                pointer1++;
                pointer2++;
            } else
            {
                if (!dict.TryAdd(s2[pointer1], 1))
                {
                    dict[s2[pointer1]] = dict[s2[pointer1]] + 1;
                }
                pointer1++;
            }
        }
        return dict.Count == 0;
    }
}
