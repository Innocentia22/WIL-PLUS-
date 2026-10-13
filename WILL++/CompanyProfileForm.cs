using System;
using System.Drawing;
using System.Windows.Forms;
using WIL__; 

namespace WILL__
{
    public class CompanyProfileForm : Form
    {
        private readonly AuthenticatedUser user;
        private readonly AuthRepository authRepo = new AuthRepository();

        private TextBox txtCompanyName;
        private TextBox txtContactPerson;
        private TextBox txtPhone;
        private ComboBox cmbIndustry;
        private TextBox txtWebsite;
        private TextBox txtAddress;
        private Button btnSave;
        private Button btnCancel;

        private CompanyProfile profile;

        public CompanyProfileForm(AuthenticatedUser user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user));
            Initialize();
            LoadProfile();
        }

        private void Initialize()
        {
            Text = "Company Profile";
            Size = new Size(600, 480);
            StartPosition = FormStartPosition.CenterParent;

            Label l1 = new Label { Text = "Company Name", Location = new Point(20, 20), Size = new Size(120, 24) };
            txtCompanyName = new TextBox { Location = new Point(20, 48), Size = new Size(520, 28) };

            Label l2 = new Label { Text = "Contact Person", Location = new Point(20, 90), Size = new Size(120, 24) };
            txtContactPerson = new TextBox { Location = new Point(20, 118), Size = new Size(300, 28) };

            Label l3 = new Label { Text = "Phone", Location = new Point(340, 90), Size = new Size(60, 24) };
            txtPhone = new TextBox { Location = new Point(340, 118), Size = new Size(200, 28) };

            Label l4 = new Label { Text = "Industry", Location = new Point(20, 160), Size = new Size(80, 24) };
            cmbIndustry = new ComboBox { Location = new Point(20, 188), Size = new Size(300, 28), DropDownStyle = ComboBoxStyle.DropDownList };
            cmbIndustry.Items.AddRange(new object[] { "Information Technology", "Engineering", "Finance", "Other" });

            Label l5 = new Label { Text = "Website", Location = new Point(20, 230), Size = new Size(80, 24) };
            txtWebsite = new TextBox { Location = new Point(20, 258), Size = new Size(520, 28) };

            Label l6 = new Label { Text = "Address", Location = new Point(20, 300), Size = new Size(80, 24) };
            txtAddress = new TextBox { Location = new Point(20, 328), Size = new Size(520, 80), Multiline = true }; 

            btnSave = new Button { Text = "Save", Location = new Point(20, 420), Size = new Size(120, 36) };
            btnCancel = new Button { Text = "Cancel", Location = new Point(160, 420), Size = new Size(120, 36) };

            btnSave.Click += BtnSave_Click;
            btnCancel.Click += (s, e) => this.Close();

            Controls.Add(l1);
            Controls.Add(txtCompanyName);
            Controls.Add(l2);
            Controls.Add(txtContactPerson);
            Controls.Add(l3);
            Controls.Add(txtPhone);
            Controls.Add(l4);
            Controls.Add(cmbIndustry);
            Controls.Add(l5);
            Controls.Add(txtWebsite);
            Controls.Add(l6);
            Controls.Add(txtAddress);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
        }

        private void LoadProfile()
        {
            profile = authRepo.GetCompanyByUserId(user.UserID) ?? new CompanyProfile { UserID = user.UserID };

            txtCompanyName.Text = profile.CompanyName;
            txtContactPerson.Text = profile.ContactPerson;
            txtPhone.Text = profile.PhoneNumber;

            if (!string.IsNullOrEmpty(profile.Industry) && cmbIndustry.Items.Contains(profile.Industry))
            {
                cmbIndustry.SelectedItem = profile.Industry;
            }
            else
            {
                cmbIndustry.SelectedIndex = -1;
            }

            txtWebsite.Text = profile.Website;
            txtAddress.Text = profile.Address;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            profile.CompanyName = txtCompanyName.Text.Trim();
            profile.ContactPerson = txtContactPerson.Text.Trim();
            profile.PhoneNumber = txtPhone.Text.Trim();
            profile.Industry = cmbIndustry.SelectedItem?.ToString() ?? string.Empty;
            profile.Website = txtWebsite.Text.Trim();
            profile.Address = txtAddress.Text.Trim();

            try
            {
                authRepo.UpdateCompanyProfile(profile);
                MessageBox.Show("Profile saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save profile: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
