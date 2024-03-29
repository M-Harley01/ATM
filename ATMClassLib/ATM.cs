using System;
using System.Threading;

namespace assignment3 {
    public class ATM
    {

        public Thread Withdraw(Account account, int amount) {
            //the multithreaded implementation of withdrawal with thread locks

            Exception ex = null;
            //assign a new thred to process the operation
            Thread thread = new Thread(() => {
                //obtain the account lock
                lock (account.AccountLock) {

                    //check if the account has sufficient funds
                    if (amount > account.Balance) {
                        ex =  new InvalidATMArgsException(
                            $"Insufficient funds: balance = {account.Balance}, withdraw amount = {amount}");
                        return;
                    }

                    //10 second sleep for Data Race demonstration purposes
                    Thread.Sleep(5000);

                    //subtract the withdraw amount from the account balance
                    account.Balance -= amount;
                    System.Diagnostics.Debug.WriteLine($"{amount} was successfully withdrawn from account number: {account.Number}");
                }
            });

            //start the thread
            thread.Start();
            thread.Join();
            if (ex is InvalidATMArgsException)
            {
                throw ex;
            }
            return thread;
        }

        public int GetAccountBalance(Account account) {
        //the multithreaded implementation of account balance with thread locks

            Nullable<int> balance = new int();

            //creating a new thread to get the balance
            Thread thread = new Thread(() => {
                //obtain the account lock
                lock (account.AccountLock) {
                    balance = account.Balance;
                }
            });

            //start the thread and .join() to wait for its completion before returning the value
            thread.Start();
            thread.Join();
            if (!balance.HasValue) {
                throw new Exception("Error getting the account balance");
            }
            return balance.Value;
        }

        public Thread WithdrawUnlocked(Account account, int amount) {
            //the multithreaded implementation of withdraing without thread locks
            //use ONLY for Data Race demonstration
            Exception ex = null;

            //assign a new thred to process the operation
            Thread thread = new Thread(() => {
                //obtain the account lock

                //check if the account has sufficient funds
                if (amount > account.Balance) {
                    ex =  new InvalidATMArgsException(
                        $"Insufficient funds: balance = {account.Balance}, withdraw amount = {amount}");
                    return;
                }

                //10 second sleep for Data Race demonstration purposes
                Thread.Sleep(5000);

                //subtract the withdraw amount from the account balance
                account.Balance -= amount;
                System.Diagnostics.Debug.WriteLine($"{amount} was successfully withdrawn from account number: {account.Number}");
            });



            //start the thread
            thread.Start();
            thread.Join();
            if (ex is InvalidATMArgsException)
            {
                throw ex;
            }
            return thread;
        }

        public int GetAccountBalanceUnlocked(Account account) {
        //the multithreaded implementation of getting account balance without thread locks
        //use ONLY for Data Race demonstration
            Nullable<int> balance = new int();

			//creating a new thread to get the balance
            Thread thread = new Thread(() => {
            	//15 second sleep for Data Race demonstration purposes
            	    
                balance = account.Balance;
            });

			//start the thread and .join() to wait for its completion before returning the value
            thread.Start();
            thread.Join();
            
            if (!balance.HasValue) {
                throw new Exception("Error getting the account balance");
            }
            return balance.Value;
        }

        public class InvalidATMArgsException : ArgumentException
        {
            public InvalidATMArgsException(string message) : base(message) { }
        }
    }
}