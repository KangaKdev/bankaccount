using System;
using System.Collections.Generic;
using System.IO;
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

            var account = new Account(id,name,balance);
            Accounts.Add(account);

            return account;
        }

        public Dictionary<string,string> GetAccountInformation(uint accountId)
        {
            var information = new Dictionary<string,string>();
            var account = Accounts.FirstOrDefault(x => x.GetID() == accountId);

            if(account==null) throw new DirectoryNotFoundException();

            information.Add("Balance",account.GetBalance().ToString());
            information.Add("Name",account.GetName());
            information.Add("Id",account.GetID().ToString());

            return information;
        }
    }
}
