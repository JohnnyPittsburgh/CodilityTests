using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodilityTests.Sorting
{
    [TestClass()]
    public class MaxProductOfThree
    {
        [TestMethod()]
        public void solutionTest()
        {
            var a = new[] {-3, 1, 2, -2, 5, 6};
            Assert.AreEqual(60, solution(a));

            var b = new[] {-8, -9, 7, 8, 2, 1};
            Assert.AreEqual(576, solution(b));
        }

        public int solution(int[] A)
        {
            // Sanity Check
            var len = A.Length;
            if (A == null || len < 3)
                return 0;

            Array.Sort(A);

            // Get two largest negative numbers
            var negativeMax = A[0] * A[1] * A[len-1];

            // Get the three largest positive numbers
            var positiveMax = A[len - 1] * A[len - 2] * A[len - 3];

            return negativeMax > positiveMax ? negativeMax : positiveMax;
        }
    }
}