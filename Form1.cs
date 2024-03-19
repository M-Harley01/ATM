using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assignment3
{
    public partial class Form1 : Form
    {
        private BankSystem currentBankSystem;
        private Account currentAccount;
        private bool useUnlockedMethods = false;
    
        private TextBox registerTxtAccountNumber;
        private TextBox registerTxtPin;
        private TextBox txtAccountNumber;
        private TextBox txtPin;
        private TextBox txtBalance;
        private TextBox txtWithdrawAmount;
        private Button btnAddAccount;
        private Button btnWithdraw;
        private Button btnLogin;
        private Button btnToggleMethod;
        private Label lblAccountInfo;
        private Label lblCurrentAccount;

        public Form1()
        {
            InitializeComponent();
            currentBankSystem = new BankSystem();
            InitializeFormComponents();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void InitializeFormComponents()
        {
            // ATM Heading
            Label lblHeading = new Label
            {
                Text = "ATM",
                Location = new System.Drawing.Point(20, 10),
                Width = 300,
                Height = 50,
                Font = new System.Drawing.Font("Arial", 24, System.Drawing.FontStyle.Bold)
            };
            Controls.Add(lblHeading);

            // Account Number
            txtAccountNumber = new TextBox
            {
                Location = new System.Drawing.Point(20, 70),
                Width = 200,
                Tag = "Account Number"
            };
            SetPlaceholderText(txtAccountNumber, "Account Number");
            Controls.Add(txtAccountNumber);

            // PIN
            txtPin = new TextBox
            {
                Location = new System.Drawing.Point(20, 110),
                Width = 200,
                Tag = "PIN",
          
            };
            SetPlaceholderText(txtPin, "PIN");
            Controls.Add(txtPin);
            
            // Account Number
            registerTxtAccountNumber = new TextBox
            {
                Location = new System.Drawing.Point(20, 70),
                Width = 200,
                Tag = "Account Number"
            };
            SetPlaceholderText(txtAccountNumber, "Account Number");
            Controls.Add(txtAccountNumber);

            // PIN
            registerTxtPin = new TextBox
            {
                Location = new System.Drawing.Point(100, 110),
                Width = 200,
                Tag = "PIN",
          
            };
            SetPlaceholderText(txtPin, "PIN");
            Controls.Add(txtPin);

            // Balance - Used only for adding account
            txtBalance = new TextBox
            {
                Location = new System.Drawing.Point(20, 150),
                Width = 200,
                Tag = "Initial Balance"
            };
            SetPlaceholderText(txtBalance, "Initial Balance");
            Controls.Add(txtBalance);

            // Withdraw Amount
            txtWithdrawAmount = new TextBox
            {
                Location = new System.Drawing.Point(20, 190),
                Width = 200,
                Tag = "Withdraw Amount"
            };
            SetPlaceholderText(txtWithdrawAmount, "Withdraw Amount");
            Controls.Add(txtWithdrawAmount);

            // Add Account Button
            btnAddAccount = new Button
            {
                Text = "Add Account",
                Location = new System.Drawing.Point(230, 150)
            };
            btnAddAccount.Click += BtnAddAccount_Click;
            Controls.Add(btnAddAccount);

            // Withdraw Button
            btnWithdraw = new Button
            {
                Text = "Withdraw",
                Location = new System.Drawing.Point(230, 190)
            };
            btnWithdraw.Click += BtnWithdraw_Click;
            Controls.Add(btnWithdraw);

            // Login Button
            btnLogin = new Button
            {
                Text = "Login",
                Location = new System.Drawing.Point(230, 110)
            };
            btnLogin.Click += BtnLogin_Click;
            Controls.Add(btnLogin);

            // Toggle Method Button
            btnToggleMethod = new Button
            {
                Text = "Toggle Lock Method",
                Location = new System.Drawing.Point(20, 230)
            };
            btnToggleMethod.Click += BtnToggleMethod_Click;
            Controls.Add(btnToggleMethod);

            // Account Info Label
            lblAccountInfo = new Label
            {
                Location = new System.Drawing.Point(20, 270),
                Width = 400,
                Height = 40
            };
            Controls.Add(lblAccountInfo);

            // Current Account Label
            lblCurrentAccount = new Label
            {
                Location = new System.Drawing.Point(20, 310),
                Width = 400,
                Height = 40
            };
            Controls.Add(lblCurrentAccount);
        }

        private void SetPlaceholderText(TextBox textBox, string placeholderText)
        {
            textBox.ForeColor = System.Drawing.Color.Gray;
            textBox.Text = placeholderText;
            textBox.Enter += (sender, e) =>
            {
                if (textBox.Text == placeholderText)
                {
                    textBox.Text = "";
                    textBox.ForeColor = System.Drawing.Color.Black;
                }
            };
            textBox.Leave += (sender, e) =>
            {
                if (textBox.Text == "")
                {
                    textBox.Text = placeholderText;
                    textBox.ForeColor = System.Drawing.Color.Gray;
                }
            };
        }

        private void BtnAddAccount_Click(object sender, EventArgs e)
        {
            try
            {
                int accountNumber = int.Parse(txtAccountNumber.Text);
                int pin = int.Parse(txtPin.Text);
                int balance = int.Parse(txtBalance.Text);
                currentBankSystem.AddAccount(accountNumber, pin, balance);
                MessageBox.Show("Account added successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding account: {ex.Message}");
            }
        }

        private void BtnWithdraw_Click(object sender, EventArgs e)
        {
            if (currentAccount == null)
            {
                MessageBox.Show("Please login first.");
                return;
            }

            try
            {
                int amount = int.Parse(txtWithdrawAmount.Text);
                var atm = currentBankSystem.DispatchATM();
                if (useUnlockedMethods)
                {
                    Task.Run(() => atm.WithdrawUnlocked(currentAccount, amount)).ContinueWith(t => UpdateAccountInfo(), TaskScheduler.FromCurrentSynchronizationContext());
                }
                else
                {
                    Task.Run(() => atm.Withdraw(currentAccount, amount)).ContinueWith(t => UpdateAccountInfo(), TaskScheduler.FromCurrentSynchronizationContext());
                }
                MessageBox.Show($"Withdrawal of {amount} initiated.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during withdrawal: {ex.Message}");
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                int accountNumber = int.Parse(txtAccountNumber.Text);
                int pin = int.Parse(txtPin.Text);
                var account = currentBankSystem.GetAccount(accountNumber);
                if (account.CheckPin(pin))
                {
                    currentAccount = account;
                    lblCurrentAccount.Text = $"Logged into account: {accountNumber}";
                    UpdateAccountInfo();
                }
                else
                {
                    MessageBox.Show("Invalid PIN");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login failed: {ex.Message}");
            }
        }

        private void BtnToggleMethod_Click(object sender, EventArgs e)
        {
            useUnlockedMethods = !useUnlockedMethods;
            UpdateAccountInfo();
            MessageBox.Show($"Now using {(useUnlockedMethods ? "Unlocked" : "Locked")} methods.");
        }

        private void UpdateAccountInfo()
        {
            if (currentAccount != null)
            {
                // This method needs to be executed in a way that it doesn't freeze the UI.
                Task.Run(() =>
                {
                    int balance = useUnlockedMethods ? currentBankSystem.DispatchATM().GetAccountBalanceUnlocked(currentAccount)
                                                     : currentBankSystem.DispatchATM().GetAccountBalance(currentAccount);
                    this.Invoke(new Action(() =>
                    {
                        lblAccountInfo.Text = $"Balance: {balance}";
                    }));
                });
            }
        }
    }
}
