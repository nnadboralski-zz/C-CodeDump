using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UberCatalogue
{
    class MusicCollection
    {
        List<Album> m_albums;
        List<Artist> m_artists;
        List<Track> m_tracks;

        private int m_fileCount;
        private int m_curFile;


        public List<Album> Albums { get { return m_albums; } }
        public List<Artist> Artists { get { return m_artists; } }
        public List<Track> Tracks { get { return m_tracks; } }

        public delegate void ProgressCallback(int file, int total);
        public delegate void FinishedCallback();

        public event ProgressCallback Progress;
        public event FinishedCallback Finished;

        public MusicCollection()
        {
            m_albums = new List<Album>();
            m_artists = new List<Artist>();
            m_tracks = new List<Track>();
        }

        public void LoadDir(string dir)
        {
            m_curFile = 0;
            m_fileCount = CountFiles(dir);
            AddDirectory(dir);
            if(Finished != null)
                Finished();
        }

        public Album GetAlbum(string name)
        {
            foreach (Album a in m_albums)
                if (a.Title == name)
                    return a;
            return null;
        }

        public Artist GetArtist(string name)
        {
            foreach (Artist a in m_artists)
                if (a.Name == name)
                    return a;
            return null;
        }

        public Track GetTrack(string name)
        {
            foreach (Track a in m_tracks)
                if (a.Title == name)
                    return a;
            return null;
        }

        private int CountFiles(string dir)
        {
            string[] dirs = Directory.GetDirectories(dir);
            int ret = 0;
            foreach (string d in dirs)
            {
                ret += CountFiles(d);
            }
            ret += Directory.GetFiles(dir, "*.mp3").Length;
            ret += Directory.GetFiles(dir, "*.ogg").Length;
            ret += Directory.GetFiles(dir, "*.flac").Length;
            return ret;
        }

        private void AddDirectory(string dir)
        {
            string[] dirs = Directory.GetDirectories(dir);
            foreach (string d in dirs)
            {
                AddDirectory(d);
            }
            string[] files = Directory.GetFiles(dir, "*.mp3");
            foreach (string f in files)
            {
                AddFile(f);
            }
            files = Directory.GetFiles(dir, "*.ogg");
            foreach (string f in files)
            {
                AddFile(f);
            }
            files = Directory.GetFiles(dir, "*.flac");
            foreach (string f in files)
            {
                AddFile(f);
            }
        }

        private void AddFile(string file)
        {
            m_curFile++;
            if (file.Length > 255)
            {
                return;
            }
            TagLib.File trackinfo = TagLib.File.Create(file);
            Album album = GetAlbum(trackinfo.Tag.Album);
            if (album == null)
            {
                album = new Album(trackinfo.Tag.Album);
                m_albums.Add(album);
            }
            Artist artist = GetArtist(trackinfo.Tag.FirstArtist);
            if (artist == null)
            {
                artist = new Artist(trackinfo.Tag.FirstArtist);
                m_artists.Add(artist);
            }
            // yes, this one is slightly easier to follow, but, the way info's going around is still confusing.
            Track track = new Track(album, artist, (int)trackinfo.Tag.Track, trackinfo.Tag.Title, file);           
            m_tracks.Add(track);
            album.Add(track);
            artist.Tracks.Add(track);
            artist.Albums.Add(album);
            if (Progress != null)
            {
                Progress(m_curFile, m_fileCount);
            }
        }
    }
}
