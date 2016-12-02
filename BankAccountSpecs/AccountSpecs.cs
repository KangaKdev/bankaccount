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

        [TestCase(0)]
        [TestCase(10000)]
        public void A_new_account_is_initialized_with_correct_balance(ulong balance)
        {
            Account account = new Account(balance);
            int currentbalance = account.GetBalance();
            Assert.AreEqual(balance, currentbalance);
        }

    }
}
