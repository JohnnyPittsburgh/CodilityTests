using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodilityTests.Iterations
{
    [TestClass()]
    public class BinaryGap
    {
        [TestMethod()]
        public void solutionTest()
        {
            BitTest(-8965574);

            Assert.AreEqual(0, solution(0));
            Assert.AreEqual(0, solution(1));
            Assert.AreEqual(0, solution(2));
            Assert.AreEqual(0, solution(3));
            Assert.AreEqual(0, solution(4));
            Assert.AreEqual(1,solution(5));
            Assert.AreEqual(2, solution(9));
            Assert.AreEqual(3, solution(-8965574));
        }

        public void BitTest(int N)
        {
            var binaryString = Convert.ToString(N, 2);
            Console.WriteLine($"{N} = 0x{binaryString}");
        }

        public int solution(int N)
        {            
            // No work if zero
            if (N == 0)
                return 0;

            var binaryChars = Convert.ToString(N, 2).ToCharArray();

            var start = binaryChars.Length - 1;

            if (start < 2)
                return 0;

            // remove trailing zeros, test 0, 1, 2, 3, 4
            while (binaryChars[start] == '0')
            {
                start--;
            }

            var maxZeros = 0;
            var currentZeros = 0;
            while (start >= 0)
            {
                if (binaryChars[start] == '1')
                {
                    if (currentZeros > maxZeros)
                    {
                        maxZeros = currentZeros;
                    }
                    currentZeros = 0;
                }

                else
                {
                    currentZeros++;
                }
                start--;
            }
           
            return maxZeros;
        }
    }
}