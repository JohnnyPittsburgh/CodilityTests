using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodilityTests.Johnny
{
    [TestClass()]
    public class Recursion
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

    }
}