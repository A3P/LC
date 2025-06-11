using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Solution
{
    public string ReverseWords(string s)
    {
        string[] words = s.Split(' ');
        for(int i = 0;i < words.Length;i++)
        {
            char[] chars = words[i].ToCharArray();
            int cur1 = 0;
            int cur2 = chars.Length - 1;
            char temp;
            while(cur1 < cur2)
            {
                temp = chars[cur1];
                chars[cur1] = chars[cur2];
                chars[cur2] = temp;
                cur1++;
                cur2--;
            }
            words[i] = string.Join("", chars);
        }
        return string.Join(" ", words);
    }
}