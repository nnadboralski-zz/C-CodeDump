using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CrawlStats
{
    class CrawlCharacter : Dictionary<string, string> , IComparable<CrawlCharacter>
    {
        private string m_filename;
        private string m_filePath;
        private string m_morgueFilename;
        private string m_morgueFileLink;
        private string m_7zipFilename;
        private string m_7zipFileLink;
        private string m_webPath;

        public string FilePath { get { return m_filePath; } }
        public string WebPath { get { return m_webPath; } }
        public string MorgueFilename { get { return m_morgueFilename; } }
        public string MorgueFileLink { get { return m_morgueFileLink; } }
        public string ZipFilename { get { return m_7zipFilename; } }
        public string ZipFileLink { get { return m_7zipFileLink; } }

        public string Version { get { return this["v"]; } }
        public string Name { get { return this["name"]; } }
        public int Level { get { return Convert.ToInt32(this["xl"]); } }
        public string Race { get { return this["race"]; } }
        public string Class { get { return this["cls"]; } }
        public int Turn { get { return Convert.ToInt32(this["turn"]); } }
        public int Score { get { return Convert.ToInt32(this["sc"]); } }

        public CrawlCharacter(string file)
        {
            m_filename = file;
            m_filePath = Path.GetDirectoryName(file);
            StreamReader sr = new StreamReader(file);
            string line = sr.ReadLine();
            line = line.Replace("::", "[");
            string[] splitline = line.Split(':');
            foreach (String s in splitline)
            {
                string[] values = s.Split('=');
                Add(values[0], values[1]);
            }
            m_webPath = m_filename.Substring(m_filename.LastIndexOf("CLArchives"), (m_filename.Length - m_filename.LastIndexOf("CLArchives")) - 8);
            string endDate = m_webPath.Substring(m_webPath.LastIndexOf('\\',(m_webPath.Length - 2)), m_webPath.Length - m_webPath.LastIndexOf('\\'));
            endDate = endDate.Substring(1, endDate.Length - 1);
            m_morgueFilename = "morgue-" + this["name"] + "-" + endDate + ".txt";
            m_7zipFilename = this["name"] + " - " + endDate + ".7z";
            m_morgueFileLink = m_webPath + m_morgueFilename;
            m_7zipFileLink = m_webPath + m_7zipFilename;
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
            sb.AppendLine("\t\t\t\t\t<td style=\"text-align: center;\"><a href=\"" + m_morgueFileLink + "\">View</a></td>");
            sb.AppendLine("\t\t\t\t\t<td style=\"text-align: center;\"><a href=\"" + m_7zipFileLink + "\">D/L</a></td>");
            sb.AppendLine("\t\t\t\t</tr>");

            string ret = sb.ToString();
            return ret;
        }


        #region IComparable<CrawlCharacter> Members

        public int CompareTo(CrawlCharacter other)
        {
            return Convert.ToInt32(other["xl"]) - Convert.ToInt32(this["xl"]);
        }

        #endregion
    }
}
