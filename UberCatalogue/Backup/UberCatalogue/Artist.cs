using System;
using System.Collections.Generic;
using System.Text;

namespace UberCatalogue
{
    class Artist
    {
        string m_name;
        List<Album> m_albums;
        List<Track> m_tracks;

        public string Name { get { return m_name; } }
        public List<Album> Albums { get { return m_albums; } }
        public List<Track> Tracks { get { return m_tracks; } }

        public Artist(string n)
        {
            m_name = n;
            m_albums = new List<Album>();
            m_tracks = new List<Track>();
        }
    }
}
