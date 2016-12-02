using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
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
            Assert.IsNotNull(account);
        }

        [Test]
        public void A_Bank_Can_Get_Information_From_Existing_Account()
        {
            var bank = new Bank();
            var name = "";
            ulong balance = 0;
            var account = bank.OpenAccount(name, balance);
            var accountInformation = bank.GetAccountInformation(account.GetID());
            Assert.AreEqual(account.GetBalance().ToString(), accountInformation["Balance"]);
            Assert.AreEqual(account.GetID().ToString(), accountInformation["Id"]);
            Assert.AreEqual(account.GetName(), accountInformation["Name"]);
        }

        [Test]
        public void Test()
        {
            
        }
    }
}
