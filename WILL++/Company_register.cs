using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using WIL__;

namespace WILL__
{
    public partial class Company_register : Form
    {
        public Company_register()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string companyName = txtCompanyName.Text.Trim();
            string contact = txtContactName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string industry = cmbIndustry.SelectedItem?.ToString() ?? "";
            string website = txtWebsite?.Text.Trim() ?? string.Empty;
            string address = txtAddress?.Text.Trim() ?? string.Empty;
            string pass = txtPassword.Text;
            string confirm = txtConfirmPassword.Text;

            if (string.IsNullOrWhiteSpace(companyName) ||
                string.IsNullOrWhiteSpace(contact) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(phone) ||
                string.IsNullOrWhiteSpace(industry) ||
                string.IsNullOrWhiteSpace(pass) ||
                string.IsNullOrWhiteSpace(confirm))
            {
                MessageBox.Show("Please complete all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (pass.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            if (pass != confirm)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
                return;
            }

            try
            {
                var repo = new AuthRepository();
                repo.RegisterCompany(companyName, contact, phone, industry, email, pass, website, address);

                // Attempt to log the new company in immediately and open the company dashboard
                var user = repo.Login(email, pass);
                if (user != null)
                {
                    MessageBox.Show("Company registered and logged in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var dashboard = new CompanyDashboard(user);
                    dashboard.FormClosed += (s, args) => this.Close();
                    dashboard.Show();
                }
                else
                {
                    MessageBox.Show("Company registered successfully. Please login.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var login = new LoginForm();
                    login.Show();
                    this.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error during registration: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Registration failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var login = new LoginForm();
            login.Show();
            this.Close();
        }
    }
}
