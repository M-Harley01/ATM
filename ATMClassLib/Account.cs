using System;

namespace assignment3 {
    public class Account {

        private int _balance;
        private readonly int _number, _pin;
        private Object _accountLock;

        public Account(int number, int pin, int balance) {
            if (!IsValidAccountNumber(number)) {
                throw new InvalidAccountArgsException($"{number} is not a valid account number: must be 6 digits, must be positive");
            }

            if (!IsValidPin(pin)) {
                throw new InvalidAccountArgsException($"{pin} is not a valid pin: must be 4 digits, must be positive");
            }
            
            if (!IsValidBalance(balance)) {
                throw new InvalidAccountArgsException($"balance must be positive");
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
        
        private static bool IsValidBalance(int balance) {
            return balance >= 0;
        }

        public class InvalidAccountArgsException : ArgumentException {
            public InvalidAccountArgsException(string message) : base(message) {}
        }
    }
}