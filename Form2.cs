using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoMart
{
    public partial class Form2 : Form
    {
        DBConnect dbCon = new DBConnect();
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            btnUpdate.Visible = false;
            btnDelete.Visible = false;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtcatname.Text == String.Empty)
            {
                MessageBox.Show("Please Enter Category Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               txtcatname.Focus();
                return;
            }
            else if (rtbcatdesc.Text == String.Empty)
            {
                MessageBox.Show("Please Enter valid Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rtbcatdesc.Focus();
                return;
            }
            // For Storing the Category Data
            else
            {
                    SqlCommand cmd = new SqlCommand("select CategoryName from tblCategory where CategoryName=@CategoryName", dbCon.GetCon());
                    cmd.Parameters.AddWithValue("@CategoryName", txtcatname.Text);
                    dbCon.OpenCon();
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    { 
                        MessageBox.Show(String.Format("CategoryName {0} already exists"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    } 
                    else
                    { 
                        cmd = new SqlCommand("spCatInsert", dbCon.GetCon());
                        cmd.Parameters.AddWithValue("@CategoryName", txtcatname.Text);
                        cmd.Parameters.AddWithValue("@CategoryDesc", rtbcatdesc.Text);
                        cmd.CommandType = CommandType.StoredProcedure; int i = cmd.ExecuteNonQuery();
                        if (i > 0)
                        {
                            MessageBox.Show("Category inserted successfully...", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        } 
                    }
                    dbCon.CloseCon();
                }
        }
        // A function for the Clearance
       // of the TextBoxes
       private void txtClear()
        {
            txtcatname.Clear();
            rtbcatdesc.Clear();

        }
    }
}
