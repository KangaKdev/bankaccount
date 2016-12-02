using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class Bank
    {
        public Bank()
        {
            Accounts = new List<Account>();
        }
        public List<Account> Accounts{ get; set; }

        public Account OpenAccount(string name, ulong balance)
        {
            throw new NotImplementedException();
        }
    }
}
