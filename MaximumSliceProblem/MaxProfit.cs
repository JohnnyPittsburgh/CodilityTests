using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodilityTests.MaximumSliceProblem
{
    [TestClass()]
    public class MaxProfit
    {
        [TestMethod()]
        public void solutionTest()
        {
            var a = new[] { 5, -7, 3, 5, -2, 4, -1 };
            Assert.AreEqual(10, MaxSliceProblem(a));


            var b = new[] {23171, 21011, 21123, 21366, 21013, 21367};
            Assert.AreEqual(356, solution(b));
        }


        public int solution(int[] A)
        {
            // Sanity checks.  If the length is 0 or 1 cannot take a difference
            if (A == null || A.Length < 2)
                return 0;

            var maxEnd = 0;
            var maxSlice = 0;

            for(var i=1; i<A.Length; i++)
            {
                var delta = A[i] - A[i - 1];
                maxEnd = Math.Max(0, maxEnd + delta);
                maxSlice = Math.Max(maxSlice, maxEnd);
            }

            // Ensure the profit is positive or return 0.
            return maxSlice > 0 ? maxSlice : 0;
        }


        /// <summary>
        /// This problem was in the reading material and I had to look
        /// up the O(n) algorithm.  Tricky but simple.
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public int MaxSliceProblem(int[] A)
        {
            if (A == null || A.Length == 0)
                return 0;

            var max = A[0];
            var sum = 0;

            foreach (var num in A)
            {
                sum += num;
                sum = Math.Max(sum, num);
                max = Math.Max(max, sum);
            }

            return max;
        }





    }
}