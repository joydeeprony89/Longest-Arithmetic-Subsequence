using System;
using System.Collections.Generic;

namespace Longest_Arithmetic_Subsequence
{
  class Program
  {
    static void Main(string[] args)
    {
      int[] nums = new int[] { 20, 1, 15, 3, 10, 5, 8 };
      Solution s = new Solution();
      var answer = s.LongestArithSeqLength(nums);
      Console.WriteLine(answer);
    }
  }

  public class Solution
  {
    public int LongestArithSeqLength(int[] nums)
    {
      // the idea is here at each index we will calculate the diff bw current index - previous index no. 
      // we update the dictinary with the diff as key and value as 2 at any index.
      // why value 2 ??? coz atleast we need two element to get the diff and if all the diffs are unique still our result should be 2 atleast.
      // at any inedx, the diff frequency is stored in dictionary of diff as key
      // if we have found the same diff again then will add +1 with the last diff key value.
      int longest = 0;
      Dictionary<int, int>[] dp = new Dictionary<int, int>[nums.Length];
      for (int i = 0; i < nums.Length; i++)
      {
        dp[i] = new Dictionary<int, int>();
      }

      for (int i = 0; i < nums.Length; i++)
      {
        for (int j = 0; j < i; j++)
        {
          int diff = nums[i] - nums[j];
          // set the dp 
          // i is the index and diff is the key for dictionary
          // at ith index the diff frequency is 
          dp[i][diff] = (dp[j].ContainsKey(diff) ? dp[j][diff] : 1) + 1;
          longest = Math.Max(longest, dp[i][diff]);
        }
      }

      return longest;
    }
    public bool SequenceIsArithmetic(int[] nums)
    {
      if (nums.Length == 1) return true;

      HashSet<int> hash = new HashSet<int>();
      int min = int.MaxValue;
      int max = int.MinValue;
      foreach (int n in nums)
      {
        min = Math.Min(min, n);
        max = Math.Max(max, n);
        hash.Add(n);
      }

      int d = (max - min) / (nums.Length - 1);
      for (int i = 0; i < nums.Length; i++)
      {
        int n = min + d * i;
        if (!hash.Contains(n)) return false;
      }

      return true;
    }
  }
}
