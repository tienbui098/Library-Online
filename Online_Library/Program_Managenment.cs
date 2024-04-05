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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;
using System.Security.Permissions;
using System.Diagnostics.Eventing.Reader;
using System.Security.Policy;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Globalization;
using System.Net;
using System.Text.RegularExpressions;

namespace Online_Library
{
    public partial class Program_Managenment : Form
    {
        SqlConnection conn;
        public Program_Managenment()
        {
            InitializeComponent();
            conn = new SqlConnection("Data Source=QUANGGTIENN\\QUANGTIEN;Initial Catalog=Online_Library;Integrated Security=True");
        }

        public Program_Managenment(string username)
        {
            InitializeComponent();
            conn = new SqlConnection("Data Source=QUANGGTIENN\\QUANGTIEN;Initial Catalog=Online_Library;Integrated Security=True");
            lbl_Users.Text = "User : " + username;
        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_Form login = new Login_Form();
            login.ShowDialog();
            this.ShowDialog();
        }

        private void Program_Managenment_Load(object sender, EventArgs e)
        {
            conn.Open();

            FillDataRole();

            FillDataAccount();
            GetRole1();

            FillDataAuthor();

            FillDataCategory();

            FillData_Users();
            GetDataRole();
           
            FillDataBook();
            GetAuthor();
            GetCategories();

            FillDataLibrarian();

            FillDataPublisher();

            FillDataLibraryCard();
            GetUserID();

            FillDataLoans();
            GetUserIDLoan();
            GetBookIDLoan();

            FillDataBorrowingSlip();
            GetUsersIDBorrowingSlip();
            GetBookIDBorrowingSlip();

        }





        public void FillDataRole()
        {
            foreach (DataGridViewColumn column in dgv_Role.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dgv_Role.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            string query = "select * from Roles";
            DataTable dtrole = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, conn);
            ad.Fill(dtrole);
            dgv_Role.DataSource = dtrole;
            conn.Close();
        }

        public void FillDataAccount()
        {
            foreach (DataGridViewColumn column in dgv_Account.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dgv_Account.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            string query = "select * from Account";
            DataTable dtaccount = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, conn);
            ad.Fill(dtaccount);
            dgv_Account.DataSource = dtaccount;
            conn.Close();
        }

        public void ClearDataAccount()
        {
            tbx_Username.Clear();
            tbx_Password.Clear();
        }

        public void GetRole1()
        {
            string query = "select Role_ID, Role_Name from Roles";
            DataTable tblRole = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            adapter.Fill(tblRole);
            cbx_RoleID.DataSource = tblRole;
            cbx_RoleID.DisplayMember = "Role_Name";
            cbx_RoleID.ValueMember = "Role_ID";
        }

        private void btn_Insert_Account_Click(object sender, EventArgs e)
        {
            int error = 0;
            string username = tbx_Username.Text;
            if (username.Equals(""))
            {
                error = error + 1;
                lbl_Error_Username.Text = "Username can't be blank";
            }
            else lbl_Error_Username.Text = "";

            string password = tbx_Password.Text;
            if (password.Equals(""))
            {
                error = error + 1;
                lbl_Error_Password.Text = "Password can't be blank";
            }
            else
            {
                string query = "select * from Account where Users_name =@Username";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@Username", SqlDbType.VarChar);
                cmd.Parameters["@Username"].Value = username;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    error++;
                    lbl_Error_Username.Text = "select * from Account where Users_name =@Username";
                }
                else
                {
                    lbl_Error_Password.Text = "";
                }
                conn.Close();
            }
            string Roleid = cbx_RoleID.SelectedValue.ToString(); 
            if (error == 0)
            {
                string insert = "insert into Account values (@Username,@Password,@Roleid)";
                conn.Open();
                SqlCommand cmd = new SqlCommand(insert, conn);
                cmd.Parameters.Add("@Username", SqlDbType.VarChar);
                cmd.Parameters["@Username"].Value = username;

                cmd.Parameters.Add("@Password", SqlDbType.VarChar);
                cmd.Parameters["@Password"].Value = password;

                cmd.Parameters.Add("@Roleid", SqlDbType.VarChar);
                cmd.Parameters["@Roleid"].Value = Roleid;

                cmd.ExecuteNonQuery();
                FillDataAccount();
                ClearDataAccount();
                MessageBox.Show(this, "Inserted successfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgv_Account_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgv_Account.Rows[e.RowIndex];
                tbx_Username.Text = row.Cells["Users_name"].Value.ToString();
                tbx_Password.Text = row.Cells["Password_Users"].Value.ToString();
                cbx_RoleID.Text = row.Cells["Role_ID"].Value.ToString();
            }
        }

