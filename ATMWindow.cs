using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assignment3
{
    public partial class ATMWindow : Form
    {

        Label atmScreen = new Label();

        Button[,] keyPad = new Button[4, 4];

        private BankSystem _bankSystem;

        public ATMWindow(BankSystem bankSystem)
        {
            InitializeComponent();
            //Bind();
            _bankSystem = bankSystem;

            atmScreen.Location = new Point(250, 100);
            atmScreen.BackColor = Color.Green;
            atmScreen.Width = 250;
            atmScreen.Height = 70;
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
                    keyPad[i, j].SetBounds(275 + (55 * i), 200 + (55 * j), 50, 50);
                    keyPad[i, j].BackColor = Color.Gray;
                    keyPad[i, j].ForeColor = Color.Black;
                    keyPad[i, j].Text = buttonLabels[j, i];
                    keyPad[i, j].Click += new EventHandler(this.KeyPadButtonClick);
                    this.Controls.Add(keyPad[i, j]);
                }
            }
        }

        private void KeyPadButtonClick(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;


            if (clickedButton.Text == "Enter")
            {

            }
            else if (clickedButton.Text == "Cancel")
            {
                if (atmScreen.Text.Length > 0)
                {
                    atmScreen.Text = atmScreen.Text.Substring(0, atmScreen.Text.Length - 1);
                }
            }
            else if (clickedButton.Text == "Clear")
            {
                atmScreen.Text = "";
            }
            else
            {
                atmScreen.Text += clickedButton.Text;
            }
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

        private void unlockedThreading_Click(object sender, EventArgs e)
        {

        }
    }
}
