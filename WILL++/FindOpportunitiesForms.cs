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
    public partial class FindOpportunitiesForms : Form
    {
        private readonly WIL__.AuthenticatedUser studentUser;

        public FindOpportunitiesForms()
        {
            InitializeComponent();
            SetupOpportunities();
        }

        public FindOpportunitiesForms(WIL__.AuthenticatedUser user) : this()
        {
            this.studentUser = user;
        }


        // Use the repository Opportunity model when loading from DB
        private List<WIL__.Opportunity> opportunities = new List<WIL__.Opportunity>();
        // Track opportunities the student has already applied to for immediate UI feedback
        private System.Collections.Generic.HashSet<int> appliedOpportunityIds = new System.Collections.Generic.HashSet<int>();

        private void SetupOpportunities()
        {
            // Search and filter defaults
            cmbDiscipline.Items.Clear();
            cmbDiscipline.Items.AddRange(new object[]
            {
        "All Disciplines",
        "Electrical Engineering",
        "Civil Engineering",
        "Mechanical Engineering"
            });
            cmbDiscipline.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDiscipline.SelectedIndex = 0;

            cmbType.Items.Clear();
            cmbType.Items.AddRange(new object[]
            {
        "All Types",
        "WIL",
        "In-Service Training"
            });
            cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbType.SelectedIndex = 0;

            cmbLocation.Items.Clear();
            cmbLocation.Items.AddRange(new object[]
            {
        "All Locations",
        "East London",
        "Mthatha",
        "Gqeberha",
        "Cape Town",
        "Johannesburg",
        "Durban"
            });
            cmbLocation.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbLocation.SelectedIndex = 0;

            txtSearch.TextChanged += (s, e) => DisplayOpportunities();
            cmbDiscipline.SelectedIndexChanged +=
                (s, e) => DisplayOpportunities();
            cmbType.SelectedIndexChanged +=
                (s, e) => DisplayOpportunities();
            cmbLocation.SelectedIndexChanged +=
                (s, e) => DisplayOpportunities();

            LoadOpportunityData();
            DisplayOpportunities();
        }

        private void LoadOpportunityData()
        {
            opportunities.Clear();

            // Load active opportunities from the database
            var repo = new WIL__.OpportunitiesRepository();
            try
            {
                opportunities = repo.GetAllActive();

                // If a student is logged in, load their existing applications for UI state
                appliedOpportunityIds.Clear();
                if (studentUser != null)
                {
                    var appsRepo = new WIL__.ApplicationsRepository();
                    var apps = appsRepo.GetByStudentUserId(studentUser.UserID);
                    if (apps != null)
                    {
                        foreach (var a in apps)
                        {
                            appliedOpportunityIds.Add(a.OpportunityID);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load opportunities: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                opportunities = new List<WIL__.Opportunity>();
            }
        }

        private void DisplayOpportunities()
        {
            string search = txtSearch.Text.Trim();

            string discipline =
                cmbDiscipline.SelectedItem?.ToString() ?? "All Disciplines";

            string type =
                cmbType.SelectedItem?.ToString() ?? "All Types";

            string location =
                cmbLocation.SelectedItem?.ToString() ?? "All Locations";

            var results = opportunities.Where(o =>
                (string.IsNullOrWhiteSpace(search) ||
                 (o.Title ?? "").IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0 ||
                 (o.Description ?? "").IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0) &&

                (discipline == "All Disciplines" || string.IsNullOrWhiteSpace(o.Course) || o.Course == discipline) &&

                (type == "All Types" || string.IsNullOrWhiteSpace(o.Industry) || o.Industry == type) &&

                (location == "All Locations" || string.IsNullOrWhiteSpace(o.Location) || o.Location == location)
            ).ToList();

            flowLayoutPanelOpportunities.SuspendLayout();
            flowLayoutPanelOpportunities.Controls.Clear();

            foreach (WIL__.Opportunity opportunity in results)
            {
                var card = CreateOpportunityCard(opportunity);
                flowLayoutPanelOpportunities.Controls.Add(card);
            }

            if (results.Count == 0)
            {
                Label noResults = new Label
                {
                    Text = "No opportunities match your search.",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 11, FontStyle.Regular),
                    Margin = new Padding(15)
                };

                flowLayoutPanelOpportunities.Controls.Add(noResults);
            }

            flowLayoutPanelOpportunities.ResumeLayout();
        }

        private Panel CreateOpportunityCard(WIL__.Opportunity opportunity)
        {
            Panel card = new Panel
            {
                Width = Math.Max(
                    300, flowLayoutPanelOpportunities.ClientSize.Width - 35),
                Height = 145,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                Margin = new Padding(5, 5, 5, 10),
                Padding = new Padding(10)
            };

            // Resolve company name from UserID when possible
            string companyName = "Company";
            try
            {
                var auth = new WIL__.AuthRepository();
                var profile = auth.GetCompanyByUserId(opportunity.UserID);
                if (profile != null && !string.IsNullOrWhiteSpace(profile.CompanyName))
                    companyName = profile.CompanyName;
                else
                    companyName = "Company #" + opportunity.UserID;
            }
            catch { /* ignore profile lookup errors */ }

            Label company = new Label
            {
                Text = companyName,
                Location = new Point(12, 10),
                AutoSize = true,
                Font = new Font("Segoe UI", 11, FontStyle.Bold)
            };

            Label position = new Label
            {
                Text = opportunity.Title,
                Location = new Point(12, 35),
                AutoSize = true
            };

            // Build details from available fields
            var parts = new List<string>();
            if (!string.IsNullOrWhiteSpace(opportunity.Course)) parts.Add(opportunity.Course);
            if (!string.IsNullOrWhiteSpace(opportunity.Industry)) parts.Add(opportunity.Industry);
            if (!string.IsNullOrWhiteSpace(opportunity.Location)) parts.Add(opportunity.Location);

            Label details = new Label
            {
                Text = string.Join(" | ", parts),
                Location = new Point(12, 60),
                AutoSize = true
            };

            Label closing = new Label
            {
                Text = "Closing date: " + (opportunity.ClosingDate.HasValue ? opportunity.ClosingDate.Value.ToString("yyyy/MM/dd") : "N/A"),
                Location = new Point(12, 85),
                AutoSize = true
            };

            Button viewButton = new Button
            {
                Text = "View",
                Location = new Point(card.Width - 95, 95),
                Size = new Size(75, 30),
                Anchor = AnchorStyles.Right | AnchorStyles.Bottom,
                BackColor = Color.RoyalBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            Button applyButton = new Button
            {
                Name = "btnApply",
                Text = "Apply",
                Location = new Point(card.Width - 180, 95),
                Size = new Size(75, 30),
                Anchor = AnchorStyles.Right | AnchorStyles.Bottom,
                BackColor = Color.SeaGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            // If the student already applied, show applied state and disable apply
            if (studentUser != null && appliedOpportunityIds.Contains(opportunity.OpportunityID))
            {
                applyButton.Text = "Applied";
                applyButton.Enabled = false;
                applyButton.BackColor = Color.Gray;
            }

            applyButton.Click += (s, e) =>
            {
                // if not logged in, prompt to login
                if (studentUser == null)
                {
                    MessageBox.Show("Please login as a student to apply.", "Login Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Open application form for details and then record application
                var appForm = new ApplicationForm();
                if (appForm.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        var appsRepo = new WIL__.ApplicationsRepository();

                        // Prevent duplicate applications by this student for the same opportunity
                        var existing = appsRepo.GetByStudentUserId(studentUser.UserID).Find(a => a.OpportunityID == opportunity.OpportunityID);
                        if (existing != null)
                        {
                            MessageBox.Show("You have already applied for this opportunity.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        int id = appsRepo.CreateApplication(opportunity.OpportunityID, studentUser.UserID);
                        // Update UI state immediately: mark as applied and disable button
                        appliedOpportunityIds.Add(opportunity.OpportunityID);
                        applyButton.Text = "Applied";
                        applyButton.Enabled = false;
                        applyButton.BackColor = Color.Gray;
                        MessageBox.Show("Application submitted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Failed to submit application: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            };

            viewButton.Click += (s, e) =>
            {
                MessageBox.Show(
                    "Company: " + companyName +
                    "\nPosition: " + opportunity.Title +
                    "\nCourse/Discipline: " + (opportunity.Course ?? "") +
                    "\nType/Industry: " + (opportunity.Industry ?? "") +
                    "\nLocation: " + (opportunity.Location ?? "") +
                    "\nClosing date: " + (opportunity.ClosingDate.HasValue ? opportunity.ClosingDate.Value.ToString("yyyy/MM/dd") : "N/A") +
                    "\n\nDescription:\n" + (opportunity.Description ?? ""),
                    "Opportunity Details",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            };

            card.Controls.Add(company);
            card.Controls.Add(position);
            card.Controls.Add(details);
            card.Controls.Add(closing);
            card.Controls.Add(viewButton);
            card.Controls.Add(applyButton);

            // Ensure controls layout after adding buttons
            viewButton.BringToFront();
            applyButton.BringToFront();

            return card;
        }

        private void txtSearch_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

    }
}
