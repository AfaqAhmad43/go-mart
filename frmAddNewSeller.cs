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
    public partial class frmAddNewSeller : Form
    {
        DBConnect dbCon = new DBConnect();
        public frmAddNewSeller()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmAddNewSeller_Load(object sender, EventArgs e)
        {
            lblSellerID.Visible = false;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnAdd.Visible = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (txtSellerName.Text == String.Empty)
            {
                MessageBox.Show("Please Enter Seller Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSellerName.Focus();
                return;
            }
            else if (txtPassword.Text == String.Empty)
            {
                MessageBox.Show("Please Enter valid Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
                return;
            }
            else
            {
                SqlCommand cmd = new SqlCommand("select SellerName from tblSeller where SellerName=@SellerName", dbCon.GetCon());
                cmd.Parameters.AddWithValue("@CategoryName", txtSellerName.Text);
                dbCon.OpenCon();
                var result = cmd.ExecuteScalar();
                if (result != null)
                {
                    MessageBox.Show("SellerName already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    cmd = new SqlCommand("spSellerInsert", dbCon.GetCon());
                    cmd.Parameters.AddWithValue("@SellerName", txtSellerName.Text);
                    cmd.Parameters.AddWithValue("@SellerAge", txtAge.Text);
                    cmd.Parameters.AddWithValue("@SellerPhone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@SellerPassword", txtPassword.Text);
                    cmd.CommandType = CommandType.StoredProcedure;
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Seller inserted successfully...", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtClear();
                        bindSeller();
                    }
                }
                dbCon.CloseCon();
            }
        }

        private void txtClear()
        {
            txtSellerName.Clear();
            txtAge.Clear();
            txtPassword.Clear();
            txtPhone.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void bindSeller()
        {
            SqlCommand cmd = new SqlCommand("select CategoryID , CategoryName, CategoryDesc as CategoryDescription from tblCategory", dbCon.GetCon());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dbCon.OpenCon();
        }
    }
}
