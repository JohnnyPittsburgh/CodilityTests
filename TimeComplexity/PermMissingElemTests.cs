using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodilityTests.TimeComplexity
{
    [TestClass()]
    public class PermMissingElemTests
    {
        [TestMethod()]
        public void solutionTest()
        {
            var a = new[] {2,3,1,5};
            Assert.AreEqual(4, solution(a));

            var b = new[] {2, 4, 5, 3};
            Assert.AreEqual(1, solution(b));
        }

        public int solution(int[] A)
        {
            var missing = 1;
            Array.Sort(A);

            foreach (var t in A)
            {
                if (t == missing)
                    missing = t + 1;
            }

            return missing;
        }
    }
}