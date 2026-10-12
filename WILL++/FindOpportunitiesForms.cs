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
        public FindOpportunitiesForms()
        {
            InitializeComponent();
        }


        private class Opportunity
        {
            public string Company { get; set; }
            public string Position { get; set; }
            public string Discipline { get; set; }
            public string Type { get; set; }
            public string Location { get; set; }
            public string ClosingDate { get; set; }
            public string Description { get; set; }
        }

        private List<Opportunity> opportunities =
            new List<Opportunity>();

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

            // DEMONSTRATION DATA ONLY.
            // Replace these examples with real database records.

            opportunities.Add(new Opportunity
            {
                Company = "Example Electrical Ltd",
                Position = "Electrical Engineering Intern",
                Discipline = "Electrical Engineering",
                Type = "WIL",
                Location = "East London",
                ClosingDate = "30 November 2026",
                Description =
                    "Practical electrical engineering workplace experience."
            });

            opportunities.Add(new Opportunity
            {
                Company = "Example Civil Works",
                Position = "Civil Engineering Trainee",
                Discipline = "Civil Engineering",
                Type = "In-Service Training",
                Location = "Mthatha",
                ClosingDate = "15 December 2026",
                Description =
                    "Civil construction and site experience."
            });

            opportunities.Add(new Opportunity
            {
                Company = "Example Mechanical Services",
                Position = "Mechanical Engineering Intern",
                Discipline = "Mechanical Engineering",
                Type = "WIL",
                Location = "Gqeberha",
                ClosingDate = "20 December 2026",
                Description =
                    "Mechanical maintenance and workshop experience."
            });

            opportunities.Add(new Opportunity
            {
                Company = "Example Engineering Group",
                Position = "Electrical Engineering Trainee",
                Discipline = "Electrical Engineering",
                Type = "In-Service Training",
                Location = "Cape Town",
                ClosingDate = "10 December 2026",
                Description =
                    "Electrical systems and maintenance training."
            });
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
                 o.Company.IndexOf(search,
                     StringComparison.OrdinalIgnoreCase) >= 0 ||
                 o.Position.IndexOf(search,
                     StringComparison.OrdinalIgnoreCase) >= 0 ||
                 o.Discipline.IndexOf(search,
                     StringComparison.OrdinalIgnoreCase) >= 0) &&

                (discipline == "All Disciplines" ||
                 o.Discipline == discipline) &&

                (type == "All Types" || o.Type == type) &&

                (location == "All Locations" ||
                 o.Location == location)
            ).ToList();

            flowLayoutPanelOpportunities.SuspendLayout();
            flowLayoutPanelOpportunities.Controls.Clear();

            foreach (Opportunity opportunity in results)
            {
                flowLayoutPanelOpportunities.Controls.Add(
                    CreateOpportunityCard(opportunity));
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

        private Panel CreateOpportunityCard(Opportunity opportunity)
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

            Label company = new Label
            {
                Text = opportunity.Company,
                Location = new Point(12, 10),
                AutoSize = true,
                Font = new Font("Segoe UI", 11, FontStyle.Bold)
            };

            Label position = new Label
            {
                Text = opportunity.Position,
                Location = new Point(12, 35),
                AutoSize = true
            };

            Label details = new Label
            {
                Text = opportunity.Discipline + " | " +
                       opportunity.Type + " | " + opportunity.Location,
                Location = new Point(12, 60),
                AutoSize = true
            };

            Label closing = new Label
            {
                Text = "Closing date: " + opportunity.ClosingDate,
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

            viewButton.Click += (s, e) =>
            {
                MessageBox.Show(
                    "Company: " + opportunity.Company +
                    "\nPosition: " + opportunity.Position +
                    "\nDiscipline: " + opportunity.Discipline +
                    "\nType: " + opportunity.Type +
                    "\nLocation: " + opportunity.Location +
                    "\nClosing date: " + opportunity.ClosingDate +
                    "\n\nDescription:\n" + opportunity.Description,
                    "Opportunity Details",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            };

            card.Controls.Add(company);
            card.Controls.Add(position);
            card.Controls.Add(details);
            card.Controls.Add(closing);
            card.Controls.Add(viewButton);

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
