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
using System.Diagnostics;
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
            scan.Star();
            Debug.WriteLine($"Tarea() ==> Finalizada ..");          
        }

        private void EndOneThreadFile(string commit, int total)
        {
            this.BeginInvoke(new ScanThumb.EndOneThread(EndOneThreadHandler), new Object[] { commit, total });    
        }

        private void EndOneThreadHandler(string commit, int total)
        {
            listBoxTareas.Items.Add($"{commit}");
            _index++;
            labelIndex.Text = (total - _index).ToString();
        }

        private int _index = 0;
        private void EndthreadfileAll(string[] workfiles, bool tar)
        {
            this.BeginInvoke(new ScanThumb.EndThreadFile(EndThreadFileHandler), new Object[] { workfiles,tar });
               
        }
        private void EndThreadFileHandler(string[] workfiles, bool tar)
        {
            listBoxTareas.Items.Clear();
            BtnTask.Enabled = true;
            listBoxTareas.Items.AddRange(workfiles);
        }
        private ScanThumb scan;
        private void BtnTask_Click(object sender, EventArgs e)
        {
            _index = 0;
            listBoxTareas.Items.Clear();
            if (Directory.Exists(textBox1.Text))
            {
                BtnTask.Enabled = false;
                scan = new ScanThumb(textBox1.Text);
                scan.EndThreadEvent += EndthreadfileAll;
                scan.EndOneThreadEvent += EndOneThreadFile;
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
            foreach (Process proceso in Process.GetProcesses())
            {
                Debug.WriteLine($"Proceso : {proceso.ProcessName}");
                if (proceso.ProcessName == "ffmpeg")
                    proceso.Kill();
            }
        }

        private void ThumbForm_Load(object sender, EventArgs e)
        {
            string dirwork = Properties.Settings.Default.FileDir;
            if (!String.IsNullOrEmpty(dirwork)) textBox1.Text = dirwork;
        }
        /// <summary>
        /// lanza formulario buscar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Buscar busca = new Buscar();
            busca.Show();
        }
    }
}
