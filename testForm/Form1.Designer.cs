namespace testForm
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
            this.BtnAction = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // BtnAction
            // 
            this.BtnAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAction.Location = new System.Drawing.Point(463, 43);
            this.BtnAction.Name = "BtnAction";
            this.BtnAction.Size = new System.Drawing.Size(97, 28);
            this.BtnAction.TabIndex = 0;
            this.BtnAction.Text = "Action";
            this.BtnAction.UseVisualStyleBackColor = true;
            this.BtnAction.Click += new System.EventHandler(this.BtnAction_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(548, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "C:\\Users\\hernani\\Downloads\\Video\\Huge-melons";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 83);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.BtnAction);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnAction;
        private System.Windows.Forms.TextBox textBox1;
    }
}

