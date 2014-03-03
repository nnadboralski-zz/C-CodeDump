using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace hp_tac_tk_scbtool
{
    public partial class Form1 : Form
    {
        List<LFNode> lfList = new List<LFNode>();
        Dictionary<string, LFNode> lfDict = new Dictionary<string, LFNode>();

        public Form1()
        {
            InitializeComponent();
        }

        private void ReadConcentraFileV2(string file)
        {
            /// Code provided by Doug Cullum
            //string firstNodeText = "";
            StreamReader freader = null;
            string[] splitStuff = { "template=\"", "text=\"", "ID=\"", "Log=\"", "ShowCheckBox=\"", "EndLevel2Code=\"", "PID=\"", "Doc_Link=\"", "Tree=\"", "Productline=\"","Node=\"", "CID=\"", "Book=\"" };
            string template = "", text = "", id = "", log = "", showCheckBox = "", endLevel2Code = "", pid = "", doc_Link = "", cid = "", tree = "", productLine = "", node="", book = "";

            try
            {
                freader = File.OpenText(file);

                string text_line;

                string[] words = null;
                // bool firstNode = true;

                while ((text_line = freader.ReadLine()) != null )
                {
                    template = "";
                    text = "";
                    id = "";
                    log = "";
                    showCheckBox = "";
                    endLevel2Code = "";
                    pid = "";
                    doc_Link = "";
                    book = "";
                    cid = "";
                    tree = "";
                    productLine = "";
                    node = "";

                    int endPos = 0;
                    for (int i = 0; i < splitStuff.Length && text_line.StartsWith("<node "); i++)
                    {
                        string[] split = new string[] { splitStuff[i] };
                        
                        words = text_line.Split(split, StringSplitOptions.None);
                        string temp = "";
                        if (words.Length > 1)
                        {
                            endPos = words[1].IndexOf("=\""); //locate the next occurance of the =" string which indicates the next XML attribute
                            if (endPos < 0) //When this is less than 0, it means that it hit the end of the text_Line
                            {
                                endPos = words[1].IndexOf("\"  />");
                                temp = words[1].Substring(0, endPos);
                                //will contain actual needed text, so skip to switch from here
                            }
                            else
                            {
                                temp = words[1].Substring(0, endPos);
                                endPos = temp.LastIndexOf("\" ");
                            }
                            if (endPos < 0)
                            {
                                endPos = 0;
                            }
                        }
                        else
                        {
                            endPos = 0;
                        }

                        switch (splitStuff[i])
                        {
                            case "template=\"":
                                template = temp.Substring(0, endPos);
                                break;
                            case "text=\"":
                                text = temp.Substring(0, endPos);
                                break;
                            case "ID=\"":
                                id = temp.Substring(0, endPos);
                                break;
                            case "Log=\"":
                                log = temp.Substring(0, endPos);
                                break;
                            case "ShowCheckBox=\"":
                                showCheckBox = temp.Substring(0, endPos);
                                break;
                            case "EndLevel2Code=\"":
                                endLevel2Code = temp.Substring(0, endPos);
                                break;
                            case "PID=\"":
                                pid = temp.Substring(0, endPos);
                                break;
                            case "Doc_Link=\"":
                                doc_Link = temp.Substring(0, endPos);
                                break;
                            case "Book=\"":
                                book = temp.Substring(0, endPos);
                                break;
                            case "CID=\"":
                                cid = temp.Substring(0, endPos);
                                break;
                            case "Tree=\"":
                                tree = temp.Substring(0, endPos);
                                break;
                            case "Productline=\"":
                                productLine = temp.Substring(0, endPos);
                                break;
                            case "Node=\"":
                                node = temp.Substring(0, endPos);
                                break;
                        }
                    }

                    //if the row is formatted correctly, add to data table
                    //each row is split into the individual elements then put into their appropriate column within the DataTable
                    if (text_line.Split(splitStuff, StringSplitOptions.RemoveEmptyEntries).Length >= 7)
                    {

                        LFNode lf = new LFNode(template, text, id, log, showCheckBox, endLevel2Code, pid, doc_Link, cid, book, tree, productLine, node);
                        lfList.Add(lf);
                        if (lf.ID != "")
                        {
                            try
                            {
                                lfDict.Add(lf.ID, lf);
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.ToString());
                            }
                        }
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

        private void ReadConcentraFile(string file)
        {
            // Concentra document read code is by Doug Cullum.
            StreamReader sr = null;
            try
            {
                sr = File.OpenText(file);
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
                            //MessageBox.Show(words[i]);
                            words[i] = words[i].TrimEnd(new char[] { ' ', '\"' });
                            

                        }
                        LFNode lf = new LFNode(words);
                        lfList.Add(lf);
                        if (lf.ID != "")
                        {
                            try
                            {
                                lfDict.Add(lf.ID, lf);
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.ToString());
                            }
                        }
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
        }

        private void btnFilePath_Click(object sender, EventArgs e)
        {
            DialogResult dr = ofdConcentra.ShowDialog();
            if (dr != DialogResult.Abort || dr != DialogResult.Cancel)
            {
                txtFilePath.Text = ofdConcentra.FileName;
                ReadConcentraFileV2(txtFilePath.Text);
            }

            foreach (LFNode l in lfList)
            {
                for (int i = 0; i < lfList.Count(); i++)
                {
                    if (l.PID == lfList[i].ID)
                    {
                        lfList[i].Children.Add(l.ID);
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
                    listBox1.Items.Add(lfList[i]);
                    //.Text += lfList[i].ToString() + "\n\n";

                    //foreach (string s in lfList[i].Children)
                    //{
                        //l
                    //}

                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            string parent = ((LFNode)listBox1.Items[listBox1.SelectedIndex]).PID;
            Stack<LFNode> lfStack = new Stack<LFNode>();
            while (parent != "root")
            {
                lfStack.Push(lfDict[parent]);
                parent = lfDict[parent].PID;
            }

            while (lfStack.Count() > 0)
            {
                listBox2.Items.Add(lfStack.Pop());
            }
            /**
            string parent2 = lfDict[parent].PID;
            string parent3 = lfDict[lfDict[parent].PID].PID;
            string parent4 = lfDict[lfDict[lfDict[parent].PID].PID].PID;
            listBox2.Items.Add(lfDict[parent4]);
            listBox2.Items.Add(lfDict[parent3]);
            listBox2.Items.Add(lfDict[parent2]);
            listBox2.Items.Add(lfDict[parent]);
            listBox2.Items.Add(listBox1.Items[listBox1.SelectedIndex]);
             * **/
            // listBox2.Items.Add(((LFNode)listBox1.Items[listBox1.SelectedIndex]).PID);
            // MessageBox.Show(listBox1.Items[listBox1.SelectedIndex].ToString());
            // MessageBox.Show(listBox1.SelectedIndex.ToString());
        }
    }
}
