namespace assignment3
{
    partial class BankAdmin
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.accountNumberTXTBox = new System.Windows.Forms.TextBox();
            this.pinTXTBox = new System.Windows.Forms.TextBox();
            this.initBalanceTXTBox = new System.Windows.Forms.TextBox();
            this.addAccountBtn = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.accountNumberTXTBox);
            this.flowLayoutPanel1.Controls.Add(this.pinTXTBox);
            this.flowLayoutPanel1.Controls.Add(this.initBalanceTXTBox);
            this.flowLayoutPanel1.Controls.Add(this.addAccountBtn);
            this.flowLayoutPanel1.Controls.Add(this.listBox1);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1, 1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(746, 457);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // accountNumberTXTBox
            // 
            this.accountNumberTXTBox.Location = new System.Drawing.Point(3, 3);
            this.accountNumberTXTBox.Name = "accountNumberTXTBox";
            this.accountNumberTXTBox.Size = new System.Drawing.Size(100, 20);
            this.accountNumberTXTBox.TabIndex = 0;
            // 
            // pinTXTBox
            // 
            this.pinTXTBox.Location = new System.Drawing.Point(109, 3);
            this.pinTXTBox.Name = "pinTXTBox";
            this.pinTXTBox.Size = new System.Drawing.Size(100, 20);
            this.pinTXTBox.TabIndex = 1;
            // 
            // initBalanceTXTBox
            // 
            this.initBalanceTXTBox.Location = new System.Drawing.Point(215, 3);
            this.initBalanceTXTBox.Name = "initBalanceTXTBox";
            this.initBalanceTXTBox.Size = new System.Drawing.Size(100, 20);
            this.initBalanceTXTBox.TabIndex = 2;
            // 
            // addAccountBtn
            // 
            this.addAccountBtn.Location = new System.Drawing.Point(321, 3);
            this.addAccountBtn.Name = "addAccountBtn";
            this.addAccountBtn.Size = new System.Drawing.Size(75, 23);
            this.addAccountBtn.TabIndex = 3;
            this.addAccountBtn.Text = "button1";
            this.addAccountBtn.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(402, 3);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 95);
            this.listBox1.TabIndex = 4;
            // 
            // BankAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "BankAdmin";
            this.Text = "Form2";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox accountNumberTXTBox;
        private System.Windows.Forms.TextBox pinTXTBox;
        private System.Windows.Forms.TextBox initBalanceTXTBox;
        private System.Windows.Forms.Button addAccountBtn;
        private System.Windows.Forms.ListBox listBox1;
    }
}