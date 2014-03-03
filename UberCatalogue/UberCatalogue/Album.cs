using System;
using System.Collections.Generic;
using System.Text;


namespace UberCatalogue
{
    class Album : List<Track>
    {
        string m_title;     
        public string Title { get { return m_title; } }

        public Album(string t)
        {
            m_title = t;
        }

    }
}
