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
            this.unlockedThreading = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pinTXTBox = new System.Windows.Forms.TextBox();
            this.accountNumberTXTBox = new System.Windows.Forms.TextBox();
            this.addAccountBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // unlockedThreading
            // 
            this.unlockedThreading.Location = new System.Drawing.Point(699, 26);
            this.unlockedThreading.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.unlockedThreading.Name = "unlockedThreading";
            this.unlockedThreading.Size = new System.Drawing.Size(200, 35);
            this.unlockedThreading.TabIndex = 0;
            this.unlockedThreading.Text = "Unlocked Threading";
            this.unlockedThreading.UseVisualStyleBackColor = true;
            this.unlockedThreading.Click += new System.EventHandler(this.unlockedThreading_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Account Balance:";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(165, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "2500";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // pinTXTBox
            // 
            this.pinTXTBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pinTXTBox.Location = new System.Drawing.Point(18, 95);
            this.pinTXTBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pinTXTBox.Name = "pinTXTBox";
            this.pinTXTBox.Size = new System.Drawing.Size(421, 26);
            this.pinTXTBox.TabIndex = 3;
            this.pinTXTBox.Text = "account pin";
            // 
            // accountNumberTXTBox
            // 
            this.accountNumberTXTBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.accountNumberTXTBox.Location = new System.Drawing.Point(18, 55);
            this.accountNumberTXTBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.accountNumberTXTBox.Name = "accountNumberTXTBox";
            this.accountNumberTXTBox.Size = new System.Drawing.Size(421, 26);
            this.accountNumberTXTBox.TabIndex = 4;
            this.accountNumberTXTBox.Text = "account number";
            // 
            // addAccountBtn
            // 
            this.addAccountBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.addAccountBtn.Location = new System.Drawing.Point(18, 135);
            this.addAccountBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addAccountBtn.Name = "addAccountBtn";
            this.addAccountBtn.Size = new System.Drawing.Size(220, 35);
            this.addAccountBtn.TabIndex = 5;
            this.addAccountBtn.Text = "Login";
            this.addAccountBtn.UseVisualStyleBackColor = true;
            this.addAccountBtn.Click += new System.EventHandler(this.addAccountBtn_Click);
            // 
            // ATMWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 1138);
            this.Controls.Add(this.addAccountBtn);
            this.Controls.Add(this.accountNumberTXTBox);
            this.Controls.Add(this.pinTXTBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.unlockedThreading);
            this.Name = "ATMWindow";
            this.Text = "ATM";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button unlockedThreading;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox pinTXTBox;
        private System.Windows.Forms.TextBox accountNumberTXTBox;
        private System.Windows.Forms.Button addAccountBtn;
    }
}

