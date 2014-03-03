using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace hp_tac_tk_lfeditor
{
    public partial class Form1 : Form
    {
        List<LFNode> lfList = new List<LFNode>();
        Dictionary<string, LFNode> lfDict = new Dictionary<string, LFNode>();
        LFTreeNode clipboard = new LFTreeNode();

        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = ofdConcentra.ShowDialog();
            if (dr != DialogResult.Abort || dr != DialogResult.Cancel)
            {
                ReadConcentraFileV2(ofdConcentra.FileName);
            }

            foreach (LFNode l in lfList)
            {
                for (int i = 0; i < lfList.Count(); i++)
                {
                    if (l.PID == lfList[i].ID)
                    {
                        lfList[i].Children.Add(l.ID);
                        // lfDict[lfList[i].ID].Children.Add(l.ID);
                    }
                }
            }
            LFTreeNode tn = new LFTreeNode(lfDict["root"]);
            foreach (string s in lfDict["root"].Children)
            {
                LoadTreeView(tn, lfDict[s]);
            }

            tvLogicFlow.Nodes.Add(tn);
        }

        private void LoadTreeView(LFTreeNode parent, LFNode child)
        {
            LFTreeNode newNode = new LFTreeNode(child);
            newNode.Tag = child;
            parent.Nodes.Add(newNode);
            foreach (string s in child.Children)
            {
                if (child.Children.Count != 0)
                {
                    LoadTreeView(newNode, lfDict[s]);
                }
            }
        }

        private void ReadConcentraFileV2(string file)
        {
            /// Code provided by Doug Cullum
            // string firstNodeText = "";
            StreamReader freader = null;
            string[] splitStuff = { "template=\"", "text=\"", "ID=\"", "Log=\"", "ShowCheckBox=\"", "EndLevel2Code=\"", "PID=\"", "Doc_Link=\"", "Tree=\"", "Productline=\"", "Node=\"", "CID=\"", "Book=\"" };
            string template = "", text = "", id = "", log = "", showCheckBox = "", endLevel2Code = "", pid = "", doc_Link = "", cid = "", tree = "", productLine = "", node = "", book = "";

            try
            {
                freader = File.OpenText(file);

                string text_line;

                string[] words = null;
                // bool firstNode = true;

                while ((text_line = freader.ReadLine()) != null)
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

        private void tvLogicFlow_AfterSelect(object sender, TreeViewEventArgs e)
        {
            foreach (LFTreeNode N in tvLogicFlow.Nodes)
            {
                UpdateIDs(N);
            }
            
            LFTreeNode selected = (LFTreeNode)e.Node;
            txtContent.Text = selected.LogicFlow.Text;
            textBox2.Text = selected.LogicFlow.ID;
            lblCurrentNodeValue.Text = selected.LogicFlow.ID;
            txtSCB.Text = selected.LogicFlow.ShowCheckBox;
            txtEL2Code.Text = selected.LogicFlow.EndLevel2Code;
        }

        private void tvLogicFlow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.X && e.Modifiers == Keys.Control)
            {
                
                clipboard = ((LFTreeNode)tvLogicFlow.SelectedNode);
                if (clipboard.LogicFlow.ID == "root")
                {
                    MessageBox.Show("Can not cut the root node.");
                    return;
                }

                tvLogicFlow.SelectedNode.Remove();
            }
            if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control)
            {
                tvLogicFlow.SelectedNode.Nodes.Insert(0,(LFTreeNode)clipboard);
                clipboard = null;
            }
            if (e.KeyCode == Keys.Insert)
            {
                tvLogicFlow.SelectedNode.Nodes.Insert(0, new LFTreeNode(new LFNode()));
                tvLogicFlow.SelectedNode.Nodes[0].BackColor = Color.Red;
            }
        }

        private void UpdateIDs(LFTreeNode lfTN)
        {
            lfTN.LogicFlow.ID = "root";
            int counter = 1;
            foreach (LFTreeNode child in lfTN.Nodes)
            {
                string id = counter.ToString();
                UpdateIDs(child, counter, id);
                counter++;
            }
        }
        private void UpdateIDs(LFTreeNode lfTN, int c, string id)
        {
            lfTN.LogicFlow.ID = id;
            int counter = 1;
            foreach (LFTreeNode child in lfTN.Nodes)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(id + "." + counter.ToString());
                UpdateIDs(child, counter, sb.ToString());
                counter++;
            }
        }

        private void txtContent_TextChanged(object sender, EventArgs e)
        {
            LFTreeNode edit;
            edit = (LFTreeNode)tvLogicFlow.SelectedNode;
            edit.LogicFlow.Text = txtContent.Text;
            edit.Text = edit.LogicFlow.Text;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void showCheckBoxConfiguraitonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SCBConfiguration scbConfig = new SCBConfiguration();
            scbConfig.ShowDialog();
        }

        //private void tvLogicFlow_DragDrop(object sender, DragEventArgs e)
        //{
        //    LFTreeNode lfNode;

        //    if (e.Data.GetDataPresent(typeof(LFTreeNode)))
        //    {
        //        Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
        //        LFTreeNode DestinationNode = (LFTreeNode)((TreeView)sender).GetNodeAt(pt);
        //        lfNode = (LFTreeNode)e.Data.GetData(typeof(LFTreeNode));
        //        if (DestinationNode.TreeView == lfNode.TreeView)
        //        {
        //            DestinationNode.Nodes.Add((LFTreeNode)lfNode.Clone());
        //            DestinationNode.Expand();
        //            //Remove Original Node
        //            lfNode.Remove();
        //        }
        //    }
        //    //TreeView tree = (TreeView)sender;
        //    //Point pt = new Point(e.X, e.Y);
        //    //pt = tree.PointToClient(pt);
        //    //LFTreeNode node = (LFTreeNode)tree.GetNodeAt(pt);    
        //    //node.Nodes.Add((LFTreeNode)e.Data.GetData(typeof(LFTreeNode)));
        //    //node.Expand();
        
        //}

        //private void tvLogicFlow_DragEnter(object sender, DragEventArgs e)
        //{
        //    e.Effect = DragDropEffects.Move;
        //}

        //private void tvLogicFlow_DragOver(object sender, DragEventArgs e)
        //{
        //    // Get the tree.
        //    TreeView tree = (TreeView)sender;

        //    // Drag and drop denied by default.
        //    e.Effect = DragDropEffects.None;

        //    // Is it a valid format?
        //    if (e.Data.GetData(typeof(LFTreeNode)) != null)
        //    {
        //        // Get the screen point.
        //        Point pt = new Point(e.X, e.Y);

        //        // Convert to a point in the TreeView's coordinate system.
        //        pt = tree.PointToClient(pt);

        //        // Is the mouse over a valid node?
        //        LFTreeNode node = (LFTreeNode)tree.GetNodeAt(pt);
        //        if (node != null)
        //        {
        //            e.Effect = DragDropEffects.Move;
        //            tree.SelectedNode = node;
        //        }
        //    }
        //}

        //private void tvLogicFlow_ItemDrag(object sender, ItemDragEventArgs e)
        //{
        //    DoDragDrop(e.Item, DragDropEffects.Move);
        //}
    }
}
