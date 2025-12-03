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
    public partial class addAdmin : Form
    {
        DBConnect dbCon = new DBConnect();  
        public addAdmin()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtAdminName.Text == String.Empty || txtAdminID.Text == String.Empty || txtPassword.Text == String.Empty)
            {
                MessageBox.Show("Please Enter Valid Admin Name, User ID, Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

            }

        }

        private void addAdmin_Load(object sender, EventArgs e)
        {
            lblAdminID.Visible = false;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnAdd.Visible = true;
            txtAdminName.Focus();
        }

        private void clrBtn()
        {
            txtAdminID.Clear();
            txtAdminName.Clear();
            txtPassword.Clear();
            txtAdminName.Focus();
        }
    }
}
