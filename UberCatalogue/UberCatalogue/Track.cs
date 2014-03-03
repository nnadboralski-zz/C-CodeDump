using System;
using System.Collections.Generic;
using System.Text;
using TagLib;

namespace UberCatalogue
{
    class Track
    {
        Album m_album;
        Artist m_artist;
        int m_trackNum;
        string m_title;
        string m_fileName;

        public Album Album { get { return m_album; } }
        public Artist Artist { get { return m_artist; } }
        public int TrackNumber { get { return m_trackNum; } }
        public string Title { get { return m_title; } }
        public string FileName { get { return m_fileName; } }

        public Track(Album al, Artist ar, int num, string title, string filename)
        {
            m_album = al;
            m_artist = ar;
            m_trackNum = num;
            m_title = title;
            m_fileName = filename;
        }

    }
}
