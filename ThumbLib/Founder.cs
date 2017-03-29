using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThumbLib
{
    public partial class Founder : Component
    {
        public List<string> FilesNotFound { get; set; } = new List<string>();
        public Founder()
        {
            InitializeComponent();
        }

        public Founder(IContainer container)
        {
            container.Add(this);

            InitializeComponent();  
        }
        /// <summary>
        /// delegado genericoa implement interfaz IEnumerable
        /// </summary>
        public delegate IEnumerable getChilds<T>(T element);
        /// <summary>
        /// Función generica de busqueda implement interfaz IEnumerable
        /// se obtiene los nodos de busqueda IEnumerable (elementos) por
        /// que los elementos sólo implementan la interfaz no generiaca.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parent">Elemento contenedor</param>
        /// <param name="elements">coleccion de elementos implementan IEnumerable</param>
        /// <param name="criterial">logica del criterio de busqueda</param>
        /// <returns></returns>
        IEnumerable<T> FindRescursive<T>(T parent, getChilds<T> elements, Predicate<T> criterial)
        {
            foreach (T element in elements.Invoke(parent))
            {
                if (criterial.Invoke(element))
                    yield return element;
                foreach (T element2 in FindRescursive<T>(element, elements, criterial))
                {
                    yield return element2;
                }
            }
        }//end FindRecursive.
        /// <summary>
        /// Criterio de busqueda bajo la definicion de delegado.
        /// </summary>
        readonly Predicate<DirectoryInfo> LookForDirectory = (DirectoryInfo D) => D is DirectoryInfo;
        /// <summary>
        /// este delegado define como se obtiene los subdirectorios.
        /// </summary>
        readonly getChilds<DirectoryInfo> getChildDirectorys = (DirectoryInfo D)=> D.GetDirectories();
        /// <summary>
        /// busca recursiva un fichero en el directorio y subdirectorios pasado
        /// devuelve cauantas veces se repite, si se repite.
        /// </summary>
        /// <param name="Dir">directorio donde buscar</param>
        /// <param name="file">nombre del fichero a buscar</param>
        public void SearchFileinDirectory(DirectoryInfo Dir, FileInfo file)
        {
            bool encontrado = false;
            foreach (DirectoryInfo element in FindRescursive<DirectoryInfo>(Dir, getChildDirectorys, LookForDirectory))
            {
                //Console.WriteLine(element.Name);
                Debug.WriteLine(element.Name);               
                foreach (FileInfo item in element.GetFiles())
                {
                    if (item.Name.Equals(file.Name))
                    {
                        encontrado = true;
                        OnFileFounderHandler(item);
                        //Console.WriteLine($"found in directory:{element.Name} fichero: {item.FullName}");
                        Debug.WriteLine($"found in directory:{element.Name} fichero: {item.FullName}");
                    }
                }
            }
            if (!encontrado)
            {
                //no fue encontrado.
                FilesNotFound.Add(file.Name);

            }
            OnFileFounderHandler(null);//simepre que termina la busqueda
        }
        /// <summary>
        /// devuelve un array string de los nombres de ficheros
        /// contenidos en el directorio pasado.
        /// -devuelve null si no existe nada.
        /// </summary>
        /// <param name="dir">directorio a extraer la lista de ficheros</param>
        /// <returns></returns>
        public static string[] ArrayFilesFromDirectory(string dir)
        {
            if (!string.IsNullOrEmpty(dir) && Directory.Exists(dir))
            {
                string[] files = Directory.GetFiles(dir, "*.*");
                string[] filesNames = new string[files.Length];
                for (int i = 0; i < files.Length; i++)
                {
                    filesNames[i] = Path.GetFileName(files[i]);
                }
                return filesNames;
            }
            return null;
        }
        public delegate void FileFounder(FileInfo file);
        public event FileFounder FileFounderEvent;
        private void OnFileFounderHandler(FileInfo file)
        {
            FileFounderEvent?.Invoke(file);
        }
    }
}
