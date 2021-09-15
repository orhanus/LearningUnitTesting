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
        [TestCase(14)]
        [TestCase(222)]
        public void IsOddNumber_InputEvenNumber_False(int a)
        {
            Calculator calc = new();
            bool result = calc.IsOddNumber(4);
            Assert.IsFalse(result);
        }
        [Test]
        [TestCase(10, ExpectedResult = false)]
        [TestCase(1, ExpectedResult = true)]
        public bool IsOddNumber_InputNumber_ReturnTrueIfOdd(int a)
        {
            Calculator calc = new();
            return calc.IsOddNumber(a);
        }

        [Test]
        [TestCase(9.9,1.1, ExpectedResult = 11.0)]
        [TestCase(3.6, 1.9, ExpectedResult = 5.5)]
        [TestCase(9.9, 5.9, ExpectedResult = 15.8)]
        [DefaultFloatingPointTolerance(0.001)]
        public double AddNumbersDouble_InputTwoDouble_GetCorrectAddition(double a, double b)
        {
            Calculator calc = new();
            return calc.AddNumbersDouble(a, b);
        }
    }
}
