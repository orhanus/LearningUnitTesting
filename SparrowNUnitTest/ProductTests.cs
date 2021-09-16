using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparrow
{
    [TestFixture]
    public class ProductTests
    {
        [Test]
        public void GetProductPrice_PlatinumCustomer_ReturnPriceWith20Discount()
        {
            Product product = new() { Price = 50 };
            var result = product.GetPrice(new Customer { IsPlatinum = true });
            Assert.AreEqual(40, result);
        }
    }
}
