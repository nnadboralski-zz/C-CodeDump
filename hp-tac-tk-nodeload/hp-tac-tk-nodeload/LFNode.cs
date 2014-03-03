using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace hp_tac_tk_nodeload
{
    class LFNode
    {
        private string m_template;
        private string m_text;
        private string m_id;
        private string m_log;
        private string m_scb;
        private string m_el2;
        private string m_pid;
        private string m_doclink;
        private string m_cid;
        private string m_book;
        private List<string> m_children = new List<string>();

        public string Template { get { return m_template; } set { m_template = value; } }
        public string Text { get { return m_text; } set { m_text = value; } }
        public string ID { get { return m_id; } set { m_id = value; } }
        public string Log { get { return m_log; } set { m_log = value; } }
        public string ShowCheckBox { get { return m_scb; } set { m_scb = value; } }
        public string EndLevel2Code { get { return m_el2; } set { m_el2 = value; } }
        public string PID { get { return m_pid; } set { m_pid = value; } }
        public string DocLink { get { return m_doclink; } set { m_doclink = value; } }
        public string CID { get { return m_cid; } set { m_cid = value; } }
        public string Book { get { return m_book; } set { m_book = value; } }
        public List<string> Children { get { return m_children; } set { m_children = value; } }

        public LFNode(string[] w)
        {
            Template = w[0];
            Text = w[1];
            ID = w[2];
            Log = w[3];
            ShowCheckBox = w[4];
            EndLevel2Code = w[5];
            PID = w[6];
        }

        public override string ToString()
        {
            string ret;
            ret = "<node Template=\"" + Template + "\" text=\"" + Text + "\" ID=\"" + ID + "\" Log=\"" + Log + "\" ShowCheckBox=\"" + ShowCheckBox + "\" EndLevel2Code=\"" + EndLevel2Code + "\" PID=\"" + PID + "\" />";
            return ret;
        }
    }
}
