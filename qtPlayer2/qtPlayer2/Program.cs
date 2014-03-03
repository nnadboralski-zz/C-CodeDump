using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace qtPlayer2
{
    class Program
    {      
        [STAThread]
        static void Main(string[] args)
        {
            Application.Run(new qtPlayer(args));
        }
    }
}
