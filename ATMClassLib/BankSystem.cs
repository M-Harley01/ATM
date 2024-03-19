using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


namespace assignment3 {
    public class BankSystem {
    //class to store and manage bank accounts and dispatch new ATMs 

        private Dictionary<int, Account> _accounts;
        //A dictionary to store all bank accounts key: account number, value: account

        public BankSystem() {
            _accounts = new Dictionary<int, Account>();
        }

        public void AddAccount(Account account) {
            try {
                _accounts.Add(account.Number, account);
            }
            catch (ArgumentException e) {
                Console.WriteLine($"The account with this number({account.Number}) already exists: {e.Message}");
                throw new AccountExistsException();
            }
        }

        public void AddAccount(int accountNumber, int pin, int balance) {
        //function to add new accounts to the system 
            try {
                Account account = new Account(accountNumber, pin, balance);
                AddAccount(account);
            }
            catch (AccountExistsException)
            {
                throw;
            }
            catch (Account.InvalidAccountArgsException e) {
            //catch invalid account number, pin and initial balance
            //also catches account numbers that already exist
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public Account GetAccount(int accountNumber) {
        //returns an account with a given account number
            try {
                return _accounts[accountNumber];
            }
            catch (KeyNotFoundException e) {
            //catches in case the given account number doesn't exist
                Console.WriteLine($"[ERROR] Account number {accountNumber} not found: {e.Message}");
                throw;
            }
        }

        public List<Account> GetAccounts()
        {
            List<Account> accounts = _accounts.Values.ToList();
            return accounts;
        }

        public ATMWindow DispatchATM() {
            return new ATMWindow();
        }

        public class AccountExistsException : ArgumentException {}
    }

    
    
}