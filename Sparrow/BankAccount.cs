﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparrow
{
    public class BankAccount
    {
        private readonly ILogBook _logBook;

        public int balance { get; set; }
        public BankAccount(ILogBook logBook)
        {
            balance = 0;
            this._logBook = logBook;
        }
        public bool Deposit(int amount)
        {
            _logBook.Message("Deposit invoked");
            _logBook.Message("Test");
            _logBook.LogSeverity = 101;
            balance += amount;
            return true;
        }
        public bool Withdraw(int amount)
        {
            if (amount <= balance)
            {
                _logBook.LogToDb("Withdrawal amount: " + amount.ToString());
                balance -= amount;
                return _logBook.LogBalanceAfterWithdrawal(balance);
            }
            return _logBook.LogBalanceAfterWithdrawal(balance-amount);
        }
        public int GetBalance()
        {
            return balance;
        }
    }
}
