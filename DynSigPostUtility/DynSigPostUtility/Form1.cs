using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.IO;
using System.Windows.Forms;

namespace DynSigPostUtility
{
    public partial class Form1 : Form
    {
        Dictionary<string, string> fvPair = new Dictionary<string, string>();

        //List<string> fvPair = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtField.Clear();
            txtValue.Clear();
            txtURL.Clear();
            txtSubmission.Clear();
            fvPair.Clear();
        }

        private void txtURL_TextChanged(object sender, EventArgs e)
        {
            txtSubmission.Text = txtURL.Text;
        }

        private void btnAddField_Click(object sender, EventArgs e)
        {
            fvPair.Add(txtField.Text, txtValue.Text);
            txtField.Clear();
            txtValue.Clear();
            txtSubmission.Text = txtURL.Text + "?";
            foreach (string s in fvPair.Keys)
            {
                if (txtSubmission.Text == txtURL.Text + "?")
                {
                    txtSubmission.Text = txtURL.Text + "?" + s + "=" + fvPair[s];
                }
                else
                {
                    txtSubmission.Text = txtSubmission.Text + "&" + s + "=" + fvPair[s];
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            HttpWebRequest request = null;
            string fvData = null; ;
            foreach (string s in fvPair.Keys)
            {
                if (fvData == null)
                {
                    fvData = fvData + s + "=" + fvPair[s];
                }
                else
                {
                    fvData = fvData + "&" + s + "=" + fvPair[s];
                }
            }
            Uri uri = new Uri(txtURL.Text + "?" + fvData);
            request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "GET";
            string result = string.Empty;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream responseStream = response.GetResponseStream())
                {
                    using (StreamReader readStream = new StreamReader(responseStream, Encoding.UTF8))
                    {
                        result = readStream.ReadToEnd();
                    }
                }
            }

            
            /* postData = (HttpWebRequest)WebRequest.Create(uri);
            postData.Method = "POST";
            postData.ContentType = "application/x-www-for-urlencoded";
            postData.ContentLength = fvData.Length;
            using (Stream writeStream = postData.GetRequestStream())
            {
                UTF8Encoding encoding = new UTF8Encoding();
                byte[] bytes = encoding.GetBytes(fvData);
                writeStream.Write(bytes, 0, bytes.Length);
            }
             * */
        }
    }
}
