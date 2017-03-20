using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThumbLib;

namespace test
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
                System.Console.WriteLine("Please enter a path");
                System.Console.WriteLine("ScanThumb: Path");
                return;
            }
            if (args.Length == 1)
            {
                System.Console.WriteLine($"args = {args.Length}");
                System.Console.WriteLine($"valour = {args[0]}");
                ScanThumb scan = new ScanThumb(args[0]);
                
            }
            
            //esperamos para salir.
            System.Console.ReadKey();
        }
    }
}
