using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class Bank
    {
        private uint _currentAccountId = 1;

        public Bank()
        {
            Accounts = new List<Account>();
        }
        public List<Account> Accounts{ get; set; }

        public Account OpenAccount(string name, ulong balance = 0)
        {
            uint id = _currentAccountId++;

            var account = new Account(id,name,balance);
            Accounts.Add(account);

            return account;
        }

        public Dictionary<string,string> GetAccountInformation(uint accountId)
        {
            var information = new Dictionary<string,string>();
            var account = Accounts.FirstOrDefault(x => x.GetID() == accountId);

            if(account==null) throw new Exception();

            information.Add("Balance",account.GetBalance().ToString());
            information.Add("Name",account.GetName());
            information.Add("Id",account.GetID().ToString());

            return information;
        }

        public void CloseAccount(uint id)
        {
            var account = Accounts.FirstOrDefault(x => x.GetID() == id);

            if (account == null) throw new Exception();


            if(account.GetBalance() != 0)
                throw new Exception("Can not close Account. Balance musst be 0!");

            Accounts.Remove(account);
           
        }
    }
}
