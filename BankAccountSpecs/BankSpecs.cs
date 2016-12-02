using System;
using BankAccount;
using NUnit.Framework;

namespace BankAccountSpecs
{
    [TestFixture]
    public class BankSpecs
    {
        private Bank _bank;

        [SetUp]
        public void SetUp()
        {
            _bank = new Bank();   
        }
        [Test]
        public void A_New_Bank_Must_Not_Have_Any_Accounts()
        {
            Assert.AreEqual(0,_bank.Accounts.Count);
        }

        [Test]
        public void A_New_Account_Can_Be_Opened_In_A_Bank()
        {
            var name = "";
            ulong balance = 0;
            var account = _bank.OpenAccount(name, balance);
            Assert.IsNotNull(account);
        }

        [Test]
        public void A_New_Account_Can_Be_Opened_In_A_Bank_Without_Any_Balance()
        {
            var name = "";
            var account = _bank.OpenAccount(name);
            Assert.AreEqual(0, account.GetBalance());
        }

        [TestCase((ulong)1000)]
        [TestCase((ulong)1500)]
        [TestCase((ulong)9999)]
        [TestCase((ulong)1)]
        [TestCase((ulong)0)]
        public void A_New_Account_Can_Be_Opened_In_A_Bank_With_Balance(ulong balance)
        {
            var name = "";
            var account = _bank.OpenAccount(name, balance);
            Assert.AreEqual(balance, account.GetBalance());
        }

        [Test]
        public void A_Bank_Can_Get_Information_From_Existing_Account()
        {
            var name = "";
            ulong balance = 0;
            var account = _bank.OpenAccount(name, balance);
            var accountInformation = _bank.GetAccountInformation(account.GetID());
            Assert.AreEqual(account.GetBalance().ToString(), accountInformation["Balance"]);
            Assert.AreEqual(account.GetID().ToString(), accountInformation["Id"]);
            Assert.AreEqual(account.GetName(), accountInformation["Name"]);
        }

        [Test]
        public void Get_Information_From_not_Existing_Account_Fails()
        {
            Assert.Catch<Exception>(() => _bank.GetAccountInformation(2));
        }

        [Test]
        public void A_Bank_Can_Close_An_Existing_Account_With_Balance_0()
        {
            var name = "";
           
            var account = _bank.OpenAccount(name);
            var id = account.GetID();

            _bank.CloseAccount(id);

            Assert.Catch<Exception>(() => _bank.GetAccountInformation(id));
        }

        [Test]
        public void A_Bank_Can_NOT_Close_An_Existing_Account_With_Balance()
        {
            var name = "";
            ulong balance = 100;
            var account = _bank.OpenAccount(name,balance);
            var id = account.GetID();

            Assert.Catch<Exception>(() => _bank.CloseAccount(id));
        }

        [Test]
        public void A_Bank_Can_NOT_Close_A_NOT_Existing_Account()
        {
            Assert.Catch<Exception>(() => _bank.CloseAccount(3));
        }

        [Test]
        public void A_Bank_Can_Deposit_Money_to_An_Existing_Account()
        {
            var name = "";
            ulong balance = 100;
            ulong amount = 200;
            var account = _bank.OpenAccount(name, balance);
            _bank.DepositMoney(account.GetID(), amount);

            Assert.AreEqual(balance + amount, account.GetBalance());
        }

        [Test]
        public void Deposit_Money_to_A_Not_Existing_Account_Fails()
        {
            Assert.Catch<Exception>(()=> _bank.DepositMoney(2, 1000));
        }

        [Test]
        public void A_Bank_Can_Withdraw_Money_Within_Balance_From_An_Existing_Account()
        {
            var name = "";
            ulong balance = 100;
            ulong amount = 50;
            var account = _bank.OpenAccount(name, balance);
            _bank.WithdrawMoney(account.GetID(), amount);

            Assert.AreEqual(balance - amount, account.GetBalance());
        }

        [Test]
        public void A_Bank_Can_Withdraw_Money_Over_Balance_From_An_Existing_Account()
        {
            var name = "";
            ulong balance = 100;
            ulong amount = 200;

            var account = _bank.OpenAccount(name, balance);

            Assert.Catch<Exception>(() => _bank.WithdrawMoney(account.GetID(), amount));
        }

        [Test]
        public void Withdraw_Money_From_A_Not_Existing_Account_Fails()
        {
            Assert.Catch<Exception>(() => _bank.WithdrawMoney(2, 1000));
        }


        [Test]
        public void Transfer_money_with_enough_balance_removes_money_from_fromAccount()
        {
            Bank bank = new Bank();


            Account accountFrom = bank.OpenAccount("Account1", 1000);
            Account accountTo = bank.OpenAccount("Account2", 1000);

            bank.TransferMoney(accountFrom.GetID(), accountTo.GetID(), 500);
            Assert.AreEqual(500, accountFrom.GetBalance());
        }


        [Test]
        public void Transfer_money_with_enough_balance_adds_money_to_ToAccount()
        {
            Bank bank = new Bank();


            Account accountFrom = bank.OpenAccount("Account1", 1000);
            Account accountTo = bank.OpenAccount("Account2", 1000);

            bank.TransferMoney(accountFrom.GetID(), accountTo.GetID(), 500);
            Assert.AreEqual(1500, accountTo.GetBalance());
        }


    }
}
