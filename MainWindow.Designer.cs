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
            this.SuspendLayout();
            // 
            // openAdminBtn
            // 
            this.openAdminBtn.Location = new System.Drawing.Point(326, 78);
            this.openAdminBtn.Name = "openAdminBtn";
            this.openAdminBtn.Size = new System.Drawing.Size(187, 23);
            this.openAdminBtn.TabIndex = 0;
            this.openAdminBtn.Text = "open Admin window";
            this.openAdminBtn.UseVisualStyleBackColor = true;
            this.openAdminBtn.Click += new System.EventHandler(this.openAdminBtn_Click);
            // 
            // newATMBtn
            // 
            this.newATMBtn.Location = new System.Drawing.Point(326, 159);
            this.newATMBtn.Name = "newATMBtn";
            this.newATMBtn.Size = new System.Drawing.Size(75, 23);
            this.newATMBtn.TabIndex = 1;
            this.newATMBtn.Text = "button2";
            this.newATMBtn.UseVisualStyleBackColor = true;
            this.newATMBtn.Click += new System.EventHandler(this.newATMBtn_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.newATMBtn);
            this.Controls.Add(this.openAdminBtn);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button openAdminBtn;
        private System.Windows.Forms.Button newATMBtn;
    }
}