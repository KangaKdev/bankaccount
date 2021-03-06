﻿using System;
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
            uint id = 1;
            string name = "hubbabubba";

            Account account = new Account(id, name, balance);
            ulong currentbalance = account.GetBalance();
            Assert.AreEqual(balance, currentbalance);
        }

        [Test]
        public void A_new_account_can_initialized_with_no_balance()
        {
            uint id = 1;
            string name = "hubbabubba";
            Account account = new Account(id, name);
            ulong currentbalance = account.GetBalance();
            Assert.AreEqual((ulong)0, currentbalance);
        }

        [Test]
        public void When_A_account_is_created_the_name_is_stored()
        {
            uint id = 1;
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
        [TestCase((uint)100000000)]
        public void A_account_id_cant_be_bigger_than_8_digits(uint id)
        {
            string name = "hubbabubba";
            Assert.Catch <OverflowException>(() => new Account(id, name));
        }

        [Test]
        public void A_account_id_cant_be_zero()
        {
            string name = "hubbabubba";
            uint id = 0;
            Assert.Catch<OverflowException>(() => new Account(id, name));
        }

        [TestCase((ulong)1000)]
        [TestCase((ulong)100000)]
        [TestCase((ulong)999)]
        public void Depositing_money_to_an_empty_account_puts_the_money_on_the_account(ulong amount)
        {
            Account account = new Account(1,"bla");
            account.DepositMoney(amount);

            Assert.AreEqual(amount,account.GetBalance());
        }

        [TestCase((ulong)1000, (ulong)10000)]
        [TestCase((ulong)100000, (ulong)9484)]
        [TestCase((ulong)999, (ulong)57373)]
        public void Depositing_money_to_an_account_increases_the_balance_by_amount(ulong balance, ulong amount)
        {

            Account account = new Account(1, "bla",balance);
            account.DepositMoney(amount);

            Assert.AreEqual(amount+balance, account.GetBalance());
        }


        [TestCase((ulong)10000, (ulong)10000)]
        [TestCase((ulong)10000, (ulong)9484)]
        [TestCase((ulong)99999, (ulong)57373)]
        public void Withdrawing_money_with_enough_balance_decreases_the_balance_by_amount(ulong balance, ulong amount)
        {

            Account account = new Account(1, "bla", balance);
            Assert.IsTrue(account.WithdrawMoney(amount));
            Assert.AreEqual(balance-amount, account.GetBalance());
        }

        [TestCase((ulong)1000, (ulong)10000)]
        [TestCase((ulong)1000, (ulong)9484)]
        [TestCase((ulong)9999, (ulong)57373)]
        public void Withdrawing_money_without_enough_balance_returns_false(ulong balance, ulong amount)
        {

            Account account = new Account(1, "bla", balance);
            Assert.IsFalse(account.WithdrawMoney(amount));
        }


    }
}
