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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmbrole.SelectedIndex = 0;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {

                // this is for the Confirming the Role of the User(Admin or User)
                if (cmbrole.SelectedIndex > 0)
                {
                    if (txtusername.Text == String.Empty)
                    {
                        MessageBox.Show("Please Enter valid UserName", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtusername.Focus();
                        return;
                    }
                    if (txtpassword.Text == String.Empty)
                    {
                        MessageBox.Show("Please Enter valid Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtpassword.Focus();
                        return;
                    }

                    // Login Code is Here for the Admin and User
                    if (cmbrole.SelectedIndex > 0 && txtusername.Text != String.Empty && txtpassword.Text != String.Empty)
                    {
                        // Login code


                    }

                    else
                    {
                        MessageBox.Show("Please Enter User name or the Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cmbrole.SelectedIndex = 0;
                        txtusername.Clear();
                        txtpassword.Clear();

                    }
                }


 else
                {
                    MessageBox.Show("Please Select any Role", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mbrole.SelectedIndex = 0;
                    txtusername.Clear();
                    txtpassword.Clear();
                }


            
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}
