using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Online_Library
{
    public partial class Manager : Form
    {
        SqlConnection conn;
        public Manager()
        {
            InitializeComponent();
            conn = new SqlConnection("Data Source=QUANGGTIENN\\QUANGTIEN;Initial Catalog=Online_Library;Integrated Security=True");
        }
        public Manager(string username)
        {
            InitializeComponent();
            conn = new SqlConnection("Data Source=QUANGGTIENN\\QUANGTIEN;Initial Catalog=Online_Library;Integrated Security=True");
            lbl_Users1.Text = "User : " + username;
        }

        private void Manager_Load(object sender, EventArgs e)
        {
            FillDataReview();
        }

        public void FillDataReview()
        {
            foreach (DataGridViewColumn column in dgv_Reviews.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dgv_Reviews.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            string query = "SELECT * FROM Reviews";
            DataTable tblReviews = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, conn);
            ad.Fill(tblReviews);
            dgv_Reviews.DataSource = tblReviews;
            conn.Close();
        }

        private void dgv_Reviews_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgv_Reviews.Rows[e.RowIndex];
                tbx_Review_ID.Text = row.Cells["Review_ID"].Value.ToString();
                tbx_Rating.Text = row.Cells["Rating"].Value.ToString();
                tbx_Comment.Text = row.Cells["Comment"].Value.ToString();
            }
        }

        private void btn_Delete_Review_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbx_Review_ID.Text))
            {
                MessageBox.Show(this, "Please select a record to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ((MessageBox.Show(this, "Do you want to delete?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                conn.Open();
                string delete = "delete from Users where Review_ID = @Reviewid";
                SqlCommand cmd = new SqlCommand(delete, conn);
                cmd.Parameters.Add("@Reviewid", SqlDbType.Int);
                cmd.Parameters["@Reviewid"].Value = tbx_Review_ID.Text;
                cmd.ExecuteNonQuery();
                FillDataReview();
                MessageBox.Show(this, "Delete sccessfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Cancel_Review_Click(object sender, EventArgs e)
        {
            tbx_Review_ID.Text = "";
            tbx_Rating.Text = "";
            tbx_Comment.Text = "";
        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_Form login = new Login_Form();
            login.ShowDialog();
            this.ShowDialog();
        }
    }
}
