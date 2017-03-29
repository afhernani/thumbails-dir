/*
 * Creado por SharpDevelop.
 * Usuario: hernani
 * Fecha: 17/11/2016
 * Hora: 23:15
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Windows.Forms;

namespace ThumbLib
{
	/// <summary>
	/// Description of FileLibrary.
	/// </summary>
	public class FileLibrary
	{
	    public delegate void FileHandler(string res);

	    public static event FileHandler FileEndHandler;

	    private static void OnFileEndHandler(string res)
	    {
	        if (FileEndHandler != null)
	            FileEndHandler(res);
	    }
		/// <summary>
        /// Crea un fichero vacio fichero vacio
        /// </summary>
        public static void CreateEmptyFile(string fullPath)
        {
            if (!System.IO.File.Exists(fullPath))
            {
            	System.IO.File.Create(fullPath).Close();
                OnFileEndHandler("File create.");
            }
            else
                OnFileEndHandler("File olredy exist.");
        }


        /// <summary>
        /// Crear un directorio vacio
        /// </summary>
        public static void CreateEmptyDirectory(string fullPath)
        {
            if (!System.IO.Directory.Exists(fullPath))
            {
                System.IO.Directory.CreateDirectory(fullPath);
                OnFileEndHandler("Directory create.");
            }
            else
            {
                OnFileEndHandler("Directory olready exist.");
            } 
        }


        /// <summary>
        /// Borrar un archivo
        /// </summary>
        public static void DeleteFile(string fullPath)
        {
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.FileInfo info = new System.IO.FileInfo(fullPath);
                info.Attributes = System.IO.FileAttributes.Normal;
                System.IO.File.Delete(fullPath);
                OnFileEndHandler("File deleted.");
            }
        }


        /// <summary>
        /// Borrar un directorio y su contenido
        /// </summary>
        public static void DeleteFolder(string fullPath)
        {
            if (System.IO.Directory.Exists(fullPath))
            {
                System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo(fullPath) {
                    Attributes = System.IO.FileAttributes.Normal
                };

                foreach (var info in directory.GetFileSystemInfos("*", System.IO.SearchOption.AllDirectories))
                {
                    System.IO.FileInfo fInfo = info as System.IO.FileInfo;
                    if (fInfo != null) info.Attributes = System.IO.FileAttributes.Normal;
                }
                System.Threading.Thread.Sleep(100);
                directory.Delete(true);
                OnFileEndHandler("Directory and files has been deleted.");
            }

        }


        /// <summary>
        /// Borra el contenido de un directorio
        /// </summary>
        public static void DeleteFolderContent(string fullPath)
        {
            DeleteFolder(fullPath);
            CreateEmptyDirectory(fullPath);
        }


        /// <summary>
        /// Copiar archivo
        /// </summary>
        public static void CopyFile(string origPath, string destPath, bool overwrite)
        {
            try
            {
                if (System.IO.Path.GetExtension(destPath) == "")
                {
                    destPath = System.IO.Path.Combine(destPath, System.IO.Path.GetFileName(origPath));
                }
                if(!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(destPath)))
                {
                    CreateEmptyDirectory(System.IO.Path.GetDirectoryName(destPath));
                }
                if (!System.IO.File.Exists(destPath))
                {
                    System.IO.File.Copy(origPath, destPath, true);
                }
                else
                {
                    if (overwrite == true)
                    {
                        DeleteFile(destPath);
                        System.IO.File.Copy(origPath, destPath, true);
                    }
                }
                OnFileEndHandler("File has been copied.");
            }
            catch (Exception ex)
            {
                ;
            }
        }
        /// <summary>
        /// Mover archivo.
        /// </summary>
        /// <param name="origPath">archivo origen con ruta completa</param>
        /// <param name="destPath">ruta de destino</param>
        /// <param name="overwrite">true, se sobreescribe si existe en el destino</param>
        public static void MoveFile(string origPath, string destPath, bool overwrite){
        	try
            {
                if (System.IO.Path.GetExtension(destPath) == "")
                {
                    destPath = System.IO.Path.Combine(destPath, System.IO.Path.GetFileName(origPath));
                }
                if(!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(destPath)))
                {
                    CreateEmptyDirectory(System.IO.Path.GetDirectoryName(destPath));
                }
                if (!System.IO.File.Exists(destPath))
                {
                    System.IO.File.Move(origPath, destPath);
                }
                else
                {
                    if (overwrite == true)
                    {
                        if (destPath.Equals(origPath)) return; //si es el mismo fichero
                        DeleteFile(destPath);
                        System.IO.File.Move(origPath, destPath);
                    }
                }
                OnFileEndHandler("File has been moved.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("€\\> " + ex.Message);
            }
        }
        /// <summary>
        /// Copiar el contenido de un directorio
        /// </summary>
        private static void CopyDirectoryContent(string origPath, string destPath, bool overwrite)
        {
            if (System.IO.Directory.Exists(origPath))
            {
                foreach (string dirPath in System.IO.Directory.GetDirectories(origPath, "*", System.IO.SearchOption.AllDirectories))
                {
                    CreateEmptyDirectory(dirPath.Replace(origPath, destPath));
                }

                foreach (string newPath in System.IO.Directory.GetFiles(origPath, "*.*", System.IO.SearchOption.AllDirectories))
                {
                    CopyFile(newPath, newPath.Replace(origPath, destPath), overwrite);
                }
                OnFileEndHandler("Directory and Content has been copied.");
            }
        }
		
		
		/// <summary>
        /// Copiar un directorio y su contenido
        /// </summary>
        public static void CopyDirectory(string origPath, string destPath, bool replace)
        {
            if (replace == true)
            {
            	DeleteFolder(destPath);
            	CreateEmptyDirectory(destPath);
            	CopyDirectoryContent(origPath, destPath, true);
            }
            else
            {
                CopyDirectoryContent(origPath, destPath, true);
            }
            OnFileEndHandler("Directory and files has been copied.");
        }
	}
}
