using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace hp_tac_tk_nodeload
{
    class Program
    {
        static void Main(string[] args)
        {
            List<LFNode> lfList = new List<LFNode>();
            // Concentra document read code is by Doug Cullum.
            StreamReader sr = null;
            try
            {
                sr = File.OpenText(args[0]);
                string[] delimiterValues = { "<node ", "template=\"", "text=\"", "ID=\"", "Log=\"", "ShowCheckBox=\"", "EndLevel2Code=\"", "PID=\"", "Doc_Link=\"", "CID=\"", "Book=\"", " />" };
                string text_line;

                string[] words = null;

                while ((text_line = sr.ReadLine()) != null)
                {
                    words = text_line.Split(delimiterValues, StringSplitOptions.RemoveEmptyEntries);
                    
                    //if the row is formatted correctly, add to data table
                    //each row is split into the individual elements then put into their appropriate column within the DataTable

                    if (words.Length >= 7)
                    {

                        for (int i = 0; i < words.Length; i++)
                        {
                            words[i] = words[i].TrimEnd(new char[] { ' ', '\"' });
                            // Console.WriteLine(words[i]);
                            
                        }
                        LFNode lf = new LFNode(words);
                        lfList.Add(lf);
                        //Add the words array to the data table
                        // xmlTbl.Rows.Add(words);
                        //Console.WriteLine(lf.ToString());
                    }                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("Nodes read");
            Console.ReadKey();

            foreach (LFNode l in lfList)
            {
                for (int i = 0; i < lfList.Count(); i++)
                {
                    if (l.PID == lfList[i].ID)
                    {
                        lfList[i].Children.Add(l.ID);
                        Console.Write("Derp.");
                    }
                }
            }

            for (int i = 0; i < lfList.Count(); i++)
            {
                /*
                if (lfList[i].ShowCheckBox != "False")
                {
                    for (int j = 0; j < lfList.Count(); j++)
                    {
                        if (lfList[j].ID == lfList[i].PID)
                        {
                            Console.WriteLine(lfList[j].Text);
                        }
                    }
                    Console.WriteLine("-- " + lfList[i].Text);
                    Console.WriteLine(lfList[i].ShowCheckBox);
                }
                 **/
                if (lfList[i].Children.Count == 0)
                {
                    Console.WriteLine(lfList[i].ToString());
                    foreach (string s in lfList[i].Children)
                    {
                        Console.WriteLine(s);
                    }
                    Console.ReadKey();
                }
            }
            Console.ReadKey();
        }

        
        /// <summary>
        /// Reads the XML file(s) and stores each node value into the XML DataTable
        /// </summary>
        /// <param name="path">full file path of the xml file being read</param>

/*        private void readXML(string path)
        {
            StreamReader freader = null;
            try
            {
                freader = File.OpenText(path);
                string[] delimiterValues = { "<node ", "template=\"", "text=\"", "ID=\"", "Log=\"", "ShowCheckBox=\"", "EndLevel2Code=\"", "PID=\"", "Doc_Link=\"", "CID=\"", "Book=\"", " />" };
                string text_line;

                string[] words = null;

                while ((text_line = freader.ReadLine()) != null)
                {
                    words = text_line.Split(delimiterValues, StringSplitOptions.RemoveEmptyEntries);

                    //if the row is formatted correctly, add to data table
                    //each row is split into the individual elements then put into their appropriate column within the DataTable
                    if (words.Length >= 7)
                    {

                        for (int i = 0; i < words.Length; i++)
                        {
                            words[i] = words[i].TrimEnd(new char[] { ' ', '\"' });
                        }

                        //Add the words array to the data table
                        xmlTbl.Rows.Add(words);
                    }
                }
            }
            catch (FileLoadException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // must explicitly close the readers
                freader.Close();
            }
        }
 */
    }
}
