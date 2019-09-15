using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodilityTests.Johnny
{
    [TestClass()]
    public class Sandbox
    {
        [TestMethod()]
        public void solutionTest()
        {
            RecursionPrint(5);
        }

        public void RecursionPrint(int k)
        {
            Console.WriteLine($"Recursion({k}) begin");
            if (k == 0) return;
            RecursionPrint(k - 1);
            Console.WriteLine($"Recursion({k}) exit");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="W">Sorted array of weights</param>
        /// <param name="K">Canoe weight limit</param>
        /// <returns></returns>
        public int GreedyCanoeist(int[] W, int K)
        {
            var canoes = 0;
            var j = 0;
            var i = W.Length - 1;
            while (j > i)
            {
                if (W[i] + W[j] < K)
                    j += 1;

                canoes++;
                i -= 1;
            }

            return canoes;
        }

        /// <summary>
        /// Roof is an array of 0's and 1's.  1 represents a hole.
        /// You are given a number of same length boards. 
        /// Determine the minimum length of of the boards.
        /// </summary>
        /// <param name="roof">Roof with holes in it. 1 = hole,  0 = not hole</param>
        /// <param name="K">Number of boards</param>
        /// <returns>Minimum length of boards</returns>
        public int BoardsBinary(int[] roof, int K)
        {
            var len = roof.Length;
            var begin = 1;
            var end = len;
            var result = -1;

            while (begin <= end)
            {
                var mid = (begin + end) / 2;
                if (BoardCheck(roof, K) <= K)
                {
                    end = mid - 1;
                    result = mid;
                }
                else
                {
                    begin = mid + 1;
                }               
            }

            return result;
        }

        private int BoardCheck(int[] roof, int k)
        {
            var len = roof.Length;
            var boards = 0;
            var last = -1;
            for(var i=0; i<len; i++)
            {
                if (roof[i] == 1 && last < i)
                {
                    boards += 1;
                    last = i + k - 1;
                }
            }
            return boards;
        }
    }
}