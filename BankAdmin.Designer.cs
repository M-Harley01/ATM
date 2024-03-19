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
            this.accountNumberTXTBox = new System.Windows.Forms.TextBox();
            this.pinTXTBox = new System.Windows.Forms.TextBox();
            this.initBalanceTXTBox = new System.Windows.Forms.TextBox();
            this.addAccountBtn = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // accountNumberTXTBox
            // 
            this.accountNumberTXTBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.accountNumberTXTBox.Location = new System.Drawing.Point(81, 3);
            this.accountNumberTXTBox.Name = "accountNumberTXTBox";
            this.accountNumberTXTBox.Size = new System.Drawing.Size(282, 20);
            this.accountNumberTXTBox.TabIndex = 0;
            this.accountNumberTXTBox.Text = "account number";
            // 
            // pinTXTBox
            // 
            this.pinTXTBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pinTXTBox.Location = new System.Drawing.Point(81, 27);
            this.pinTXTBox.Name = "pinTXTBox";
            this.pinTXTBox.Size = new System.Drawing.Size(282, 20);
            this.pinTXTBox.TabIndex = 1;
            this.pinTXTBox.Text = "account pin";
            // 
            // initBalanceTXTBox
            // 
            this.initBalanceTXTBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.initBalanceTXTBox.Location = new System.Drawing.Point(81, 50);
            this.initBalanceTXTBox.Name = "initBalanceTXTBox";
            this.initBalanceTXTBox.Size = new System.Drawing.Size(282, 20);
            this.initBalanceTXTBox.TabIndex = 2;
            this.initBalanceTXTBox.Text = "account balance";
            this.initBalanceTXTBox.TextChanged += new System.EventHandler(this.initBalanceTXTBox_TextChanged);
            // 
            // addAccountBtn
            // 
            this.addAccountBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.addAccountBtn.Location = new System.Drawing.Point(148, 77);
            this.addAccountBtn.Name = "addAccountBtn";
            this.addAccountBtn.Size = new System.Drawing.Size(147, 23);
            this.addAccountBtn.TabIndex = 3;
            this.addAccountBtn.Text = "add account";
            this.addAccountBtn.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(3, 109);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(438, 498);
            this.listBox1.TabIndex = 4;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.addAccountBtn, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.listBox1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.initBalanceTXTBox, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.pinTXTBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.accountNumberTXTBox, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(100, 100);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.58139F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.41861F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 505F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(444, 611);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // BankAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 635);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "BankAdmin";
            this.Text = "Form2";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        private void Bind()
        {
            this.addAccountBtn.Click += (sender, e) => this.addAccountBtn_Click(sender, e, this.accountNumberTXTBox.Text, this.pinTXTBox.Text, this.initBalanceTXTBox.Text);
        }

        #endregion
        private System.Windows.Forms.TextBox accountNumberTXTBox;
        private System.Windows.Forms.TextBox pinTXTBox;
        private System.Windows.Forms.TextBox initBalanceTXTBox;
        private System.Windows.Forms.Button addAccountBtn;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}