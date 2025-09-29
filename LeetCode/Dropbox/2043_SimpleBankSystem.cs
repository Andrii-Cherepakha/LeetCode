using System;
using NUnit.Framework;

namespace LeetCode.Dropbox
{
    public class SimpleBankSystem
    {
        private readonly long[] balance;
        private readonly object[] locks;

        public SimpleBankSystem(long[] balance)
        {
            this.balance = balance;
            locks = new object[balance.Length];
            for (int i = 0; i < balance.Length; i++)
            {
                locks[i] = new object();
            }
        }

        private bool IsAccountValid(int account)
        { 
            return account-1 >=0 && account-1 < balance.Length;
        }

        private bool HasEnoughtMoney(int account, long money)
        {
            return balance[account-1] >= money;
        }

        public bool Transfer(int account1, int account2, long money)
        {
            if (!IsAccountValid(account1) || !IsAccountValid(account2))
            {
                return false;
            }

            // Lock accounts by order to avoid deadlocks
            int max = Math.Max(account1 - 1, account2 - 1);
            int min = Math.Min(account1 - 1, account2 - 1);

            lock (locks[min]) lock (locks[max])
            {
                if (!HasEnoughtMoney(account1, money))
                {
                    return false;
                }
                balance[account1 - 1] -= money;
                balance[account2 - 1] += money;
                return true;
            }
        }

        public bool Deposit(int account, long money)
        {
            if (!IsAccountValid(account))
            {
                return false;
            }
            lock (locks[account-1])
            {
                balance[account - 1] += money;
            }
            return true;
        }

        public bool Withdraw(int account, long money)
        {
            /*
            if (!IsAccountValid(account) || !HasEnoughtMoney(account, money))
            //if (!(IsAccountValid(account) && HasEnoughtMoney(account, money)))
            {
                return false;
            }
            */

            if (!IsAccountValid(account))
            {
                return false;
            }

            lock (locks[account - 1])
            {
                if (!HasEnoughtMoney(account, money))
                {
                    return false;
                }
                balance[account - 1] -= money;
                return true;
            }
        }
    }

    public class SimpleBankSystemTests
    {
        [Test]
        public void test1()
        {
            // ["Bank",             "withdraw","transfer","deposit","transfer","withdraw"]
            // [[[10,100,20,50,30]],[3,10],    [5,1,20],  [5,20],   [3,4,15],  [10,50]]
            var system = new SimpleBankSystem(new long[] { 10, 100, 20, 50, 30 });
            system.Withdraw(3, 10);
            system.Transfer(5, 1, 20);
            system.Deposit(5, 20);
            system.Transfer(3, 4, 15);
            system.Withdraw(10, 50);
        }
    }
}
