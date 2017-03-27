namespace testForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThumbForm));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.BtnTask = new System.Windows.Forms.Button();
            this.listBoxTareas = new System.Windows.Forms.ListBox();
            this.labeltex = new System.Windows.Forms.Label();
            this.labelIndex = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(548, 20);
            this.textBox1.TabIndex = 1;
            // 
            // BtnTask
            // 
            this.BtnTask.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnTask.Location = new System.Drawing.Point(566, 12);
            this.BtnTask.Name = "BtnTask";
            this.BtnTask.Size = new System.Drawing.Size(97, 28);
            this.BtnTask.TabIndex = 2;
            this.BtnTask.Text = "Tarea";
            this.BtnTask.UseVisualStyleBackColor = true;
            this.BtnTask.Click += new System.EventHandler(this.BtnTask_Click);
            // 
            // listBoxTareas
            // 
            this.listBoxTareas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxTareas.FormattingEnabled = true;
            this.listBoxTareas.Location = new System.Drawing.Point(12, 35);
            this.listBoxTareas.Name = "listBoxTareas";
            this.listBoxTareas.Size = new System.Drawing.Size(548, 82);
            this.listBoxTareas.TabIndex = 3;
            // 
            // labeltex
            // 
            this.labeltex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labeltex.AutoSize = true;
            this.labeltex.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeltex.Location = new System.Drawing.Point(570, 52);
            this.labeltex.Name = "labeltex";
            this.labeltex.Size = new System.Drawing.Size(55, 16);
            this.labeltex.TabIndex = 4;
            this.labeltex.Text = "Tareas:";
            // 
            // labelIndex
            // 
            this.labelIndex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelIndex.AutoSize = true;
            this.labelIndex.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.labelIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIndex.Location = new System.Drawing.Point(600, 79);
            this.labelIndex.Name = "labelIndex";
            this.labelIndex.Size = new System.Drawing.Size(40, 24);
            this.labelIndex.TabIndex = 5;
            this.labelIndex.Text = "000";
            // 
            // ThumbForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 133);
            this.Controls.Add(this.labelIndex);
            this.Controls.Add(this.labeltex);
            this.Controls.Add(this.listBoxTareas);
            this.Controls.Add(this.BtnTask);
            this.Controls.Add(this.textBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
        private System.Windows.Forms.ListBox listBoxTareas;
        private System.Windows.Forms.Label labeltex;
        private System.Windows.Forms.Label labelIndex;
    }
}

