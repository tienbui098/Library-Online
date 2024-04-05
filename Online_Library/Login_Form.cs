using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Online_Library
{
    public partial class Login_Form : Form
    {
        SqlConnection conn;
        public Login_Form()
        {
            InitializeComponent();
            conn = new SqlConnection("Data Source=QUANGGTIENN\\QUANGTIEN;Initial Catalog=Online_Library;Integrated Security=True");
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            string username = tbx_Username.Text;
            string password = tbx_Password.Text;
            string query = "select * from Account where Users_name =@username and Password_Users =@password";
            conn.Open();
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@username", SqlDbType.VarChar);
            cmd.Parameters["@username"].Value = username;

            cmd.Parameters.AddWithValue("@password", SqlDbType.VarChar);
            cmd.Parameters["@password"].Value = password;
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                string role = reader["Role_ID"].ToString();
                if (role.Equals("R1"))
                {
                    MessageBox.Show(this, "Login successful! ", "result", MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Hide();
                    Program_Managenment p = new Program_Managenment(username);
                    p.ShowDialog();
                    this.Dispose();
                }
                else if (role.Equals("R2"))
                {
                    MessageBox.Show(this, "Logim successful! ", "result", MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Hide();
                    View_Infor vp = new View_Infor(username);
                    vp.ShowDialog();
                    this.Dispose();
                }
                else if (role.Equals("R3"))
                {
                    MessageBox.Show(this, "Logim successful! ", "result", MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Hide();
                    Manager m = new Manager(username);
                    m.ShowDialog();
                    this.Dispose();
                }
                else
                    lbl_Error.Text = "You are not allowed to access";
            }
            else
            {
                lbl_Error.Text = "Wrong username or password";
            }
            conn.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show(this, "Do you want to exit?", "question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                Application.Exit();
            }
        }
    }
}
