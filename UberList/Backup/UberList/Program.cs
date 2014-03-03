using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Un4seen.Bass;
using Un4seen.Bass.AddOn.Tags;
using TagLib;
using System.Threading;

namespace UberList
{
    class Program
    {
        static List<string> m_files = new List<string>();
        static DateTime dtStart;
        static DateTime dtFinish;
        static DateTime dtStart2;
        static DateTime dtFinish2;
        static TimeSpan dtSpan2;
        static DateTime dtStart3;
        static DateTime dtFinish3;
        static TimeSpan dtSpan3;

        static void Main(string[] args)
        {
            Thread bassThread = new Thread(new ThreadStart(ParseFilesBass));
            Thread tlibThread = new Thread(new ThreadStart(ParseFilesTagLib));
            dtStart = DateTime.Now;
            GetDirs(@"K:\Uber\DL");
            dtFinish = DateTime.Now;
            TimeSpan diff = dtFinish - dtStart;
            string ms = diff.TotalMilliseconds.ToString();
            string s = diff.TotalSeconds.ToString();
            int Count = m_files.Count;
            double perFile = diff.TotalMilliseconds / Count;
            Console.WriteLine(Count.ToString());
            Console.WriteLine(ms + " " + s);
            Console.WriteLine(perFile.ToString());
            // bassThread.Start();
            tlibThread.Start();
           
            Console.ReadLine();
        }

        static public void ParseFilesTagLib()
        {
            TimeSpan diff = dtFinish - dtStart;
            string ms = diff.TotalMilliseconds.ToString();
            string s = diff.TotalSeconds.ToString();
            int Count = m_files.Count;
            double perFile = diff.TotalMilliseconds / Count;

            dtStart = DateTime.Now;
            foreach (string f in m_files)
            {
                // Console.WriteLine(s);
                dtStart2 = DateTime.Now;
                //TagLib.File trackInfo = TagLib.File.Create(f);
                //TAG_INFO tagInfo = BassTags.BASS_TAG_GetFromFile(s);
                //if (tagInfo != null)
                //Console.WriteLine(tagInfo.album + " " + tagInfo.artist + " " + tagInfo.year);
                //Console.WriteLine(trackInfo.Tag.Album + " " + trackInfo.Tag.FirstArtist + " " + trackInfo.Tag.Year);
                dtFinish2 = DateTime.Now;
                dtSpan2 = dtFinish2 - dtStart2;
                string ms2 = dtSpan2.TotalMilliseconds.ToString();
                //Console.WriteLine("TLIB: "+ trackInfo.Tag.FirstArtist + " - " + trackInfo.Tag.Year + " - " + trackInfo.Tag.Album + " obtained in " + ms2 + "ms");
            }
            dtFinish = DateTime.Now;
            diff = dtFinish - dtStart;
            ms = diff.TotalMilliseconds.ToString();
            s = diff.TotalSeconds.ToString();
            Count = m_files.Count;
            perFile = diff.TotalMilliseconds / Count;
            Console.WriteLine(Count.ToString());
            Console.WriteLine(ms + " " + s);
            Console.WriteLine(perFile.ToString());


        }

        static public void ParseFilesBass()
        {
            if (Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero, null))
                {
                foreach (string s in m_files)
                {
                    // Console.WriteLine(s);
                    dtStart3 = DateTime.Now;
                    //TagLib.File trackInfo = TagLib.File.Create(s);
                    //TAG_INFO tagInfo = BassTags.BASS_TAG_GetFromFile(s);
                    //if (tagInfo != null)
                        //Console.WriteLine(tagInfo.album + " " + tagInfo.artist + " " + tagInfo.year);
                    //Console.WriteLine(trackInfo.Tag.Album + " " + trackInfo.Tag.FirstArtist + " " + trackInfo.Tag.Year);
                    dtFinish3 = DateTime.Now;
                    dtSpan3 = dtFinish3 - dtStart3;
                    string ms = dtSpan3.TotalMilliseconds.ToString();
                    Console.WriteLine("Bass: " + ms + "ms");
                }
            }
        }

        static public void GetDirs(string baseDir)
        {
            string[] dirs = Directory.GetDirectories(baseDir);
            foreach (string d in dirs)
            {
                GetDirs(d);
            }
            string[] files = Directory.GetFiles(baseDir, "*.mp3");
            foreach (string f in files)
                m_files.Add(f);
            files = Directory.GetFiles(baseDir, "*.ogg");
            foreach (string f in files)
                m_files.Add(f);
            files = Directory.GetFiles(baseDir, "*.flac");
            foreach (string f in files)
                m_files.Add(f);
        }
    }
}
