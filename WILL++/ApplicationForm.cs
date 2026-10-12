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
    public partial class ApplicationForm : Form
    {
            private Label lblTitle;
            private Label lblSubtitle;
            private GroupBox grpOpportunity;
            private Label lblOpportunityDetails;

            private Label lblCoverLetter;
            private TextBox txtCoverLetter;

            private Label lblStartDate;
            private DateTimePicker dtpStartDate;

            private Label lblDuration;
           
            private Label lblAdditionalInfo;
            private TextBox txtAdditionalInfo;

            private Button btnSubmitApplication;
         

            public ApplicationForm()
            {
                InitializeComponent();
                BuildForm();
            }

            private void BuildForm()
            {
                this.Text = "Apply for Opportunity";
                this.Size = new Size(850, 780);
                this.StartPosition = FormStartPosition.CenterScreen;
                this.BackColor = Color.FromArgb(246, 249, 253);
                this.FormBorderStyle = FormBorderStyle.FixedSingle;
                this.MaximizeBox = false;

                // Page heading
                lblTitle = new Label();
                lblTitle.Text = "Apply for Opportunity";
                lblTitle.Font = new Font("Segoe UI", 22, FontStyle.Bold);
                lblTitle.ForeColor = Color.FromArgb(18, 35, 65);
                lblTitle.Location = new Point(30, 20);
                lblTitle.AutoSize = true;
                this.Controls.Add(lblTitle);

                lblSubtitle = new Label();
                lblSubtitle.Text =
                    "Complete your application for this opportunity";
                lblSubtitle.Font = new Font("Segoe UI", 10);
                lblSubtitle.ForeColor = Color.Gray;
                lblSubtitle.Location = new Point(33, 65);
                lblSubtitle.AutoSize = true;
                this.Controls.Add(lblSubtitle);

                // Opportunity summary
                grpOpportunity = new GroupBox();
                grpOpportunity.Text = "Opportunity Summary";
                grpOpportunity.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                grpOpportunity.Location = new Point(30, 100);
                grpOpportunity.Size = new Size(770, 120);
                this.Controls.Add(grpOpportunity);

                lblOpportunityDetails = new Label();
                lblOpportunityDetails.Text =
                    "Electrical Engineering WIL Programme\n" +
                    "TECHSOLUTIONS ENGINEERING\n" +
                    "East London, Eastern Cape\n" +
                    "WIL / In-Service Training";

                lblOpportunityDetails.Font = new Font("Segoe UI", 10);
                lblOpportunityDetails.Location = new Point(20, 25);
                lblOpportunityDetails.Size = new Size(720, 85);
                grpOpportunity.Controls.Add(lblOpportunityDetails);

                // Cover letter
                lblCoverLetter = new Label();
                lblCoverLetter.Text = "Cover Letter *";
                lblCoverLetter.Location = new Point(30, 240);
                lblCoverLetter.AutoSize = true;
                lblCoverLetter.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                this.Controls.Add(lblCoverLetter);

                txtCoverLetter = new TextBox();
                txtCoverLetter.Multiline = true;
                txtCoverLetter.ScrollBars = ScrollBars.Vertical;
                txtCoverLetter.Location = new Point(30, 270);
                txtCoverLetter.Size = new Size(770, 100);
                txtCoverLetter.Font = new Font("Segoe UI", 10);
                this.Controls.Add(txtCoverLetter);

                // Available start date
                lblStartDate = new Label();
                lblStartDate.Text = "Available Start Date *";
                lblStartDate.Location = new Point(30, 390);
                lblStartDate.AutoSize = true;
                lblStartDate.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                this.Controls.Add(lblStartDate);

                dtpStartDate = new DateTimePicker();
                dtpStartDate.Name = "dtpStartDate";
                dtpStartDate.Format = DateTimePickerFormat.Custom;
                dtpStartDate.CustomFormat = "yyyy/MM/dd";
                dtpStartDate.MinDate = DateTime.Today;
                dtpStartDate.Location = new Point(30, 420);
                dtpStartDate.Size = new Size(350, 30);
                this.Controls.Add(dtpStartDate);

                // Preferred duration
                lblDuration = new Label();
                lblDuration.Text = "Preferred Duration *";
                lblDuration.Location = new Point(430, 390);
                lblDuration.AutoSize = true;
                lblDuration.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                this.Controls.Add(lblDuration);

                cmbDuration = new ComboBox();
                cmbDuration.Name = "cmbDuration";
                cmbDuration.Location = new Point(430, 420);
                cmbDuration.Size = new Size(370, 30);
                cmbDuration.DropDownStyle = ComboBoxStyle.DropDownList;

                cmbDuration.Items.AddRange(new string[]
                {
                "1 month",
                "3 months",
                "6 months",
                "12 months"
                });

                cmbDuration.SelectedIndex = 2;
                this.Controls.Add(cmbDuration);

                // Additional information
                lblAdditionalInfo = new Label();
                lblAdditionalInfo.Text = "Additional Information";
                lblAdditionalInfo.Location = new Point(30, 465);
                lblAdditionalInfo.AutoSize = true;
                lblAdditionalInfo.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                this.Controls.Add(lblAdditionalInfo);

                txtAdditionalInfo = new TextBox();
                txtAdditionalInfo.Multiline = true;
                txtAdditionalInfo.ScrollBars = ScrollBars.Vertical;
                txtAdditionalInfo.Location = new Point(30, 495);
                txtAdditionalInfo.Size = new Size(770, 90);
                txtAdditionalInfo.Font = new Font("Segoe UI", 10);
                this.Controls.Add(txtAdditionalInfo);

                // Submit button
                btnSubmitApplication = new Button();
                btnSubmitApplication.Text = "Submit Application";
                btnSubmitApplication.Location = new Point(30, 620);
                btnSubmitApplication.Size = new Size(220, 45);
                btnSubmitApplication.BackColor = Color.FromArgb(0, 105, 230);
                btnSubmitApplication.ForeColor = Color.White;
                btnSubmitApplication.FlatStyle = FlatStyle.Flat;
                btnSubmitApplication.Font =
                    new Font("Segoe UI", 10, FontStyle.Bold);
                btnSubmitApplication.Click +=
                    btnSubmitApplication_Click;
                this.Controls.Add(btnSubmitApplication);

                // Cancel button
                btnCancel = new Button();
                btnCancel.Text = "Cancel";
                btnCancel.Location = new Point(270, 620);
                btnCancel.Size = new Size(150, 45);
                btnCancel.BackColor = Color.LightGray;
                btnCancel.ForeColor = Color.Black;
                btnCancel.FlatStyle = FlatStyle.Flat;
                btnCancel.Font = new Font("Segoe UI", 10);
                btnCancel.Click += btnCancel_Click;
                this.Controls.Add(btnCancel);
            }

            private void btnSubmitApplication_Click(
                object sender, EventArgs e)
            {
                // Validate required fields
                if (string.IsNullOrWhiteSpace(txtCoverLetter.Text))
                {
                    MessageBox.Show(
                        "Please enter your cover letter.",
                        "Missing Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtCoverLetter.Focus();
                    return;
                }

                if (cmbDuration.SelectedIndex == -1)
                {
                    MessageBox.Show(
                        "Please select your preferred duration.",
                        "Missing Information",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    cmbDuration.Focus();
                    return;
                }

                // Read the selected values
                DateTime availableStartDate = dtpStartDate.Value.Date;
                string preferredDuration = cmbDuration.Text;
                string coverLetter = txtCoverLetter.Text.Trim();
                string additionalInfo = txtAdditionalInfo.Text.Trim();

                // Display submitted information
                MessageBox.Show(
                    "Application submitted successfully!\n\n" +
                    "Available Start Date: " +
                    availableStartDate.ToString("yyyy/MM/dd") + "\n" +
                    "Preferred Duration: " + preferredDuration,
                    "WIL++ Application",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // TODO: Save the application to a shared list or database
                // so it appears on the My Applications page.
            }

            private void btnCancel_Click(object sender, EventArgs e)
            {
                this.Close();
            }
        }
    }