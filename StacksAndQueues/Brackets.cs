using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodilityTests.StacksAndQueues
{
    [TestClass()]
    public class Brackets
    {
        [TestMethod()]
        public void solutionTest()
        {
            Assert.AreEqual(1, solution("{[()()]}"));
            Assert.AreEqual(0, solution("([)()]"));
            Assert.AreEqual(0, solution("))("));
            Assert.AreEqual(1, solution("{[9]}"));
        }

        public int solution(string S)
        {
            var chars = S.ToCharArray();

            var matched = new Dictionary<char, char>
            {
                {'}', '{'},
                {']', '['},
                {')', '('}
            };

            var pushElement = new List<char> {'{', '[', '('};
            var popElement = new List<char> {'}', ']', ')'};

            var stack = new Stack<char>();

            foreach (var c in chars)
            {
                if (pushElement.Contains(c))
                    stack.Push(c);

                else if (popElement.Contains(c))
                {
                    if (stack.Count == 0)
                        return 0;

                    if (stack.Pop() != matched[c])
                        return 0;
                }
            }

            if (stack.Count == 0)
                return 1;

            return 0;
        }
    }
}