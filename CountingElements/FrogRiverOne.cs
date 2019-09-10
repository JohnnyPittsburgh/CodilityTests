using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodilityTests.CountingElements
{
    [TestClass()]
    public class FrogRiverOne
    {
        [TestMethod()]
        public void solutionTest()
        {
            var a = new[] {1, 3, 1, 4, 2, 3, 5, 4};

            Assert.AreEqual(solution(5, a), 6);

        }


        public int solution(int X, int[] A)
        {
            // Invalid
            if (A == null)
                return -1;

            // Not enough leaves
            if (A.Length < X)
                return -1;

            var leafOnRiver = new bool[X];

            var desiredSum = (X * (X + 1)) / 2;
            var currentSum = 0;

            for (var i = 0; i < A.Length; i++)
            {
                if (A[i] > X)
                    continue;

                var pos = A[i] - 1;
                if (!leafOnRiver[pos])
                {
                    leafOnRiver[pos] = true;
                    currentSum += A[i];

                    if (desiredSum == currentSum)
                        return i;
                }
            }

            return -1;
        }

        
        



    }
}