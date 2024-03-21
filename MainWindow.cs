using System;
using System.Threading;
using System.Windows.Forms;

namespace assignment3
{
    public partial class MainWindow : Form
    {


        private bool _adminOpen = false;
        private BankSystem _bankSystem = null;
        public MainWindow()
        {
            _bankSystem = new BankSystem();
            _bankSystem.AddAccount(333333, 3333, 1000);
            InitializeComponent();
        }

        private void newATMBtn_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => { Application.Run(new AltATM(_bankSystem)); });
            thread.Start();

        }

        private void openAdminBtn_Click(object sender, EventArgs e)
        {
            if (!_adminOpen)
            {
                _adminOpen = true;
                Thread thread = new Thread(() => {
                    Application.Run(new BankAdmin(_bankSystem));
                    _adminOpen = false;
                });
                thread.Start();
            }
        }
    }
}
