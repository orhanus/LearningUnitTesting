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
            Assert.Multiple(() =>
            {
                Assert.That(fullName, Is.EqualTo("Hello, Orhan Usanovic"));
                Assert.That(fullName, Does.Contain(","));
                Assert.That(fullName, Does.StartWith("Hello,"));
                Assert.That(fullName, Does.EndWith("Usanovic"));
                Assert.That(fullName, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
            });

            
        }
        [Test]
        public void GreetMessage_NotGreeted_ReturnNull()
        {

            Assert.That(customer.GreetMessage, Is.Null);
        }
        [Test]
        public void GreetMessage_InputFirstName_ReturnGreeting()
        {
            string fullName = customer.GreetAndCombineNames("Orhan", "");

            Assert.That(fullName, Is.EqualTo("Hello, Orhan "));
        }
        [Test]
        public void GreetMessage_InputLastName_ThrowsException()
        {
            var ExceptionDetails = Assert.Throws<ArgumentException>(() =>
            {
                customer.GreetAndCombineNames("", "Usanovic");
            });
            Assert.That(ExceptionDetails.Message, Is.EqualTo("First name cannot be empty"));
            Assert.That(() => customer.GreetAndCombineNames("", "Usanovic"),
                Throws.ArgumentException.With.Message.EqualTo("First name cannot be empty"));

        }
        [Test]
        public void CustomerType_CreateCustomerWithLessThan100Order_ReturnBasicCustomer()
        {
            customer.orderTotal = 10;
            var result = customer.GetCustomerDetails();
            Assert.That(result, Is.TypeOf<BasicCustomer>());
        }
        [Test]
        public void CustomerType_CreateCustomerWithMoreThan100Order_ReturnPlatinumCustomer()
        {
            customer.orderTotal = 101;
            var result = customer.GetCustomerDetails();
            Assert.That(result, Is.TypeOf<PlatinumCustomer>());
        }
    }
}
