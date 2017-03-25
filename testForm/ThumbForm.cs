using System;
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
    public partial class ThumbForm : Form
    {
        public ThumbForm()
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

        private void ThumbForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.FileDir = textBox1.Text;
            Properties.Settings.Default.Save();
        }

        private void ThumbForm_Load(object sender, EventArgs e)
        {
            string dirwork = Properties.Settings.Default.FileDir;
            if (!String.IsNullOrEmpty(dirwork)) textBox1.Text = dirwork;
        }
    }
}
