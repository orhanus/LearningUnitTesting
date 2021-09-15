using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sparrow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparrowMSTest
{
    [TestClass]
    public class CalculatorMSTests
    {
        [TestMethod]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            Calculator calc = new();
            int result = calc.AddNumbers(10, 20);

            Assert.AreEqual(30, result);
        }
    }
}
