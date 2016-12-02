using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BankAccount;
using NUnit.Framework;

namespace BankAccountSpecs
{
    [TestFixture]
    public class BankSpecs
    {
        [Test]
        public void A_New_Bank_Must_Not_Have_Any_Account()
        {
            var bank = new Bank();
            Assert.AreEqual(0,bank.Accounts.Count);
        }

        [Test]
        public void A_New_Account_Can_Be_Opened_In_A_Bank()
        {
            var bank = new Bank();
            var name = "";
            ulong balance = 0;
            var account = bank.OpenAccount(name, balance);
        }
    }
}
