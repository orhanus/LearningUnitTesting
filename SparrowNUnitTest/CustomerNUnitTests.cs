using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparrow
{
    [TestFixture]
    public class CustomerNUnitTests
    {
        private Customer customer;
        [SetUp]
        public void Setup()
        {
            customer = new Customer();
        }
        [Test]
        public void CombineName_InputFirstAndLastName_ReturnFullName()
        {

            string fullName = customer.GreetAndCombineNames("Orhan", "Usanovic");

            Assert.That(fullName, Is.EqualTo("Hello, Orhan Usanovic"));
            Assert.That(fullName, Does.Contain(","));
            Assert.That(fullName, Does.StartWith("Hello,"));
            Assert.That(fullName, Does.EndWith("Usanovic"));
            Assert.That(fullName, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
        }
        [Test]
        public void GreetMessage_NotGreeted_ReturnNull()
        {

            Assert.That(customer.GreetMessage, Is.Null);
        }
    }
}
