using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparrow
{
    [TestFixture]
    public class GradingCalculatorTests
    {
        GradingCalculator calc;
        [SetUp]
        public void Setup()
        {
            calc = new GradingCalculator();
        }
        [Test]
        public void GetGrade_InputScore95Attendance90_ReturnA()
        {
            calc.Score = 95;
            calc.AttendancePercentage = 90;
            Assert.That(calc.GetGrade(), Is.EqualTo("A"));
        }
        [Test]
        public void GetGrade_InputScore85Attendance90_ReturnB()
        {
            calc.Score = 85;
            calc.AttendancePercentage = 90;
            Assert.That(calc.GetGrade(), Is.EqualTo("B"));
        }
        [Test]
        public void GetGrade_InputScore65Attendance90_ReturnC()
        {
            calc.Score = 65;
            calc.AttendancePercentage = 90;
            Assert.That(calc.GetGrade(), Is.EqualTo("C"));
        }
        [Test]
        public void GetGrade_InputScore95Attendance65_ReturnB()
        {
            calc.Score = 95;
            calc.AttendancePercentage = 65;
            Assert.That(calc.GetGrade(), Is.EqualTo("B"));
        }
        [Test]
        [TestCase(95, 55)]
        [TestCase(65, 55)]
        [TestCase(50, 90)]
        public void GetGrade_FailureScenarios_ReturnF(int score, int attendance)
        {
            calc.Score = score;
            calc.AttendancePercentage = attendance;
            Assert.That(calc.GetGrade(), Is.EqualTo("F"));
        }
        [Test]
        [TestCase(95, 90, ExpectedResult = "A")]
        [TestCase(85, 90, ExpectedResult = "B")]
        [TestCase(65, 90, ExpectedResult = "C")]
        [TestCase(95, 65, ExpectedResult = "B")]
        [TestCase(95, 55, ExpectedResult = "F")]
        [TestCase(65, 55, ExpectedResult = "F")]
        [TestCase(50, 90, ExpectedResult = "F")]
        public string GetGrade_AllScenarios_ReturnExpectedGrade(int score, int attendance)
        {
            calc.Score = score;
            calc.AttendancePercentage = attendance;
            return calc.GetGrade();
        }
    }
}
