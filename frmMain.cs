using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoMart
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // if the Login name is not null then show the main form
            if (Form1.loginname!=null)
            {
                // We have to show the login name in the status strip
                toolStripStatusLabel2.Text=Form1.loginname;


            }
            //This is for the Another Logic
            if(Form1.logintype!=null&& Form1.logintype=="Seller" )
            {
                // then
                masterToolStripItem.Enabled = false;
                productToolStripMenuItem.Enabled = false;
                addUserToolStripMenuItem.Enabled = false;

            }
        }

        private void masterToolStripItem_Click(object sender, EventArgs e)
        {
            Form2 fcat = new Form2();
            fcat.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 abt = new AboutBox1();
            abt.Show();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to close this application?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);

            if (dialog == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
