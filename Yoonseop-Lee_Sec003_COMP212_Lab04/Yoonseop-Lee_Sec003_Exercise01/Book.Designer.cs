namespace Yoonseop_Lee_Sec003_Exercise01
{
    partial class Book
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
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.queriesComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // outputTextBox
            // 
            this.outputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputTextBox.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputTextBox.Location = new System.Drawing.Point(13, 3);
            this.outputTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputTextBox.Size = new System.Drawing.Size(962, 504);
            this.outputTextBox.TabIndex = 1;
            // 
            // queriesComboBox
            // 
            this.queriesComboBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.queriesComboBox.FormattingEnabled = true;
            this.queriesComboBox.Items.AddRange(new object[] {
            "Authors and Titles (Sort by title):",
            "Authors and Titles (Sort by title and authors name):",
            "authors grouped by title:"});
            this.queriesComboBox.Location = new System.Drawing.Point(0, 548);
            this.queriesComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.queriesComboBox.Name = "queriesComboBox";
            this.queriesComboBox.Size = new System.Drawing.Size(991, 24);
            this.queriesComboBox.TabIndex = 4;
            this.queriesComboBox.SelectedIndexChanged += new System.EventHandler(this.queriesComboBox_SelectedIndexChanged);
            // 
            // Book
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 572);
            this.Controls.Add(this.queriesComboBox);
            this.Controls.Add(this.outputTextBox);
            this.Name = "Book";
            this.Text = "Book";
            this.Load += new System.EventHandler(this.Book_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox outputTextBox;
        private System.Windows.Forms.ComboBox queriesComboBox;
    }
}

