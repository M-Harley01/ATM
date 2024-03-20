using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assignment3
{
    public partial class BankAdmin : Form
    {

        private BankSystem _bankSystem;
        public BankAdmin(BankSystem bankSystem)
        {
            InitializeComponent();
            Bind();
            _bankSystem = bankSystem;
        }

        private void addAccountBtn_Click(object sender, EventArgs e, string number, string pin, string balance)
        {
            int acc_num, acc_pin, acc_balance;
            try {
                acc_num = Int32.Parse(number);
                acc_pin = Int32.Parse(pin);
                acc_balance = Int32.Parse(balance);
            } catch (FormatException) {
                string message = "the input must be numerical";
                string title = "invalid input";
                MessageBox.Show(message, title);
                return;
            }
            try {
                _bankSystem.AddAccount(acc_num, acc_pin, acc_balance);
            } catch (BankSystem.AccountExistsException) {
                string message = "an account with this numer already exists";
                string title = "invalid input";
                MessageBox.Show(message, title);
                return;
            } catch (Account.InvalidAccountArgsException exception)
            {
                string message = exception.Message;
                string title = "invalid input";
                MessageBox.Show(message, title);
                return;
            }
            Console.WriteLine($"{number}, {pin}, {balance}");
            UpdateAccountList();
        }

        private void UpdateAccountList()
        {
            this.listBox1.Items.Clear();
            foreach (Account acc in _bankSystem.GetAccounts())
            {
                this.listBox1.Items.Add(acc.toString());
            }
        }
    }
}
