using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Solution
{
    public int CarFleet(int target, int[] position, int[] speed)
    {
        int fleetCount = 0;
        int[] sortedIndex = position.Select((val, i) => new { value = val, index = i })
                                    .OrderByDescending(v => v.value).Select(i => i.index).ToArray();
        Stack<double> timeStack = new Stack<double>();
        foreach (int index in sortedIndex)
        {
            int distance = target - position[index];
            double timeNeeded = (double)distance / (double)speed[index];
            if (timeStack.Count > 0)
            {
                double carFleetTime = timeStack.Peek();
                //Console.WriteLine($"CarFleetTime Needed: {carFleetTime}, timeNeeded: {timeNeeded}");
                if(carFleetTime < timeNeeded)
                {
                    fleetCount++;
                    timeStack.Pop();
                    timeStack.Push(timeNeeded);
                }
            }
            else
            {
                timeStack.Push(timeNeeded);
            }
        }
        while(timeStack.Count > 0)
        {
            timeStack.Pop();
            fleetCount++;
        }
        return fleetCount;
    }
}