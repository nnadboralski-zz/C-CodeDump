using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace hp_tac_tk_lfeditor
{
    public partial class SCBConfiguration : Form
    {
        SerializableDictionary<string, List<string>> SCBConfigs = new SerializableDictionary<string, List<string>>();

        public SCBConfiguration()
        {
            InitializeComponent();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void txtShowCheckBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNewShowCheckBox_Click(object sender, EventArgs e)
        {
            lstShowCheckBox.Items.Add("New Item");
        }

        private void txtShowCheckBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (lstShowCheckBox.SelectedItem != null)
                {
                    int index = lstShowCheckBox.SelectedIndex;
                    lstShowCheckBox.Items.RemoveAt(index);
                    lstShowCheckBox.Items.Insert(index, txtShowCheckBox.Text);
                    SCBConfigs.Remove(lstShowCheckBox.SelectedItem.ToString());


                }
                else
                {
                    lstShowCheckBox.Items.Add(txtShowCheckBox.Text);
                }
            }   
        }
    }
}
