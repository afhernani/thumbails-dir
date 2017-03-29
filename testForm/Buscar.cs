using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThumbLib;

namespace testForm
{
    public partial class Buscar : Form
    {
        public Buscar()
        {
            InitializeComponent();
        }

        private void BtnAction_Click(object sender, EventArgs e)
        {
            // si ratio-boton esta abilitado es un directorio
            // el label dir de cabeza, si no es un fichero.

            //comprobaremos si existe el fichero o el directorio
            //que se pretende busacar.

            //comprobar si existe el directorio en donde buscar.

            //los resultados deben ser incluidos en list
            WorkingHard();
        }
        private void WorkingHard()
        {
            string what = textBoxWhat.Text;
            string where = textBoxWhere.Text;
            if (string.IsNullOrEmpty(what) && string.IsNullOrWhiteSpace(what)) return;
            if (string.IsNullOrEmpty(where) && string.IsNullOrWhiteSpace(where)) return;
            if (Directory.Exists(what))
            {
                //busqueda comparativa de cada fichero en el directorio
                //con respecto al otro directorio.
                string[] lista = Founder.ArrayFilesFromDirectory(what);
                //StringBuilder build = new StringBuilder();
                foreach (var item in lista)
                {
                    richTextBox.AppendText(item + "\n");
                    if (Directory.Exists(where))
                    {
                        foun.SearchFileinDirectory(new DirectoryInfo(where), new FileInfo(item));
                    }
                    //build.Append(item).Append("\n");
                }
                //richTextBox.AppendText(build.ToString());
            }else //es una cadena
            {
                if (Directory.Exists(where))
                {
                    foun.SearchFileinDirectory(new DirectoryInfo(where), new FileInfo(what));
                }
            }
        }
        Founder foun = new Founder();

        private void Buscar_Load(object sender, EventArgs e)
        {
            foun.FileFounderEvent += FileLocalizado;
        }

        private void FileLocalizado(FileInfo file)
        {
            if(file != null)
            {
                richTextBox.AppendText(file.FullName.ToString()+"\n");
                //if (Path.GetFullPath(file.FullName) == null) Console.WriteLine(file.FullName.ToString());
            }else
            {
                richTextBox.AppendText("End\n");
            }
        }
    }
}