        private void btn_Delete_Account_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbx_Username.Text))
            {
                MessageBox.Show(this, "Please select a record to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ((MessageBox.Show(this, "Do you want to delete?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                conn.Open();
                string delete = "delete from Account where Users_name = @Usersname";
                SqlCommand cmd = new SqlCommand(delete, conn);
                cmd.Parameters.Add("@Usersname", SqlDbType.VarChar);
                cmd.Parameters["@Usersname"].Value = tbx_Username.Text;
                cmd.ExecuteNonQuery();
                FillDataAccount();
                ClearDataAccount();
                MessageBox.Show(this, "Delete sccessfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Cancel_Account_Click(object sender, EventArgs e)
        {
            tbx_Username.Text = "";
            tbx_Password.Text = "";
        }





        public void ClearData()
        {
            tbx_Users_ID.Clear();
            tbx_Email.Clear();
            tbx_Full_Name.Clear();
            tbx_Address.Clear();
            tbx_Phone.Clear();
        }

        public void FillData_Users()
        {
            foreach (DataGridViewColumn column in dgv_Users.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dgv_Users.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            string query = "select * from Users";
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, conn);
            ad.Fill(dt);
            dgv_Users.DataSource = dt;
            conn.Close();
        }

        public void GetDataRole()
        {
            string query = "select Role_ID, Role_Name from Roles";
            DataTable tblrole = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            adapter.Fill(tblrole);
            cbx_Role_ID.DataSource = tblrole;
            cbx_Role_ID.DisplayMember = "Role_Name";
            cbx_Role_ID.ValueMember = "Role_ID";
        }

        private bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@fpt.btec$";
            return Regex.IsMatch(email, pattern);
        }

        private void btn_Insert_Click(object sender, EventArgs e)
        {
            int error = 0;
            string usersid = tbx_Users_ID.Text;
            if (usersid.Equals(""))
            {
                error = error + 1;
                lbl_Error_ID.Text = "Users ID can't be blank";
            }
            else lbl_Error_ID.Text = "";

            string email = tbx_Email.Text;
            if (email.Equals(""))
            {
                error = error + 1;
                lbl_Error_Email.Text = "Email can't be blank";
            }
            else if (!IsValidEmail(email))
            {
                error = error + 1;
                lbl_Error_Email.Text = "email must be in the form '@fpt.btec'";
            }
            else lbl_Error_Email.Text = "";

            string fullname = tbx_Full_Name.Text;
            if (fullname.Equals(""))
            {
                error = error + 1;
                lbl_Error_FullName.Text = "Full Name can't be blank";
            }
            else lbl_Error_FullName.Text = "";

            string address = tbx_Address.Text;
            if (address.Equals(""))
            {
                error = error + 1;
                lbl_Error_Address.Text = "Address can't be blank";
            }
            else lbl_Error_Address.Text = "";

            string phone = tbx_Phone.Text;
            if (phone.Equals(""))
            {
                error = error + 1;
                lbl_Error_Phone.Text = "Phone can't be blank";
            }
            else if (phone.Length > 10)
            {
                phone = phone.Substring(0, 10);
                error = error + 1;
                lbl_Error_Phone.Text = "includes 10 numbers";
            }
            else
            {
                string query = "select * from Users where Users_ID = @usersid";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@usersid", SqlDbType.Int);
                cmd.Parameters["@usersid"].Value = usersid;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    error++;
                    lbl_Error_ID.Text = "This ID is existing, please choose another";
                }
                else
                {
                    lbl_Error_Phone.Text = "";
                }
                conn.Close();
            }
            string roleid = cbx_Role_ID.SelectedValue.ToString();
            if (error == 0)
            {
                string insert = "insert into Users values (@usersid,@email,@fullname,@address,@phone,@roleid)";
                conn.Open();
                SqlCommand cmd = new SqlCommand(insert, conn);
                cmd.Parameters.Add("@usersid", SqlDbType.Int);
                cmd.Parameters["@usersid"].Value = usersid;

                cmd.Parameters.Add("@email", SqlDbType.VarChar);
                cmd.Parameters["@email"].Value = email;

                cmd.Parameters.Add("@fullname", SqlDbType.VarChar);
                cmd.Parameters["@fullname"].Value = fullname;

                cmd.Parameters.Add("@address", SqlDbType.VarChar);
                cmd.Parameters["@address"].Value = address;

                cmd.Parameters.Add("@phone", SqlDbType.VarChar);
                cmd.Parameters["@phone"].Value = phone;

                cmd.Parameters.Add("@roleid", SqlDbType.VarChar);
                cmd.Parameters["@roleid"].Value = roleid;

                cmd.ExecuteNonQuery();
                FillData_Users();
                ClearData();
                MessageBox.Show(this, "Inserted successfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            int error = 0;
            string usersid = tbx_Users_ID.Text;
            if (usersid.Equals(""))
            {
                error = error + 1;
                lbl_Error_ID.Text = "Users ID can't be blank";
            }
            else lbl_Error_ID.Text = "";

            string email = tbx_Email.Text;
            if (email.Equals(""))
            {
                error = error + 1;
                lbl_Error_Email.Text = "Email can't be blank";
            }
            else if (!IsValidEmail(email))
            {
                error = error + 1;
                lbl_Error_Email.Text = "email must be in the form '@fpt.btec'";
            }
            else lbl_Error_Email.Text = "";

            string fullname = tbx_Full_Name.Text;
            if (fullname.Equals(""))
            {
                error = error + 1;
                lbl_Error_FullName.Text = "Full Name can't be blank";
            }
            else lbl_Error_FullName.Text = "";

            string address = tbx_Address.Text;
            if (address.Equals(""))
            {
                error = error + 1;
                lbl_Error_Address.Text = "Address can't be blank";
            }
            else lbl_Error_Address.Text = "";

            string phone = tbx_Phone.Text;
            if (phone.Equals(""))
            {
                error = error + 1;
                lbl_Error_Phone.Text = "Phone can't be blank";
            }
            else if (phone.Length > 10)
            {
                phone = phone.Substring(0, 10);
                error = error + 1;
                lbl_Error_Phone.Text = "includes 10 numbers";
            }
            else lbl_Error_Phone.Text = "";
            conn.Close();

            if (error == 0)
            {


                if ((MessageBox.Show(this, "Do you want to update?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    string update = "update Users set Email_Users =@email, FullName_Users =@fullname, Address_Users =@address, Phone_Users =@phone "
                        + " where Users_ID = @usersid";

                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    SqlCommand cmd = new SqlCommand(update, conn);
                    cmd.Parameters.Add("@email", SqlDbType.VarChar);
                    cmd.Parameters["@email"].Value = tbx_Email.Text;

                    cmd.Parameters.Add("@fullname", SqlDbType.VarChar);
                    cmd.Parameters["@fullname"].Value = tbx_Full_Name.Text;

                    cmd.Parameters.Add("@address", SqlDbType.VarChar);
                    cmd.Parameters["@address"].Value = tbx_Address.Text;

                    cmd.Parameters.Add("@phone", SqlDbType.VarChar);
                    cmd.Parameters["@phone"].Value = tbx_Phone.Text;

                    cmd.Parameters.Add("@usersid", SqlDbType.Int);
                    cmd.Parameters["@usersid"].Value = tbx_Users_ID.Text;

                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        FillData_Users();
                        ClearData();
                        MessageBox.Show(this, "Update successfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void dgv_Users_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgv_Users.Rows[e.RowIndex];
                tbx_Users_ID.Text = row.Cells["Users_ID"].Value.ToString();
                tbx_Email.Text = row.Cells["Email_Users"].Value.ToString();
                tbx_Full_Name.Text = row.Cells["FullName_Users"].Value.ToString();
                tbx_Address.Text = row.Cells["Address_Users"].Value.ToString();
                tbx_Phone.Text = row.Cells["Phone_Users"].Value.ToString();
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbx_Users_ID.Text))
            {
                MessageBox.Show(this, "Please select a record to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ((MessageBox.Show(this, "Do you want to delete?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                conn.Open();
                string delete = "delete from Users where Users_ID = @usersid";
                SqlCommand cmd = new SqlCommand(delete, conn);
                cmd.Parameters.Add("@usersid", SqlDbType.Int);
                cmd.Parameters["@usersid"].Value = tbx_Users_ID.Text;
                cmd.ExecuteNonQuery();
                FillData_Users();
                ClearData();
                MessageBox.Show(this, "Delete sccessfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_CanCel_Click(object sender, EventArgs e)
        {
            tbx_Users_ID.Text = "";
            tbx_Email.Text = "";
            tbx_Full_Name.Text = "";
            tbx_Address.Text = "";
            tbx_Phone.Text = "";
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

        public void ClearDataLibraryCards()
        {
            tbx_LibraryCard_ID.Clear();
            tbx_Card_Number.Clear();
            tbx_Issued_Date.Clear();
            tbx_Expiration_Date.Clear();
        }

        public void GetUserID()
        {
            string query = "select Users_ID, Email_Users from Users";
            DataTable tblLibraryCard = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            adapter.Fill(tblLibraryCard);
            cbx_Users_ID_LibraryCard.DataSource = tblLibraryCard;
            cbx_Users_ID_LibraryCard.DisplayMember = "Email_Users";
            cbx_Users_ID_LibraryCard.ValueMember = "Users_ID";
        }

        private void btn_Insert_LibraryCards_Click_1(object sender, EventArgs e)
        {
            int error = 0;
            string LibraryCardID = tbx_LibraryCard_ID.Text;
            if (LibraryCardID.Equals(""))
            {
                error = error + 1;
                lbl_Error_LibraryCard_ID.Text = "LibraryCard ID can't be blank";
            }
            else lbl_Error_LibraryCard_ID.Text = "";

            string CardNumber = tbx_Card_Number.Text;
            if (CardNumber.Equals(""))
            {
                error = error + 1;
                lbl_Error_Card_Number.Text = "Card Number can't be blank";
            }
            else lbl_Error_Card_Number.Text = "";

            string IssuedDate = tbx_Issued_Date.Text;
            if (IssuedDate.Equals(""))
            {
                error = error + 1;
                lbl_Error_Issued_Date.Text = "Issued Date can't be blank";
            }

            string ExpirationDate = tbx_Expiration_Date.Text;
            if (ExpirationDate.Equals(""))
            {
                error = error + 1;
                lbl_Error_Expiration_Date.Text = "Expiration Date can't be blank";
            }
            else
            {

                string query = "select * from LibraryCards where LibraryCard_ID = @LibraryCardID";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@LibraryCardID", SqlDbType.Int);
                cmd.Parameters["@LibraryCardID"].Value = LibraryCardID;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    error++;
                    lbl_Error_LibraryCard_ID.Text = "This ID is existing, please choose another";
                }
                else
                {
                    lbl_Error_Expiration_Date.Text = "";
                }
                conn.Close();
            }
            string UsersID = cbx_Users_ID_LibraryCard.SelectedValue.ToString();
            if (error == 0)
            {
                string insert = "insert into LibraryCards values (@LibraryCardID,@UsersID,@CardNumber,@IssuedDate,@ExpirationDate)";
                conn.Open();
                SqlCommand cmd = new SqlCommand(insert, conn);
                cmd.Parameters.Add("@LibraryCardID", SqlDbType.Int);
                cmd.Parameters["@LibraryCardID"].Value = LibraryCardID;

                cmd.Parameters.Add("@UsersID", SqlDbType.Int);
                cmd.Parameters["@UsersID"].Value = UsersID;

                cmd.Parameters.Add("@CardNumber", SqlDbType.VarChar);
                cmd.Parameters["@CardNumber"].Value = CardNumber;

                cmd.Parameters.Add("@IssuedDate", SqlDbType.Date);
                cmd.Parameters["@IssuedDate"].Value = IssuedDate;

                cmd.Parameters.Add("@ExpirationDate", SqlDbType.Date);
                cmd.Parameters["@ExpirationDate"].Value = ExpirationDate;

                cmd.ExecuteNonQuery();
                FillDataLibraryCard();
                ClearDataLibraryCards();
                MessageBox.Show(this, "Inserted successfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Update_LibraryCards_Click_1(object sender, EventArgs e)
        {
            int error = 0;
            string LibraryCardID = tbx_LibraryCard_ID.Text;
            if (LibraryCardID.Equals(""))
            {
                error = error + 1;
                lbl_Error_LibraryCard_ID.Text = "LibraryCard ID can't be blank";
            }
            else lbl_Error_LibraryCard_ID.Text = "";

            string CardNumber = tbx_Card_Number.Text;
            if (CardNumber.Equals(""))
            {
                error = error + 1;
                lbl_Error_Card_Number.Text = "Card Number can't be blank";
            }
            else lbl_Error_Card_Number.Text = "";

            string IssuedDate = tbx_Issued_Date.Text;
            if (IssuedDate.Equals(""))
            {
                error = error + 1;
                lbl_Error_Issued_Date.Text = "Issued Date can't be blank";
            }

            string ExpirationDate = tbx_Expiration_Date.Text;
            if (ExpirationDate.Equals(""))
            {
                error = error + 1;
                lbl_Error_Expiration_Date.Text = "Expiration Date can't be blank";
            }
            else lbl_Error_Expiration_Date.Text = "";
            conn.Close();

            if (error == 0)
            {
                if ((MessageBox.Show(this, "Do you want to update?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    string update = "update LibraryCards set CardNumber = @CardNumber, IssuedDate = @IssuedDate, ExpirationDate = @ExpirationDate "
                        + " where LibraryCard_ID = @LibraryCardID";

                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    SqlCommand cmd = new SqlCommand(update, conn);
                    cmd.Parameters.Add("@CardNumber", SqlDbType.VarChar);
                    cmd.Parameters["@CardNumber"].Value = tbx_Card_Number.Text;

                    cmd.Parameters.Add("@IssuedDate", SqlDbType.Date);
                    cmd.Parameters["@IssuedDate"].Value = tbx_Issued_Date.Text;

                    cmd.Parameters.Add("@ExpirationDate", SqlDbType.Date);
                    cmd.Parameters["@ExpirationDate"].Value = tbx_Expiration_Date.Text;

                    cmd.Parameters.Add("@LibraryCardID", SqlDbType.Int);
                    cmd.Parameters["@LibraryCardID"].Value = tbx_LibraryCard_ID.Text;

                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        FillDataLibraryCard();
                        ClearDataLibraryCards();
                        MessageBox.Show(this, "Update successfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void dgv_LibraryCards_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgv_LibraryCards.Rows[e.RowIndex];
                tbx_LibraryCard_ID.Text = row.Cells["LibraryCard_ID"].Value.ToString();
                cbx_Users_ID_LibraryCard.Text = row.Cells["Users_ID"].Value.ToString();
                tbx_Card_Number.Text = row.Cells["CardNumber"].Value.ToString();
                tbx_Issued_Date.Text = row.Cells["IssuedDate"].Value.ToString();
                tbx_Expiration_Date.Text = row.Cells["ExpirationDate"].Value.ToString();
            }
        }

        private void btn_Delete_LibraryCards_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbx_LibraryCard_ID.Text))
            {
                MessageBox.Show(this, "Please select a record to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ((MessageBox.Show(this, "Do you want to delete?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                conn.Open();
                string delete = "delete from LibraryCards where LibraryCard_ID = @LibraryCardID";
                SqlCommand cmd = new SqlCommand(delete, conn);
                cmd.Parameters.Add("@LibraryCardID", SqlDbType.Int);
                cmd.Parameters["@LibraryCardID"].Value = tbx_LibraryCard_ID.Text;
                cmd.ExecuteNonQuery();
                FillDataLibraryCard();
                ClearDataLibraryCards();
                MessageBox.Show(this, "Delete sccessfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Cancel_LibraryCards_Click_1(object sender, EventArgs e)
        {
            tbx_LibraryCard_ID.Text = "";
            tbx_Card_Number.Text = "";
            tbx_Issued_Date.Text = "";
            tbx_Expiration_Date.Text = "";
        }










        public void FillDataAuthor()
        {
            foreach (DataGridViewColumn column in dgv_Author.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dgv_Author.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            string query = "select * from Authors";
            DataTable dtauthor = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, conn);
            ad.Fill(dtauthor);
            dgv_Author.DataSource = dtauthor;
            conn.Close();
        }

        public void ClearDataAuthor()
        {
            tbx_Author_ID.Clear();
            tbx_Author_Name.Clear();
        }

        private void btn_Insert_Author_Click(object sender, EventArgs e)
        {
            int error = 0;
            string authorid = tbx_Author_ID.Text;
            if (authorid.Equals(""))
            {
                error = error + 1;
                lbl_Error_Author_ID.Text = "Author ID can't be blank";
            }
            else lbl_Error_Author_ID.Text = "";

            string authorname = tbx_Author_Name.Text;
            if (authorname.Equals(""))
            {
                error = error + 1;
                lbl_Error_Author_Name.Text = "Author Name can't be blank";
            }
            else
            {
                string query = "select * from Authors where Author_ID =@authorid";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@authorid", SqlDbType.Int);
                cmd.Parameters["@authorid"].Value = authorid;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    error++;
                    lbl_Error_Author_ID.Text = "select * from Authors where Author_ID =@authorid";
                }
                else
                {
                    lbl_Error_Author_Name.Text = "";
                }
                conn.Close();
            }
            if (error == 0)
            {
                string insert = "insert into Authors values (@authorid,@authorname)";
                conn.Open();
                SqlCommand cmd = new SqlCommand(insert, conn);
                cmd.Parameters.Add("@authorid", SqlDbType.Int);
                cmd.Parameters["@authorid"].Value = authorid;

                cmd.Parameters.Add("@authorname", SqlDbType.VarChar);
                cmd.Parameters["@authorname"].Value = authorname;

                cmd.ExecuteNonQuery();
                FillDataAuthor();
                ClearDataAuthor();
                MessageBox.Show(this, "Inserted successfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Update_Author_Click(object sender, EventArgs e)
        {
            int error = 0;
            string authorid = tbx_Author_ID.Text;
            if (authorid.Equals(""))
            {
                error = error + 1;
                lbl_Error_Author_ID.Text = "Author ID can't be blank";
            }
            else lbl_Error_Author_ID.Text = "";

            string authorname = tbx_Author_Name.Text;
            if (authorname.Equals(""))
            {
                error = error + 1;
                lbl_Error_Author_Name.Text = "Author Name can't be blank";
            }
            else lbl_Error_Author_Name.Text = "";
            conn.Close();

            if (error == 0)
            {
                if ((MessageBox.Show(this, "Do you want to update?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    string update = "update Authors set Author_Name = @authorname"
                        + " where Author_ID =@authorid";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(update, conn);
                    cmd.Parameters.Add("@authorname", SqlDbType.VarChar);
                    cmd.Parameters["@authorname"].Value = tbx_Author_Name.Text;

                    cmd.Parameters.Add("@authorid", SqlDbType.Int);
                    cmd.Parameters["@authorid"].Value = tbx_Author_ID.Text;

                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        FillDataAuthor();
                        ClearDataAuthor();
                        MessageBox.Show(this, "Update successfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void dgv_Author_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgv_Author.Rows[e.RowIndex];
                tbx_Author_ID.Text = row.Cells["Author_ID"].Value.ToString();
                tbx_Author_Name.Text = row.Cells["Author_Name"].Value.ToString();
            }
        }

        private void btn_Delete_Author_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbx_Author_ID.Text))
            {
                MessageBox.Show(this, "Please select a record to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ((MessageBox.Show(this, "Do you want to delete?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                conn.Open();
                string delete = "delete from Authors where Author_ID = @authorid";
                SqlCommand cmd = new SqlCommand(delete, conn);
                cmd.Parameters.Add("@authorid", SqlDbType.Int);
                cmd.Parameters["@authorid"].Value = tbx_Author_ID.Text;
                cmd.ExecuteNonQuery();
                FillDataAuthor();
                ClearDataAuthor();
                MessageBox.Show(this, "Delete sccessfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Cancel_Author_Click(object sender, EventArgs e)
        {
            tbx_Author_ID.Text = "";
            tbx_Author_Name.Text = "";
        }

       






        public void FillDataCategory()
        {
            foreach (DataGridViewColumn column in dgv_Category.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dgv_Category.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            string query = "select * from Categories";
            DataTable dtcategory = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, conn);
            ad.Fill(dtcategory);
            dgv_Category.DataSource = dtcategory;
            conn.Close();
        }

        public void ClearDataCategory()
        {
            tbx_Category_ID.Clear();
            tbx_Category_Name.Clear();
        }

        private void btn_Insert_Category_Click(object sender, EventArgs e)
        {
            int error = 0;
            string categoryid = tbx_Category_ID.Text;
            if (categoryid.Equals(""))
            {
                error = error + 1;
                lbl_Error_Category_ID.Text = "Category ID can't be blank";
            }
            else lbl_Error_Category_ID.Text = "";

            string categoryname = tbx_Category_Name.Text;
            if (categoryname.Equals(""))
            {
                error = error + 1;
                lbl_Error_Category_Name.Text = "Category Name can't be blank";
            }
            else
            {
                string query = "select * from Categories where Category_ID =@categoryid";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@categoryid", SqlDbType.Int);
                cmd.Parameters["@categoryid"].Value = categoryid;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    error++;
                    lbl_Error_Category_ID.Text = "select * from Categories where Categort_ID =@categoryid";
                }
                else
                {
                    lbl_Error_Category_Name.Text = "";
                }
                conn.Close();
            }
            if (error == 0)
            {
                string insert = "insert into Categories values (@categoryid,@categoryname)";
                conn.Open();
                SqlCommand cmd = new SqlCommand(insert, conn);
                cmd.Parameters.Add("@categoryid", SqlDbType.Int);
                cmd.Parameters["@categoryid"].Value = categoryid;

                cmd.Parameters.Add("@categoryname", SqlDbType.VarChar);
                cmd.Parameters["@categoryname"].Value = categoryname;

                cmd.ExecuteNonQuery();
                FillDataCategory();
                ClearDataCategory();
                MessageBox.Show(this, "Inserted successfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Update_Category_Click(object sender, EventArgs e)
        {
            int error = 0;
            string categoryid = tbx_Category_ID.Text;
            if (categoryid.Equals(""))
            {
                error = error + 1;
                lbl_Error_Category_ID.Text = "Category ID can't be blank";
            }
            else lbl_Error_Category_ID.Text = "";

            string categoryname = tbx_Category_Name.Text;
            if (categoryname.Equals(""))
            {
                error = error + 1;
                lbl_Error_Category_Name.Text = "Category Name can't be blank";
            }
            else lbl_Error_Category_Name.Text = "";
            conn.Close();

            if (error == 0)
            {
                if ((MessageBox.Show(this, "Do you want to update?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    string update = "update categories set Category_Name = @categoryname"
                        + " where Category_ID =@categoryid";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(update, conn);
                    cmd.Parameters.Add("@categoryname", SqlDbType.VarChar);
                    cmd.Parameters["@categoryname"].Value = tbx_Category_Name.Text;

                    cmd.Parameters.Add("@categoryid", SqlDbType.Int);
                    cmd.Parameters["@categoryid"].Value = tbx_Category_ID.Text;

                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        FillDataCategory();
                        ClearDataCategory();
                        MessageBox.Show(this, "Update successfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void dgv_Category_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgv_Category.Rows[e.RowIndex];
                tbx_Category_ID.Text = row.Cells["Category_ID"].Value.ToString();
                tbx_Category_Name.Text = row.Cells["Category_Name"].Value.ToString();
            }
        }

        private void btn_Delete_Category_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbx_Category_ID.Text))
            {
                MessageBox.Show(this, "Please select a record to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ((MessageBox.Show(this, "Do you want to delete?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                conn.Open();
                string delete = "delete from Categories where Category_ID = @categoryid";
                SqlCommand cmd = new SqlCommand(delete, conn);
                cmd.Parameters.Add("@categoryid", SqlDbType.Int);
                cmd.Parameters["@categoryid"].Value = tbx_Category_ID.Text;
                cmd.ExecuteNonQuery();
                FillDataCategory();
                ClearDataCategory();
                MessageBox.Show(this, "Delete sccessfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Cancel_Category_Click(object sender, EventArgs e)
        {
            tbx_Category_ID.Text = "";
            tbx_Category_Name.Text = "";
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

        public void ClearDataBook()
        {
            tbx_Book_ID.Clear();
            tbx_Book_Name.Clear();
            tbx_Title.Clear();
            tbx_Publisher.Clear();
            tbx_Publication_Year.Clear();
            tbx_ISBN.Clear();
            tbx_Description.Clear();
        }

        public void GetAuthor()
        {
            string query = "select Author_ID, Author_Name from Authors";
            DataTable tblauthor = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            adapter.Fill(tblauthor);
            cbx_AuhtorID.DataSource = tblauthor;
            cbx_AuhtorID.DisplayMember = "Author_Name";
            cbx_AuhtorID.ValueMember = "Author_ID";
        }

        public void GetCategories()
        {
            string query = "select Category_ID, Category_Name from Categories";
            DataTable tblcategory = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            adapter.Fill(tblcategory);
            cbx_Category_ID.DataSource = tblcategory;
            cbx_Category_ID.DisplayMember = "Category_Name";
            cbx_Category_ID.ValueMember = "Category_ID";
        }

        private void btn_Insert_Book_Click(object sender, EventArgs e)
        {
            int error = 0;
            string bookid = tbx_Book_ID.Text;
            if (bookid.Equals(""))
            {
                error = error + 1;
                lbl_Error_BookID.Text = "Book ID can't be blank";
            }
            else lbl_Error_BookID.Text = "";

            string bookname = tbx_Book_Name.Text;
            if (bookname.Equals(""))
            {
                error = error + 1;
                lbl_Error_Book_Name.Text = "Book Name can't be blank";
            }
            else lbl_Error_Book_Name.Text = "";

            string title = tbx_Title.Text;
            if (title.Equals(""))
            {
                error = error + 1;
                lbl_Error_TitleBook.Text = "Title can't be blank";
            }
            else lbl_Error_TitleBook.Text = "";

            string publisher = tbx_Publisher.Text;
            if (publisher.Equals(""))
            {
                error = error + 1;
                lbl_Error_PublisherBook.Text = "Publisher can't be blank";
            }
            else lbl_Error_PublisherBook.Text = "";

            string publication = tbx_Publication_Year.Text;
            if (publication.Equals(""))
            {
                error = error + 1;
                lbl_Error_PublicationBook.Text = "Publication Year can't be blank";
            }
            else lbl_Error_PublicationBook.Text = "";

            string isbn = tbx_ISBN.Text;
            if (isbn.Equals(""))
            {
                error = error + 1;
                lbl_Error_ISBN.Text = "ISBN can't be blank";
            }
            else lbl_Error_ISBN.Text = "";

            string description = tbx_Description.Text;
            if (description.Equals(""))
            {
                error = error + 1;
                lbl_Error_DescriptionBook.Text = "Description can't be blank";
            }
            else
            {
                string query = "select * from Books where Book_ID = @bookid";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@bookid", SqlDbType.Int);
                cmd.Parameters["@bookid"].Value = bookid;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    error++;
                    lbl_Error_BookID.Text = "This ID is existing, please choose another";
                }
                else
                {
                    lbl_Error_DescriptionBook.Text = "";
                }
                conn.Close();
            }

            string authorid = cbx_AuhtorID.SelectedValue.ToString();
            string categoryid = cbx_Category_ID.SelectedValue.ToString();
            if (error == 0)
            {
                string insert = "insert into Books values (@bookid,@bookname,@authorid,@title,@publisher,@publication,@isbn,@description,@categoryid)";
                conn.Open();
                SqlCommand cmd = new SqlCommand(insert, conn);
                cmd.Parameters.Add("@bookid", SqlDbType.Int);
                cmd.Parameters["@bookid"].Value = bookid;

                cmd.Parameters.Add("@bookname", SqlDbType.VarChar);
                cmd.Parameters["@bookname"].Value = bookname;

                cmd.Parameters.Add("@authorid", SqlDbType.Int);
                cmd.Parameters["@authorid"].Value = authorid;

                cmd.Parameters.Add("@title", SqlDbType.VarChar);
                cmd.Parameters["@title"].Value = title;

                cmd.Parameters.Add("@publisher", SqlDbType.VarChar);
                cmd.Parameters["@publisher"].Value = publisher;

                cmd.Parameters.Add("@publication", SqlDbType.Int);
                cmd.Parameters["@publication"].Value = publication;

                cmd.Parameters.Add("@isbn", SqlDbType.VarChar);
                cmd.Parameters["@isbn"].Value = isbn;

                cmd.Parameters.Add("@description", SqlDbType.Text);
                cmd.Parameters["@description"].Value = description;

                cmd.Parameters.Add("@categoryid", SqlDbType.Int);
                cmd.Parameters["@categoryid"].Value = categoryid;

                cmd.ExecuteNonQuery();
                FillDataBook();
                ClearDataBook();
                MessageBox.Show(this, "Inserted successfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Update_Book_Click(object sender, EventArgs e)
        {
            int error = 0;
            string bookid = tbx_Book_ID.Text;
            if (bookid.Equals(""))
            {
                error = error + 1;
                lbl_Error_BookID.Text = "Book ID can't be blank";
            }
            else lbl_Error_BookID.Text = "";

            string bookname = tbx_Book_Name.Text;
            if (bookname.Equals(""))
            {
                error = error + 1;
                lbl_Error_Book_Name.Text = "Book Name can't be blank";
            }
            else lbl_Error_Book_Name.Text = "";

            string title = tbx_Title.Text;
            if (title.Equals(""))
            {
                error = error + 1;
                lbl_Error_TitleBook.Text = "Title can't be blank";
            }
            else lbl_Error_TitleBook.Text = "";

            string publisher = tbx_Publisher.Text;
            if (publisher.Equals(""))
            {
                error = error + 1;
                lbl_Error_PublisherBook.Text = "Publisher can't be blank";
            }
            else lbl_Error_PublisherBook.Text = "";

            string publication = tbx_Publication_Year.Text;
            if (publication.Equals(""))
            {
                error = error + 1;
                lbl_Error_PublicationBook.Text = "Publication Year can't be blank";
            }
            else lbl_Error_PublicationBook.Text = "";

            string isbn = tbx_ISBN.Text;
            if (isbn.Equals(""))
            {
                error = error + 1;
                lbl_Error_ISBN.Text = "ISBN can't be blank";
            }
            else lbl_Error_ISBN.Text = "";

            string description = tbx_Description.Text;
            if (description.Equals(""))
            {
                error = error + 1;
                lbl_Error_DescriptionBook.Text = "Description can't be blank";
            }
            else lbl_Error_DescriptionBook.Text = "";

            conn.Close();

            if (error == 0)
            {
                if ((MessageBox.Show(this, "Do you want to update?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    string update = "update Books set Book_Name =@bookname, Title_Books = @title, Publisher_Books = @publisher, PublicationYear_Books = @publication, ISBN_Books = @isbn, Description_Books = @description "
                        + " where Book_ID = @bookid";

                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    SqlCommand cmd = new SqlCommand(update, conn);

                    cmd.Parameters.Add("@bookname", SqlDbType.VarChar);
                    cmd.Parameters["@bookname"].Value = tbx_Book_Name.Text;

                    cmd.Parameters.Add("@title", SqlDbType.VarChar);
                    cmd.Parameters["@title"].Value = tbx_Title.Text;

                    cmd.Parameters.Add("@publisher", SqlDbType.VarChar);
                    cmd.Parameters["@publisher"].Value = tbx_Publisher.Text;

                    cmd.Parameters.Add("@publication", SqlDbType.Int);
                    cmd.Parameters["@publication"].Value = tbx_Publication_Year.Text;

                    cmd.Parameters.Add("@isbn", SqlDbType.VarChar);
                    cmd.Parameters["@isbn"].Value = tbx_ISBN.Text;

                    cmd.Parameters.Add("@description", SqlDbType.Text);
                    cmd.Parameters["@description"].Value = tbx_Description.Text;

                    cmd.Parameters.Add("@bookid", SqlDbType.Int);
                    cmd.Parameters["@bookid"].Value = tbx_Book_ID.Text;

                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        FillDataBook();
                        ClearDataBook();
                        MessageBox.Show(this, "Update successfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void dgv_Books_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgv_Books.Rows[e.RowIndex];
                tbx_Book_ID.Text = row.Cells["Book_ID"].Value.ToString();
                tbx_Book_Name.Text = row.Cells["Book_Name"].Value.ToString();
                tbx_Title.Text = row.Cells["Title_Books"].Value.ToString();
                tbx_Publisher.Text = row.Cells["Publisher_Books"].Value.ToString();
                tbx_Publication_Year.Text = row.Cells["PublicationYear_Books"].Value.ToString();
                tbx_ISBN.Text = row.Cells["ISBN_Books"].Value.ToString();
                tbx_Description.Text = row.Cells["Description_Books"].Value.ToString();
            }
        }

        private void btn_Delete_Book_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbx_Book_ID.Text))
            {
                MessageBox.Show(this, "Please select a record to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ((MessageBox.Show(this, "Do you want to delete?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                conn.Open();
                string delete = "delete from Books where Book_ID = @bookid";
                SqlCommand cmd = new SqlCommand(delete, conn);
                cmd.Parameters.Add("@bookid", SqlDbType.Int);
                cmd.Parameters["@bookid"].Value = tbx_Book_ID.Text;
                cmd.ExecuteNonQuery();
                FillDataBook();
                ClearDataBook();
                MessageBox.Show(this, "Delete sccessfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Cancel_Book_Click(object sender, EventArgs e)
        {
            tbx_Book_ID.Text = "";
            tbx_Book_Name.Text = "";
            tbx_Title.Text = "";
            tbx_Publisher.Text = "";
            tbx_Publication_Year.Text = "";
            tbx_ISBN.Text = "";
            tbx_Description.Text = "";
        }











        public void FillDataPublisher()
        {
            foreach (DataGridViewColumn column in dgv_Publisher.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dgv_Publisher.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            string query = "SELECT * FROM Publishers";
            DataTable tblPublishers = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, conn);
            ad.Fill(tblPublishers);
            dgv_Publisher.DataSource = tblPublishers;
            conn.Close();
        }

        public void ClearDataPublisher()
        {
            tbx_Publisher_ID.Clear();
            tbx_Publisher_Name.Clear();
            tbx_Address_Publisher.Clear();
            tbx_Email_Publisher.Clear();
        }

        private void btn_Insert_Publisher_Click(object sender, EventArgs e)
        {
            int error = 0;
            string publisherid = tbx_Publisher_ID.Text;
            if (publisherid.Equals(""))
            {
                error = error + 1;
                lbl_Error_Publisher_ID.Text = "Publisher ID can't be blank";
            }
            else lbl_Error_Publisher_ID.Text = "";

            string publishername = tbx_Publisher_Name.Text;
            if (publishername.Equals(""))
            {
                error = error + 1;
                lbl_Error_Publisher_Name.Text = "Publisher Name can't be blank";
            }
            else lbl_Error_Publisher_Name.Text = "";

            string address = tbx_Address_Publisher.Text;
            if (address.Equals(""))
            {
                error = error + 1;
                lbl_Error_Address_Publisher.Text = "Address can't be blank";
            }
            else lbl_Error_Address_Publisher.Text = "";

            string email = tbx_Email_Publisher.Text;
            if (email.Equals(""))
            {
                error = error + 1;
                lbl_Error_Email_Publisher.Text = "Email can't be blank";
            }
            else
            {

                string query = "select * from Publishers where Publisher_ID = @publisherid";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@publisherid", SqlDbType.Int);
                cmd.Parameters["@publisherid"].Value = publisherid;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    error++;
                    lbl_Error_Publisher_ID.Text = "This ID is existing, please choose another";
                }
                else
                {
                    lbl_Error_Email_Publisher.Text = "";
                }
                conn.Close();
            }
            if (error == 0)
            {
                string insert = "insert into Publishers values (@publisherid,@publishername,@address,@email)";
                conn.Open();
                SqlCommand cmd = new SqlCommand(insert, conn);
                cmd.Parameters.Add("@publisherid", SqlDbType.Int);
                cmd.Parameters["@publisherid"].Value = publisherid;

                cmd.Parameters.Add("@publishername", SqlDbType.VarChar);
                cmd.Parameters["@publishername"].Value = publishername;

                cmd.Parameters.Add("@address", SqlDbType.VarChar);
                cmd.Parameters["@address"].Value = address;

                cmd.Parameters.Add("@email", SqlDbType.VarChar);
                cmd.Parameters["@email"].Value = email;

                cmd.ExecuteNonQuery();
                FillDataPublisher();
                ClearDataPublisher();
                MessageBox.Show(this, "Inserted successfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Update_Publisher_Click_1(object sender, EventArgs e)
        {
            int error = 0;
            string publisherid = tbx_Publisher_ID.Text;
            if (publisherid.Equals(""))
            {
                error = error + 1;
                lbl_Error_Publisher_ID.Text = "Publisher ID can't be blank";
            }
            else lbl_Error_Publisher_ID.Text = "";

            string publishername = tbx_Publisher_Name.Text;
            if (publishername.Equals(""))
            {
                error = error + 1;
                lbl_Error_Publisher_Name.Text = "Publisher Name can't be blank";
            }
            else lbl_Error_Publisher_Name.Text = "";

            string address = tbx_Address_Publisher.Text;
            if (address.Equals(""))
            {
                error = error + 1;
                lbl_Error_Address_Publisher.Text = "Address can't be blank";
            }
            else lbl_Error_Address_Publisher.Text = "";

            string email = tbx_Email_Publisher.Text;
            if (email.Equals(""))
            {
                error = error + 1;
                lbl_Error_Email_Publisher.Text = "Email can't be blank";
            }
            else lbl_Error_Email_Publisher.Text = "";
            conn.Close();

            if (error == 0)
            {
                if ((MessageBox.Show(this, "Do you want to update?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    string update = "update Publishers set Publisher_Name = @publishername, Address_ = @address, Email = @email "
                        + " where Publisher_ID = @publisherid";

                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    SqlCommand cmd = new SqlCommand(update, conn);
                    cmd.Parameters.Add("@publishername", SqlDbType.VarChar);
                    cmd.Parameters["@publishername"].Value = tbx_Publisher_Name.Text;

                    cmd.Parameters.Add("@address", SqlDbType.VarChar);
                    cmd.Parameters["@address"].Value = tbx_Address_Publisher.Text;

                    cmd.Parameters.Add("@email", SqlDbType.VarChar);
                    cmd.Parameters["@email"].Value = tbx_Email_Publisher.Text;

                    cmd.Parameters.Add("@publisherid", SqlDbType.Int);
                    cmd.Parameters["@publisherid"].Value = tbx_Publisher_ID.Text;

                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        FillDataPublisher();
                        ClearDataPublisher();
                        MessageBox.Show(this, "Update successfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void dgv_Publisher_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgv_Publisher.Rows[e.RowIndex];
                tbx_Publisher_ID.Text = row.Cells["Publisher_ID"].Value.ToString();
                tbx_Publisher_Name.Text = row.Cells["Publisher_Name"].Value.ToString();
                tbx_Address_Publisher.Text = row.Cells["Address_"].Value.ToString();
                tbx_Email_Publisher.Text = row.Cells["Email"].Value.ToString();
            }
        }

        private void btn_Delete_Publisher_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbx_Publisher_ID.Text))
            {
                MessageBox.Show(this, "Please select a record to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ((MessageBox.Show(this, "Do you want to delete?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                conn.Open();
                string delete = "delete from Publishers where Publisher_ID = @publisherid";
                SqlCommand cmd = new SqlCommand(delete, conn);
                cmd.Parameters.Add("@publisherid", SqlDbType.Int);
                cmd.Parameters["@publisherid"].Value = tbx_Publisher_ID.Text;
                cmd.ExecuteNonQuery();
                FillDataPublisher();
                ClearDataPublisher();
                MessageBox.Show(this, "Delete sccessfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Cancel_Publisher_Click_1(object sender, EventArgs e)
        {
            tbx_Publisher_ID.Text = "";
            tbx_Publisher_Name.Text = "";
            tbx_Address_Publisher.Text = "";
            tbx_Email_Publisher.Text = "";
        }








        public void FillDataBorrowingSlip()
        {
            foreach (DataGridViewColumn column in dgv_BorrowingSlip.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dgv_BorrowingSlip.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            string query = "SELECT * FROM BorrowingSlips";
            DataTable tblBorrowingSlip = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, conn);
            ad.Fill(tblBorrowingSlip);
            dgv_BorrowingSlip.DataSource = tblBorrowingSlip;
            conn.Close();
        }

        public void ClearDataBorrowingSlip()
        {
            tbx_BorrowingSlip_ID.Clear();
            tbx_BorrowDate.Clear();
            tbx_DueDate_BorrowingSlip.Clear();
            tbx_Status.Clear();
        }

        public void GetUsersIDBorrowingSlip()
        {
            string query = "select Users_ID, Email_Users from Users";
            DataTable tblUsersIDBorrowingSlip = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            adapter.Fill(tblUsersIDBorrowingSlip);
            cbx_UsersID_BorrowingSlip.DataSource = tblUsersIDBorrowingSlip;
            cbx_UsersID_BorrowingSlip.DisplayMember = "Email_Users";
            cbx_UsersID_BorrowingSlip.ValueMember = "Users_ID";
        }

        public void GetBookIDBorrowingSlip()
        {
            string query = "select Book_ID, Book_Name from Books";
            DataTable tblBookBorrowingSlip = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            adapter.Fill(tblBookBorrowingSlip);
            cbx_BookID_BorrowingSlip.DataSource = tblBookBorrowingSlip;
            cbx_BookID_BorrowingSlip.DisplayMember = "Book_Name";
            cbx_BookID_BorrowingSlip.ValueMember = "Book_ID";
        }

        private void btn_Insert_BorrowingSlip_Click_1(object sender, EventArgs e)
        {
            int error = 0;
            string BorrowingSlipID = tbx_BorrowingSlip_ID.Text;
            if (BorrowingSlipID.Equals(""))
            {
                error = error + 1;
                lbl_Error_BorrowingSlip_ID.Text = "Borrowing Slip ID can't be blank";
            }
            else lbl_Error_BorrowingSlip_ID.Text = "";

            string BorrowDate = tbx_BorrowDate.Text;
            if (BorrowDate.Equals(""))
            {
                error = error + 1;
                lbl_Error_BorrowDate.Text = "Borrow Date can't be blank";
            }
            else lbl_Error_BorrowDate.Text = "";

            string DueDate = tbx_DueDate_BorrowingSlip.Text;
            if (DueDate.Equals(""))
            {
                error = error + 1;
                lbl_Error_DueDate_BorrowingSlip.Text = "Due Date can't be blank";
            }
            else lbl_Error_DueDate_BorrowingSlip.Text = "";

            string Status = tbx_Status.Text;
            if (Status.Equals(""))
            {
                error = error + 1;
                lbl_Error_Status.Text = "Status Date can't be blank";
            }
            else
            {

                string query = "select * from BorrowingSlips where BorrowingSlip_ID = @BorrowingSlipID";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@BorrowingSlipID", SqlDbType.Int);
                cmd.Parameters["@BorrowingSlipID"].Value = BorrowingSlipID;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    error++;
                    lbl_Error_BorrowingSlip_ID.Text = "This ID is existing, please choose another";
                }
                else
                {
                    lbl_Error_Status.Text = "";
                }
                conn.Close();
            }
            string UsersID = cbx_UsersID_BorrowingSlip.SelectedValue.ToString();
            string BookID = cbx_BookID_BorrowingSlip.SelectedValue.ToString();
            if (error == 0)
            {
                string insert = "insert into BorrowingSlips values (@BorrowingSlipID, @UsersID, @BookID, @BorrowDate, @DueDate, @Status)";
                conn.Open();
                SqlCommand cmd = new SqlCommand(insert, conn);
                cmd.Parameters.Add("@BorrowingSlipID", SqlDbType.Int);
                cmd.Parameters["@BorrowingSlipID"].Value = BorrowingSlipID;

                cmd.Parameters.Add("@UsersID", SqlDbType.Int);
                cmd.Parameters["@UsersID"].Value = UsersID;

                cmd.Parameters.Add("@BookID", SqlDbType.Int);
                cmd.Parameters["@BookID"].Value = BookID;

                cmd.Parameters.Add("@BorrowDate", SqlDbType.Date);
                cmd.Parameters["@BorrowDate"].Value = BorrowDate;

                cmd.Parameters.Add("@DueDate", SqlDbType.Date);
                cmd.Parameters["@DueDate"].Value = DueDate;

                cmd.Parameters.Add("@Status", SqlDbType.VarChar);
                cmd.Parameters["@Status"].Value = Status;

                cmd.ExecuteNonQuery();
                FillDataBorrowingSlip();
                ClearDataBorrowingSlip();
                MessageBox.Show(this, "Inserted successfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Update_BorrowingSlip_Click_1(object sender, EventArgs e)
        {
            int error = 0;
            string BorrowingSlipID = tbx_BorrowingSlip_ID.Text;
            if (BorrowingSlipID.Equals(""))
            {
                error = error + 1;
                lbl_Error_BorrowingSlip_ID.Text = "Borrowing Slip ID can't be blank";
            }
            else lbl_Error_BorrowingSlip_ID.Text = "";

            string BorrowDate = tbx_BorrowDate.Text;
            if (BorrowDate.Equals(""))
            {
                error = error + 1;
                lbl_Error_BorrowDate.Text = "Borrow Date can't be blank";
            }
            else lbl_Error_BorrowDate.Text = "";

            string DueDate = tbx_DueDate_BorrowingSlip.Text;
            if (DueDate.Equals(""))
            {
                error = error + 1;
                lbl_Error_DueDate_BorrowingSlip.Text = "Due Date can't be blank";
            }
            else lbl_Error_DueDate_BorrowingSlip.Text = "";

            string Status = tbx_Status.Text;
            if (Status.Equals(""))
            {
                error = error + 1;
                lbl_Error_Status.Text = "Status Date can't be blank";
            }
            else lbl_Error_Status.Text = "";
            conn.Close();

            if (error == 0)
            {
                if ((MessageBox.Show(this, "Do you want to update?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    string update = "update BorrowingSlips set BorrowDate =@BorrowDate, DueDate = @DueDate, Status = @Status"
                        + " where BorrowingSlip_ID = @BorrowingSlipID";

                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    SqlCommand cmd = new SqlCommand(update, conn);
                    cmd.Parameters.Add("@BorrowDate", SqlDbType.Date);
                    cmd.Parameters["@BorrowDate"].Value = tbx_BorrowDate.Text;

                    cmd.Parameters.Add("@DueDate", SqlDbType.Date);
                    cmd.Parameters["@DueDate"].Value = tbx_DueDate_BorrowingSlip.Text;

                    cmd.Parameters.Add("@Status", SqlDbType.VarChar);
                    cmd.Parameters["@Status"].Value = tbx_Status.Text;

                    cmd.Parameters.Add("@BorrowingSlipID", SqlDbType.Int);
                    cmd.Parameters["@BorrowingSlipID"].Value = tbx_BorrowingSlip_ID.Text;

                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        FillDataBorrowingSlip();
                        ClearDataBorrowingSlip();
                        MessageBox.Show(this, "Update successfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void dgv_BorrowingSlip_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgv_BorrowingSlip.Rows[e.RowIndex];
                tbx_BorrowingSlip_ID.Text = row.Cells["BorrowingSlip_ID"].Value.ToString();
                cbx_UsersID_BorrowingSlip.Text = row.Cells["Users_ID"].Value.ToString();
                cbx_BookID_BorrowingSlip.Text = row.Cells["Book_ID"].Value.ToString();
                tbx_BorrowDate.Text = row.Cells["BorrowDate"].Value.ToString();
                tbx_DueDate_BorrowingSlip.Text = row.Cells["DueDate"].Value.ToString();
                tbx_Status.Text = row.Cells["Status"].Value.ToString();
            }
        }

        private void btn_Delete_BorrowingSlip_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbx_BorrowingSlip_ID.Text))
            {
                MessageBox.Show(this, "Please select a record to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ((MessageBox.Show(this, "Do you want to delete?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                conn.Open();
                string delete = "delete from BorrowingSlips where BorrowingSlip_ID = @BorrowingSlipID";
                SqlCommand cmd = new SqlCommand(delete, conn);
                cmd.Parameters.Add("@BorrowingSlipID", SqlDbType.Int);
                cmd.Parameters["@BorrowingSlipID"].Value = tbx_BorrowingSlip_ID.Text;
                cmd.ExecuteNonQuery();
                FillDataBorrowingSlip();
                ClearDataBorrowingSlip();
                MessageBox.Show(this, "Delete sccessfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Cancel_BorrowingSlip_Click_1(object sender, EventArgs e)
        {
            tbx_BorrowingSlip_ID.Text = "";
            tbx_BorrowDate.Text = "";
            tbx_DueDate_BorrowingSlip.Text = "";
            tbx_Status.Text = "";
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

        public void ClearDataLoans()
        {
            tbx_Loans_ID.Clear();
            tbx_LoanDate.Clear();
            tbx_DueDate.Clear();
            tbx_ReturnDate.Clear();
        }

        public void GetUserIDLoan()
        {
            string query = "select Users_ID, Email_Users from Users";
            DataTable tblLoan = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            adapter.Fill(tblLoan);
            cbx_UsersID_Loans.DataSource = tblLoan;
            cbx_UsersID_Loans.DisplayMember = "Email_Users";
            cbx_UsersID_Loans.ValueMember = "Users_ID";
        }

        public void GetBookIDLoan()
        {
            string query = "select Book_ID, Book_Name from Books";
            DataTable tblBook = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            adapter.Fill(tblBook);
            cbx_BookID_Loans.DataSource = tblBook;
            cbx_BookID_Loans.DisplayMember = "Book_Name";
            cbx_BookID_Loans.ValueMember = "Book_ID";
        }

        private void btn_Insert_Loans_Click_1(object sender, EventArgs e)
        {
            int error = 0;
            string LoanID = tbx_Loans_ID.Text;
            if (LoanID.Equals(""))
            {
                error = error + 1;
                lbl_Error_Loans_ID.Text = "Loan ID can't be blank";
            }
            else lbl_Error_Loans_ID.Text = "";

            string LoanDate = tbx_LoanDate.Text;
            if (LoanDate.Equals(""))
            {
                error = error + 1;
                lbl_Error_LoanDate.Text = "Loan Date can't be blank";
            }
            else lbl_Error_LoanDate.Text = "";

            string DueDate = tbx_DueDate.Text;
            if (DueDate.Equals(""))
            {
                error = error + 1;
                lbl_Error_DueDate.Text = "Due Date can't be blank";
            }

            string ReturnDate = tbx_ReturnDate.Text;
            if (ReturnDate.Equals(""))
            {
                error = error + 1;
                lbl_Error_ReturnDate.Text = "Return Date can't be blank";
            }
            else
            {

                string query = "select * from Loans where Loan_ID = @LoanID";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@LoanID", SqlDbType.Int);
                cmd.Parameters["@LoanID"].Value = LoanID;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    error++;
                    lbl_Error_Loans_ID.Text = "This ID is existing, please choose another";
                }
                else
                {
                    lbl_Error_ReturnDate.Text = "";
                }
                conn.Close();
            }
            string UsersID = cbx_UsersID_Loans.SelectedValue.ToString();
            string BookID = cbx_BookID_Loans.SelectedValue.ToString();
            if (error == 0)
            {
                string insert = "insert into Loans values (@LoanID, @UsersID, @BookID, @LoanDate, @DueDate, @ReturnDate)";
                conn.Open();
                SqlCommand cmd = new SqlCommand(insert, conn);
                cmd.Parameters.Add("@LoanID", SqlDbType.Int);
                cmd.Parameters["@LoanID"].Value = LoanID;

                cmd.Parameters.Add("@UsersID", SqlDbType.Int);
                cmd.Parameters["@UsersID"].Value = UsersID;

                cmd.Parameters.Add("@BookID", SqlDbType.Int);
                cmd.Parameters["@BookID"].Value = BookID;

                cmd.Parameters.Add("@LoanDate", SqlDbType.Date);
                cmd.Parameters["@LoanDate"].Value = LoanDate;

                cmd.Parameters.Add("@DueDate", SqlDbType.Date);
                cmd.Parameters["@DueDate"].Value = DueDate;

                cmd.Parameters.Add("@ReturnDate", SqlDbType.Date);
                cmd.Parameters["@ReturnDate"].Value = ReturnDate;

                cmd.ExecuteNonQuery();
                FillDataLoans();
                ClearDataLoans();
                MessageBox.Show(this, "Inserted successfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Update_Loans_Click_1(object sender, EventArgs e)
        {
            int error = 0;
            string LoanID = tbx_Loans_ID.Text;
            if (LoanID.Equals(""))
            {
                error = error + 1;
                lbl_Error_Loans_ID.Text = "Loan ID can't be blank";
            }
            else lbl_Error_Loans_ID.Text = "";

            string LoanDate = tbx_LoanDate.Text;
            if (LoanDate.Equals(""))
            {
                error = error + 1;
                lbl_Error_LoanDate.Text = "Loan Date can't be blank";
            }
            else lbl_Error_LoanDate.Text = "";

            string DueDate = tbx_DueDate.Text;
            if (DueDate.Equals(""))
            {
                error = error + 1;
                lbl_Error_DueDate.Text = "Due Date can't be blank";
            }

            string ReturnDate = tbx_ReturnDate.Text;
            if (ReturnDate.Equals(""))
            {
                error = error + 1;
                lbl_Error_ReturnDate.Text = "Return Date can't be blank";
            }
            else lbl_Error_ReturnDate.Text = "";
            conn.Close();

            if (error == 0)
            {
                if ((MessageBox.Show(this, "Do you want to update?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    string update = "update Loans set LoanDate = @LoanDate, DueDate = @DueDate, ReturnDate = @ReturnDate "
                        + " where Loan_ID = @LoanID";

                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    SqlCommand cmd = new SqlCommand(update, conn);
                    cmd.Parameters.Add("@LoanDate", SqlDbType.Date);
                    cmd.Parameters["@LoanDate"].Value = tbx_LoanDate.Text;

                    cmd.Parameters.Add("@DueDate", SqlDbType.Date);
                    cmd.Parameters["@DueDate"].Value = tbx_DueDate.Text;

                    cmd.Parameters.Add("@ReturnDate", SqlDbType.Date);
                    cmd.Parameters["@ReturnDate"].Value = tbx_ReturnDate.Text;

                    cmd.Parameters.Add("@LoanID", SqlDbType.Int);
                    cmd.Parameters["@LoanID"].Value = tbx_Loans_ID.Text;

                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        FillDataLoans();
                        ClearDataLoans();
                        MessageBox.Show(this, "Update successfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void dgv_Loans_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgv_Loans.Rows[e.RowIndex];
                tbx_Loans_ID.Text = row.Cells["Loan_ID"].Value.ToString();
                cbx_UsersID_Loans.Text = row.Cells["Users_ID"].Value.ToString();
                cbx_BookID_Loans.Text = row.Cells["Book_ID"].Value.ToString();
                tbx_LoanDate.Text = row.Cells["LoanDate"].Value.ToString();
                tbx_DueDate.Text = row.Cells["DueDate"].Value.ToString();
                tbx_ReturnDate.Text = row.Cells["ReturnDate"].Value.ToString();
            }
        }

        private void btn_Delete_Loans_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbx_Loans_ID.Text))
            {
                MessageBox.Show(this, "Please select a record to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ((MessageBox.Show(this, "Do you want to delete?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                conn.Open();
                string delete = "delete from Loans where Loan_ID = @LoanID";
                SqlCommand cmd = new SqlCommand(delete, conn);
                cmd.Parameters.Add("@LoanID", SqlDbType.Int);
                cmd.Parameters["@LoanID"].Value = tbx_Loans_ID.Text;
                cmd.ExecuteNonQuery();
                FillDataLoans();
                ClearDataLoans();
                MessageBox.Show(this, "Delete sccessfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Cancel_Loans_Click_1(object sender, EventArgs e)
        {
            tbx_Loans_ID.Text = "";
            tbx_LoanDate.Text = "";
            tbx_DueDate.Text = "";
            tbx_ReturnDate.Text = "";
        }












        private void FillDataLibrarian()
        {
            foreach (DataGridViewColumn column in dgv_Librarian.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dgv_Librarian.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            string query = "SELECT * FROM Librarians";
            DataTable tbllibrarians = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, conn);
            ad.Fill(tbllibrarians);
            dgv_Librarian.DataSource = tbllibrarians;
            conn.Close();
        }

        public void ClearDataLibrarian()
        {
            tbx_Librarian_ID.Clear();
            tbx_Librarian_Name.Clear();
            tbx_Position.Clear();
            tbx_Email_Librarian.Clear();
        }

        private void btn_Insert_Librarians_Click(object sender, EventArgs e)
        {
            int error = 0;
            string librarianid = tbx_Librarian_ID.Text;
            if (librarianid.Equals(""))
            {
                error = error + 1;
                lbl_Error_Librarian_ID.Text = "Librarian ID can't be blank";
            }
            else lbl_Error_Librarian_ID.Text = "";

            string librarianname = tbx_Librarian_Name.Text;
            if (librarianname.Equals(""))
            {
                error = error + 1;
                lbl_Error_Librarian_Name.Text = "Librarian Name can't be blank";
            }
            else lbl_Error_Librarian_Name.Text = "";

            string position = tbx_Position.Text;
            if (position.Equals(""))
            {
                error = error + 1;
                lbl_Error_Position.Text = "Publisher can't be blank";
            }
            else lbl_Error_Position.Text = "";

            string email = tbx_Email_Librarian.Text;
            if (email.Equals(""))
            {
                error = error + 1;
                lbl_Error_Email_Librarian.Text = "Publication Year can't be blank";
            }
            else
            {

                string query = "select * from Librarians where Librarian_ID = @librarianid";
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@librarianid", SqlDbType.Int);
                cmd.Parameters["@librarianid"].Value = librarianid;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    error++;
                    lbl_Error_Librarian_ID.Text = "This ID is existing, please choose another";
                }
                else
                {
                    lbl_Error_Email_Librarian.Text = "";
                }
                conn.Close();
            }
            if (error == 0)
            {
                string insert = "insert into Librarians values (@librarianid,@librarianname,@position,@email)";
                conn.Open();
                SqlCommand cmd = new SqlCommand(insert, conn);
                cmd.Parameters.Add("@librarianid", SqlDbType.Int);
                cmd.Parameters["@librarianid"].Value = librarianid;

                cmd.Parameters.Add("@librarianname", SqlDbType.VarChar);
                cmd.Parameters["@librarianname"].Value = librarianname;

                cmd.Parameters.Add("@position", SqlDbType.VarChar);
                cmd.Parameters["@position"].Value = position;

                cmd.Parameters.Add("@email", SqlDbType.VarChar);
                cmd.Parameters["@email"].Value = email;

                cmd.ExecuteNonQuery();
                FillDataLibrarian();
                ClearDataLibrarian();
                MessageBox.Show(this, "Inserted successfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Update_Librarians_Click(object sender, EventArgs e)
        {
            int error = 0;
            string librarianid = tbx_Librarian_ID.Text;
            if (librarianid.Equals(""))
            {
                error = error + 1;
                lbl_Error_Librarian_ID.Text = "Librarian ID can't be blank";
            }
            else lbl_Error_Librarian_ID.Text = "";

            string librarianname = tbx_Librarian_Name.Text;
            if (librarianname.Equals(""))
            {
                error = error + 1;
                lbl_Error_Librarian_Name.Text = "Librarian Name can't be blank";
            }
            else lbl_Error_Librarian_Name.Text = "";

            string position = tbx_Position.Text;
            if (position.Equals(""))
            {
                error = error + 1;
                lbl_Error_Position.Text = "Publisher can't be blank";
            }
            else lbl_Error_Position.Text = "";

            string email = tbx_Email_Librarian.Text;
            if (email.Equals(""))
            {
                error = error + 1;
                lbl_Error_Email_Librarian.Text = "Publication Year can't be blank";
            }
            else lbl_Error_Email_Librarian.Text = "";
            conn.Close();

            if (error == 0)
            {
                if ((MessageBox.Show(this, "Do you want to update?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    string update = "update Librarians set Librarian_Name = @librarianname, Position = @position, Email = @email "
                        + " where Librarian_ID = @librarianid";

                    if (conn.State != ConnectionState.Open)
                    {
                        conn.Open();
                    }
                    SqlCommand cmd = new SqlCommand(update, conn);
                    cmd.Parameters.Add("@librarianname", SqlDbType.VarChar);
                    cmd.Parameters["@librarianname"].Value = tbx_Librarian_Name.Text;

                    cmd.Parameters.Add("@position", SqlDbType.VarChar);
                    cmd.Parameters["@position"].Value = tbx_Position.Text;

                    cmd.Parameters.Add("@email", SqlDbType.VarChar);
                    cmd.Parameters["@email"].Value = tbx_Email_Librarian.Text;

                    cmd.Parameters.Add("@librarianid", SqlDbType.Int);
                    cmd.Parameters["@librarianid"].Value = tbx_Librarian_ID.Text;

                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        FillDataLibrarian();
                        ClearDataLibrarian();
                        MessageBox.Show(this, "Update successfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void dgv_Librarian_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgv_Librarian.Rows[e.RowIndex];
                tbx_Librarian_ID.Text = row.Cells["Librarian_ID"].Value.ToString();
                tbx_Librarian_Name.Text = row.Cells["Librarian_Name"].Value.ToString();
                tbx_Position.Text = row.Cells["Position"].Value.ToString();
                tbx_Email_Librarian.Text = row.Cells["Email"].Value.ToString();
            }
        }

        private void btn_Dalete_Librarians_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbx_Librarian_ID.Text))
            {
                MessageBox.Show(this, "Please select a record to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ((MessageBox.Show(this, "Do you want to delete?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                conn.Open();
                string delete = "delete from Librarians where Librarian_ID = @librarianid";
                SqlCommand cmd = new SqlCommand(delete, conn);
                cmd.Parameters.Add("@librarianid", SqlDbType.Int);
                cmd.Parameters["@librarianid"].Value = tbx_Librarian_ID.Text;
                cmd.ExecuteNonQuery();
                FillDataLibrarian();
                ClearDataLibrarian();
                MessageBox.Show(this, "Delete sccessfully", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Cancel_Librarians_Click(object sender, EventArgs e)
        {
            tbx_Librarian_ID.Text = "";
            tbx_Librarian_Name.Text = "";
            tbx_Position.Text = "";
            tbx_Email_Librarian.Text = "";
        }

      
    }
    
}
