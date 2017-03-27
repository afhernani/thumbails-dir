using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
            scan.EndThreadEvent += Endthreadfiles;
            scan.EndOneThreadEvent += EndOneThreadFile;
            scan.Star();
            Debug.WriteLine($"Tarea() ==> Finalizada ..");          
        }

        private void EndOneThreadFile(string commit, int total)
        {
            listBoxTareas.Items.Add($"{commit}");
            _index++;
            labelIndex.Text = (total-_index).ToString();
        }

        
        private int _index = 0;
        private void Endthreadfiles(string[] workfiles, bool tar)
        {
            BtnTask.Enabled = true;
            listBoxTareas.Items.AddRange(workfiles);
            _index = 0;
        }

        private void BtnTask_Click(object sender, EventArgs e)
        {
            listBoxTareas.Items.Clear();
            if (Directory.Exists(textBox1.Text))
            {
                BtnTask.Enabled = false;
                T = Task.Factory.StartNew(Tarea);
            }
            else
            {
                MessageBox.Show($"No exite del directorio {textBox1.Text}");
            }
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
