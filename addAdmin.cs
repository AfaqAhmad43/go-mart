using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

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

                // This is for Checking the Duplicate User ID
                // We Used SQL Command Microsoft.Data.SqlClient
                SqlCommand cmd = new SqlCommand("select SellerName from tblSeller where AdminID=@ID", dbCon.GetCon());
                cmd.Parameters.AddWithValue("@ID", txtAdminID.Text);
                dbCon.OpenCon();
                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    MessageBox.Show("Admin ID already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    clrBtn();
                }
                else
                {
                    cmd = new SqlCommand("spAddAdmin", dbCon.GetCon());
                    cmd.Parameters.AddWithValue("@AdminID",txtAdminID.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@FullName",txtAdminName.Text);

                    cmd.CommandType = CommandType.StoredProcedure;
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Admin inserted successfully...", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
clrBtn();
                        BindAdmin();


                    }

                }
                dbCon.CloseCon();
            }

        }

        private void BindAdmin()
        {
            SqlCommand cmd = new SqlCommand("select * from tblAdmin", dbCon.GetCon());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dbCon.OpenCon();
    
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
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
               if(lblAdminID.Text==String.Empty)
                {
                    MessageBox.Show("Please Select Admin Record ","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    if (DialogResult.Yes == MessageBox.Show("Do you want to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        SqlCommand cmd = new SqlCommand("spDeleteAdmin", dbCon.GetCon());
                        cmd.Parameters.AddWithValue("AdminID", Convert.ToInt32(lblAdminID.Text));
                        cmd.CommandType = CommandType.StoredProcedure;
                        dbCon.OpenCon();
                        int i = cmd.ExecuteNonQuery();

                        if (i > 0)
                        {
                            MessageBox.Show("Seller deleted successfully...", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                           clrBtn();
                           BindAdmin();
                            btnUpdate.Visible = false;
                            btnDelete.Visible = false;
                            btnAdd.Visible = true;
                            lblAdminID.Visible = false;
                        }
                        else
                        {
                            MessageBox.Show("Category delete failed...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            clrBtn();
                        }
                        dbCon.CloseCon();
                    }
                }
            }
            catch (Exception ex)
            {
            }

        }

    }
}
