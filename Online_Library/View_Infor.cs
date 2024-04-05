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
using System.Data.SqlClient;

namespace Online_Library
{
    public partial class View_Infor : Form
    {
        SqlConnection conn;
        public View_Infor()
        {
            InitializeComponent();
            conn = new SqlConnection("Data Source=QUANGGTIENN\\QUANGTIEN;Initial Catalog=Online_Library;Integrated Security=True");
        }

        public View_Infor(string username)
        {
            InitializeComponent();
            conn = new SqlConnection("Data Source=QUANGGTIENN\\QUANGTIEN;Initial Catalog=Online_Library;Integrated Security=True");
            lbl_Users1.Text = "User : " + username;
            lbl_Users2.Text = "User : " + username;
            lbl_Users3.Text = "User : " + username;
            lbl_Users.Text = "User : " + username;

            conn.Open();
            //string query = "SELECT Users_ID FROM Users";
            //SqlCommand command = new SqlCommand(query, conn);

            //SqlDataReader reader = command.ExecuteReader();
            //if (reader.Read())
            //{
            //    string Users = reader["Users_ID"].ToString();

            //    lbl_UsersID.Text = "Users ID : " + Users;
            //}
           

            //reader.Close();
            //conn.Close();

        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_Form login = new Login_Form();
            login.ShowDialog();
            this.ShowDialog();
        }


        private void View_Infor_Load(object sender, EventArgs e)
        {
            FillDataLibraryCard();
            FillDataBook();
            FillDataLoans();

            FillDataReview();
            ClearDataReview();
            GetUserID();
            GetBookID();
        }

        private void FillDataBook()
        {
            foreach (DataGridViewColumn column in dgv_Books.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dgv_Books.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            string query = "SELECT * FROM Books";
            DataTable tblBook = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, conn);
            ad.Fill(tblBook);
            dgv_Books.DataSource = tblBook;
            conn.Close();
        }

