using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace hp_tac_tk_remdspace
{
    class Program
    {
        static void Main(string[] args)
        {
            if (File.Exists(args[0]))
            {
                string[] lines = File.ReadAllLines(args[0]);
                StreamWriter sw = new StreamWriter("Test.txt");
                foreach (string line in lines)
                {
                    string cleanline = System.Text.RegularExpressions.Regex.Replace(line, @"\s{2,}", " ");
                    cleanline = Regex.Replace(cleanline, @"\u00A0", " ");
                    sw.WriteLine(cleanline);
                }
                sw.Flush();
                sw.Close();
            }
            else {
                Console.WriteLine("File does not exist: " + args[0]);
            }
        }
    }
}
