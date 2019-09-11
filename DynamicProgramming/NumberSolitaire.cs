using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodilityTests.DynamicProgramming
{
    [TestClass()]
    public class NumberSolitaire
    {
        [TestMethod()]
        public void solutionTest()
        {
            var a = new[] { 1, -2, 0, 9, -1, -2 };
            Assert.AreEqual(8, solution(a));

            var b = new[] { 1, 3, 4 };
            Assert.AreEqual(8, solution(b));

            var c = new[] { 1, -2, 4 };
            Assert.AreEqual(5, solution(c));

            // Made some data where the max = max + -1 because it was repeated 6 times.
            var d = new[] { 1, -2, 0, 9, -1, -2, 5, -1, -1, -1, -1, -1, -1, 6 };
            Assert.AreEqual(20, solution(d));
        }

        /// <summary>
        /// https://app.codility.com/programmers/lessons/17-dynamic_programming/number_solitaire/
        /// </summary>
        /// <param name="A"></param>
        /// <returns></returns>
        public int solution(int[] A)
        {
            // Had to cheat and find a good solution.  Spent a lot of my morning banging my
            //  head on this one.  I get what's going on.  Have a sliding window that tracks
            // the max.
            const int sides = 6;
            var n = A.Length;

            // To reduce space, you only have to keep track of each side of dice. Reduces
            //  the space complexity to O(sides).
            var maxScore = new int[sides];
            for (var i = 0; i < sides; i++)
                maxScore[i] = A[0];

            // Iterate through each item and calculate the sliding maximum with the addition
            //  of the current element.  At the end of the for loop, the answer is in the correct positin.

            for (var i = 1; i < n; i++)
            {
                // Going to simplify and use the LinQ max function.  I broke out the values
                //  so I can print what's going on.  Helps with the understanding of the algorithm.
                var max = maxScore.Max();
                var index = i % sides;
                maxScore[index] = max + A[i];

                Console.WriteLine($"i={i} max={max} A[{i}]={A[i]} maxScore[{index}]={maxScore[index]}");
            }

            // Notice the tricky use of the modulo on the return.  This ensures we return the last
            //  maximum value calculated.
            return maxScore[(n - 1) % sides];
        }
    }
}