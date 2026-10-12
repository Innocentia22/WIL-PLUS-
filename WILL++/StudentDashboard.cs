using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WILL__
{
    public partial class StudentDashboard : Form
    {
        public StudentDashboard()
        {
            InitializeComponent();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are already on the Dashboard.");
        }

        private void btnFindOpportunities_Click(object sender, EventArgs e)
        {
            FindOpportunitiesForms form = new FindOpportunitiesForms();
            form.Show();
        }

        private void btnMyApplications_Click(object sender, EventArgs e)
        {
            MessageBox.Show("My Applications page selected.");
        }

        private void btnMyProfile_Click(object sender, EventArgs e)
        {
            StudentProfileForm form = new StudentProfileForm();
            form.Show();
        }

        private void btnNotifications_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Notifications page selected.");
        }


        public partial class FindOpportunitiesForms : Form
        {
            private TextBox txtSearch;
            private ComboBox cmbCourse;
            private DataGridView dgvOpportunities;
            private Button btnSearch;
            private Button btnViewDetails;
            private Button btnBack;

            private DataTable opportunities;

            public FindOpportunitiesForms()
            {

                BuildForm();
                LoadOpportunities();
            }

            private void BuildForm()
            {
                Text = "WIL++ - Find Opportunities";
                Size = new Size(1000, 650);
                StartPosition = FormStartPosition.CenterScreen;
                BackColor = Color.White;

                Label title = new Label();
                title.Text = "Find WIL Opportunities";
                title.Font = new Font("Arial", 20, FontStyle.Bold);
                title.Location = new Point(30, 20);
                title.Size = new Size(500, 40);
                Controls.Add(title);

                Label searchLabel = new Label();
                searchLabel.Text = "Search company or position:";
                searchLabel.Location = new Point(30, 85);
                searchLabel.Size = new Size(200, 25);
                Controls.Add(searchLabel);

                txtSearch = new TextBox();
                txtSearch.Location = new Point(230, 82);
                txtSearch.Size = new Size(250, 30);
                Controls.Add(txtSearch);

                Label courseLabel = new Label();
                courseLabel.Text = "Course:";
                courseLabel.Location = new Point(510, 85);
                courseLabel.Size = new Size(60, 25);
                Controls.Add(courseLabel);

                cmbCourse = new ComboBox();
                cmbCourse.Location = new Point(575, 82);
                cmbCourse.Size = new Size(210, 30);
                cmbCourse.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbCourse.Items.AddRange(new object[]
                {
                "All Courses",
                "Electrical Engineering",
                "Civil Engineering",
                "Mechanical Engineering"
                });
                cmbCourse.SelectedIndex = 0;
                Controls.Add(cmbCourse);

                btnSearch = new Button();
                btnSearch.Text = "Search";
                btnSearch.Location = new Point(800, 80);
                btnSearch.Size = new Size(100, 32);
                btnSearch.Click += BtnSearch_Click;
                Controls.Add(btnSearch);

                dgvOpportunities = new DataGridView();
                dgvOpportunities.Location = new Point(30, 140);
                dgvOpportunities.Size = new Size(900, 350);
                dgvOpportunities.ReadOnly = true;
                dgvOpportunities.AllowUserToAddRows = false;
                dgvOpportunities.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;
                dgvOpportunities.MultiSelect = false;
                dgvOpportunities.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;
                Controls.Add(dgvOpportunities);

                btnViewDetails = new Button();
                btnViewDetails.Text = "View Details";
                btnViewDetails.Location = new Point(30, 515);
                btnViewDetails.Size = new Size(150, 40);
                btnViewDetails.Click += BtnViewDetails_Click;
                Controls.Add(btnViewDetails);

                btnBack = new Button();
                btnBack.Text = "Back to Dashboard";
                btnBack.Location = new Point(750, 515);
                btnBack.Size = new Size(180, 40);
                btnBack.Click += BtnBack_Click;
                Controls.Add(btnBack);
            }

            private void LoadOpportunities()
            {
                opportunities = new DataTable();

                opportunities.Columns.Add("Company");
                opportunities.Columns.Add("Position");
                opportunities.Columns.Add("Course");
                opportunities.Columns.Add("Closing Date");
                opportunities.Columns.Add("Location");
                opportunities.Columns.Add("Description");

                // Sample data for demonstration only.
                opportunities.Rows.Add(
                    "Example Electrical Ltd",
                    "Electrical Engineering Intern",
                    "Electrical Engineering",
                    "30/11/2026",
                    "East London",
                    "Practical electrical engineering workplace experience.");

                opportunities.Rows.Add(
                    "Example Civil Works",
                    "Civil Engineering Trainee",
                    "Civil Engineering",
                    "15/12/2026",
                    "East London",
                    "Civil construction and site experience.");

                opportunities.Rows.Add(
                    "Example Mechanical Services",
                    "Mechanical Engineering Intern",
                    "Mechanical Engineering",
                    "20/12/2026",
                    "Eastern Cape",
                    "Mechanical maintenance and workshop experience.");

                dgvOpportunities.DataSource = opportunities;

                // Hide the description from the main table.
                dgvOpportunities.Columns["Description"].Visible = false;
            }

            private void BtnSearch_Click(object sender, EventArgs e)
            {
                string search = txtSearch.Text.Trim().Replace("'", "''");
                string course = cmbCourse.SelectedItem.ToString()
                    .Replace("'", "''");

                string filter = "";

                if (!string.IsNullOrWhiteSpace(search))
                {
                    filter = "(Company LIKE '%" + search +
                             "%' OR Position LIKE '%" + search + "%')";
                }

                if (course != "All Courses")
                {
                    if (filter.Length > 0)
                        filter += " AND ";

                    filter += "Course = '" + course + "'";
                }

                opportunities.DefaultView.RowFilter = filter;
            }

            private void BtnViewDetails_Click(object sender, EventArgs e)
            {
                if (dgvOpportunities.SelectedRows.Count == 0)
                {
                    MessageBox.Show(
                        "Please select an opportunity first.",
                        "No Opportunity Selected",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                DataRowView selected =
                    (DataRowView)dgvOpportunities.SelectedRows[0].DataBoundItem;

                MessageBox.Show(
                    "Company: " + selected["Company"] +
                    "\nPosition: " + selected["Position"] +
                    "\nCourse: " + selected["Course"] +
                    "\nClosing Date: " + selected["Closing Date"] +
                    "\nLocation: " + selected["Location"] +
                    "\n\nDescription:\n" + selected["Description"],
                    "Opportunity Details",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            private void BtnBack_Click(object sender, EventArgs e)
            {
                Close();
            }
        }

        private void btnFindOpportunities_Click_1(object sender, EventArgs e)
        {
            FindOpportunitiesForms form = new FindOpportunitiesForms();
            form.Show();
        }

        private void btnMyApplications_Click_1(object sender, EventArgs e)
        {
            MyApplications form = new MyApplications();
            form.Show();
            this.Hide();
        }

        private void btnMyProfile_Click_1(object sender, EventArgs e)
        {
            StudentProfileForm form = new StudentProfileForm();
            form.Show();
            this.Hide();
        }
    }
}

    


    

