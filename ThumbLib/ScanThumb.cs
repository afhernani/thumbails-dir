using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThumbLib
{
    public partial class ScanThumb: UserControl
    {
        public ScanThumb()
        {
            InitializeComponent();
            this.AddFilesEvent += AddFilesHandler;
            this.AddThumbsEvent += AddThumbsHandler;
        }

        public ScanThumb(string path)
        {
            InitializeComponent();
            this.AddFilesEvent += AddFilesHandler;
            this.AddThumbsEvent += AddThumbsHandler;
            this.AddListDiferenceEvent += AddListDiferenceHandler;
            AssingPaths(path);
        }

        private string PathDir { get; set; } = null;
        private string PathThumb { get; set; } = null;

        private void AssingPaths(string path)
        {
            PathDir = path;
            PathThumb = Path.Combine(path, "Thumbails");
            //si no existe directorio lo crea
            if (!Directory.Exists(PathThumb))
            {
                Directory.CreateDirectory(PathThumb);
            }
            DirectoryInfo dir = new DirectoryInfo(PathThumb);
            dir.Attributes=FileAttributes.Hidden;
            Debug.WriteLine($"Asignado los paths ...");
            MakeLists();
            Debug.WriteLine($"Creadas las dos listas ...");
            AnalisisPaths(); //encontramos los ficheros que faltan
            Debug.WriteLine($"Analisis de directorios");
            WorkingDatos(); //trabajos los datos.

        }

        public bool MakeThumb { get; set; } = false;
        private void WorkingDatos()
        {
            //tenemos la lista de la diferencia.-no sabemos si son
            //ficheros video o gif lo que sobra. 
            //comprobamos si existe el fichero gif, si existe es
            //un fichero de de video y borramos el gif
            foreach (string fileName in ListDiference)
            {
                string filegif = Path.Combine(PathThumb, fileName);
                if (File.Exists(filegif))
                {
                    File.Delete(filegif);
                    Debug.WriteLine($"{filegif} --> delete.");
                }
                else
                {
                    string movfile = GetFileNameFromString(fileName);
                    string filemov = Path.Combine(PathDir, movfile);
                    if (File.Exists(filemov))
                    {
                        Debug.WriteLine($"{filemov} --> Pendiente make gif");
                    }
                }
            }
        }

        public static string GetFileNameFromString(string name)
        {
            int pos = name.IndexOf(@"_thumbs_", StringComparison.Ordinal);
            if (pos == -1)
                return name;
            name = name.Substring(0, pos);
            return Path.GetFileName(name);
        }
        private List<string> ListFiles { get; set; } = null;
        private List<string> ListThumbs { get; set; } = null;
        private List<string> ListDiference { get; set; } = null;

        private void MakeLists()
        {
            string[] files = ArrayDirectory(PathDir);
            string[] thumbs = ArrayDirectory(PathThumb);
            lock(this)
            {
                if (thumbs != null && files != null)
                {
                    AddFilesEvent?.Invoke(files);
                    AddThumbsEvent?.Invoke(thumbs);
                    Debug.WriteLine($"disparo de eventos add array list directories.");
                }     
            }
            //debemos analizar las listas.
            
        }

        public string Extc { get; set; } = ".gif|.flv|.mp4|.ts|.ts|.avi|.mpg|.mpeg|.web|.mkv";

        private List<string> TransFilesToNameThumbails()
        {
            List<string> listfilesthumbails = new List<string>();
            foreach (var file in ListFiles)
            {
                listfilesthumbails.Add(file+"_thumbs_0000.gif");
            }
            return listfilesthumbails;
        }
        private void AnalisisPaths()
        {
            List<string> listfilesthumbails = TransFilesToNameThumbails();

            var differences = listfilesthumbails.Where(x => ListThumbs.All(x1 => x1 != x))
            .Union(ListThumbs.Where(x => listfilesthumbails.All(x1 => x1 != x))).ToList();
            if (differences.Count() != 0)
            {
                Debug.WriteLine($"differences: {differences.GetType()}");
                lock(this){ AddListDiferenceEvent?.Invoke((List<string>) differences);}
            }
        }

        delegate void AddArrayFiles(string[] files);
        private event AddArrayFiles AddFilesEvent;
        delegate void AddArrayThumbs(string[] thumbs);
        private event AddArrayThumbs AddThumbsEvent;

        delegate void AddListDiference(List<string> ls);
        private event AddListDiference AddListDiferenceEvent;

        private void AddListDiferenceHandler(List<string> ls)
        {
            ListDiference = ls;
            OutList(ListDiference);
        }

        private void AddFilesHandler(string[] files)
        {
            //this.BeginInvoke(new AddArrayFiles(AddFiles), new Object[] {files});
            AddFiles(files);
        }

        private void AddFiles(string[] files)
        {
            ListFiles=new List<string>();
            files = files.Where(x => IsExt(Path.GetExtension(x).ToLower())).ToArray();
            ListFiles.AddRange(files);
            OutList(ListFiles);
        }
        private void AddThumbsHandler(string[] thumbs)
        {
            //this.BeginInvoke(new AddArrayFiles(AddThums), new Object[] { thumbs });
            AddThums(thumbs);
        }

        private void AddThums(string[] thumbs)
        {
            ListThumbs=new List<string>();
            thumbs = thumbs.Where(x => IsExt(Path.GetExtension(x).ToLower())).ToArray();
            ListThumbs.AddRange(thumbs);
            OutList(ListThumbs);
        }
        private string[] ArrayDirectory(string dir)
        {
            if (!string.IsNullOrEmpty(dir) && Directory.Exists(dir))
            {              
                string[] files = Directory.GetFiles(dir, "*.*");
                string[] filesNames = new string[files.Length];
                for (int i = 0; i < files.Length; i++)
                {
                    filesNames[i]= Path.GetFileName(files[i]);
                }
                return filesNames;
            }
            return null;
        }
        private void OutList(List<string> ls)
        {
            Debug.WriteLine($"---------\nList \n{ls.Count}");
            if (ls.Count == 0) Debug.WriteLine($"Ningún elemento.");
            foreach (var l in ls)
            {
                Debug.WriteLine($"ELEM: {l}");
            }
            Debug.WriteLine($"--------");
        }

        private bool IsExt(string ext)
        {
            bool comp = false;
            if (string.IsNullOrEmpty(ext)) return comp;
            string[] etc = Extc.Split('|');
            foreach (string item in etc)
            {
                comp= ext.ToLower().Equals(item.ToLower());
                if (comp == true) break;
            }
            return comp;
        }
    }
}