        public void FillDataLibraryCard()
        {
            foreach (DataGridViewColumn column in dgv_LibraryCards.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dgv_LibraryCards.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            string query = "SELECT * FROM LibraryCards";
            DataTable tblLibraryCards = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, conn);
            ad.Fill(tblLibraryCards);
            dgv_LibraryCards.DataSource = tblLibraryCards;
            conn.Close();
        }

        
        public void FillDataLoans()
        {
            foreach (DataGridViewColumn column in dgv_Loans.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dgv_Loans.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            string query = "SELECT * FROM Loans";
            DataTable tblLoans = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, conn);
            ad.Fill(tblLoans);
            dgv_Loans.DataSource = tblLoans;
            conn.Close();
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

        public void ClearDataReview()
        {
            tbx_Review_ID.Clear();
            tbx_Rating.Clear();
            tbx_Comment.Clear();
        }

        public void GetUserID()
        {
            string query = "select Users_ID, Email_Users from Users";
            DataTable tblReview = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            adapter.Fill(tblReview);
            cbx_UsersID_Review.DataSource = tblReview;
            cbx_UsersID_Review.DisplayMember = "Email_Users";
            cbx_UsersID_Review.ValueMember = "Users_ID";
        }

        public void GetBookID()
        {
            string query = "select Book_ID, Book_Name from Books";
            DataTable tblBook = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            adapter.Fill(tblBook);
            cbx_BookID_Review.DataSource = tblBook;
            cbx_BookID_Review.DisplayMember = "Book_Name";
            cbx_BookID_Review.ValueMember = "Book_ID";
        }

        private void btn_Insert_Review_Click_1(object sender, EventArgs e)
        {
            int error = 0;
            string ReviewID = tbx_Review_ID.Text;
            if (ReviewID.Equals(""))
            {
                error = error + 1;
                lbl_Error_Review_ID.Text = "Review ID can't be blank";
            }
            else lbl_Error_Review_ID.Text = "";

            string Rating = tbx_Rating.Text;
            if (Rating.Equals(""))
            {
                error = error + 1;
                lbl_Error_Rating.Text = "Rating can't be blank";
            }
            else lbl_Error_Rating.Text = "";

            string DueDate = tbx_Comment.Text;
            if (DueDate.Equals(""))
            {
                error = error + 1;
                lbl_Error_Comment.Text = "Comment can't be blank";
            }
            else
            {

                string query = "select * from Reviews where Review_ID = @ReviewID";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@ReviewID", SqlDbType.Int);
                cmd.Parameters["@ReviewID"].Value = ReviewID;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    error++;
                    lbl_Error_Review_ID.Text = "This ID is existing, please choose another";
                }
                else
                {
                    lbl_Error_Comment.Text = "";
                }
                conn.Close();
            }
            string UsersID = cbx_UsersID_Review.SelectedValue.ToString();
            string BookID = cbx_BookID_Review.SelectedValue.ToString();
            if (error == 0)
            {
                string insert = "insert into Reviews values (@ReviewID, @UsersID, @BookID, @Rating, @Comment)";
                conn.Open();
                SqlCommand cmd = new SqlCommand(insert, conn);
                cmd.Parameters.Add("@ReviewID", SqlDbType.Int);
                cmd.Parameters["@ReviewID"].Value = ReviewID;

                cmd.Parameters.Add("@UsersID", SqlDbType.Int);
                cmd.Parameters["@UsersID"].Value = UsersID;

                cmd.Parameters.Add("@BookID", SqlDbType.Int);
                cmd.Parameters["@BookID"].Value = BookID;

                cmd.Parameters.Add("@Rating", SqlDbType.Decimal);
                cmd.Parameters["@Rating"].Value = Rating;

                cmd.Parameters.Add("@Comment", SqlDbType.Text);
                cmd.Parameters["@Comment"].Value = DueDate;


                cmd.ExecuteNonQuery();
                FillDataReview();
                ClearDataReview();
                MessageBox.Show(this, "Inserted successfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Update_Review_Click_1(object sender, EventArgs e)
        {
            int error = 0;
            string ReviewID = tbx_Review_ID.Text;
            if (ReviewID.Equals(""))
            {
                error = error + 1;
                lbl_Error_Review_ID.Text = "Review ID can't be blank";
            }
            else lbl_Error_Review_ID.Text = "";

            string Rating = tbx_Rating.Text;
            if (Rating.Equals(""))
            {
                error = error + 1;
                lbl_Error_Rating.Text = "Rating can't be blank";
            }
            else lbl_Error_Rating.Text = "";

            string DueDate = tbx_Comment.Text;
            if (DueDate.Equals(""))
            {
                error = error + 1;
                lbl_Error_Comment.Text = "Comment can't be blank";
            }
            else lbl_Error_Comment.Text = "";

            conn.Close();

            if (error == 0)
            {
                if ((MessageBox.Show(this, "Do you want to update?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    string update = "update Reviews set Rating =@Rating, Comment = @Comment "
                        + " where Review_ID = @ReviewID";

                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    SqlCommand cmd = new SqlCommand(update, conn);
                    cmd.Parameters.Add("@Rating", SqlDbType.Decimal);
                    cmd.Parameters["@Rating"].Value = tbx_Rating.Text;

                    cmd.Parameters.Add("@Comment", SqlDbType.Text);
                    cmd.Parameters["@Comment"].Value = tbx_Comment.Text;

                    cmd.Parameters.Add("@ReviewID", SqlDbType.Int);
                    cmd.Parameters["@ReviewID"].Value = tbx_Review_ID.Text;

                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        FillDataReview();
                        ClearDataReview();
                        MessageBox.Show(this, "Update successfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
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
                ClearDataReview();
                MessageBox.Show(this, "Delete sccessfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Cancel_Review_Click(object sender, EventArgs e)
        {
            tbx_Review_ID.Text = "";
            tbx_Rating.Text = "";
            tbx_Comment.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_Form login = new Login_Form();
            login.ShowDialog();
            this.ShowDialog();
        }

    }
}
