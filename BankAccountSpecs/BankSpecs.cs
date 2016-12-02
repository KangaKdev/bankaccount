using System;
using System.Collections.Generic;
using System.IO;
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
        public void A_New_Account_Can_Be_Opened_In_A_Bank_Without_Any_Balance()
        {
            var bank = new Bank();
            var name = "";
            var account = bank.OpenAccount(name);
            Assert.AreEqual(0, account.GetBalance());
        }

        [Test]
        public void A_New_Account_Can_Be_Opened_In_A_Bank_With_Balance_Equals_500000()
        {
            var bank = new Bank();
            var name = "";
            ulong balance = 500000;
            var account = bank.OpenAccount(name,balance);
            Assert.AreEqual(balance, account.GetBalance());
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
        public void Get_Information_From_not_Existing_Account_Fails()
        {
            var bank = new Bank();
            Assert.Catch<DirectoryNotFoundException>(() => bank.GetAccountInformation(2));
        }

    }
}
