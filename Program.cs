using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Web;
using System.Windows.Forms;
//using System.Windows.Forms;

namespace WindowsFormsExcercise {
    internal class Program {
        [STAThread]
        static void Main(string[] args) {
            string s = "form1";
            Form1 PrvniFormular = new Form1();
            Console.WriteLine("Zadejte text, ktery bude");
            Console.WriteLine("v titulku okna formulare.");
            s = Console.ReadLine();
            PrvniFormular.Text = s;
            Application.Run(PrvniFormular);
        }
    }
}