using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * Definition of Interval:
 * public class Interval {
 *     public int start, end;
 *     public Interval(int start, int end) {
 *         this.start = start;
 *         this.end = end;
 *     }
 * }
 */

public class Solution
{
    bool[] scheduled = new bool[1000000];

    public bool CanAttendMeetings(List<Interval> intervals)
    {
        foreach(Interval interval in intervals)
        {
            for (int i = interval.start; i < interval.end; i++)
            {
                if(scheduled[i])
                {
                    return false;
                }
                scheduled[i] = true;
            }
        }
        return true;
    }
}
