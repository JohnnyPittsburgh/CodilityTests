using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodilityTests.CountingElements
{
    [TestClass()]
    public class MissingInteger
    {
        [TestMethod()]
        public void solutionTest()
        {
            var a = new[] { 1, 3, 6, 4, 1, 2 };
            Assert.AreEqual(solution(a), 5);

            var b = new[] { 1, 2, 3, 5 };
            Assert.AreEqual(solution(b), 4);

            var c = new[] { -1, -3 };
            Assert.AreEqual(solution(c), 1);

            var d = new[] {4, 5, 6, 2};
            Assert.AreEqual(solution(d), 1);

        }

        public int solution(int[] A)
        {
            var exists = new Dictionary<int, bool>();

            foreach (var num in A)
            {
                if (num < 1) continue;

                if (!exists.ContainsKey(num))
                    exists.Add(num, true);
            }

            // didn't add any numbers
            if (exists.Count == 0)
                return 1;

            var max = exists.Keys.Max() + 1;

            for(var i=1; i<= max; i++)
            {
                if (!exists.ContainsKey(i))
                    return i;
            }

            return 1;
        }
    }
}