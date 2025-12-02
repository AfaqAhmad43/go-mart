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
            bindCategory();

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
                            txtClear();
                            bindCategory();
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


        private void bindCategory()
        {
            SqlCommand cmd = new SqlCommand("select CategoryID , CategoryName, CategoryDesc as CategoryDescription from tblCategory", dbCon.GetCon());
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dbCon.OpenCon();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            btnAdd.Visible = false;
            string varCatID = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtcatname.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            rtbcatdesc.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }
    }
}
