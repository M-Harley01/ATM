using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace assignment3 {
    public partial class AltATM : Form {
        private BankSystem _bankSystem;
        private ATM _atm;
        private Account _curAcc;
        private bool Unlocked = false;

        private List<InputButton> _numberButtons;
        private State _state;

        private Dictionary<State, string> _prompts = new Dictionary<State, string>() {
            { State.ACCOUNT_NUMBER, "Please enter your account number." },
            { State.PIN, "Please enter your pin." },
            { State.OPERATION_SELECT, "Enter an option number\n[1]Withdraw\n[2]Check Balance\n[3]Exit" },
            { State.WITHDRAW, "Enter the amount you want to withdraw\n[1]10\n[2]50\n[3]500" }
        };

        private Dictionary<State, Func<string>> _operations;
        private Dictionary<State, Func<string>> _funcDict;

        private enum State {
            ACCOUNT_NUMBER,
            PIN,
            OPERATION_SELECT,
            WITHDRAW,
            BALANCE_CHECK
        }

        public AltATM(BankSystem bankSystem) {
            
            DialogResult dialogResult = MessageBox.Show("Do you want to run this unlocked?", "Prompt", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Unlocked = true;
            }
            else if (dialogResult == DialogResult.No)
            {
                Unlocked = false;
            }
            
            _bankSystem = bankSystem;
            _atm = _bankSystem.DispatchATM();
            _numberButtons = new List<InputButton>();
            InitializeComponent();
            BuildUI();
            _state = State.ACCOUNT_NUMBER;
            _funcDict = new Dictionary<State, Func<string>>() {
                { State.ACCOUNT_NUMBER, ProcessAccountNumber },
                { State.PIN, ProcessPin },
                { State.OPERATION_SELECT, ProcessOperation },
                { State.BALANCE_CHECK, ProcessCheckBalance },
                { State.WITHDRAW, ProcessWithdraw }
            };
            _operations = new Dictionary<State, Func<string>>() {
                {
                    State.BALANCE_CHECK,
                    () => $"Balance: {_atm.GetAccountBalance(_curAcc)}\nPress Enter to Return to the Operation Menu"
                }
            };
            output.Text = _prompts[_state];
        }

        private void BuildUI() {
            for (var i = 0; i < 3; i++)
            for (var j = 0; j < 3; j++) {
                var btnNum = i + 1 + j * 3;
                var btn = new InputButton(btnNum.ToString(), input);
                inputPadTable.Controls.Add(btn, i, j);
                _numberButtons.Add(btn);
            }

            inputPadTable.Controls.Add(new InputButton("0", input), 1, 3);
            Del.Click += (sender, e) => Del_Click();
            Clear.Click += (sender, e) => InputClear();
            Enter.Click += (sender, e) => Enter_Click(_funcDict[_state]);
        }

        private string ProcessAccountNumber() {
            if (!int.TryParse(input.Text, out _)) input.Text = "Unknown error, try again";
            try {
                _curAcc = _bankSystem.GetAccount(int.Parse(input.Text));
                _state = State.PIN;
                InputClear();
            }
            catch (KeyNotFoundException ex) {
                input.Text = "No account with this number exists";
            }

            return _prompts[_state];
        }

        private string ProcessPin() {
            if (!int.TryParse(input.Text, out _)) input.Text = "Unknown error, try again";
            if (_curAcc.CheckPin(int.Parse(input.Text))) {
                _state = State.OPERATION_SELECT;
                InputClear();
            }
            else {
                input.Text = "Wrong pin try again";
                _state = State.ACCOUNT_NUMBER;
            }

            return _prompts[_state];
        }

        private string ProcessOperation() {
            if (!int.TryParse(input.Text, out _)) input.Text = "Unknown error, try again";
            
            switch (int.Parse(input.Text)) {
                case 1:
                    _state = State.WITHDRAW;
                    break;
                case 2:
                    _state = State.BALANCE_CHECK;
                    return _operations[_state]();
                case 3:
                    _state = State.ACCOUNT_NUMBER;
                    break;
                default:
                    input.Text = "Invalid option, try again";
                    break;
            }

            return _prompts[_state];
        }

        private string ProcessCheckBalance() {
            _state = State.OPERATION_SELECT;
            return _prompts[_state];
        }

        private string ProcessWithdraw() {
            if (!int.TryParse(input.Text, out _)) input.Text = "Unknown error, try again";

            int amount;
            switch (int.Parse(input.Text)) {
                case 1:
                    amount = 10;
                    break;
                case 2:
                    amount = 50;
                    break;
                case 3:
                    amount = 500;
                    break;
                default:
                    input.Text = "Invalid option, try again";
                    return _prompts[_state];
            }

            try {
                if (Unlocked) {
                    _atm.WithdrawUnlocked(_curAcc, amount).Wait();
                }
                else {
                    _atm.Withdraw(_curAcc, amount).Wait();
                }

                input.Text = $"Successfully withdrew {amount}";
            }
            catch (ATM.InvalidATMArgsException ex) {
                input.Text = ex.Message;
            }

            _state = State.OPERATION_SELECT;
            return _prompts[_state];
        }

        private class InputButton : Button {
            private Label target;

            public InputButton(string name, Label target) {
                this.target = target;
                Anchor = AnchorStyles.None;
                Location = new Point(3, 3);
                Name = name;
                Size = new Size(49, 49);
                TabIndex = 0;
                Text = name;
                UseVisualStyleBackColor = true;
                Click += (sender, e) => NumberBtnClicked(sender);
            }

            private void NumberBtnClicked(object sender) {
                if (!int.TryParse(target.Text, out _)) target.Text = "";
                var sndr = sender as InputButton;
                target.Text += sndr.Text;
            }
        }

        private void Del_Click() {
            input.Text = input.Text.Remove(input.Text.Length - 1, 1);
        }

        private void InputClear() {
            input.Text = "";
        }

        private void Enter_Click(Func<string> func) {
            output.Text = func();
        }
    }
}