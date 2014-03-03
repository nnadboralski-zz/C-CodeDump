using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using TagLib;

namespace qtPlayer
{
    public class Track
    {
        // Resource Location, Name, and Properties.
        private string m_filePath;
        private string m_fileName;
        private string m_fileType;      
        private short m_bitrate;
        private int m_sampleRate;
        private TimeSpan m_duration;
        
        // Metadata From Tags
        private string m_artist;
        private string m_album;
        private string m_comment;
        private string m_title;
        private string m_genre;
        private short m_year;
        private byte m_trackNumber;
        
        // User Provided or Generated Metadata
        private byte m_rating;
        private int m_playCount;

        public string FilePath { get { return m_filePath; } }
        public string FileName { get { return m_fileName; } }
        public string FileType { get { return m_fileType; } }
        public short Bitrate { get { return m_bitrate; } }
        public int SampleRate { get { return m_sampleRate; } }
        public TimeSpan Duration { get { return m_duration; } }

        public string Artist { get { return m_artist; } }
        public string Album { get { return m_album; } }
        public string Comment { get { return m_comment; } }
        public string Title { get { return m_title; } }
        public string Genre { get { return m_genre; } }
        public short Year { get { return m_year; } }
        public byte TrackNumber { get { return m_trackNumber; } }
        public byte Rating { get { return m_rating; } }
        public int PlayCount { get { return m_playCount; } set { m_playCount = value; } }

        public bool IsValid { get { return System.IO.File.Exists(m_filePath); } }
        public bool TagsRead { get { return m_album != null; } }

        public Track(string file)
        {
            m_filePath = file;
            m_fileName = Path.GetFileName(file);
            m_fileType = Path.GetExtension(file);
        }

        public Track(Stream s)
        {
            BinaryReader br = new BinaryReader(s);
            m_filePath = br.ReadString();
            m_fileName = Path.GetFileName(m_filePath);
            m_fileType = Path.GetExtension(m_filePath);
            m_bitrate = br.ReadInt16();
            m_sampleRate = br.ReadInt32();
            m_duration = new TimeSpan(br.ReadInt32() * 10000);
            m_artist = br.ReadString();
            m_album = br.ReadString();
            m_comment = br.ReadString();
            m_title = br.ReadString();
            m_genre = br.ReadString();
            m_year = br.ReadInt16();
            m_trackNumber = br.ReadByte();
            m_rating = br.ReadByte();
            m_playCount = br.ReadInt32();
        }

        public void SaveTrackData(Stream s)
        {
            BinaryWriter bw = new BinaryWriter(s);
            bw.Write(m_filePath);
            bw.Write(m_bitrate);
            bw.Write(m_sampleRate);
            bw.Write((int)m_duration.TotalMilliseconds);
            bw.Write((m_artist == null ? "" : m_artist));
            bw.Write((m_album == null ? "" : m_album));
            bw.Write((m_comment == null ? "" : m_comment));
            bw.Write((m_title == null ? "" : m_title));
            bw.Write((m_genre == null ? "" : m_genre));
            bw.Write((m_year == -1 ? (short)0 : m_year));
            bw.Write((m_trackNumber == 0 ? (byte)0 : m_trackNumber));
            bw.Write(m_rating);
            bw.Write(m_playCount);
        }

        public void ReadTags()
        {
            TagLib.File tags = TagLib.File.Create(m_filePath);
            m_bitrate = (short)tags.Properties.AudioBitrate;
            m_sampleRate = tags.Properties.AudioSampleRate;
            m_duration = tags.Properties.Duration;
            m_artist = tags.Tag.FirstArtist;
            m_album = tags.Tag.Album;
            m_comment = tags.Tag.Comment;
            m_title = tags.Tag.Title;
            m_genre = tags.Tag.FirstGenre;
            m_year = (short)tags.Tag.Year;
            m_trackNumber = (byte)tags.Tag.Track;
        }

        public void ReadPath()
        {

        }

        public override string ToString()
        {
            if (TagsRead)
            {
                return m_artist + " - " + m_album + " - " + m_trackNumber + " - " + m_title;
            }
            else
            {
                return m_fileName;
            }
        }

        public string ToString(string f)
        {
            return f;
        }
    }
}
