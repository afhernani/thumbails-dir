﻿namespace testForm
{
    partial class ThumbForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.BtnTask = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(548, 20);
            this.textBox1.TabIndex = 1;
            // 
            // BtnTask
            // 
            this.BtnTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnTask.Location = new System.Drawing.Point(463, 43);
            this.BtnTask.Name = "BtnTask";
            this.BtnTask.Size = new System.Drawing.Size(97, 28);
            this.BtnTask.TabIndex = 2;
            this.BtnTask.Text = "Tarea";
            this.BtnTask.UseVisualStyleBackColor = true;
            this.BtnTask.Click += new System.EventHandler(this.BtnTask_Click);
            // 
            // ThumbForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 83);
            this.Controls.Add(this.BtnTask);
            this.Controls.Add(this.textBox1);
            this.Name = "ThumbForm";
            this.Text = "Thumbails-Dir";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ThumbForm_FormClosing);
            this.Load += new System.EventHandler(this.ThumbForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button BtnTask;
    }
}
