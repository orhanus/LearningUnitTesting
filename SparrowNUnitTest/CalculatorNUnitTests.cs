using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparrow
{
    [TestFixture]
    public class CalculatorNUnitTests
    {
        [Test]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            Calculator calc = new();
            int result = calc.AddNumbers(10, 20);

            Assert.AreEqual(30, result);
        }
        [Test]
        public void IsOddNumber_InputOddNumber_True()
        {
            Calculator calc = new();
            bool result = calc.IsOddNumber(3);
            Assert.IsTrue(result);
        }
        [Test]
        public void IsOddNumber_InputEvenNumber_False()
        {
            Calculator calc = new();
            bool result = calc.IsOddNumber(4);
            Assert.IsFalse(result);
        }
    }
}
