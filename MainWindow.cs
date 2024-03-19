using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
            InitializeComponent();
        }

        private void newATMBtn_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => { Application.Run(new ATMWindow()); });
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
