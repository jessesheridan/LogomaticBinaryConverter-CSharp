namespace logomaticBinaryConverterCSharp
{
    partial class Form1
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
            this.openedFileBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.decodedTextBox = new System.Windows.Forms.TextBox();
            this.saveDecodedFileButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(464, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openedFileBox
            // 
            this.openedFileBox.Location = new System.Drawing.Point(156, 22);
            this.openedFileBox.Name = "openedFileBox";
            this.openedFileBox.ReadOnly = true;
            this.openedFileBox.Size = new System.Drawing.Size(292, 20);
            this.openedFileBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Open Binary File:";
            // 
            // decodedTextBox
            // 
            this.decodedTextBox.Location = new System.Drawing.Point(69, 57);
            this.decodedTextBox.Multiline = true;
            this.decodedTextBox.Name = "decodedTextBox";
            this.decodedTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.decodedTextBox.Size = new System.Drawing.Size(470, 395);
            this.decodedTextBox.TabIndex = 3;
            // 
            // saveDecodedFileButton
            // 
            this.saveDecodedFileButton.Location = new System.Drawing.Point(275, 458);
            this.saveDecodedFileButton.Name = "saveDecodedFileButton";
            this.saveDecodedFileButton.Size = new System.Drawing.Size(75, 23);
            this.saveDecodedFileButton.TabIndex = 4;
            this.saveDecodedFileButton.Text = "Save";
            this.saveDecodedFileButton.UseVisualStyleBackColor = true;
            this.saveDecodedFileButton.Click += new System.EventHandler(this.saveDecodedFileButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 493);
            this.Controls.Add(this.saveDecodedFileButton);
            this.Controls.Add(this.decodedTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.openedFileBox);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Logomatic Binary Converter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox openedFileBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox decodedTextBox;
        private System.Windows.Forms.Button saveDecodedFileButton;
    }
}

