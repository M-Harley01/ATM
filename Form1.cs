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
    public partial class Form1 : Form
    {

        Label atmScreen = new Label();

        Button[,] keyPad = new Button[4, 4];


        public Form1()
        {
            InitializeComponent();

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
                    keyPad[i, j].SetBounds(275 + (50 * i), 200 + (50 * j), 50, 50);
                    keyPad[i, j].BackColor = Color.Gray;
                    keyPad[i, j].ForeColor = Color.Black;
                    keyPad[i, j].Text = buttonLabels[j, i];
                    keyPad[i, j].Click += new EventHandler(this.KeyPadButtonClick);
                    this.Controls.Add(keyPad[i, j]);
                }
            }

            Account[] ac = new Account[3];
            ATM atm;

            ac[0] = new Account(300, 1111, 111111);
            ac[1] = new Account(750, 2222, 222222);
            ac[2] = new Account(3000, 3333, 333333);

            //atm = new ATM(ac, atmScreen);
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
    }


    class Account
    {
        private int balance;
        private int pin;
        private int accountNum;

        public Account(int balance, int pin, int accountNum)
        {
            this.balance = balance;
            this.pin = pin;
            this.accountNum = accountNum;
        }

        public int getBalance()
        {
            return balance;
        }

        public void setBalance(int newBalance)
        {
            this.balance = newBalance;
        }

        public Boolean decrementBalance(int amount)
        {
            if (this.balance > amount)
            {
                balance -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean checkPin(int pinEntered)
        {
            if (pinEntered == pin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int getAccountNum()
        {
            return accountNum;
        }
    }

    class ATM
    {
        private Account[] ac;
        private Account activeAccount = null;
        private Label atmScreen;

        public ATM(Account[] ac, Label atmScreen)
        {
            this.ac = ac;
            this.atmScreen = atmScreen;
            updateScreen("Hello from ATM");


            // an infanite loop to keep the flow of controll going on and on
            while (true)
            {

                //ask for account number and store result in acctiveAccount (null if no match found)
                activeAccount = this.findAccount();

                if (activeAccount != null)
                {
                    //if the account is found check the pin 
                    if (activeAccount.checkPin(this.promptForPin()))
                    {
                        //if the pin is a match give the options to do stuff to the account (take money out, view balance, exit)
                        dispOptions();
                    }
                }
                else
                {   //if the account number entered is not found let the user know!
                    updateScreen("no matching account found.");
                }

                //wipes all text from the console
                updateScreen("");
            }

        }

        private void updateScreen(string message)
        {
            atmScreen.Text = message;
        }

        private Account findAccount()
        {
            updateScreen("enter your account number..");

            int input = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < this.ac.Length; i++)
            {
                if (ac[i].getAccountNum() == input)
                {
                    return ac[i];
                }
            }

            return null;
        }

        private int promptForPin()
        {
            Console.WriteLine("enter pin:");
            String str = Console.ReadLine();
            int pinNumEntered = Convert.ToInt32(str);
            return pinNumEntered;
        }

        private void dispOptions()
        {
            updateScreen("1> take out cash");
            updateScreen("2> balance");
            updateScreen("3> exit");

            int input = Convert.ToInt32(Console.ReadLine());

            if (input == 1)
            {
                dispWithdraw();
            }
            else if (input == 2)
            {
                dispBalance();
            }
            else if (input == 3)
            {


            }
            else
            {

            }

        }

        private void dispWithdraw()
        {
            updateScreen("1> 10");
            updateScreen("2> 50");
            updateScreen("3> 500");

            int input = Convert.ToInt32(Console.ReadLine());

            if (input > 0 && input < 4)
            {

                //opiton one is entered by the user
                if (input == 1)
                {

                    //attempt to decrement account by 10 punds
                    if (activeAccount.decrementBalance(10))
                    {
                        //if this is possible display new balance and await key press
                        updateScreen("new balance " + activeAccount.getBalance());
                        updateScreen(" (prese enter to continue)");
                        Console.ReadLine();
                    }
                    else
                    {
                        //if this is not possible inform user and await key press
                        updateScreen("insufficent funds");
                        updateScreen(" (prese enter to continue)");
                        Console.ReadLine();
                    }
                }
                else if (input == 2)
                {
                    if (activeAccount.decrementBalance(50))
                    {
                        updateScreen("new balance " + activeAccount.getBalance());
                        updateScreen(" (prese enter to continue)");
                        Console.ReadLine();
                    }
                    else
                    {
                        updateScreen("insufficent funds");
                        updateScreen(" (prese enter to continue)");
                        Console.ReadLine();
                    }
                }
                else if (input == 3)
                {
                    if (activeAccount.decrementBalance(500))
                    {
                        updateScreen("new balance " + activeAccount.getBalance());
                        updateScreen(" (prese enter to continue)");
                        Console.ReadLine();
                    }
                    else
                    {
                        updateScreen("insufficent funds");
                        updateScreen(" (prese enter to continue)");
                        Console.ReadLine();
                    }
                }
            }
        }

        private void dispBalance()
        {
            if (this.activeAccount != null)
            {
                updateScreen(" your current balance is : " + activeAccount.getBalance());
                updateScreen(" (prese enter to continue)");
                Console.ReadLine();
            }
        }
    }


}
