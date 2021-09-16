using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparrow
{
    public class Customer
    {
        public int Discount { get; set; } = 15;
        public string GreetMessage { get; set; }
        public int orderTotal { get; set; }
        public bool IsPlatinum { get; set; }
        public Customer()
        {
            IsPlatinum = false;
        }
        public string GreetAndCombineNames(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name cannot be empty");
            GreetMessage = $"Hello, {firstName} {lastName}";
            return GreetMessage;
        }

        public CustomerType GetCustomerDetails()
        {
            if (orderTotal < 100) return new BasicCustomer();
            return new PlatinumCustomer();
        }
    }

    public class CustomerType { }
    public class BasicCustomer : CustomerType { }
    public class PlatinumCustomer : CustomerType { }
}
