using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodilityTests.PrefixSums
{
    [TestClass()]
    public class PassingCars
    {
        [TestMethod()]
        public void solutionTest()
        {
            // Example
            var a = new[] { 0, 1, 0, 1, 1 };
            Assert.AreEqual(5, solution(a));

            // Null
            Assert.AreEqual(0, solution( null));

            var b = new[] {0, 0, 0, 0, 0};
            Assert.AreEqual(0, solution(b));

            var c = new[] { 1, 1, 1, 1, 1 };
            Assert.AreEqual(0, solution(c));
        }

        public int solution(int[] A)
        {
            // No passing cars
            if (A == null)
                return 0;

            var passingCars = 0;
            var eastCars = 0;
            foreach (var car in A)
            {
                // East car
                if (car == 0)
                    eastCars++;

                // West car
                else
                {
                    passingCars += eastCars;
                    if (passingCars > 1000000000)
                        return -1;
                }
            }

            return passingCars;
        }
    }
}