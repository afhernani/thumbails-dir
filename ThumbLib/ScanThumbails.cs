using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThumbLib
{
    public partial class ScanThumbails : Component
    {
        public ScanThumbails()
        {
            InitializeComponent();
        }

        public ScanThumbails(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        public ScanThumbails(string path)
        {
            InitializeComponent();
            this.AddFilesEvent += AddFilesHandler;
            this.AddThumbsEvent += AddThumbsHandler;
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
            dir.Attributes = FileAttributes.Hidden;
            Debug.WriteLine($"Asignado los paths ...");
            MakeLists();
            Debug.WriteLine($"Cradas las listas ...");
        }

        private List<string> ListFiles { get; set; } = null;
        private List<string> ListThumbs { get; set; } = null;

        private void MakeLists()
        {
            string[] files = ArrayDirectory(PathDir);
            string[] thumbs = ArrayDirectory(PathThumb);
            lock (this)
            {
                if (thumbs != null && files != null)
                {
                    AddFilesEvent?.Invoke(files);
                    AddThumbsEvent?.Invoke(thumbs);
                    Debug.WriteLine($"disparo de eventos add array list directories.");
                }
            }
        }

        delegate void AddArrayFiles(string[] files);
        private event AddArrayFiles AddFilesEvent;
        delegate void AddArrayThumbs(string[] thumbs);
        private event AddArrayThumbs AddThumbsEvent;

        private void AddFilesHandler(string[] files)
        {
            //this.BeginInvoke(new AddArrayFiles(AddFiles), new Object[] { files });
            AddFiles(files);
        }

        private void AddFiles(string[] files)
        {
            ListFiles = new List<string>();
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
            ListThumbs = new List<string>();
            ListThumbs.AddRange(thumbs);
            OutList(ListThumbs);
        }
        private string[] ArrayDirectory(string dir)
        {
            if (!string.IsNullOrEmpty(dir) && Directory.Exists(dir))
            {
                string[] files = Directory.GetFiles(dir, "*.*");
                return files;
            }
            return null;
        }

        private void OutList(List<string> ls)
        {
            Debug.WriteLine($"---------\nList \n");
            if(ls.Count==0) Debug.WriteLine($"Ningún elemento.");
            foreach (var l in ls)
            {
                Debug.WriteLine($"ELEM: {l}");
            }
            Debug.WriteLine($"--------");
        }
    }
}

