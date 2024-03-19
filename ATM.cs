using System;
using System.Collections.Generic;
using System.Threading;

namespace assignment3 {

    public class BankSystem {

        private Dictionary<int, Account> _accounts;

        public BankSystem() {
            _accounts = new Dictionary<int, Account>();
        }

        private void AddAccount(Account account) {
            try {
                _accounts.Add(account.Number, account);
            }
            catch (ArgumentException e) {
                Console.WriteLine($"The account with this number({account.Number}) already exists: {e.Message}");
                throw;
            }
        }

        public void AddAccount(int accountNumber, int pin, int balance) {
            try {
                Account account = new Account(accountNumber, pin, balance);
                AddAccount(account);
            }
            catch (ArgumentException e) {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public Account GetAccount(int accountNumber) {
            try {
                return _accounts[accountNumber];
            }
            catch (KeyNotFoundException e) {
                Console.WriteLine($"[ERROR] Account number {accountNumber} not found: {e.Message}");
                throw;
            }
        }

        public ATM DispatchATM() {
            return new ATM();
        }
    }

    public class ATM {

        public void Withdraw(Account account, int amount) {

            //assign a new thred to process the operation
            Thread thread = new Thread(() => {
                //obtain the account lock
                lock (account.AccountLock) {

                    //check if the account has sufficient funds
                    if (amount > account.Balance) {
                        throw new ArgumentException(
                            $"Insufficient funds: balance = {account.Balance}, withdraw amount = {amount}");
                    }

                    //10 second sleep for Data Race demonstration purposes
                    Thread.Sleep(10000);

                    //subtract the withdraw amount from the account balance
                    account.Balance -= amount;
                    Console.WriteLine($"{amount} was successfully withdrawn from account number: {account.Number}");
                }
            });

            //start the thread
            thread.Start();
        }

        public int GetAccountBalance(Account account) {

            Nullable<int> balance = new int();

            Thread thread = new Thread(() => {
                //obtain the account lock
                lock (account.AccountLock) {
                    balance = account.Balance;
                }
            });

            thread.Start();
            thread.Join();
            if (!balance.HasValue) {
                throw new Exception("Error getting the account balance");
            }
            return balance.Value;
        }

        public void WithdrawUnlocked(Account account, int amount) {
            //assign a new thred to process the operation
            Thread thread = new Thread(() => {
                //obtain the account lock

                //check if the account has sufficient funds
                if (amount > account.Balance) {
                    throw new ArgumentException(
                        $"Insufficient funds: balance = {account.Balance}, withdraw amount = {amount}");
                }

                //10 second sleep for Data Race demonstration purposes
                Thread.Sleep(10000);

                //subtract the withdraw amount from the account balance
                account.Balance -= amount;
                Console.WriteLine($"{amount} was successfully withdrawn from account number: {account.Number}");
            });

            //start the thread
            thread.Start();
        }

        public int GetAccountBalanceUnlocked(Account account) {
            Nullable<int> balance = new int();

            Thread thread = new Thread(() => {
                Thread.Sleep(15000);
                balance = account.Balance;
            });

            thread.Start();
            thread.Join();
            if (!balance.HasValue) {
                throw new Exception("Error getting the account balance");
            }
            return balance.Value;
        }
    }

    public class Account {
        private int _balance;
        private readonly int _number, _pin;
        private Object _accountLock;

        public Account(int number, int pin, int balance) {
            if (!IsValidAccountNumber(number)) {
                throw new ArgumentException(
                    $"{number} is not a valid account number: must be 6 digits, must be positive");
            }

            if (!IsValidPin(pin)) {
                throw new ArgumentException($"{pin} is not a valid pin: must be 4 digits, must be positive");
            }

            _number = number;
            _pin = pin;
            _balance = balance;
            _accountLock = new Object();
        }

        public int Number => _number;

        public Object AccountLock => _accountLock;

        public int Balance {
            get => _balance;
            set => _balance = value;
        }

        public bool CheckPin(int pin) {
            return _pin == pin;
        }

        private static bool IsValidAccountNumber(int accountNumber) {
            return accountNumber.ToString().Length == 6 && accountNumber > 0;
        }

        private static bool IsValidPin(int pin) {
            return pin.ToString().Length == 4 && pin > 0;
        }
    }
}