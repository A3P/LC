using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Solution
{
    public void ReverseString(char[] s)
    {
        int cur1 = 0;
        int cur2 = s.Length -1;
        char temp;

        while (cur1 < cur2)
        {
            temp = s[cur1];
            s[cur1] = s[cur2];
            s[cur2] = temp;
            cur1++;
            cur2--;
        }
    }
}