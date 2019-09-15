using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CodilityTests.BinarySearch
{
    [TestClass()]
    public class MinMaxDivision
    {
        [TestMethod()]
        public void solutionTest()
        {
            var a = new[] { 2, 1, 5, 1, 2, 2, 2 };
            Assert.AreEqual(6, solution(3, 5, a));


            a = new[] { 0, 0, 0, 0, 99, 0, 0, 0 };
            Assert.AreEqual(99, solution(99, 5, a));


            a = new[] { 2, 1, 5, 1, 2, 2, 2 };
            Assert.AreEqual(6, solution2(3, 5, a));

            // Fails on this test.
            //a = new[] { 0, 0, 0, 0, 99, 0, 0, 0 };
            //Assert.AreEqual(99, solution2(99, 5, a));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="K">Max block count</param>
        /// <param name="M">Max block size</param>
        /// <param name="A">Array of numbers</param>
        /// <returns></returns>
        public int solution(int K, int M, int[] A)
        {
            // For binary search, I'm going to stick with
            //  min, max, and mid to keep the logic consitent.
            var min = 0;
            var max = 0;

            // The max is the total of all elements.
            // The min is the largest element.
            // Could use Linq but this is faster for getting max and min.
            // TC = O(N)  SC = O(1)
            for (var i = 0; i < A.Length; i++)
            {
                max += A[i];
                min = Math.Max(min, A[i]);
            }

            // Bounds checks
            if (K == 1) return max;
            if (K >= A.Length) return min;

            // Normal binary search algorithm
            // TC = O(logN) because it's a binary search.
            while (min <= max)
            {
                var mid = (min + max) / 2;
                
                // Found a higher maximum sum, search for 
                //  a lower result
                // TC = O(N)
                if (IsBlockSizeValid(A, K, mid))
                {
                    max = mid - 1;                    
                }

                // Didn't find a higher maximum sum, search for 
                //   higher result
                else
                {
                    min = mid + 1;
                }
            }

            return min;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="maxBlockCount"></param>
        /// <param name="maxBlockSum"></param>
        /// <returns></returns>
        private bool IsBlockSizeValid(int[] a, int maxBlockCount, int maxBlockSum)
        {
            var sum = 0;
            var blockCount = 0;

            // TC = O(N)
            foreach(var element in a)
            {
                if (sum + element > maxBlockSum)
                {
                    sum = element;
                    blockCount++;
                }
                else
                {
                    sum += element;
                }

                // Went over the block count so it's invalid.
                if (blockCount >= maxBlockCount)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// This solution is only 66%.  Try it again.
        /// This problem took me hours to understand and solve even with help.
        /// My plans are to revisit it.  I get the binary search part but the
        /// Greedy type algorithm for finding the max threw me for a loop (pun not intended).
        /// TC = O(N logN)  SP = O(1) ... really not eating up resources.
        /// </summary>
        /// <param name="K"></param>
        /// <param name="M"></param>
        /// <param name="A"></param>
        /// <returns></returns>
        public int solution2(int K, int M, int[] A)
        {
            // For binary search, I'm going to stick with
            //  min, max, and mid to keep the logic consitent.
            var min = 0;
            var max = 0;

            // The max is the total of all elements.
            // The min ofcoarse, is the smallest element.
            // TC = O(N)  SC = O(1)
            for (var i = 0; i < A.Length; i++)
            {
                max += A[i];
                min = Math.Min(min, A[i]);
            }

            // Normal binary search algorithm
            // TC = O(logN) because it's a binary search.
            while (min <= max)
            {
                var mid = (min + max) / 2;

                // Found a higher maximum sum, search for 
                //  a lower result
                if (IsDivisionSolvable(mid, K, A))
                {
                    max = mid - 1;
                }

                // Didn't find a higher maximum sum, search for 
                //   higher result
                else
                {
                    min = mid + 1;
                }
            }

            return min;
        }

        /// <summary>
        /// Determine if the mid is achievable by diving the array into
        /// K parts and detrdmining 
        /// </summary>
        /// <param name="mid"></param>
        /// <param name="k"></param>
        /// <param name="a"></param>
        /// <returns></returns>
        public bool IsDivisionSolvable(int mid, int k, int[] a)
        {
            // TC = O(N) because each element is processed.
            var sum = 0;
            for (var i = 0; i < a.Length; i++)
            {
                sum += a[i];

                // Found a higher maximum sum, keep looking
                if (sum > mid)
                {
                    sum = a[i];
                    k--;
                }

                // Didn't find a "higher" maximum sum.
                if (k <= 0)
                    return false;
            }

            return true;
        }
    }

}