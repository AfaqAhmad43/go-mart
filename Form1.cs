using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
//using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoMart
{
  


    public partial class Form1 : Form
    {
        DBConnect dbCon = new DBConnect();
        // We WANT to  Display the User name 
       public  static string loginname, logintype;

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
                        if (cmbrole.Text == "Admin")
                        {
                            SqlCommand cmd = new SqlCommand("select top 1 AdminID, Password, FullName from tblAdmin where AdminID=@AdminID and Password=@Password", dbCon.GetCon());
                            cmd.Parameters.AddWithValue("@AdminID", txtusername.Text);
                            cmd.Parameters.AddWithValue("@Password", txtpassword.Text);
                            dbCon.OpenCon();
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            // Check if dt has received any data
                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show("Login Success, Welcome to Home Page", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                // Setted the value of the User Name to the loginname variable

                                loginname = txtusername.Text;
                                logintype = cmbrole.Text;
                                clrValue();
                                this.Hide();
                                frmMain fm = new frmMain();
                                fm.Show();
                            }
                            else
                            {
                                MessageBox.Show("Invalid login, Please check UserName and Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else if (cmbrole.Text == "Seller")
                        {
                            SqlCommand cmd = new SqlCommand("select top 1 AdminID, Password, FullName from tblAdmin where AdminID=@AdminID and Password=@Password", dbCon.GetCon());
                            cmd.Parameters.AddWithValue("@AdminID", txtusername.Text);
                            cmd.Parameters.AddWithValue("@Password", txtpassword.Text);
                            dbCon.OpenCon();
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            // Check if dt has received any data
                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show("Login Success, Welcome to Home Page", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                // Setted the value of the User Name to the loginname variable

                                loginname = txtusername.Text;
                                logintype = cmbrole.Text;
                                clrValue();
                                this.Hide();
                                frmMain fm = new frmMain();
                                fm.Show();
                            }
                            else
                            {
                                MessageBox.Show("Invalid login, Please check UserName and Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }

                    }

                    else
                    {
                        MessageBox.Show("Please Enter User name or the Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                      clrValue();

                    }
                }


 else
                {
                    MessageBox.Show("Please Select any Role", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clrValue();
                }


            
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        // This is the Method for the 
        private void clrValue()
        {
            // To make Every thing Clear
            cmbrole.SelectedIndex = 0;
            txtusername.Clear();
            txtpassword.Clear();

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
