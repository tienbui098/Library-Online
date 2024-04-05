namespace Online_Library
{
    partial class View_Infor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tab_LibraryCards = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_Users2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgv_LibraryCards = new System.Windows.Forms.DataGridView();
            this.tab_Books = new System.Windows.Forms.TabPage();
            this.lbl_Users = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dgv_Books = new System.Windows.Forms.DataGridView();
            this.tab_Reviews = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_Users1 = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.cbx_BookID_Review = new System.Windows.Forms.ComboBox();
            this.cbx_UsersID_Review = new System.Windows.Forms.ComboBox();
            this.lbl_Error_Comment = new System.Windows.Forms.Label();
            this.tbx_Comment = new System.Windows.Forms.TextBox();
            this.tbx_Rating = new System.Windows.Forms.TextBox();
            this.tbx_Review_ID = new System.Windows.Forms.TextBox();
            this.lbl_Comment = new System.Windows.Forms.Label();
            this.lbl_Error_Rating = new System.Windows.Forms.Label();
            this.lbl_Error_Review_ID = new System.Windows.Forms.Label();
            this.btn_Cancel_Review = new System.Windows.Forms.Button();
            this.btn_Delete_Review = new System.Windows.Forms.Button();
            this.btn_Update_Review = new System.Windows.Forms.Button();
            this.btn_Insert_Review = new System.Windows.Forms.Button();
            this.lbl_Rating = new System.Windows.Forms.Label();
            this.lbl_BookID_Review = new System.Windows.Forms.Label();
            this.lbl_UsersID_Review = new System.Windows.Forms.Label();
            this.lbl_Review_ID = new System.Windows.Forms.Label();
            this.dgv_Reviews = new System.Windows.Forms.DataGridView();
            this.tab_Loans = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_Users3 = new System.Windows.Forms.Label();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.dgv_Loans = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tab_LibraryCards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_LibraryCards)).BeginInit();
            this.tab_Books.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Books)).BeginInit();
            this.tab_Reviews.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Reviews)).BeginInit();
            this.tab_Loans.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Loans)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tab_LibraryCards);
            this.tabControl.Controls.Add(this.tab_Books);
            this.tabControl.Controls.Add(this.tab_Reviews);
            this.tabControl.Controls.Add(this.tab_Loans);
            this.tabControl.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(2, 2);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1283, 704);
            this.tabControl.TabIndex = 2;
            // 
            // tab_LibraryCards
            // 
            this.tab_LibraryCards.Controls.Add(this.label1);
            this.tab_LibraryCards.Controls.Add(this.lbl_Users2);
            this.tab_LibraryCards.Controls.Add(this.pictureBox1);
            this.tab_LibraryCards.Controls.Add(this.dgv_LibraryCards);
            this.tab_LibraryCards.Location = new System.Drawing.Point(4, 32);
            this.tab_LibraryCards.Name = "tab_LibraryCards";
            this.tab_LibraryCards.Padding = new System.Windows.Forms.Padding(3);
            this.tab_LibraryCards.Size = new System.Drawing.Size(1275, 668);
            this.tab_LibraryCards.TabIndex = 18;
            this.tab_LibraryCards.Text = "LibraryCards";
            this.tab_LibraryCards.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(503, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(317, 53);
            this.label1.TabIndex = 49;
            this.label1.Text = "Library Cards";
            // 
            // lbl_Users2
            // 
            this.lbl_Users2.AutoSize = true;
            this.lbl_Users2.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Users2.Location = new System.Drawing.Point(3, 3);
            this.lbl_Users2.Name = "lbl_Users2";
            this.lbl_Users2.Size = new System.Drawing.Size(104, 35);
            this.lbl_Users2.TabIndex = 48;
            this.lbl_Users2.Text = "Users :";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Online_Library.Properties.Resources.Logo_Btec;
            this.pictureBox1.Location = new System.Drawing.Point(1074, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(201, 106);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 46;
            this.pictureBox1.TabStop = false;
            // 
            // dgv_LibraryCards
            // 
            this.dgv_LibraryCards.BackgroundColor = System.Drawing.Color.White;
            this.dgv_LibraryCards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_LibraryCards.Location = new System.Drawing.Point(0, 171);
            this.dgv_LibraryCards.Name = "dgv_LibraryCards";
            this.dgv_LibraryCards.RowHeadersWidth = 51;
            this.dgv_LibraryCards.RowTemplate.Height = 24;
            this.dgv_LibraryCards.Size = new System.Drawing.Size(1275, 497);
            this.dgv_LibraryCards.TabIndex = 24;
            // 
            // tab_Books
            // 
            this.tab_Books.Controls.Add(this.lbl_Users);
            this.tab_Books.Controls.Add(this.pictureBox3);
            this.tab_Books.Controls.Add(this.label7);
            this.tab_Books.Controls.Add(this.dgv_Books);
            this.tab_Books.Location = new System.Drawing.Point(4, 32);
            this.tab_Books.Name = "tab_Books";
            this.tab_Books.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Books.Size = new System.Drawing.Size(1275, 668);
            this.tab_Books.TabIndex = 19;
            this.tab_Books.Text = "Books";
            this.tab_Books.UseVisualStyleBackColor = true;
            // 
            // lbl_Users
            // 
            this.lbl_Users.AutoSize = true;
            this.lbl_Users.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Users.Location = new System.Drawing.Point(6, 3);
            this.lbl_Users.Name = "lbl_Users";
            this.lbl_Users.Size = new System.Drawing.Size(104, 35);
            this.lbl_Users.TabIndex = 47;
            this.lbl_Users.Text = "Users :";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::Online_Library.Properties.Resources.Logo_Btec;
            this.pictureBox3.Location = new System.Drawing.Point(1074, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(201, 106);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 46;
            this.pictureBox3.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(558, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(129, 53);
            this.label7.TabIndex = 11;
            this.label7.Text = "Book";
            // 
            // dgv_Books
            // 
            this.dgv_Books.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Books.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Books.Location = new System.Drawing.Point(0, 182);
            this.dgv_Books.Name = "dgv_Books";
            this.dgv_Books.RowHeadersWidth = 51;
            this.dgv_Books.RowTemplate.Height = 24;
            this.dgv_Books.Size = new System.Drawing.Size(1275, 486);
            this.dgv_Books.TabIndex = 0;
            // 
            // tab_Reviews
            // 
            this.tab_Reviews.Controls.Add(this.button2);
            this.tab_Reviews.Controls.Add(this.label2);
            this.tab_Reviews.Controls.Add(this.lbl_Users1);
            this.tab_Reviews.Controls.Add(this.pictureBox7);
            this.tab_Reviews.Controls.Add(this.cbx_BookID_Review);
            this.tab_Reviews.Controls.Add(this.cbx_UsersID_Review);
            this.tab_Reviews.Controls.Add(this.lbl_Error_Comment);
            this.tab_Reviews.Controls.Add(this.tbx_Comment);
            this.tab_Reviews.Controls.Add(this.tbx_Rating);
            this.tab_Reviews.Controls.Add(this.tbx_Review_ID);
            this.tab_Reviews.Controls.Add(this.lbl_Comment);
            this.tab_Reviews.Controls.Add(this.lbl_Error_Rating);
            this.tab_Reviews.Controls.Add(this.lbl_Error_Review_ID);
            this.tab_Reviews.Controls.Add(this.btn_Cancel_Review);
            this.tab_Reviews.Controls.Add(this.btn_Delete_Review);
            this.tab_Reviews.Controls.Add(this.btn_Update_Review);
            this.tab_Reviews.Controls.Add(this.btn_Insert_Review);
            this.tab_Reviews.Controls.Add(this.lbl_Rating);
            this.tab_Reviews.Controls.Add(this.lbl_BookID_Review);
            this.tab_Reviews.Controls.Add(this.lbl_UsersID_Review);
            this.tab_Reviews.Controls.Add(this.lbl_Review_ID);
            this.tab_Reviews.Controls.Add(this.dgv_Reviews);
            this.tab_Reviews.Location = new System.Drawing.Point(4, 32);
            this.tab_Reviews.Name = "tab_Reviews";
            this.tab_Reviews.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Reviews.Size = new System.Drawing.Size(1275, 668);
            this.tab_Reviews.TabIndex = 20;
            this.tab_Reviews.Text = "Reviews";
            this.tab_Reviews.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(551, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 53);
            this.label2.TabIndex = 96;
            this.label2.Text = "Review";
            // 
            // lbl_Users1
            // 
            this.lbl_Users1.AutoSize = true;
            this.lbl_Users1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Users1.Location = new System.Drawing.Point(3, 3);
            this.lbl_Users1.Name = "lbl_Users1";
            this.lbl_Users1.Size = new System.Drawing.Size(104, 35);
            this.lbl_Users1.TabIndex = 95;
            this.lbl_Users1.Text = "Users :";
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::Online_Library.Properties.Resources.Logo_Btec;
            this.pictureBox7.Location = new System.Drawing.Point(1074, 0);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(201, 106);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 94;
            this.pictureBox7.TabStop = false;
            // 
            // cbx_BookID_Review
            // 
            this.cbx_BookID_Review.FormattingEnabled = true;
            this.cbx_BookID_Review.Location = new System.Drawing.Point(157, 256);
            this.cbx_BookID_Review.Name = "cbx_BookID_Review";
            this.cbx_BookID_Review.Size = new System.Drawing.Size(121, 31);
            this.cbx_BookID_Review.TabIndex = 93;
            // 
            // cbx_UsersID_Review
            // 
            this.cbx_UsersID_Review.FormattingEnabled = true;
            this.cbx_UsersID_Review.Location = new System.Drawing.Point(157, 181);
            this.cbx_UsersID_Review.Name = "cbx_UsersID_Review";
            this.cbx_UsersID_Review.Size = new System.Drawing.Size(121, 31);
            this.cbx_UsersID_Review.TabIndex = 92;
            // 
            // lbl_Error_Comment
            // 
            this.lbl_Error_Comment.AutoSize = true;
            this.lbl_Error_Comment.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Error_Comment.ForeColor = System.Drawing.Color.Red;
            this.lbl_Error_Comment.Location = new System.Drawing.Point(512, 218);
            this.lbl_Error_Comment.Name = "lbl_Error_Comment";
            this.lbl_Error_Comment.Size = new System.Drawing.Size(0, 15);
            this.lbl_Error_Comment.TabIndex = 88;
            // 
            // tbx_Comment
            // 
            this.tbx_Comment.Location = new System.Drawing.Point(515, 181);
            this.tbx_Comment.Multiline = true;
            this.tbx_Comment.Name = "tbx_Comment";
            this.tbx_Comment.Size = new System.Drawing.Size(165, 35);
            this.tbx_Comment.TabIndex = 87;
            // 
            // tbx_Rating
            // 
            this.tbx_Rating.Location = new System.Drawing.Point(515, 98);
            this.tbx_Rating.Multiline = true;
            this.tbx_Rating.Name = "tbx_Rating";
            this.tbx_Rating.Size = new System.Drawing.Size(165, 35);
            this.tbx_Rating.TabIndex = 79;
            // 
            // tbx_Review_ID
            // 
            this.tbx_Review_ID.Location = new System.Drawing.Point(157, 98);
            this.tbx_Review_ID.Multiline = true;
            this.tbx_Review_ID.Name = "tbx_Review_ID";
            this.tbx_Review_ID.Size = new System.Drawing.Size(111, 35);
            this.tbx_Review_ID.TabIndex = 78;
            // 
            // lbl_Comment
            // 
            this.lbl_Comment.AutoSize = true;
            this.lbl_Comment.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Comment.Location = new System.Drawing.Point(391, 191);
            this.lbl_Comment.Name = "lbl_Comment";
            this.lbl_Comment.Size = new System.Drawing.Size(111, 25);
            this.lbl_Comment.TabIndex = 86;
            this.lbl_Comment.Text = "Comment";
            // 
            // lbl_Error_Rating
            // 
            this.lbl_Error_Rating.AutoSize = true;
            this.lbl_Error_Rating.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Error_Rating.ForeColor = System.Drawing.Color.Red;
            this.lbl_Error_Rating.Location = new System.Drawing.Point(512, 135);
            this.lbl_Error_Rating.Name = "lbl_Error_Rating";
            this.lbl_Error_Rating.Size = new System.Drawing.Size(0, 15);
            this.lbl_Error_Rating.TabIndex = 85;
            // 
            // lbl_Error_Review_ID
            // 
            this.lbl_Error_Review_ID.AutoSize = true;
            this.lbl_Error_Review_ID.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Error_Review_ID.ForeColor = System.Drawing.Color.Red;
            this.lbl_Error_Review_ID.Location = new System.Drawing.Point(154, 136);
            this.lbl_Error_Review_ID.Name = "lbl_Error_Review_ID";
            this.lbl_Error_Review_ID.Size = new System.Drawing.Size(0, 15);
            this.lbl_Error_Review_ID.TabIndex = 84;
            // 
            // btn_Cancel_Review
            // 
            this.btn_Cancel_Review.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel_Review.Location = new System.Drawing.Point(1014, 317);
            this.btn_Cancel_Review.Name = "btn_Cancel_Review";
            this.btn_Cancel_Review.Size = new System.Drawing.Size(108, 35);
            this.btn_Cancel_Review.TabIndex = 83;
            this.btn_Cancel_Review.Text = "Cancel";
            this.btn_Cancel_Review.UseVisualStyleBackColor = true;
            this.btn_Cancel_Review.Click += new System.EventHandler(this.btn_Cancel_Review_Click);
            // 
            // btn_Delete_Review
            // 
            this.btn_Delete_Review.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Delete_Review.Location = new System.Drawing.Point(900, 317);
            this.btn_Delete_Review.Name = "btn_Delete_Review";
            this.btn_Delete_Review.Size = new System.Drawing.Size(108, 35);
            this.btn_Delete_Review.TabIndex = 82;
            this.btn_Delete_Review.Text = "Delete";
            this.btn_Delete_Review.UseVisualStyleBackColor = true;
            this.btn_Delete_Review.Click += new System.EventHandler(this.btn_Delete_Review_Click);
            // 
            // btn_Update_Review
            // 
            this.btn_Update_Review.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Update_Review.Location = new System.Drawing.Point(786, 317);
            this.btn_Update_Review.Name = "btn_Update_Review";
            this.btn_Update_Review.Size = new System.Drawing.Size(108, 35);
            this.btn_Update_Review.TabIndex = 81;
            this.btn_Update_Review.Text = "Update";
            this.btn_Update_Review.UseVisualStyleBackColor = true;
            this.btn_Update_Review.Click += new System.EventHandler(this.btn_Update_Review_Click_1);
            // 
            // btn_Insert_Review
            // 
            this.btn_Insert_Review.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Insert_Review.Location = new System.Drawing.Point(672, 317);
            this.btn_Insert_Review.Name = "btn_Insert_Review";
            this.btn_Insert_Review.Size = new System.Drawing.Size(108, 35);
            this.btn_Insert_Review.TabIndex = 80;
            this.btn_Insert_Review.Text = "Insert";
            this.btn_Insert_Review.UseVisualStyleBackColor = true;
            this.btn_Insert_Review.Click += new System.EventHandler(this.btn_Insert_Review_Click_1);
            // 
            // lbl_Rating
            // 
            this.lbl_Rating.AutoSize = true;
            this.lbl_Rating.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Rating.Location = new System.Drawing.Point(391, 108);
            this.lbl_Rating.Name = "lbl_Rating";
            this.lbl_Rating.Size = new System.Drawing.Size(79, 25);
            this.lbl_Rating.TabIndex = 77;
            this.lbl_Rating.Text = "Rating";
            // 
            // lbl_BookID_Review
            // 
            this.lbl_BookID_Review.AutoSize = true;
            this.lbl_BookID_Review.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_BookID_Review.Location = new System.Drawing.Point(22, 266);
            this.lbl_BookID_Review.Name = "lbl_BookID_Review";
            this.lbl_BookID_Review.Size = new System.Drawing.Size(96, 25);
            this.lbl_BookID_Review.TabIndex = 76;
            this.lbl_BookID_Review.Text = "Book ID";
            // 
            // lbl_UsersID_Review
            // 
            this.lbl_UsersID_Review.AutoSize = true;
            this.lbl_UsersID_Review.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_UsersID_Review.Location = new System.Drawing.Point(22, 191);
            this.lbl_UsersID_Review.Name = "lbl_UsersID_Review";
            this.lbl_UsersID_Review.Size = new System.Drawing.Size(100, 25);
            this.lbl_UsersID_Review.TabIndex = 75;
            this.lbl_UsersID_Review.Text = "Users ID";
            // 
            // lbl_Review_ID
            // 
            this.lbl_Review_ID.AutoSize = true;
            this.lbl_Review_ID.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Review_ID.Location = new System.Drawing.Point(22, 108);
            this.lbl_Review_ID.Name = "lbl_Review_ID";
            this.lbl_Review_ID.Size = new System.Drawing.Size(116, 25);
            this.lbl_Review_ID.TabIndex = 74;
            this.lbl_Review_ID.Text = "Review ID";
            // 
            // dgv_Reviews
            // 
            this.dgv_Reviews.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Reviews.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Reviews.Location = new System.Drawing.Point(0, 358);
            this.dgv_Reviews.Name = "dgv_Reviews";
            this.dgv_Reviews.RowHeadersWidth = 51;
            this.dgv_Reviews.RowTemplate.Height = 24;
            this.dgv_Reviews.Size = new System.Drawing.Size(1275, 310);
            this.dgv_Reviews.TabIndex = 73;
            this.dgv_Reviews.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Reviews_CellClick);
            // 
            // tab_Loans
            // 
            this.tab_Loans.Controls.Add(this.label3);
            this.tab_Loans.Controls.Add(this.lbl_Users3);
            this.tab_Loans.Controls.Add(this.pictureBox9);
            this.tab_Loans.Controls.Add(this.dgv_Loans);
            this.tab_Loans.Location = new System.Drawing.Point(4, 32);
            this.tab_Loans.Name = "tab_Loans";
            this.tab_Loans.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Loans.Size = new System.Drawing.Size(1275, 668);
            this.tab_Loans.TabIndex = 21;
            this.tab_Loans.Text = "Loans";
            this.tab_Loans.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(563, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 53);
            this.label3.TabIndex = 55;
            this.label3.Text = "Loans";
            // 
            // lbl_Users3
            // 
            this.lbl_Users3.AutoSize = true;
            this.lbl_Users3.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Users3.Location = new System.Drawing.Point(3, 3);
            this.lbl_Users3.Name = "lbl_Users3";
            this.lbl_Users3.Size = new System.Drawing.Size(104, 35);
            this.lbl_Users3.TabIndex = 54;
            this.lbl_Users3.Text = "Users :";
            // 
            // pictureBox9
            // 
            this.pictureBox9.Image = global::Online_Library.Properties.Resources.Logo_Btec;
            this.pictureBox9.Location = new System.Drawing.Point(1074, 0);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(201, 106);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox9.TabIndex = 53;
            this.pictureBox9.TabStop = false;
            // 
            // dgv_Loans
            // 
            this.dgv_Loans.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Loans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Loans.Location = new System.Drawing.Point(0, 162);
            this.dgv_Loans.Name = "dgv_Loans";
            this.dgv_Loans.RowHeadersWidth = 51;
            this.dgv_Loans.RowTemplate.Height = 24;
            this.dgv_Loans.Size = new System.Drawing.Size(1275, 506);
            this.dgv_Loans.TabIndex = 28;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(1161, 317);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 35);
            this.button2.TabIndex = 97;
            this.button2.Text = "Logout";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // View_Infor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 705);
            this.Controls.Add(this.tabControl);
            this.Name = "View_Infor";
            this.Text = "ViewProduct";
            this.Load += new System.EventHandler(this.View_Infor_Load);
            this.tabControl.ResumeLayout(false);
            this.tab_LibraryCards.ResumeLayout(false);
            this.tab_LibraryCards.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_LibraryCards)).EndInit();
            this.tab_Books.ResumeLayout(false);
            this.tab_Books.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Books)).EndInit();
            this.tab_Reviews.ResumeLayout(false);
            this.tab_Reviews.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Reviews)).EndInit();
            this.tab_Loans.ResumeLayout(false);
            this.tab_Loans.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Loans)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tab_LibraryCards;
        private System.Windows.Forms.Label lbl_Users2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgv_LibraryCards;
        private System.Windows.Forms.TabPage tab_Books;
        private System.Windows.Forms.Label lbl_Users;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgv_Books;
        private System.Windows.Forms.TabPage tab_Reviews;
        private System.Windows.Forms.Label lbl_Users1;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.ComboBox cbx_BookID_Review;
        private System.Windows.Forms.ComboBox cbx_UsersID_Review;
        private System.Windows.Forms.Label lbl_Error_Comment;
        private System.Windows.Forms.TextBox tbx_Comment;
        private System.Windows.Forms.TextBox tbx_Rating;
        private System.Windows.Forms.TextBox tbx_Review_ID;
        private System.Windows.Forms.Label lbl_Comment;
        private System.Windows.Forms.Label lbl_Error_Rating;
        private System.Windows.Forms.Label lbl_Error_Review_ID;
        private System.Windows.Forms.Button btn_Cancel_Review;
        private System.Windows.Forms.Button btn_Delete_Review;
        private System.Windows.Forms.Button btn_Update_Review;
        private System.Windows.Forms.Button btn_Insert_Review;
        private System.Windows.Forms.Label lbl_Rating;
        private System.Windows.Forms.Label lbl_BookID_Review;
        private System.Windows.Forms.Label lbl_UsersID_Review;
        private System.Windows.Forms.Label lbl_Review_ID;
        private System.Windows.Forms.DataGridView dgv_Reviews;
        private System.Windows.Forms.TabPage tab_Loans;
        private System.Windows.Forms.Label lbl_Users3;
        private System.Windows.Forms.PictureBox pictureBox9;
        private System.Windows.Forms.DataGridView dgv_Loans;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
    }
}