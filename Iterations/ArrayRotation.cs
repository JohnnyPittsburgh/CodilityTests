using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodilityTests.Iterations
{
    [TestClass()]
    public class ArrayRotation
    {
        [TestMethod()]
        public void solutionTest()
        {
            var a = new[] {1,2,3,4,5};
            var b = new[] {4, 5, 1, 2, 3};

            CollectionAssert.AreEqual(b, solution(a, 2));
            CollectionAssert.AreEqual(b, solution(a, 7));
        }

        public int[] solution(int[] A, int K)
        {
            if (A == null)
                return A;

            if (A.Length <= 1)
                return A;

            var rotate = K;
            if (K > A.Length)
             rotate = K % A.Length;

            var resultArray = new int[A.Length];

            var start = A.Length- rotate;

            Array.Copy(A, start, resultArray, 0, rotate);
            Array.Copy(A, 0, resultArray, rotate, start );

            return resultArray;
        }
    }
}