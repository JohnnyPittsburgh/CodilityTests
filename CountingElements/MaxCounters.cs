using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodilityTests.CountingElements
{
    [TestClass()]
    public class MaxCounters
    {
        [TestMethod()]
        public void solutionTest()
        {
            var a = new [] { 3, 4, 4, 6, 1, 4, 4};
            var b = new [] {3, 2, 2, 4, 2};
            CollectionAssert.AreEqual(solution(5, a), b);
        }


        public int[] solution(int N, int[] A)
        {
            var maxCounter = 0;
            var minCounter = 0;
            var counters = new int[N];

            for (var i = 0; i < A.Length; i++)
            {
                var val = A[i];

                // Within bounds, update counter 
                if (val >= 1 && val <= N)
                {
                    if (counters[val - 1] < minCounter)
                        counters[val - 1] = minCounter;

                    counters[val - 1]++;

                    if (counters[val - 1] > maxCounter)
                        maxCounter = counters[val - 1];
                }

                // Update all with max value;
                else if (N + 1 == val)
                {
                    minCounter = maxCounter;
                }
            }

            for(var i=0; i<N; i++)
            {
                if (counters[i] < minCounter)
                    counters[i] = minCounter;
            }

            return counters;
        }
    



        public int[] solution2(int N, int[] A)
        {
            var counters = new int[N];
            var max = 0;

            for (var i = 0; i < A.Length; i++)
            {
                var value = A[i];
                if (value > N)
                {
                    for (var j = 0; j < N; j++)
                        counters[j] = max;
                }
                else
                {
                    var index = value - 1;
                    counters[index]++;
                    if (counters[index] > max)
                        max = counters[index];
                }
            }

            return counters;
        }






    }
}