namespace assignment3
{
    partial class AltATM
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.inputPadTable = new System.Windows.Forms.TableLayoutPanel();
            this.Screen = new System.Windows.Forms.TableLayoutPanel();
            this.output = new System.Windows.Forms.Label();
            this.input = new System.Windows.Forms.Label();
            this.Del = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.Enter = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.inputPadTable.SuspendLayout();
            this.Screen.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.inputPadTable, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Screen, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 308F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(349, 495);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // inputPadTable
            // 
            this.inputPadTable.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.inputPadTable.ColumnCount = 4;
            this.inputPadTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.inputPadTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.inputPadTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.inputPadTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.inputPadTable.Controls.Add(this.Del, 3, 0);
            this.inputPadTable.Controls.Add(this.Clear, 3, 1);
            this.inputPadTable.Controls.Add(this.Enter, 3, 2);
            this.inputPadTable.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.inputPadTable.Location = new System.Drawing.Point(64, 231);
            this.inputPadTable.Name = "inputPadTable";
            this.inputPadTable.RowCount = 4;
            this.inputPadTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.inputPadTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.inputPadTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.inputPadTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.inputPadTable.Size = new System.Drawing.Size(220, 220);
            this.inputPadTable.TabIndex = 0;
            // 
            // Screen
            // 
            this.Screen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Screen.BackColor = System.Drawing.Color.OliveDrab;
            this.Screen.ColumnCount = 1;
            this.Screen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Screen.Controls.Add(this.input, 0, 1);
            this.Screen.Controls.Add(this.output, 0, 0);
            this.Screen.Location = new System.Drawing.Point(74, 43);
            this.Screen.Margin = new System.Windows.Forms.Padding(0);
            this.Screen.Name = "Screen";
            this.Screen.RowCount = 2;
            this.Screen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Screen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Screen.Size = new System.Drawing.Size(200, 100);
            this.Screen.TabIndex = 1;
            // 
            // output
            // 
            this.output.AutoSize = true;
            this.output.Location = new System.Drawing.Point(3, 3);
            this.output.Margin = new System.Windows.Forms.Padding(3);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(37, 13);
            this.output.TabIndex = 0;
            this.output.Text = "output";
            // 
            // input
            // 
            this.input.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.input.AutoSize = true;
            this.input.Location = new System.Drawing.Point(3, 84);
            this.input.Margin = new System.Windows.Forms.Padding(3);
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(0, 13);
            this.input.TabIndex = 1;
            // 
            // Del
            // 
            this.Del.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Del.Location = new System.Drawing.Point(168, 3);
            this.Del.Name = "Del";
            this.Del.Size = new System.Drawing.Size(49, 49);
            this.Del.TabIndex = 0;
            this.Del.Text = "Del";
            this.Del.UseVisualStyleBackColor = true;
            // 
            // Clear
            // 
            this.Clear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Clear.Location = new System.Drawing.Point(168, 58);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(49, 49);
            this.Clear.TabIndex = 1;
            this.Clear.Text = "Clear";
            this.Clear.UseVisualStyleBackColor = true;
            // 
            // Enter
            // 
            this.Enter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Enter.Location = new System.Drawing.Point(168, 113);
            this.Enter.Name = "Enter";
            this.Enter.Size = new System.Drawing.Size(49, 49);
            this.Enter.TabIndex = 2;
            this.Enter.Text = "Enter";
            this.Enter.UseVisualStyleBackColor = true;
            // 
            // AltATM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 519);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AltATM";
            this.Text = "AltATM";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.inputPadTable.ResumeLayout(false);
            this.Screen.ResumeLayout(false);
            this.Screen.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel inputPadTable;
        private System.Windows.Forms.TableLayoutPanel Screen;
        private System.Windows.Forms.Label output;
        private System.Windows.Forms.Label input;
        private System.Windows.Forms.Button Del;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.Button Enter;
    }
}