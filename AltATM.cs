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
    public partial class AltATM : Form
    {
        private BankSystem _bankSystem;
        private ATM _atm;

        private Label _output;
        private Label _input;
        private List<InputButton> _numberButtons;
        public AltATM(BankSystem bankSystem)
        {
            _bankSystem = bankSystem;
            _numberButtons = new List<InputButton>();
            InitializeComponent();
            BuildUI();
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
                Click += new EventHandler(this.NumberBtnClicked);
            }

            private void NumberBtnClicked(object sender, EventArgs e)
            {
                InputButton sndr = sender as InputButton;
                target.Text += sndr.Text;
            }
        }

        private void Del_Click(object sender, EventArgs e)
        {
            input.Text = input.Text.Remove(input.Text.Length - 1, 1);
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            input.Text = "";
        }
    }
}
