using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class Account
    {
        private ulong m_balance;
        private string m_name;
        private uint m_id;

        public Account(uint id, string name, ulong balance=0)
        {
            m_balance = balance;
            m_name = name;
            if (id >= (uint)100000000)
            {
                throw new OverflowException("ID more than 8 digits!");
            }

            if (id == 0)
            {
                throw new OverflowException("ID is zero!");
            }

            m_id = id;
        }

        public ulong GetBalance()
        {
            return m_balance;
        }

        public string GetName()
        {
            return m_name;
        }
        public uint GetID()
        {
            return m_id;
        }

        public void DepositMoney(ulong amount)
        {
            m_balance += amount;
        }

        public bool WithdrawMoney(ulong amount)
        {
            if (m_balance < amount)
            {
                return false;
            }
            m_balance -= amount;
            return true;
        }
    }
}
