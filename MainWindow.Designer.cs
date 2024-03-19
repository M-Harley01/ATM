namespace assignment3
{
    partial class MainWindow
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
            this.openAdminBtn = new System.Windows.Forms.Button();
            this.newATMBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openAdminBtn
            // 
            this.openAdminBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.openAdminBtn.Location = new System.Drawing.Point(294, 95);
            this.openAdminBtn.Name = "openAdminBtn";
            this.openAdminBtn.Size = new System.Drawing.Size(187, 23);
            this.openAdminBtn.TabIndex = 0;
            this.openAdminBtn.Text = "open Admin window";
            this.openAdminBtn.UseVisualStyleBackColor = true;
            this.openAdminBtn.Click += new System.EventHandler(this.openAdminBtn_Click);
            // 
            // newATMBtn
            // 
            this.newATMBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.newATMBtn.Location = new System.Drawing.Point(322, 308);
            this.newATMBtn.Name = "newATMBtn";
            this.newATMBtn.Size = new System.Drawing.Size(131, 23);
            this.newATMBtn.TabIndex = 1;
            this.newATMBtn.Text = "add ATM Window";
            this.newATMBtn.UseVisualStyleBackColor = true;
            this.newATMBtn.Click += new System.EventHandler(this.newATMBtn_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.newATMBtn, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.openAdminBtn, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(776, 426);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button openAdminBtn;
        private System.Windows.Forms.Button newATMBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}