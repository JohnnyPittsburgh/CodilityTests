using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodilityTests.PrimeAndCompositeNumbers
{
    [TestClass()]
    public class CountFactors
    {
        [TestMethod()]
        public void solutionTest()
        {
            Assert.AreEqual(8, solution(24));
        }



        public int solution(int N)
        {
            long i = 1;
            var factors = 0;

            while (i * i < N)
            {
                if (N % i == 0)
                    factors += 2;

                i++;
            }

            // Watch for prime
            if (i * i == N)
                factors++;

            return factors;
        }
    }
}