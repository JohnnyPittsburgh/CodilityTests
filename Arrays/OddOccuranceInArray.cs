using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodilityTests.Arrays
{
    [TestClass()]
    public class OddOccurancesInArray
    {
        [TestMethod()]
        public void solutionTest()
        {
            var a = new[] {9, 3, 9, 3, 9, 7, 9};
            Assert.AreEqual(7, solution(a));
        }

        public int solution(int[] A)
        {
            var res = 0;
            foreach (var t in A)
            {
                res ^= t;
            }

            return res;
        }
    }
}