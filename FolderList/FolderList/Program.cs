using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace FolderList
{
    class Program
    {
        public static List<string> folders = new List<string>();
        public static List<string> fileList = new List<string>();
        public static List<string> errors = new List<string>();
        public static List<string> noMP3 = new List<string>();
        public static List<string> noPun = new List<string>();
        public static List<string> noLog = new List<string>();
        public static List<string> APX = new List<string>();
        public static List<string> flac = new List<string>();
        public static List<string> ogg = new List<string>();
        public static List<string> empty = new List<string>();
        static void Main(string[] args)
        {
            foreach (string s in args)
                ParseFolder(s);
            foreach (string s in folders)
            {
                string[] files = Directory.GetFiles(s);
                if (files.Length == 0)
                    empty.Add(s);
                if (SearchFiles(files, ".log").Count == 0)
                    noLog.Add(s);
                else
                {
                    if (SearchFiles(files, ".mp3").Count == 0)
                        noMP3.Add(s);
                    if (ContainsText(SearchFiles(files, ".log"), ".APX."))
                        APX.Add(s);
                }
                if (SearchFiles(files, ".pun").Count == 0 && SearchFiles(files, ".flac").Count == 0)
                    noPun.Add(s);
                else if (SearchFiles(files, ".flac").Count > 0)
                    flac.Add(s);
                if (s.IndexOf("!!!_ERRORS_!!!") != -1)
                    errors.Add(s);
            }
            foreach (string s in empty)
                Console.WriteLine("Empty: " + s);
            foreach (string s in noLog)
                Console.WriteLine("NoLog: " + s);
            foreach (string s in APX)
                Console.WriteLine("APX: " + s);
            foreach (string s in noPun)
                Console.WriteLine("NoPun: " + s);
            foreach (string s in flac)
                Console.WriteLine("Flac: " + s);
            foreach (string s in noMP3)
                Console.WriteLine("NoMP3: " + s);
            foreach (string s in errors)
                Console.WriteLine("Errors: " + s);

            Console.WriteLine("Empty Count: " + empty.Count.ToString());
            Console.WriteLine("NoLog Count: " + noLog.Count.ToString());
            Console.WriteLine("APX Count: " + APX.Count.ToString());
            Console.WriteLine("NoPun Count: " + noPun.Count.ToString());
            Console.WriteLine("Flac Count: " + flac.Count.ToString());
            Console.WriteLine("Error Count: " + errors.Count.ToString());



        }
        static List<string> SearchFiles(string[] files, string pattern)
        {
            List<string> ret = new List<string>();
            foreach (string s in files)
            {
                if (s.Substring(s.Length - pattern.Length, pattern.Length) == pattern)
                    ret.Add(s);
            }
            return ret;
        }

        static bool ContainsText(List<string> files, string text)
        {
            bool ret = false;
            foreach (string s in files)
                if (s.IndexOf(text) != -1)
                    ret = true;
            return ret;
        }

        static void ParseFolder(string s)
        {
            try
            {
                string[] dirs = Directory.GetDirectories(s);
                foreach (string d in dirs)                   
                    ParseFolder(d);
                folders.Add(s);
            }
            catch { }
        }
    }
}
