﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThumbLib;

namespace testForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Task T;

        private void BtnAction_Click(object sender, EventArgs e)
        {
            ScanThumb scan = new ScanThumb(textBox1.Text);
            scan.Star();
            MessageBox.Show($"Tarea finalizada");
        }

        private void Tarea()
        {
            ScanThumb scan = new ScanThumb(textBox1.Text);
            scan.Star();
            Debug.WriteLine($"Tarea() ==> Finalizada ..");
        }

        private void BtnTask_Click(object sender, EventArgs e)
        {
            T = Task.Factory.StartNew(Tarea);
        }
    }
}
