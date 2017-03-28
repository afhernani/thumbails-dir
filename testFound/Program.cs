using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThumbLib;

namespace testFound
{
    
    class Program
    {
        /// <summary>
        /// multi tarea con ventanas windows
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // Test if input arguments were supplied:
            if (args.Length == 0)
            {
                System.Console.WriteLine("Please enter a Directory and Name File");
                System.Console.WriteLine(" Path Name-File");
                return;
            }
            if (args.Length == 2)
            {
                System.Console.WriteLine($"Argumentos pasados :=> {args.Length}");
                System.Console.WriteLine($"DirectoryInfo :=> {args[0]} \n FileInfo :=> {args[1]}");
                if (Directory.Exists(args[0]) && !String.IsNullOrEmpty(args[1]))
                {
                    Founder found = new Founder();
                    found.SearchFileinDirectory(new DirectoryInfo(args[0]), new FileInfo(args[1]));
                }
            }
            //while (!Tar)
            //{
            //    //nada.
            //}
            //esperamos para salir.
            System.Console.ReadKey();
        }
    }
}
