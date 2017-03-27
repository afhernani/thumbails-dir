using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThumbLib;

namespace test
{
    class Program
    {
        private static ScanThumb scan;
        /// <summary>
        /// multi tarea con ventanas windows
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // Test if input arguments were supplied:
            if (args.Length == 0)
            {
                System.Console.WriteLine("Please enter a path");
                System.Console.WriteLine("ScanThumb: Path");
                return;
            }
            if (args.Length == 1)
            {
                System.Console.WriteLine($"args = {args.Length}");
                System.Console.WriteLine($"valour = {args[0]}");
                if (Directory.Exists(args[0]))
                {
                    scan = new ScanThumb(args[0]);
                    scan.EndThreadEvent += EndThread;
                    scan.EndOneThreadEvent += EndOne;
                    T = Task.Factory.StartNew(()=> Tarea(args[0]));
                }    
            }
            while (!Tar)
            {
                //nada.
            }
            //esperamos para salir.
            //System.Console.ReadKey();
        }

        private static void EndOne(string commit, int total)
        {
            Console.WriteLine($"{commit}");
        }

        private static Task T;


        static void Tarea(string text)
        {
            
            scan.Star();
            Debug.WriteLine($"Tarea() ==> Finalizada ..");
        }

        private static bool Tar = false;

        private static void EndThread(string[] workfiles, bool tar)
        {
            foreach (string note in workfiles)
            {
                Console.WriteLine(note);
            }
            Console.WriteLine($"END WORK");
            Tar = tar;
        }
    }
}
