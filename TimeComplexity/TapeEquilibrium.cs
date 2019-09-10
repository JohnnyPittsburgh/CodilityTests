using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodilityTests.TimeComplexity
{
    [TestClass()]
    public class TapeEquilibrium
    {
        [TestMethod()]
        public void solutionTest()
        {
            var a = new[] {3,1,2,4,3};
            Assert.AreEqual(1, solution(a));

            var b = new[] { -1000, 1000 };
            Assert.AreEqual(2000,solution(b));
        }

        public int solution(int[] A)
        {
            // tape cannot be split
            if (A == null || A.Length == 1)
                return 0;

            // Just 2
            if (A.Length == 2)
                return Math.Abs(A[0] - A[1]);

            var left = A[0];
            var right = A.Sum() - left;
            var min = Math.Abs(left - right);
            for(var i=1; i<A.Length-1; i++)
            {
                left += A[i];
                right -= A[i];
                var diff = Math.Abs(left - right);
                if (diff < min)
                    min = diff;
            }

            return min;
        }
    }
}