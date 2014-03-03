using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using TagLib;
using System.Diagnostics;


namespace YAUT
{
    class Track
    {
        private string m_filename;
        private string m_artist;
        private string m_album;
        private string m_title;
        private TimeSpan m_duration;
        private int m_year;
        private int m_trackNumber;

        public string Filename { get { return m_filename; } }
        public string Artist { get { return m_artist; } }
        public string Album { get { return m_album; } }
        public string Title { get { return m_title; } }
        public TimeSpan Duration { get { return m_duration; } }
        public int Year { get { return m_year; } }
        public int TrackNumber { get { return m_trackNumber; } }

        public Track(string file)
        {
            TagLib.File tagInfo = TagLib.File.Create(file);
            m_filename = file;
            m_artist = tagInfo.Tag.FirstArtist;
            m_album = tagInfo.Tag.Album;
            m_title = tagInfo.Tag.Title;
            m_duration = tagInfo.Properties.Duration;
            m_year = (int)tagInfo.Tag.Year;
            m_trackNumber = (int)tagInfo.Tag.Track;        
        }

        public Track(string fn, string art, string alb, string t, int y, int tn)
        {
        }


    }
}
