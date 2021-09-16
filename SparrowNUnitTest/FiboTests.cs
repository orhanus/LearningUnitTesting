using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparrow
{
    [TestFixture]
    public class FiboTests
    {
        Fibo fibo;
        [SetUp]
        public void Setup()
        {
            fibo = new Fibo();
        }
        [Test]
        public void Fibo_InputRangeEquals1_ReturnListWithOneMember()
        {
            fibo.Range = 1;
            var result = fibo.GetFiboSeries();
            var expected = new List<int> { 0 };
            Assert.That(result, Is.Not.Empty);
            Assert.That(result, Is.Ordered);
            Assert.That(result, Is.EquivalentTo(expected));
        }
        [Test]
        public void Fibo_InputRangeEquals6_ReturnListWithSixMembers()
        {
            fibo.Range = 6;
            var expected = new List<int> { 0, 1, 1, 2, 3, 5 };
            var actual = fibo.GetFiboSeries();

            Assert.That(actual, Does.Contain(3));
            Assert.That(actual, Has.Count.EqualTo(6));
            Assert.That(actual, Does.Not.Contain(4));
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
