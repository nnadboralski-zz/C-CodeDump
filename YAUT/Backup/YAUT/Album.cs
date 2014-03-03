using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace YAUT
{
    class Album : List<Track>
    {
        private string m_title;
        private string m_year;
        private string m_artist;
        private string m_path;
        private string m_hash;

        public string Title { get { return m_title; } }
        public string Year { get { return m_year; } }
        public string Artist { get { return m_artist; } }
        public string FPath { get { return m_path; } }
        public string Hash { get { return m_hash; } }

        public Album(string folder)
        {
            Debug.WriteLine(folder);
            m_path = folder;
            string[] files = Directory.GetFiles(folder,"*.mp3");
            foreach (string s in files)
                Add(new Track(s));
            for (int j = 0; j < this.Count; j++)
            {
                if (this[0].Artist == this[j].Artist)
                {
                    m_artist = this[j].Artist;
                }
                else
                {
                    m_artist = "Various Artists";
                }
            }
            m_title = this[0].Album;
            m_year = this[0].Year.ToString();
            HashAlgorithm hash = new SHA512Managed();
            StringBuilder sb = new StringBuilder();
            sb.Append(this.Count.ToString());
            foreach (Track t in this)
                sb.Append(((int)t.Duration.TotalSeconds).ToString());
            string hashData = sb.ToString();
            byte[] hashBytes = hash.ComputeHash(Encoding.UTF8.GetBytes(hashData));
            m_hash = Convert.ToBase64String(hashBytes);
        }

        public Album(string xml, bool dummy)
        {
        }
    }
}
