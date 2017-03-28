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
        /// busca recursiva un fichero en todos los directorios a ver
        /// si se repite.
        /// </summary>
        /// <param name="Dir"></param>
        /// <param name="file"></param>
        public void SearchFileinDirectory(DirectoryInfo Dir, FileInfo file)
        {
            foreach (DirectoryInfo element in FindRescursive<DirectoryInfo>(Dir, getChildDirectorys, LookForDirectory))
            {
                Console.WriteLine(element.Name);
                Debug.WriteLine(element.Name);               
                foreach (FileInfo item in element.GetFiles())
                {
                    if (item.Name.Equals(file.Name))
                    {
                        Console.WriteLine($"found in directory:{element.Name} fichero: {item.FullName}");
                        Debug.WriteLine($"found in directory:{element.Name} fichero: {item.FullName}");
                    }
                }
            }
        }
    }
}
