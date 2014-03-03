using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UberStats
{
    class Album
    {
        private int m_iYear;
        private string m_strArtist;
        private string m_strAlbum;
      
        public int Year { get { return m_iYear; } set { m_iYear = value; } }
        public string Artist { get { return m_strArtist; } set { m_strArtist = value; } }
        public string AlbumName { get { return m_strAlbum; } set { m_strAlbum = value; } }

        public Album(int i, string ar, string al)
        {
            Year = i;
            Artist = ar;
            AlbumName = al;
        }

        public Album(string s)
        {
            Exception nodate = new Exception("No date found in album string.");
            int i = 0;
            while ((i = s.IndexOf("- ", i)) != -1)
            {
                i += 2;
                if (s.Length - i < 4) throw (nodate);

                try
                {
                    m_iYear = Convert.ToInt32(s.Substring(i, 4));
                }
                catch
                {
                    //throw (nodate);
                    continue;
                }

                m_strArtist = s.Substring(0, i-2).Trim();
                i += 4;
                if (s.Length - i > 3)
                {
                    m_strAlbum = s.Substring(i + 3).Trim();
                }
                break;
            }
            if (i == -1) throw (nodate);
        }

        public override string ToString()
        {
            if (AlbumName == "")
                return Artist + " " + Year;
            else
                return Artist + " " + Year + " " + AlbumName;
        }
    }
}
