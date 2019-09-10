using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodilityTests
{
    [TestClass()]
    public class SampleTests
    {
        [TestMethod()]
        public void solutionTest()
        {
            Assert.AreEqual(solution(0), 0);

            var a = new[] { 1, 2, 3, 4, 5 };
            CollectionAssert.AreEqual(a, solution2(a));
        }

        public int solution(int K)
        {
            return K;
        }

        public int[] solution2(int[] A)
        {
            return A;
        }
    }
}