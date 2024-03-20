using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assignment3
{
    public partial class ATMWindow : Form
    {
        private BankSystem _bankSystem;

        public ATMWindow(BankSystem bankSystem)
        {
            InitializeComponent();
            Bind();
            _bankSystem = bankSystem;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void addAccountBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
