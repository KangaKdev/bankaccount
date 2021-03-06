﻿using System;
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

            if(account==null) throw new Exception("Acount does not exist");

            information.Add("Balance",account.GetBalance().ToString());
            information.Add("Name",account.GetName());
            information.Add("Id",account.GetID().ToString());

            return information;
        }

        public void CloseAccount(uint id)
        {
            var account = Accounts.FirstOrDefault(x => x.GetID() == id);

            if (account == null) throw new Exception("Account does not exist");


            if(account.GetBalance() != 0)
                throw new Exception("Can not close Account. Balance musst be 0!");

            Accounts.Remove(account);
           
        }

        public void DepositMoney(uint id, ulong amount)
        {
            var account = Accounts.FirstOrDefault(x => x.GetID() == id);

            if (account == null) throw new Exception("Account does not exist");

            account.DepositMoney(amount);

        }

        public void WithdrawMoney(uint id, ulong amount)
        {
            var account = Accounts.FirstOrDefault(x => x.GetID() == id);

            if (account == null) throw new Exception("Account does not exist");

            if(false == account.WithdrawMoney(amount))
                throw new Exception("Balance not sufficient!");

        }

        public bool TransferMoney(uint accountFromId, uint accountToId, ulong amount)
        {
            Account fromAccount = Accounts.FirstOrDefault(x => x.GetID() == accountFromId);
            Account toAccount = Accounts.FirstOrDefault(x => x.GetID() == accountToId);

            if (fromAccount.GetBalance()<amount) {
                return false;
            }
            fromAccount.WithdrawMoney(amount);
            toAccount.DepositMoney(amount);

            return true;
        }
    }
}
