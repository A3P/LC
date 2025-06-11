public class Solution {

    private int target;
    private int[] cache;

    public int ClimbStairs(int n) {
        cache = new int[n];
        target = n;
        return CountSteps(0);
    }

    private int CountSteps(int n) {
        //Console.WriteLine($"counting at {n}");
        if (cache.ContainsKey(n))
        {
            return cache[n];
        }
        if(n == target) {
            return 1;
        } else if(n < target) {
            int v1 = CountSteps(n+1);
            int v2 = CountSteps(n+2);
            cache.Add(n, v1+v2);
            return v1 + v2;
        }
        return 0;
    }
}