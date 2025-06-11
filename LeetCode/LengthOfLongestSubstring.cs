using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        Dictionary<char, int> chars = new Dictionary<char, int>();
        int maxLength = 0;
        int start = 0;
        for(int current = 0; current < s.Length; current++)
        {
            if (chars.ContainsKey(s[current]))
            {
                if(maxLength < current - start)
                {
                    maxLength = current - start;
                }
                // Reset index and dictionary to check for next substring
                start = chars[s[current]] + 1;
                if(maxLength >= s.Length - start)
                {
                    break;
                }
                current = start;
                chars.Clear();
            }
            chars[s[current]] = current;
        }
        if(maxLength < s.Length - start)
        {
            maxLength = s.Length - start;
        }
        return maxLength;
    }
}