using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ResupplyCalculationTests
{
    [TestClass]
    public class InputUT : ResupplyCalculation.Input
    {
        private string[] gInput = new string[] { "abc", "-1", "0", "-1000000.5", "999999.5", "1000000" };
        private int gIndex = 0;

        [TestMethod]
        public void TestLetter()
        {
            ReadDistance(false);
            ReadDistance(false);
            ReadDistance(false);
            ReadDistance(false);
            ReadDistance(false);
            ReadDistance(false);
        }

        public override string ReadLine()
        {
            return gInput[gIndex++];
        }
    }
}
