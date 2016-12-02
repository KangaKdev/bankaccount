using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BankAccount;


namespace BankAccountSpecs
{
    [TestFixture]
    public class AccountSpecs
    {

        [TestCase((ulong)0)]
        [TestCase((ulong)10000)]
        public void A_new_account_is_initialized_with_correct_balance(ulong balance)
        {
            uint id = 0;
            string name = "hubbabubba";

            Account account = new Account(id, name, balance);
            ulong currentbalance = account.GetBalance();
            Assert.AreEqual(balance, currentbalance);
        }

        [Test]
        public void A_new_account_can_initialized_with_no_balance()
        {
            uint id = 0;
            string name = "hubbabubba";
            Account account = new Account(id, name);
            ulong currentbalance = account.GetBalance();
            Assert.AreEqual((ulong)0, currentbalance);
        }

        [Test]
        public void When_A_account_is_created_the_name_is_stored()
        {
            uint id = 0;
            string name = "hubbabubba";
            Account account = new Account(id, name);
            string accountname = account.GetName();
            Assert.AreEqual(name, accountname);
        }


        [TestCase((uint)12345)]
        [TestCase((uint)54321)]
        public void When_A_account_is_created_the_id_is_stored(uint id)
        {
            string name = "hubbabubba";
            Account account = new Account(id, name);
            uint accountid = account.GetID();
            Assert.AreEqual(id, accountid);
        }

        [TestCase((uint)123456789)]
        [TestCase((uint)234567890)]
        public void A_account_id_cant_be_bigger_than_8_digits(uint id)
        {
            string name = "hubbabubba";
            Assert.Catch <OverflowException>(() => new Account(id, name));
        }

    }
}
