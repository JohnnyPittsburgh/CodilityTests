using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodilityTests.CountingElements
{
    [TestClass()]
    public class PermCheck
    {
        [TestMethod()]
        public void solutionTest()
        {
            var a = new[] {4, 1, 3, 2};
            var b = new[] {4, 1, 3};
            Assert.AreEqual(solution(a), 1);
            Assert.AreEqual(solution(b), 0);
        }

        public int solution(int[] A)
        {
            if (A == null || A.Length == 0)
                return 0;

            Array.Sort(A);

            for (var i = 0; i < A.Length; i++)
            {
                if (A[i] != i + 1)
                    return 0;
            }

            return 1;
        }
    }
}