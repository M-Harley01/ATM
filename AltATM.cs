using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assignment3
{
    public partial class AltATM : Form
    {
        private BankSystem _bankSystem;
        private ATM _atm;
        private Account _curAcc;

        private Label _output;
        private Label _input;
        private List<InputButton> _numberButtons;
        private State _state;
        private Dictionary<State, String> _prompts = new Dictionary<State, string>()
        {
            {State.ACCOUNT_NUMBER, "Please enter your account number."},
            {State.PIN, "Please enter your pin."},
            {State.OPERATION_SELECT, "Enter an option number\n[1]Withdraw\n[2]Check Balance\n[3]Exit" }
        };
        private Dictionary<State, Func<String>> _funcDict;

        enum State
        {
            ACCOUNT_NUMBER,
            PIN,
            OPERATION_SELECT,
            WITHDRAW,
            BALANCE_CHECK
        }
        public AltATM(BankSystem bankSystem)
        {
            _bankSystem = bankSystem;
            _numberButtons = new List<InputButton>();
            InitializeComponent();
            BuildUI();
            _state = State.ACCOUNT_NUMBER;
            _funcDict = new Dictionary<State, Func<String>>()
            {
                {State.ACCOUNT_NUMBER, ProcessAccountNumber},
                {State.PIN, ProcessPin},
            };
            output.Text = _prompts[_state];
        }

        private void BuildUI()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int btnNum = i + 1 + j*3;
                    InputButton btn = new InputButton(btnNum.ToString(), input);
                    this.inputPadTable.Controls.Add(btn, i, j);
                    _numberButtons.Add(btn);
                }
            }
            this.inputPadTable.Controls.Add(new InputButton("0", input), 1, 3);
            Del.Click += (sender, e) => Del_Click();
            Clear.Click += (sender, e) => InputClear();
            Enter.Click += (sender, e) => Enter_Click(_funcDict[_state]);
        }

        private string ProcessAccountNumber()
        {
            if (!Int32.TryParse(input.Text, out _))
            {
                output.Text = "Unknown error, try again";
                Thread.Sleep(2000);
            }
            try
            {
                _curAcc = _bankSystem.GetAccount(Int32.Parse(input.Text));
                _state = State.PIN;
            }catch (KeyNotFoundException ex)
            {
                output.Text = "No account with this number exists";
                getWaitThread().Join();
            }
            return _prompts[_state];
        }

        private string ProcessPin()
        {
            if (!Int32.TryParse(input.Text, out _))
            {
                output.Text = "Unknown error, try again";
                Thread.Sleep(2000);
            }
            if (_curAcc.CheckPin(Int32.Parse(input.Text)))
            {
                _state = State.OPERATION_SELECT;
            }
            else
            {
                output.Text = "Wrong pin try again";
                Thread.Sleep(2000);
                _state = State.ACCOUNT_NUMBER;
            }
            return _prompts[_state];
        }

        private class InputButton: Button
        {
            Label target;
            public InputButton(string name, Label target) {
                this.target = target;
                Anchor = System.Windows.Forms.AnchorStyles.None;
                Location = new System.Drawing.Point(3, 3);
                Name = name;
                Size = new System.Drawing.Size(49, 49);
                TabIndex = 0;
                Text = name;
                UseVisualStyleBackColor = true;
                Click += (sender, e) => NumberBtnClicked(sender);
            }

            private void NumberBtnClicked(object sender)
            {
                InputButton sndr = sender as InputButton;
                target.Text += sndr.Text;
            }
        }

        private void Del_Click()
        {
            input.Text = input.Text.Remove(input.Text.Length - 1, 1);
        }

        private void InputClear()
        {
            input.Text = "";
        }

        private void Enter_Click(Func<String> func)
        {
            output.Text = func();
            InputClear();
        }

        private Thread getWaitThread()
        {
            Thread thread = new Thread(() => { Thread.Sleep(2000); });
            thread.Start();
            return thread;
        }
    }
}
