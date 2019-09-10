using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodilityTests.Leader
{
    [TestClass()]
    public class Dominator
    {
        [TestMethod()]
        public void solutionTest()
        {
            var a = new[] { 3, 4, 3, 2, 3, -1, 3, 3 };
            Assert.AreEqual(7, solution(a));

            var b = new[] { 3, 3 };
            Assert.AreEqual(1, solution(b));

            var c = new[] { 3 };
            Assert.AreEqual(0, solution(c));

            var d = new[] { 3, 4, 3, 2, 3, -1 };
            Assert.AreEqual(-1, solution(d));

            Assert.AreEqual(-1, solution(new int[0]));

            Assert.AreEqual(-1, solution(null));
        }

        public int solution(int[] A)
        {
            // Impossible to have a dominator
            if (A == null || A.Length == 0)
                return -1;

            if (A.Length == 1)
                return 0;

            var domIndex = -1;
            var domStack = new Stack<int>();

            var i = 1;
            domStack.Push(A[0]);
            do
            {
                if (domStack.Count > 0 && domStack.Peek() != A[i])
                    domStack.Pop();
                else
                    domStack.Push(A[i]);
                
                i++;
            } while (i < A.Length );

            if (domStack.Count == 0)
                return -1;

            var candidate = domStack.Pop();

            var domCount = 0;
            for (var j = 0; j < A.Length; j++)
            {
                if (A[j] != candidate) continue;

                domCount++;
                domIndex = j;
            }

            if (domCount > A.Length / 2)
                return domIndex;

            return -1;
        }
    }
}