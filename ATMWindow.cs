using Microsoft.VisualBasic;
using System;
using System.Drawing;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assignment3
{
    public partial class ATMWindow : Form
    {

        Label atmScreen = new Label();
        Label userInput = new Label();

        Button[,] keyPad = new Button[4, 4];

        private BankSystem _bankSystem;
        private ATM _atm = new ATM();
        private Boolean runLocked = false;
        private Account _currentAccount;

        public class ATMState
        {
            private int _stage;
            private string[] _textStages = {
                "Enter Account Number",
                "Enter Your Pin",
                "(Withdrawls take 10 seconds to process)\nCheck Balance [0]\nWithdraw [1]\nExit [2]\n",
                "[0] 10\n[1] 50\n[2] 500"
            };
            private Label _atmScreen;

            public ATMState(Label atmScreen)
            {
                _stage = 0;
                _atmScreen = atmScreen;
            }

            public int GetStage()
            {
                return _stage;
            }

            public void NextStage()
            {
                _stage += 1;
                this.SetStageText();
            }

            public void SetStage(int stage)
            {
                _stage = stage;
            }

            public void SetStageText(string forcedText)
            {
                System.Diagnostics.Debug.WriteLine("Forced text ran " + forcedText);
                _atmScreen.Text = forcedText;
            }

            public void SetStageText()
            {
                System.Diagnostics.Debug.WriteLine("Resetting type shi");
                _atmScreen.Text = _textStages[_stage];
            }

            public void ShowError()
            {
                _atmScreen.Text = _textStages[_stage] + "\nIncorrect, please retry";
            }
        }

        private ATMState _atmStage;

        public ATMWindow(BankSystem bankSystem)
        {
            InitializeComponent();

            DialogResult dialogResult = MessageBox.Show("Do you want to run this locked?", "Prompt", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                runLocked = true;
            }
            else if (dialogResult == DialogResult.No)
            {
                runLocked = false;
            }

            _bankSystem = bankSystem;

            atmScreen.Location = new Point(250, 100);
            atmScreen.BackColor = Color.Green;
            atmScreen.Width = 250;
            atmScreen.Height = 100;

            userInput.Location = new Point(250, 180);
            userInput.BackColor = Color.Green;
            userInput.Width = 250;
            userInput.Height = 20;

            this.Controls.Add(userInput);
            this.Controls.Add(atmScreen);

            string[,] buttonLabels = {
                { "1", "2", "3", "Cancel" },
                { "4", "5", "6", "Clear" },
                { "7", "8", "9", "Enter" },
                { "*", "0", "#", "D" }
            };

            for (int i = 0; i < keyPad.GetLength(0); i++)
            {
                for (int j = 0; j < keyPad.GetLength(1); j++)
                {
                    keyPad[i, j] = new Button();
                    keyPad[i, j].FlatStyle = FlatStyle.Flat;
                    keyPad[i, j].FlatAppearance.BorderColor = Color.Gray;
                    keyPad[i, j].SetBounds(275 + (55 * i), 250 + (55 * j), 50, 50);
                    keyPad[i, j].BackColor = Color.Gray;
                    keyPad[i, j].ForeColor = Color.Black;
                    keyPad[i, j].Text = buttonLabels[j, i];
                    keyPad[i, j].Click += new EventHandler(this.KeyPadButtonClick);
                    this.Controls.Add(keyPad[i, j]);
                }
            }

            _atmStage = new ATMState(atmScreen);
            _atmStage.SetStage(0);
            _atmStage.SetStageText();
        }

        private void KeyPadButtonClick(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;


            if (clickedButton.Text == "Enter")
            {
                switch (_atmStage.GetStage())
                {
                    case -1:
                        _atmStage.SetStage(2);
                        _atmStage.SetStageText();

                        userInput.Text = String.Empty;

                        break;
                    case 0:
                        try
                        {
                            _currentAccount = _bankSystem.GetAccount(Int32.Parse(userInput.Text));
                            userInput.Text = "";
                            _atmStage.NextStage();
                        }
                        catch
                        {
                            _atmStage.ShowError();
                            userInput.Text = "";
                        }
                        break;
                    case 1:
                        try
                        {
                            Boolean pinValid = _currentAccount.CheckPin(Int32.Parse(userInput.Text));

                            if (pinValid)
                            {
                                userInput.Text = "";
                                _atmStage.NextStage();
                            } else
                            {
                                throw new Exception("Invalid Pin");
                            }
                        }
                        catch
                        {
                            _atmStage.ShowError();
                            userInput.Text = "";
                        }
                        break;
                    case 2:
                        // Check Balance [0]\nWithdraw [1]\nExit [2]\n       
                        int optionSelected = Int32.Parse(userInput.Text);

                        userInput.Text = "";

                        System.Diagnostics.Debug.WriteLine("YELLOW");

                        switch (optionSelected)
                        {
                            case 0:
                                if (_currentAccount != null)
                                {
                                    System.Diagnostics.Debug.WriteLine("RAN THIS");

                                    if (runLocked)
                                    {
                                        _atmStage.SetStageText("Current Balance: " + _atm.GetAccountBalance(_currentAccount).ToString() + "\nEnter [1] to return");
                                    }
                                    else
                                    {
                                        _atmStage.SetStageText("Current Balance: " + _atm.GetAccountBalanceUnlocked(_currentAccount).ToString() + "\nEnter [1] to return");
                                    }

                                    userInput.Text = "";

                                    _atmStage.SetStage(-1);
                                }
                                break;
                            case 1:
                                if (_currentAccount != null)
                                {
                                    _atmStage.NextStage();
                                    _atmStage.SetStageText();
                                }
                                break;
                            case 2:
                                _currentAccount = null;

                                _atmStage.SetStage(0);
                                _atmStage.SetStageText();

                                break;
                        }
                        break;
                     case 3:
                        int withdrawAmount;
                        int selectedWithdraw = Int32.Parse(userInput.Text);

                        if (_currentAccount == null) throw new Exception("Your not logged in");

                            switch (selectedWithdraw)
                            {
                                case 0:
                                    withdrawAmount = 10;

                                    try
                                    {
                                        if (_currentAccount.Balance >= withdrawAmount)
                                        {
                                            if (runLocked)
                                            {
                                                _atm.Withdraw(_currentAccount, withdrawAmount);
                                            } else
                                            {
                                                _atm.WithdrawUnlocked(_currentAccount, withdrawAmount);
                                            }

                                            _atmStage.SetStage(2);
                                            _atmStage.SetStageText();
                                        }
                                        else
                                        {
                                            _atmStage.SetStageText("You don't have enough balance");

                                            Thread.Sleep(2000);

                                            _atmStage.SetStage(2);
                                            _atmStage.SetStageText();
                                        }
                                    }
                                    catch (ATM.InvalidATMArgsException ex)
                                    {
                                        _atmStage.SetStageText(ex.Message);

                                        Thread.Sleep(2000);

                                        _atmStage.SetStage(2);
                                        _atmStage.SetStageText();
                                    }

                                    break;
                            case 1:
                                withdrawAmount = 50;

                                try
                                {
                                    if (_currentAccount.Balance >= withdrawAmount)
                                    {
                                        if (runLocked)
                                        {
                                            _atm.Withdraw(_currentAccount, withdrawAmount);
                                        }
                                        else
                                        {
                                            _atm.WithdrawUnlocked(_currentAccount, withdrawAmount);
                                        }

                                        _atmStage.SetStage(2);
                                        _atmStage.SetStageText();
                                    }
                                    else
                                    {
                                        _atmStage.SetStageText("You don't have enough balance");

                                        Thread.Sleep(2000);

                                        _atmStage.SetStage(2);
                                        _atmStage.SetStageText();
                                    }
                                }
                                catch (ATM.InvalidATMArgsException ex)
                                {
                                    _atmStage.SetStageText(ex.Message);

                                    Thread.Sleep(2000);

                                    _atmStage.SetStage(2);
                                    _atmStage.SetStageText();
                                }

                                break;
                            case 2:
                                withdrawAmount = 500;

                                try {
                                    if (_currentAccount.Balance >= withdrawAmount) {
                                        if (runLocked)
                                        {
                                            _atm.Withdraw(_currentAccount, withdrawAmount);
                                        }
                                        else
                                        {
                                            _atm.WithdrawUnlocked(_currentAccount, withdrawAmount);
                                        }

                                        _atmStage.SetStage(2);
                                        _atmStage.SetStageText();
                                    }
                                    else
                                    {
                                        _atmStage.SetStageText("You don't have enough balance");

                                        Thread.Sleep(2000);

                                        _atmStage.SetStage(2);
                                        _atmStage.SetStageText();
                                    }
                                }
                                catch (ATM.InvalidATMArgsException ex)
                                {
                                    _atmStage.SetStageText(ex.Message);

                                    Thread.Sleep(2000);

                                    _atmStage.SetStage(2);
                                    _atmStage.SetStageText();
                                }

                                break;
                            }
                 

                        //userInput.Text = "";

                        //_atmStage.SetStage(2);
                        //_atmStage.SetStageText();

                        break;
                }
            }
            else if (clickedButton.Text == "Cancel")
            {
                if (userInput.Text.Length > 0)
                {
                    userInput.Text = atmScreen.Text.Substring(0, atmScreen.Text.Length - 1);
                }
            }
            else if (clickedButton.Text == "Clear")
            {
                userInput.Text = "";
            }
            else
            {
                userInput.Text += clickedButton.Text;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ATMWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
