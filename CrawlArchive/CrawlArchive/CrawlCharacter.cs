using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CrawlArchive
{
    class CrawlCharacter : Dictionary<string, string>
    {
        private string m_version;       
        private string m_name;
        private int m_level;
        private string m_race;
        private string m_class;
        private string m_title;
        private int m_turns;
        private int m_score;
        private string m_start;
        private string m_end;
        private string m_morgue;
        private string m_download;
        private string m_morgueFile;
        private string m_downloadFile;
        private string m_file;
        private string m_path;

        public string Version { get { return m_version; } set { m_version = value; } }
        public string Name { get { return m_name; } set { m_name = value; } }
        public int Level { get { return m_level; } set { m_level = value; } }
        public string Race { get { return m_race; } set { m_race = value; } }
        public string Class { get { return m_class; } set { m_class = value; } }
        public string Title { get { return m_title; } set { m_title = value; } }
        public int Turns { get { return m_turns; } set { m_turns = value; } }
        public int Score { get { return m_score; } set { m_score = value; } }
        public string Start { get { return m_start; } set { m_start = value; } }
        public string End { get { return m_end; } set { m_end = value; } }
        public string Morgue { get { return m_morgue; } set { m_morgue = value; } }
        public string Download { get { return m_download; } set { m_download = value; } }
        public string MorgueFile { get { return m_morgueFile; } set { m_morgueFile = value; } }
        public string DownloadFile { get { return m_downloadFile; } set { m_downloadFile = value; } }
        public string FilePath { get { return m_path; } set { m_path = value; } }

        public CrawlCharacter(string file)
        {
            m_file = file;
            m_path = Path.GetDirectoryName(file);
            StreamReader sr = new StreamReader(file);
            string line = sr.ReadLine();
            line = line.Replace("::", "[");
            string[] spline = line.Split(':');
            foreach (string s in spline)
            {
                string[] values = s.Split('=');
                Add(values[0], values[1]);
            }
            m_start = this["start"];
            m_end = this["end"];
            string m_endHumanYear = m_end.Substring(0,4);
            string m_endHumanMonth = m_end.Substring(4,2);
            m_endHumanMonth = (Convert.ToInt32(m_endHumanMonth) + 1).ToString();
            if (Convert.ToInt32(m_endHumanMonth) < 10)
                m_endHumanMonth = "0" + m_endHumanMonth;
            string m_endHumanDay = m_end.Substring(6,2);
            string m_endHumanHour = m_end.Substring(8,2);
            string m_endHumanMin = m_end.Substring(10,2);
            string m_endHumanSecs = m_end.Substring(12,2);
            string m_endHumanDate = m_endHumanYear + m_endHumanMonth + m_endHumanDay + "-" + m_endHumanHour + m_endHumanMin + m_endHumanSecs;
            m_morgue = "CLArchives/Trinkit/" + this["name"] + "/" + m_endHumanDate + "/morgue-" + this["name"] + "-" + m_endHumanDate + ".txt";
            m_morgueFile = m_path + "/morgue-" + this["name"] + "-" + m_endHumanDate + ".txt";
            m_download = "CLArchives/Trinkit/" + this["name"] + "/" + m_endHumanDate + "/" + this["name"] + " - " + m_endHumanDate + ".7z";
            m_downloadFile = m_path + "/" + this["name"] + " - " + m_endHumanDate + ".7z";
        }

        public string ToHTML()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("\t\t\t\t<tr>");
            sb.AppendLine("\t\t\t\t\t<td>" + this["v"] + "</td>");
            sb.AppendLine("\t\t\t\t\t<td>" + this["name"] + "</td>");
            sb.AppendLine("\t\t\t\t\t<td>" + this["xl"] + "</td>");
            sb.AppendLine("\t\t\t\t\t<td>" + this["race"] + "</td>");
            sb.AppendLine("\t\t\t\t\t<td>" + this["cls"] + "</td>");
            sb.AppendLine("\t\t\t\t\t<td>" + this["turn"] + "</td>");
            sb.AppendLine("\t\t\t\t\t<td>" + this["sc"] + "</td>");
            sb.AppendLine("\t\t\t\t\t<td style=\"text-align: center;\"><a href=\"" + m_morgue + "\">View</a></td>");
            sb.AppendLine("\t\t\t\t\t<td style=\"text-align: center;\"><a href=\"" + m_download + "\">D/L</a></td>");
            sb.AppendLine("\t\t\t\t</tr>");

            string ret = sb.ToString();
            return ret;         
        }
    }
}
