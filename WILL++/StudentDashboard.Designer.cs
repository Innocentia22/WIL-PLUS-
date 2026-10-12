namespace WILL__
{
    partial class StudentDashboard
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pnlSidebar = new Panel();
            label10 = new Label();
            btnLogout = new Button();
            btnNotifications = new Button();
            btnMyProfile = new Button();
            btnMyApplications = new Button();
            btnFindOpportunities = new Button();
            btnDashboard = new Button();
            label1 = new Label();
            pnlSubmitted = new Panel();
            panel1 = new Panel();
            dvgOpportunities = new DataGridView();
            Company = new DataGridViewTextBoxColumn();
            Opportunity = new DataGridViewTextBoxColumn();
            Type = new DataGridViewTextBoxColumn();
            ClosingDate = new DataGridViewTextBoxColumn();
            Action = new DataGridViewButtonColumn();
            label9 = new Label();
            btnBrowse = new Button();
            label8 = new Label();
            pnlOffers = new Panel();
            label7 = new Label();
            pnlReview = new Panel();
            label6 = new Label();
            panel2 = new Panel();
            label5 = new Label();
            pnlAvailable = new Panel();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            pnlSidebar.SuspendLayout();
            pnlSubmitted.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dvgOpportunities).BeginInit();
            pnlOffers.SuspendLayout();
            pnlReview.SuspendLayout();
            panel2.SuspendLayout();
            pnlAvailable.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(8, 33, 61);
            pnlSidebar.Controls.Add(label10);
            pnlSidebar.Controls.Add(btnLogout);
            pnlSidebar.Controls.Add(btnNotifications);
            pnlSidebar.Controls.Add(btnMyProfile);
            pnlSidebar.Controls.Add(btnMyApplications);
            pnlSidebar.Controls.Add(btnFindOpportunities);
            pnlSidebar.Controls.Add(btnDashboard);
            pnlSidebar.Controls.Add(label1);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Margin = new Padding(3, 4, 3, 4);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(457, 881);
            pnlSidebar.TabIndex = 0;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 42F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.White;
            label10.Location = new Point(67, 12);
            label10.Name = "label10";
            label10.Size = new Size(269, 93);
            label10.TabIndex = 6;
            label10.Text = "WIL++";
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.FromArgb(22, 119, 255);
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(23, 811);
            btnLogout.Margin = new Padding(3, 4, 3, 4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(360, 43);
            btnLogout.TabIndex = 5;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // btnNotifications
            // 
            btnNotifications.BackColor = Color.FromArgb(22, 119, 255);
            btnNotifications.FlatStyle = FlatStyle.Flat;
            btnNotifications.ForeColor = Color.White;
            btnNotifications.Location = new Point(23, 557);
            btnNotifications.Margin = new Padding(3, 4, 3, 4);
            btnNotifications.Name = "btnNotifications";
            btnNotifications.Size = new Size(360, 43);
            btnNotifications.TabIndex = 2;
            btnNotifications.Text = "Notifications";
            btnNotifications.UseVisualStyleBackColor = false;
            // 
            // btnMyProfile
            // 
            btnMyProfile.BackColor = Color.FromArgb(22, 119, 255);
            btnMyProfile.FlatStyle = FlatStyle.Flat;
            btnMyProfile.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnMyProfile.ForeColor = Color.White;
            btnMyProfile.Location = new Point(23, 468);
            btnMyProfile.Margin = new Padding(3, 4, 3, 4);
            btnMyProfile.Name = "btnMyProfile";
            btnMyProfile.Size = new Size(360, 43);
            btnMyProfile.TabIndex = 1;
            btnMyProfile.Text = "My Profile";
            btnMyProfile.UseVisualStyleBackColor = false;
            btnMyProfile.Click += btnMyProfile_Click_1;
            // 
            // btnMyApplications
            // 
            btnMyApplications.BackColor = Color.FromArgb(22, 119, 255);
            btnMyApplications.FlatStyle = FlatStyle.Flat;
            btnMyApplications.ForeColor = Color.White;
            btnMyApplications.Location = new Point(23, 381);
            btnMyApplications.Margin = new Padding(3, 4, 3, 4);
            btnMyApplications.Name = "btnMyApplications";
            btnMyApplications.Size = new Size(360, 43);
            btnMyApplications.TabIndex = 1;
            btnMyApplications.Text = "My Applications";
            btnMyApplications.UseVisualStyleBackColor = false;
            btnMyApplications.Click += btnMyApplications_Click_1;
            // 
            // btnFindOpportunities
            // 
            btnFindOpportunities.BackColor = Color.FromArgb(22, 119, 255);
            btnFindOpportunities.FlatStyle = FlatStyle.Flat;
            btnFindOpportunities.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnFindOpportunities.ForeColor = Color.White;
            btnFindOpportunities.Location = new Point(23, 289);
            btnFindOpportunities.Margin = new Padding(3, 4, 3, 4);
            btnFindOpportunities.Name = "btnFindOpportunities";
            btnFindOpportunities.Size = new Size(360, 43);
            btnFindOpportunities.TabIndex = 1;
            btnFindOpportunities.Text = "Find Opportunities";
            btnFindOpportunities.UseVisualStyleBackColor = false;
            btnFindOpportunities.Click += btnFindOpportunities_Click_1;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = Color.FromArgb(22, 119, 255);
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDashboard.ForeColor = Color.DarkBlue;
            btnDashboard.Location = new Point(23, 200);
            btnDashboard.Margin = new Padding(3, 4, 3, 4);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(360, 43);
            btnDashboard.TabIndex = 1;
            btnDashboard.Text = "Dashboard";
            btnDashboard.UseVisualStyleBackColor = false;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(8, 33, 61);
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(67, 127);
            label1.Name = "label1";
            label1.Size = new Size(143, 69);
            label1.TabIndex = 1;
            label1.Text = "Work-Intergrated \r\nLearning Plus\r\n\r\n";
            // 
            // pnlSubmitted
            // 
            pnlSubmitted.BackColor = Color.FromArgb(245, 247, 250);
            pnlSubmitted.Controls.Add(panel1);
            pnlSubmitted.Controls.Add(pnlOffers);
            pnlSubmitted.Controls.Add(pnlReview);
            pnlSubmitted.Controls.Add(panel2);
            pnlSubmitted.Controls.Add(pnlAvailable);
            pnlSubmitted.Controls.Add(label3);
            pnlSubmitted.Controls.Add(label2);
            pnlSubmitted.Dock = DockStyle.Fill;
            pnlSubmitted.Location = new Point(457, 0);
            pnlSubmitted.Margin = new Padding(3, 4, 3, 4);
            pnlSubmitted.Name = "pnlSubmitted";
            pnlSubmitted.Size = new Size(896, 881);
            pnlSubmitted.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(dvgOpportunities);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(btnBrowse);
            panel1.Controls.Add(label8);
            panel1.Location = new Point(32, 436);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(841, 417);
            panel1.TabIndex = 6;
            // 
            // dvgOpportunities
            // 
            dvgOpportunities.AllowUserToAddRows = false;
            dvgOpportunities.AllowUserToResizeRows = false;
            dvgOpportunities.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dvgOpportunities.BackgroundColor = Color.White;
            dvgOpportunities.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(8, 33, 61);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dvgOpportunities.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dvgOpportunities.ColumnHeadersHeight = 40;
            dvgOpportunities.Columns.AddRange(new DataGridViewColumn[] { Company, Opportunity, Type, ClosingDate, Action });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(23, 32, 51);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(232, 241, 255);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(23, 32, 51);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dvgOpportunities.DefaultCellStyle = dataGridViewCellStyle2;
            dvgOpportunities.GridColor = Color.FromArgb(229, 231, 235);
            dvgOpportunities.Location = new Point(43, 204);
            dvgOpportunities.Margin = new Padding(3, 4, 3, 4);
            dvgOpportunities.Name = "dvgOpportunities";
            dvgOpportunities.ReadOnly = true;
            dvgOpportunities.RowHeadersWidth = 51;
            dvgOpportunities.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dvgOpportunities.RowTemplate.Height = 42;
            dvgOpportunities.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dvgOpportunities.Size = new Size(767, 187);
            dvgOpportunities.TabIndex = 9;
            // 
            // Company
            // 
            Company.HeaderText = "Company";
            Company.MinimumWidth = 6;
            Company.Name = "Company";
            Company.ReadOnly = true;
            Company.Width = 120;
            // 
            // Opportunity
            // 
            Opportunity.HeaderText = "Opportunity";
            Opportunity.MinimumWidth = 6;
            Opportunity.Name = "Opportunity";
            Opportunity.ReadOnly = true;
            Opportunity.Width = 200;
            // 
            // Type
            // 
            Type.HeaderText = "Type";
            Type.MinimumWidth = 6;
            Type.Name = "Type";
            Type.ReadOnly = true;
            Type.Width = 125;
            // 
            // ClosingDate
            // 
            ClosingDate.HeaderText = "Closing Date";
            ClosingDate.MinimumWidth = 6;
            ClosingDate.Name = "ClosingDate";
            ClosingDate.ReadOnly = true;
            ClosingDate.Width = 125;
            // 
            // Action
            // 
            Action.HeaderText = "Action";
            Action.MinimumWidth = 6;
            Action.Name = "Action";
            Action.ReadOnly = true;
            Action.Resizable = DataGridViewTriState.True;
            Action.SortMode = DataGridViewColumnSortMode.Automatic;
            Action.Text = "APPLY";
            Action.UseColumnTextForButtonValue = true;
            Action.Width = 90;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(43, 131);
            label9.Name = "label9";
            label9.Size = new Size(241, 32);
            label9.TabIndex = 8;
            label9.Text = "Latest Opportunites";
            // 
            // btnBrowse
            // 
            btnBrowse.BackColor = Color.FromArgb(22, 119, 255);
            btnBrowse.FlatStyle = FlatStyle.Flat;
            btnBrowse.ForeColor = Color.White;
            btnBrowse.Location = new Point(325, 100);
            btnBrowse.Margin = new Padding(3, 4, 3, 4);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(190, 43);
            btnBrowse.TabIndex = 7;
            btnBrowse.Text = "Browse Opportunites";
            btnBrowse.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(286, 19);
            label8.Name = "label8";
            label8.Size = new Size(316, 100);
            label8.TabIndex = 0;
            label8.Text = "YOUR ENGINEERING FUTURE STARTS HERE\r\n\r\nFind opportunities. Gain experience. Grow.\r\n\r\n\r\n";
            // 
            // pnlOffers
            // 
            pnlOffers.Controls.Add(label7);
            pnlOffers.Location = new Point(671, 239);
            pnlOffers.Margin = new Padding(3, 4, 3, 4);
            pnlOffers.Name = "pnlOffers";
            pnlOffers.Size = new Size(166, 93);
            pnlOffers.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(45, 23);
            label7.Name = "label7";
            label7.Size = new Size(122, 40);
            label7.TabIndex = 0;
            label7.Text = "2\r\nOffers Accepted";
            // 
            // pnlReview
            // 
            pnlReview.Controls.Add(label6);
            pnlReview.Location = new Point(470, 239);
            pnlReview.Margin = new Padding(3, 4, 3, 4);
            pnlReview.Name = "pnlReview";
            pnlReview.Size = new Size(163, 93);
            pnlReview.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(19, 23);
            label6.Name = "label6";
            label6.Size = new Size(106, 40);
            label6.TabIndex = 0;
            label6.Text = "3\r\nUnder Review\r\n";
            // 
            // panel2
            // 
            panel2.Controls.Add(label5);
            panel2.Location = new Point(254, 239);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(187, 93);
            panel2.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(14, 23);
            label5.Name = "label5";
            label5.Size = new Size(173, 40);
            label5.TabIndex = 0;
            label5.Text = "5\r\nApplications Submitted\r\n";
            // 
            // pnlAvailable
            // 
            pnlAvailable.Controls.Add(label4);
            pnlAvailable.Location = new Point(32, 239);
            pnlAvailable.Margin = new Padding(3, 4, 3, 4);
            pnlAvailable.Name = "pnlAvailable";
            pnlAvailable.Size = new Size(190, 93);
            pnlAvailable.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(9, 23);
            label4.Name = "label4";
            label4.Size = new Size(174, 40);
            label4.TabIndex = 0;
            label4.Text = "24 \r\nAvailable Opportunities\r\n";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Gray;
            label3.Location = new Point(394, 123);
            label3.Name = "label3";
            label3.Size = new Size(238, 56);
            label3.TabIndex = 1;
            label3.Text = "Find opportunities and \r\nmanage your WIL journey\r\n";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(15, 23, 32, 51);
            label2.Location = new Point(305, 33);
            label2.Name = "label2";
            label2.Size = new Size(469, 50);
            label2.TabIndex = 0;
            label2.Text = "Welcome back, Manyano ";
            // 
            // StudentDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1353, 881);
            Controls.Add(pnlSubmitted);
            Controls.Add(pnlSidebar);
            ForeColor = Color.FromArgb(23, 32, 51);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "StudentDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "StudentDashboard-WIL++";
            pnlSidebar.ResumeLayout(false);
            pnlSidebar.PerformLayout();
            pnlSubmitted.ResumeLayout(false);
            pnlSubmitted.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dvgOpportunities).EndInit();
            pnlOffers.ResumeLayout(false);
            pnlOffers.PerformLayout();
            pnlReview.ResumeLayout(false);
            pnlReview.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            pnlAvailable.ResumeLayout(false);
            pnlAvailable.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSidebar;
        private Label label1;
        private Button btnDashboard;
        private Button btnFindOpportunities;
        private Button btnMyProfile;
        private Button btnMyApplications;
        private Panel pnlSubmitted;
        private Label label3;
        private Label label2;
        private Panel panel2;
        private Panel pnlAvailable;
        private Label label4;
        private Panel pnlReview;
        private Label label5;
        private Panel panel1;
        private Label label8;
        private Panel pnlOffers;
        private Label label7;
        private Label label6;
        private Button btnNotifications;
        private Button btnLogout;
        private Button btnBrowse;
        private DataGridView dvgOpportunities;
        private Label label9;
        private DataGridViewTextBoxColumn Company;
        private DataGridViewTextBoxColumn Opportunity;
        private DataGridViewTextBoxColumn Type;
        private DataGridViewTextBoxColumn ClosingDate;
        private DataGridViewButtonColumn Action;
        private Label label10;
    }
}