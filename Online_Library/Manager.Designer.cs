namespace Online_Library
{
    partial class Manager
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
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_Users1 = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.btn_Cancel_Review = new System.Windows.Forms.Button();
            this.btn_Delete_Review = new System.Windows.Forms.Button();
            this.dgv_Reviews = new System.Windows.Forms.DataGridView();
            this.lbl_Review_ID = new System.Windows.Forms.Label();
            this.lbl_UsersID_Review = new System.Windows.Forms.Label();
            this.lbl_BookID_Review = new System.Windows.Forms.Label();
            this.lbl_Rating = new System.Windows.Forms.Label();
            this.lbl_Error_Review_ID = new System.Windows.Forms.Label();
            this.lbl_Error_Rating = new System.Windows.Forms.Label();
            this.lbl_Comment = new System.Windows.Forms.Label();
            this.tbx_Review_ID = new System.Windows.Forms.TextBox();
            this.tbx_Rating = new System.Windows.Forms.TextBox();
            this.cbx_BookID_Review = new System.Windows.Forms.ComboBox();
            this.lbl_Error_Comment = new System.Windows.Forms.Label();
            this.cbx_UsersID_Review = new System.Windows.Forms.ComboBox();
            this.tbx_Comment = new System.Windows.Forms.TextBox();
            this.btn_Logout = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Reviews)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(556, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 53);
            this.label2.TabIndex = 117;
            this.label2.Text = "Review";
            // 
            // lbl_Users1
            // 
            this.lbl_Users1.AutoSize = true;
            this.lbl_Users1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Users1.Location = new System.Drawing.Point(3, 2);
            this.lbl_Users1.Name = "lbl_Users1";
            this.lbl_Users1.Size = new System.Drawing.Size(104, 35);
            this.lbl_Users1.TabIndex = 116;
            this.lbl_Users1.Text = "Users :";
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::Online_Library.Properties.Resources.Logo_Btec;
            this.pictureBox7.Location = new System.Drawing.Point(1074, 2);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(201, 106);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 115;
            this.pictureBox7.TabStop = false;
            // 
            // btn_Cancel_Review
            // 
            this.btn_Cancel_Review.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel_Review.Location = new System.Drawing.Point(986, 303);
            this.btn_Cancel_Review.Name = "btn_Cancel_Review";
            this.btn_Cancel_Review.Size = new System.Drawing.Size(108, 35);
            this.btn_Cancel_Review.TabIndex = 107;
            this.btn_Cancel_Review.Text = "Cancel";
            this.btn_Cancel_Review.UseVisualStyleBackColor = true;
            this.btn_Cancel_Review.Click += new System.EventHandler(this.btn_Cancel_Review_Click);
            // 
            // btn_Delete_Review
            // 
            this.btn_Delete_Review.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Delete_Review.Location = new System.Drawing.Point(872, 303);
            this.btn_Delete_Review.Name = "btn_Delete_Review";
            this.btn_Delete_Review.Size = new System.Drawing.Size(108, 35);
            this.btn_Delete_Review.TabIndex = 106;
            this.btn_Delete_Review.Text = "Delete";
            this.btn_Delete_Review.UseVisualStyleBackColor = true;
            this.btn_Delete_Review.Click += new System.EventHandler(this.btn_Delete_Review_Click);
            // 
            // dgv_Reviews
            // 
            this.dgv_Reviews.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Reviews.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Reviews.Location = new System.Drawing.Point(0, 344);
            this.dgv_Reviews.Name = "dgv_Reviews";
            this.dgv_Reviews.RowHeadersWidth = 51;
            this.dgv_Reviews.RowTemplate.Height = 24;
            this.dgv_Reviews.Size = new System.Drawing.Size(1275, 388);
            this.dgv_Reviews.TabIndex = 97;
            this.dgv_Reviews.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Reviews_CellClick);
            // 
            // lbl_Review_ID
            // 
            this.lbl_Review_ID.AutoSize = true;
            this.lbl_Review_ID.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Review_ID.Location = new System.Drawing.Point(21, 113);
            this.lbl_Review_ID.Name = "lbl_Review_ID";
            this.lbl_Review_ID.Size = new System.Drawing.Size(116, 25);
            this.lbl_Review_ID.TabIndex = 98;
            this.lbl_Review_ID.Text = "Review ID";
            // 
            // lbl_UsersID_Review
            // 
            this.lbl_UsersID_Review.AutoSize = true;
            this.lbl_UsersID_Review.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_UsersID_Review.Location = new System.Drawing.Point(21, 196);
            this.lbl_UsersID_Review.Name = "lbl_UsersID_Review";
            this.lbl_UsersID_Review.Size = new System.Drawing.Size(100, 25);
            this.lbl_UsersID_Review.TabIndex = 99;
            this.lbl_UsersID_Review.Text = "Users ID";
            // 
            // lbl_BookID_Review
            // 
            this.lbl_BookID_Review.AutoSize = true;
            this.lbl_BookID_Review.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_BookID_Review.Location = new System.Drawing.Point(21, 271);
            this.lbl_BookID_Review.Name = "lbl_BookID_Review";
            this.lbl_BookID_Review.Size = new System.Drawing.Size(96, 25);
            this.lbl_BookID_Review.TabIndex = 100;
            this.lbl_BookID_Review.Text = "Book ID";
            // 
            // lbl_Rating
            // 
            this.lbl_Rating.AutoSize = true;
            this.lbl_Rating.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Rating.Location = new System.Drawing.Point(421, 113);
            this.lbl_Rating.Name = "lbl_Rating";
            this.lbl_Rating.Size = new System.Drawing.Size(79, 25);
            this.lbl_Rating.TabIndex = 101;
            this.lbl_Rating.Text = "Rating";
            // 
            // lbl_Error_Review_ID
            // 
            this.lbl_Error_Review_ID.AutoSize = true;
            this.lbl_Error_Review_ID.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Error_Review_ID.ForeColor = System.Drawing.Color.Red;
            this.lbl_Error_Review_ID.Location = new System.Drawing.Point(153, 141);
            this.lbl_Error_Review_ID.Name = "lbl_Error_Review_ID";
            this.lbl_Error_Review_ID.Size = new System.Drawing.Size(0, 15);
            this.lbl_Error_Review_ID.TabIndex = 108;
            // 
            // lbl_Error_Rating
            // 
            this.lbl_Error_Rating.AutoSize = true;
            this.lbl_Error_Rating.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Error_Rating.ForeColor = System.Drawing.Color.Red;
            this.lbl_Error_Rating.Location = new System.Drawing.Point(542, 140);
            this.lbl_Error_Rating.Name = "lbl_Error_Rating";
            this.lbl_Error_Rating.Size = new System.Drawing.Size(0, 15);
            this.lbl_Error_Rating.TabIndex = 109;
            // 
            // lbl_Comment
            // 
            this.lbl_Comment.AutoSize = true;
            this.lbl_Comment.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Comment.Location = new System.Drawing.Point(421, 196);
            this.lbl_Comment.Name = "lbl_Comment";
            this.lbl_Comment.Size = new System.Drawing.Size(111, 25);
            this.lbl_Comment.TabIndex = 110;
            this.lbl_Comment.Text = "Comment";
            // 
            // tbx_Review_ID
            // 
            this.tbx_Review_ID.Location = new System.Drawing.Point(156, 103);
            this.tbx_Review_ID.Multiline = true;
            this.tbx_Review_ID.Name = "tbx_Review_ID";
            this.tbx_Review_ID.Size = new System.Drawing.Size(111, 35);
            this.tbx_Review_ID.TabIndex = 102;
            // 
            // tbx_Rating
            // 
            this.tbx_Rating.Location = new System.Drawing.Point(545, 103);
            this.tbx_Rating.Multiline = true;
            this.tbx_Rating.Name = "tbx_Rating";
            this.tbx_Rating.Size = new System.Drawing.Size(165, 35);
            this.tbx_Rating.TabIndex = 103;
            // 
            // cbx_BookID_Review
            // 
            this.cbx_BookID_Review.FormattingEnabled = true;
            this.cbx_BookID_Review.Location = new System.Drawing.Point(156, 272);
            this.cbx_BookID_Review.Name = "cbx_BookID_Review";
            this.cbx_BookID_Review.Size = new System.Drawing.Size(126, 24);
            this.cbx_BookID_Review.TabIndex = 114;
            // 
            // lbl_Error_Comment
            // 
            this.lbl_Error_Comment.AutoSize = true;
            this.lbl_Error_Comment.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Error_Comment.ForeColor = System.Drawing.Color.Red;
            this.lbl_Error_Comment.Location = new System.Drawing.Point(542, 223);
            this.lbl_Error_Comment.Name = "lbl_Error_Comment";
            this.lbl_Error_Comment.Size = new System.Drawing.Size(0, 15);
            this.lbl_Error_Comment.TabIndex = 112;
            // 
            // cbx_UsersID_Review
            // 
            this.cbx_UsersID_Review.FormattingEnabled = true;
            this.cbx_UsersID_Review.Location = new System.Drawing.Point(156, 196);
            this.cbx_UsersID_Review.Name = "cbx_UsersID_Review";
            this.cbx_UsersID_Review.Size = new System.Drawing.Size(121, 24);
            this.cbx_UsersID_Review.TabIndex = 113;
            // 
            // tbx_Comment
            // 
            this.tbx_Comment.Location = new System.Drawing.Point(545, 186);
            this.tbx_Comment.Multiline = true;
            this.tbx_Comment.Name = "tbx_Comment";
            this.tbx_Comment.Size = new System.Drawing.Size(165, 35);
            this.tbx_Comment.TabIndex = 111;
            // 
            // btn_Logout
            // 
            this.btn_Logout.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Logout.Location = new System.Drawing.Point(1155, 303);
            this.btn_Logout.Name = "btn_Logout";
            this.btn_Logout.Size = new System.Drawing.Size(108, 35);
            this.btn_Logout.TabIndex = 118;
            this.btn_Logout.Text = "Logout";
            this.btn_Logout.UseVisualStyleBackColor = true;
            this.btn_Logout.Click += new System.EventHandler(this.btn_Logout_Click);
            // 
            // Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1275, 732);
            this.Controls.Add(this.btn_Logout);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_Users1);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.cbx_BookID_Review);
            this.Controls.Add(this.cbx_UsersID_Review);
            this.Controls.Add(this.lbl_Error_Comment);
            this.Controls.Add(this.tbx_Comment);
            this.Controls.Add(this.tbx_Rating);
            this.Controls.Add(this.tbx_Review_ID);
            this.Controls.Add(this.lbl_Comment);
            this.Controls.Add(this.lbl_Error_Rating);
            this.Controls.Add(this.lbl_Error_Review_ID);
            this.Controls.Add(this.btn_Cancel_Review);
            this.Controls.Add(this.btn_Delete_Review);
            this.Controls.Add(this.lbl_Rating);
            this.Controls.Add(this.lbl_BookID_Review);
            this.Controls.Add(this.lbl_UsersID_Review);
            this.Controls.Add(this.lbl_Review_ID);
            this.Controls.Add(this.dgv_Reviews);
            this.Name = "Manager";
            this.Text = "Manager";
            this.Load += new System.EventHandler(this.Manager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Reviews)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_Users1;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Button btn_Cancel_Review;
        private System.Windows.Forms.Button btn_Delete_Review;
        private System.Windows.Forms.DataGridView dgv_Reviews;
        private System.Windows.Forms.Label lbl_Review_ID;
        private System.Windows.Forms.Label lbl_UsersID_Review;
        private System.Windows.Forms.Label lbl_BookID_Review;
        private System.Windows.Forms.Label lbl_Rating;
        private System.Windows.Forms.Label lbl_Error_Review_ID;
        private System.Windows.Forms.Label lbl_Error_Rating;
        private System.Windows.Forms.Label lbl_Comment;
        private System.Windows.Forms.TextBox tbx_Review_ID;
        private System.Windows.Forms.TextBox tbx_Rating;
        private System.Windows.Forms.ComboBox cbx_BookID_Review;
        private System.Windows.Forms.Label lbl_Error_Comment;
        private System.Windows.Forms.ComboBox cbx_UsersID_Review;
        private System.Windows.Forms.TextBox tbx_Comment;
        private System.Windows.Forms.Button btn_Logout;
    }
}