using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class Bank
    {
        private uint _currentAcountId = 0;

        public Bank()
        {
            Accounts = new List<Account>();
        }
        public List<Account> Accounts{ get; set; }

        public Account OpenAccount(string name, ulong balance)
        {
            uint id = _currentAcountId++;
            return new Account(id,name,balance);
        }

        public Dictionary<string,string> GetAccountInformation(uint getId)
        {
            throw new NotImplementedException();
        }
    }
}
