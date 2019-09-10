using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodilityTests.TimeComplexity
{
    [TestClass()]
    public class FrogJmpTests
    {
        [TestMethod()]
        public void solutionTest()
        {
            Assert.AreEqual(3, solution(10, 85, 30));
            Assert.AreEqual(0, solution(10, 10, 30));
            Assert.AreEqual(1, solution(10, 11, 30));
        }

        public int solution(int X, int Y, int D)
        {
            var distance = Y - X;
            if (distance == 0)
                return 0;

            var jumps = distance / D;
            if (jumps <= 1)
                return 1;

            if (distance % D > 0)
                jumps++;

            return jumps;
        }
    }
}