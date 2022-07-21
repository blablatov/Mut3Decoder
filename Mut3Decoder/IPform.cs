using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mut3Decoder
{
    public partial class IPform : Form
    {
        public IPform()
        {
            InitializeComponent();
        }

        Db db = new Db();
        public void _btnEnter_Click(object sender, EventArgs e)
        {
            //if (comboBox1.SelectedIndex != -1)
            {
                if (chkBoxLh.Checked == true) DbSettings.server = "localhost";
                else
                DbSettings.server = textBox1.Text;
                //DbSettings.port = "1574";
                //DbSettings.dBase = "CAESARCOMPDB2";
                DbSettings.dBase = "CAESARCOMPDB2";
                DbSettings.userId = "CAESAR-DB";
                DbSettings.pass = "CAESAR";
                
                if (db.CheckConnect(db.SqlConnStr()))
                {
                    MessageBox.Show(" Is connected");
                    Close();
                    Form1 Mut3 = new Form1(new Mut3());
                    Mut3.ShowDialog();
                    //MessageBox.Show("соединение с сервером... " + db.SqlConnStr());
                }
                else
                {
                    return;
                }
            }            

        }

        private void IPform_Load_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        public string textBox1_TextChanged_1(object sender, EventArgs e)
        {
           return textBox1.Text;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkBoxLh_CheckedChanged(object sender, EventArgs e)
        {
            chkBoxLh.Enabled = true;
            textBox1.Enabled = false;
        }
        
    }
}
