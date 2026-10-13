using System;
using System.Drawing;
using System.Windows.Forms;
using WIL__;

namespace WILL__
{
    public class PostOpportunityForm : Form
    {
        private readonly AuthenticatedUser user;
        private readonly OpportunitiesRepository repo = new OpportunitiesRepository();

        private TextBox txtTitle;
        private TextBox txtDescription;
        private ComboBox cmbCourse;
        private TextBox txtLocation;
        private ComboBox cmbIndustry;
        private DateTimePicker dtpClosing;
        private Button btnPost;
        private Button btnCancel;

        public PostOpportunityForm(AuthenticatedUser user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user));
            Initialize();
        }

        private void Initialize()
        {
            Text = "Post Opportunity";
            Size = new Size(700, 650);
            StartPosition = FormStartPosition.CenterParent;

            Label lbl = new Label { Text = "Title", Location = new Point(20, 20), Size = new Size(100, 24) };
            txtTitle = new TextBox { Location = new Point(20, 48), Size = new Size(620, 28) };

            Label lblDesc = new Label { Text = "Description", Location = new Point(20, 90), Size = new Size(100, 24) };
            txtDescription = new TextBox { Location = new Point(20, 118), Size = new Size(620, 200), Multiline = true, ScrollBars = ScrollBars.Vertical };

            Label lblCourse = new Label { Text = "Course", Location = new Point(20, 330), Size = new Size(100, 24) };
            cmbCourse = new ComboBox { Location = new Point(20, 358), Size = new Size(300, 28), DropDownStyle = ComboBoxStyle.DropDownList };
            cmbCourse.Items.AddRange(new object[] { "All Courses", "Electrical Engineering", "Civil Engineering", "Mechanical Engineering" });
            cmbCourse.SelectedIndex = 0;

            Label lblLocation = new Label { Text = "Location", Location = new Point(340, 330), Size = new Size(100, 24) };
            txtLocation = new TextBox { Location = new Point(340, 358), Size = new Size(300, 28) };

            Label lblIndustry = new Label { Text = "Industry", Location = new Point(20, 400), Size = new Size(100, 24) };
            cmbIndustry = new ComboBox { Location = new Point(20, 428), Size = new Size(300, 28), DropDownStyle = ComboBoxStyle.DropDownList };
            cmbIndustry.Items.AddRange(new object[] { "Information Technology", "Engineering", "Finance", "Other" });
            cmbIndustry.SelectedIndex = 0;

            Label lblClosing = new Label { Text = "Closing Date (optional)", Location = new Point(340, 400), Size = new Size(200, 24) };
            dtpClosing = new DateTimePicker { Location = new Point(340, 428), Size = new Size(300, 28), Format = DateTimePickerFormat.Short, ShowCheckBox = true };

            btnPost = new Button { Text = "Post Opportunity", Location = new Point(20, 500), Size = new Size(200, 36) };
            btnCancel = new Button { Text = "Cancel", Location = new Point(240, 500), Size = new Size(120, 36) };

            btnPost.Click += BtnPost_Click;
            btnCancel.Click += (s, e) => this.Close();

            Controls.Add(lbl);
            Controls.Add(txtTitle);
            Controls.Add(lblDesc);
            Controls.Add(txtDescription);
            Controls.Add(lblCourse);
            Controls.Add(cmbCourse);
            Controls.Add(lblLocation);
            Controls.Add(txtLocation);
            Controls.Add(lblIndustry);
            Controls.Add(cmbIndustry);
            Controls.Add(lblClosing);
            Controls.Add(dtpClosing);
            Controls.Add(btnPost);
            Controls.Add(btnCancel);
        }

        private void BtnPost_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Please enter a title.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return;
            }

            var opp = new Opportunity
            {
                UserID = user.UserID,
                Title = txtTitle.Text.Trim(),
                Description = txtDescription.Text.Trim(),
                Course = cmbCourse.SelectedItem?.ToString() ?? "",
                Location = txtLocation.Text.Trim(),
                Industry = cmbIndustry.SelectedItem?.ToString() ?? "",
                PostedAt = DateTime.Now,
                ClosingDate = dtpClosing.Checked ? dtpClosing.Value.Date : (DateTime?)null,
                IsActive = true
            };

            try
            {
                int id = repo.CreateOpportunity(opp);
                MessageBox.Show("Opportunity posted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to post opportunity: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
