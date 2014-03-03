using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace Kohana.Utilities
{
    public class Tracker
    {
        private string m_processName;
        private string m_windowTitle;
        private int m_lastCount;

        public string ProcessName { get { return m_processName; } }
        public string WindowTitle { get { return m_windowTitle; } }
        public int LastCount { get { return m_lastCount; } }

        internal Tracker(string proc, string title)
        {
            m_processName = proc;
            m_windowTitle = title;
            Check();
        }

        public bool Check()
        {
            Process[] procs = null;
            if (m_processName != null)
                procs = Process.GetProcessesByName(m_processName);
            else
                procs = Process.GetProcesses();
            int count = 0;
            if (m_windowTitle == null)
                count = procs.Length;
            else
            {
                foreach (Process p in procs)
                    if (p.MainWindowTitle == m_windowTitle)
                        count++;
            }
            if (count != m_lastCount)
            {
                m_lastCount = count;
                return true;
            }
            return false;
        }
    }

    public class ProcessWatch
    {
        public delegate void ProcessUpdateDelegate(string name, string title, int count);
        public event ProcessUpdateDelegate Update;
        private List<Tracker> m_trackers;
        private Timer m_check;
        private bool m_running;

        public bool Running {get{return m_running;} set{if(m_running)Stop();else Start();}}

        public ProcessWatch()
        {
            m_trackers = new List<Tracker>();
            m_running = false;
        }

        public void Add(string processName, string windowTitle)
        {
            m_trackers.Add(new Tracker(processName, windowTitle));
        }

        public void Remove(string processName, string windowTitle)
        {
            Tracker item = null;
            foreach (Tracker t in m_trackers)
            {
                if (t.WindowTitle == windowTitle && t.ProcessName == processName)
                {
                    item = t;
                    break;
                }
            }
            if (item != null)
                m_trackers.Remove(item);
        }

        private void Poll(object o)
        {
            lock (m_trackers)
            {
                foreach (Tracker t in m_trackers)
                    if (t.Check() && Update != null)
                        Update(t.ProcessName, t.WindowTitle, t.LastCount);
            }
        }

        public void Start()
        {
            if (m_running)
                return;
            m_check = new Timer(new TimerCallback(Poll), null, 100, 100);
        }

        public void Stop()
        {
            if (!m_running)
                return;
            m_check.Dispose();
            m_check = null;
        }
    }
}
