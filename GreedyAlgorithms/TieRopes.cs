using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodilityTests.GreedyAlgorithms
{
    [TestClass()]
    public class TieRopes
    {
        [TestMethod()]
        public void solutionTest()
        {
            var a = new[] { 1, 2, 3, 4, 1, 1, 3 };
            Assert.AreEqual(3, solution(4, a));

        }

        /// <summary>
        /// https://app.codility.com/programmers/lessons/16-greedy_algorithms/tie_ropes/
        /// </summary>
        /// <param name="K"></param>
        /// <param name="A"></param>
        /// <returns></returns>
        public int solution(int K, int[] A)
        {
            // Took a little time to understand why this can be greedy.
            //  Only adjacent ropes can be tied. So you have to take what you
            //  are given until it exceeds the length.  Then start again.
            var ropes = 0;
            var ropeLength = 0;

            foreach (var segment in A)
            {
                // Keep tying ropes together until we exceed the desired length.
                ropeLength = ropeLength + segment;
                if (ropeLength < K) continue;

                // Exceeded the desired length, start again.
                ropes++;
                ropeLength = 0;
            }
            
            return ropes;
        }
    }
}