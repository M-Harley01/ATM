namespace assignment3
{
    partial class ATMWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pinTXTBox = new System.Windows.Forms.TextBox();
            this.accountNumberTXTBox = new System.Windows.Forms.TextBox();
            this.addAccountBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(466, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Unlocked Threading";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Account Balance:";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(110, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "2500";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // pinTXTBox
            // 
            this.pinTXTBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pinTXTBox.Location = new System.Drawing.Point(12, 62);
            this.pinTXTBox.Name = "pinTXTBox";
            this.pinTXTBox.Size = new System.Drawing.Size(282, 20);
            this.pinTXTBox.TabIndex = 3;
            this.pinTXTBox.Text = "account pin";
            // 
            // accountNumberTXTBox
            // 
            this.accountNumberTXTBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.accountNumberTXTBox.Location = new System.Drawing.Point(12, 36);
            this.accountNumberTXTBox.Name = "accountNumberTXTBox";
            this.accountNumberTXTBox.Size = new System.Drawing.Size(282, 20);
            this.accountNumberTXTBox.TabIndex = 4;
            this.accountNumberTXTBox.Text = "account number";
            // 
            // addAccountBtn
            // 
            this.addAccountBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.addAccountBtn.Location = new System.Drawing.Point(12, 88);
            this.addAccountBtn.Name = "addAccountBtn";
            this.addAccountBtn.Size = new System.Drawing.Size(147, 23);
            this.addAccountBtn.TabIndex = 5;
            this.addAccountBtn.Text = "Login";
            this.addAccountBtn.UseVisualStyleBackColor = true;
            this.addAccountBtn.Click += new System.EventHandler(this.addAccountBtn_Click);
            // 
            // ATMWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 740);
            this.Controls.Add(this.addAccountBtn);
            this.Controls.Add(this.accountNumberTXTBox);
            this.Controls.Add(this.pinTXTBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ATMWindow";
            this.Text = "ATM";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox pinTXTBox;
        private System.Windows.Forms.TextBox accountNumberTXTBox;
        private System.Windows.Forms.Button addAccountBtn;
    }
}

