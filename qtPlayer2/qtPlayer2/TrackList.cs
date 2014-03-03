using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;

namespace qtPlayer2
{
    public class TrackList : List<Track>
    {

        private bool m_updatingTags; // cute.   'am updating tags'

        public bool UpdatingTags { get { return m_updatingTags; } }

        public delegate void UpdateDelegate(Track t);       
        public event UpdateDelegate TrackUpdated;
        
        public event ThreadStart FinishedReading;
        public static Thread updateTags = null;

        private static string[] types = new string[] { "*.mp3", "*.ogg", "*.flac" };

        public TrackList()
        {
        }

        public TrackList(string dir)
        {
            AddDirectory(dir);
        }

        public TrackList(string file, bool dummy)
        {
            LoadCache(file);
        }

        public TrackList(string[] files, bool dummy)
        {
            foreach (string file in files)
            {
                if (Path.GetExtension(file) == ".qtPlaylist")
                    LoadCache(file);
                if (Path.GetExtension(file) == ".m3u")
                    LoadM3u(file);
                foreach (string t in types)
                {
                    if (Path.GetExtension(file) == Path.GetExtension(t))
                        Add(new Track(file));
                }
            }
        }

        private void UpdateTags()
        {
            int i = 0;
            while (m_updatingTags && i < Count)
            {
                lock (this[i])
                {
                    if (!this[i].TagsRead)
                        this[i].ReadTags();
                }
                if (m_updatingTags && TrackUpdated != null)
                    TrackUpdated(this[i]);
                i++;
            }
            m_updatingTags = false;
            if (FinishedReading != null)
                FinishedReading();
        }

        public void ReadTags()
        {
            if (m_updatingTags) return;
            m_updatingTags = true;
            updateTags = new Thread(new ThreadStart(UpdateTags));
            updateTags.Start();
        }

        public void StopReadingTags()
        {
            m_updatingTags = false;
            updateTags.Abort();
        }

        public void AddDirectory(string dir)
        {
            string[] dirs = Directory.GetDirectories(dir);
            foreach (string d in dirs)
                AddDirectory(d);
            foreach (string t in types)
            {
                string[] files = Directory.GetFiles(dir, t);
                foreach (string f in files)
                    Add(new Track(f));
            }           
        }
        private void LoadCache(string s)
        {
            BinaryReader br = new BinaryReader(File.OpenRead(s));
            int count = br.ReadInt32();
            for (int i = 0; i < count; i++)
                Add(new Track(br.BaseStream));
            br.Close();
        }

        public void SaveCache(string s)
        {
            BinaryWriter bw = new BinaryWriter(File.OpenWrite(s));
            bw.Write((int)Count);
            foreach (Track t in this)
                t.SaveTrackData(bw.BaseStream);
            bw.Close();
        }

        public void LoadM3u(string s)
        {
            string m3uFile;
            string filePath = Path.GetDirectoryName(s);
            StreamReader srM3u = new StreamReader(s, System.Text.Encoding.Default);
            m3uFile = srM3u.ReadLine();
            while (m3uFile != null)
            {
                Add(new Track(filePath + "\\" + m3uFile));
                m3uFile = srM3u.ReadLine();
            }
        }
    }
}
