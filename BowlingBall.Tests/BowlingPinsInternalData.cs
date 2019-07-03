using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingBall.Tests
{
    class BowlingPinsInternalData
    {
        public static IEnumerable<object[]> PlayData
        {
            get
            {
                //yield return new object[] { new int[] { 1, 2, 3, 4, 5, 2, 4, 4, 10, 2, 3, 2, 8, 6, 3, 1, 1, 3, 4 } };
                yield return new object[] { new int[] { 2, 3, 4, 3, 5, 1, 7, 3, 8, 1, 5, 1, 6, 4, 4, 3, 10, 10, 3,1 } };
                //yield return new object[] { new int[] {10,1,2,3,7,6,4,2,3,2,0,5,5,6,0,1,1,4,3} };

            }

        }

        public static IEnumerable<object[]> PlayAllZerosData
        {
            get
            {
                yield return new object[] { new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 ,0 , 0, 0,0,0,0,0,0 } };
            }
        }

        public static IEnumerable<object[]> PlayAllStrikesData
        {
            get
            {
                yield return new object[] { new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 } };
            }
        }

        public static IEnumerable<object[]> PlayAllSparesData
        {
            get
            {
                yield return new object[] { new int[] {2,8,3,7,6,4,1,9,5,5,4,6,0,10,3,7,8,2,9,1,0} };
            }
        }

        public static IEnumerable<object[]> PlayAllTenthFrameStrikeData
        {
            get
            {
                yield return new object[] { new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 10,10,10 } };
            }
        }

        public static IEnumerable<object[]> PlayAllTenthFrameSpareData
        {
            get
            {
                yield return new object[] { new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 8, 10 } };
            }
        }






    }
}
