using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodilityTests.Johnny
{
    [TestClass()]
    public class Sandbox
    {
        [TestMethod()]
        public void solutionTest()
        {
            RecursionPrint(5);
        }

        public void RecursionPrint(int k)
        {
            Console.WriteLine($"Recursion({k}) begin");
            if (k == 0) return;
            RecursionPrint(k - 1);
            Console.WriteLine($"Recursion({k}) exit");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="W">Sorted array of weights</param>
        /// <param name="K">Canoe weight limit</param>
        /// <returns></returns>
        public int GreedyCanoeist(int[] W, int K)
        {
            var canoes = 0;
            var j = 0;
            var i = W.Length - 1;
            while (j > i)
            {
                if (W[i] + W[j] < K)
                    j += 1;

                canoes++;
                i -= 1;
            }

            return canoes;
        }


    }
}