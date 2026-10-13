using System;
using System.Drawing;
using System.Windows.Forms;
using WIL__;

namespace WILL__
{
    public class CompanyDashboard : Form
    {
        private readonly AuthenticatedUser user;
        private readonly OpportunitiesRepository repo = new OpportunitiesRepository();

        private DataGridView dgvOpportunities;
        private Button btnPostOpportunity;
        private Button btnManageProfile;
        private Button btnRefresh;
        private Button btnLogout;

        public CompanyDashboard(AuthenticatedUser user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user));
            Initialize();
            LoadOpportunities();
        }

        private void Initialize()
        {
            Text = "Company Dashboard - WIL++";
            Size = new Size(1000, 650);
            StartPosition = FormStartPosition.CenterScreen;

            Label title = new Label();
            title.Text = "Company Dashboard";
            title.Font = new Font("Arial", 20, FontStyle.Bold);
            title.Location = new Point(20, 20);
            title.Size = new Size(400, 40);
            Controls.Add(title);

            btnPostOpportunity = new Button();
            btnPostOpportunity.Text = "Post Opportunity";
            btnPostOpportunity.Location = new Point(20, 80);
            btnPostOpportunity.Size = new Size(140, 36);
            btnPostOpportunity.Click += BtnPostOpportunity_Click;
            Controls.Add(btnPostOpportunity);

            btnManageProfile = new Button();
            btnManageProfile.Text = "Manage Profile";
            btnManageProfile.Location = new Point(180, 80);
            btnManageProfile.Size = new Size(140, 36);
            btnManageProfile.Click += BtnManageProfile_Click;
            Controls.Add(btnManageProfile);

            btnRefresh = new Button();
            btnRefresh.Text = "Refresh";
            btnRefresh.Location = new Point(340, 80);
            btnRefresh.Size = new Size(100, 36);
            btnRefresh.Click += (s, e) => LoadOpportunities();
            Controls.Add(btnRefresh);

            btnLogout = new Button();
            btnLogout.Text = "Logout";
            btnLogout.Location = new Point(820, 20);
            btnLogout.Size = new Size(120, 34);
            btnLogout.Click += BtnLogout_Click;
            Controls.Add(btnLogout);

            dgvOpportunities = new DataGridView();
            dgvOpportunities.Location = new Point(20, 140);
            dgvOpportunities.Size = new Size(940, 440);
            dgvOpportunities.ReadOnly = true;
            dgvOpportunities.AllowUserToAddRows = false;
            dgvOpportunities.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOpportunities.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Controls.Add(dgvOpportunities);

            dgvOpportunities.DoubleClick += DgvOpportunities_DoubleClick;
        }

        private void LoadOpportunities()
        {
            try
            {
                var list = repo.GetByCompanyUserId(user.UserID);
                // Convert to a BindingSource to support refresh and proper binding
                var bs = new BindingSource();
                bs.DataSource = list;
                dgvOpportunities.DataSource = bs;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load opportunities: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvOpportunities_DoubleClick(object sender, EventArgs e)
        {
            if (dgvOpportunities.CurrentRow == null) return;

            var opp = dgvOpportunities.CurrentRow.DataBoundItem as Opportunity;
            if (opp == null) return;

            MessageBox.Show($"{opp.Title}\n\n{opp.Description}", "Opportunity Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnPostOpportunity_Click(object sender, EventArgs e)
        {
            var form = new PostOpportunityForm(user);
            form.FormClosed += (s, args) => LoadOpportunities();
            form.ShowDialog(this);
        }

        private void BtnManageProfile_Click(object sender, EventArgs e)
        {
            var form = new CompanyProfileForm(user);
            form.FormClosed += (s, args) => { /* optionally refresh */ };
            form.ShowDialog(this);
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            var login = new LoginForm();
            login.Show();
            this.Close();
        }
    }
}
