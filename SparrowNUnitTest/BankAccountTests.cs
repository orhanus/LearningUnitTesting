using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparrow
{
    [TestFixture]
    public class BankAccountTests
    {
        private BankAccount account;
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void BankDeposit_Add100_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            BankAccount bankAccount = new(logMock.Object);

            bool result = bankAccount.Deposit(100);
            Assert.IsTrue(result);
            Assert.That(bankAccount.GetBalance(), Is.EqualTo(100));
        }
        [Test]
        public void BankWithdrawal_Withdraw100With200Balance_ReturnsTrue()
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(u => u.LogToDb(It.IsAny<string>())).Returns(true);
            logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.Is<int>(x => x > 0))).Returns(true);

            BankAccount bankAccount = new BankAccount(logMock.Object);
            bankAccount.Deposit(200);
            var result = bankAccount.Withdraw(100);
            Assert.IsTrue(result);
        } 
        [Test]
        public void BankWithdrawal_Withdraw300With200Balance_ReturnsFalse()
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.Is<int>(x => x > 0))).Returns(true);
            logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.IsInRange<int>(int.MinValue, -1, Moq.Range.Inclusive))).Returns(false);

            BankAccount bankAccount = new BankAccount(logMock.Object);
            bankAccount.Deposit(200);
            var result = bankAccount.Withdraw(300);
            Assert.IsFalse(result);
        }
        [Test]
        public void BankLogDummy_LogMockString_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            string desiredOutput = "Mock";
            logMock.Setup(u => u.MessageWithReturnStr(It.IsAny<string>())).Returns((string str) => str);

            Assert.That(logMock.Object.MessageWithReturnStr("Mock"), Is.EqualTo(desiredOutput));
        }
        [Test]
        public void BankLogDummy_LogMockStringOutputStr_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            string desiredOutput = "Hello";
            logMock.Setup(u => u.LogWithOutputResult(It.IsAny<string>(), out desiredOutput)).Returns(true);
            string result = "";
            Assert.IsTrue(logMock.Object.LogWithOutputResult("Ben", out result));

            Assert.That(result, Is.EqualTo(desiredOutput));
        }
        [Test]
        public void BankLogDummy_LogRefChecker_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            Customer customer = new();
            Customer customerNotUsed = new();
            Customer ssomeCustomer = customer;
            logMock.Setup(u => u.LogWithRefObject(ref customer)).Returns(true);

            Assert.IsTrue(logMock.Object.LogWithRefObject(ref customer));
            Assert.IsFalse(logMock.Object.LogWithRefObject(ref customerNotUsed));
            Assert.IsTrue(logMock.Object.LogWithRefObject(ref ssomeCustomer));
        }
        [Test]
        public void BankLogDummy_SetAndGetLogTypeAndSeverityMock_MockTest()
        {
            var logMock = new Mock<ILogBook>();

            logMock.Setup(u => u.LogSeverity).Returns(10);
            logMock.Setup(u => u.LogType).Returns("Warning");

            Assert.That(logMock.Object.LogSeverity, Is.EqualTo(10));
            Assert.That(logMock.Object.LogType, Is.EqualTo("Warning"));
        }
        [Test]
        public void BankLogDummy_VerifyExample()
        {
            var logMock = new Mock<ILogBook>();
            BankAccount bankAccount = new(logMock.Object);
            bankAccount.Deposit(100);

            Assert.That(bankAccount.GetBalance(), Is.EqualTo(100));

            //verification
            logMock.Verify(u => u.Message(It.IsAny<string>()), Times.Exactly(2));
            logMock.VerifySet(u => u.LogSeverity = 101, Times.Once);
            logMock.Verify(u => u.Message("Deposit invoked"), Times.AtLeastOnce);
        }
    }
}
