
using System;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;
using WIL__;

namespace WILL__
{
    public partial class coordinator_register : Form
    {
        private readonly AuthRepository repository = new AuthRepository();

        public coordinator_register()
        {
            InitializeComponent();

            txtPass.UseSystemPasswordChar = true;
            txtConfirmPass.UseSystemPasswordChar = true;

            // Populate dropdowns.
            if (cmbDepartment.Items.Count == 0)
            {
                cmbDepartment.Items.AddRange(new object[]
                {
                    "Information Technology",
                    "Computer Science",
                    "Engineering",
                    "Business Studies",
                    "Other"
                });
            }

            if (cmbCoordinator.Items.Count == 0)
            {
                cmbCoordinator.Items.AddRange(new object[]
                {
                    "WIL Coordinator",
                    "Department Coordinator"
                });
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Read form values.
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string staffNumber = txtStaffNumber.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhoneNumber.Text.Trim();
            string password = txtPass.Text;
            string confirmPassword = txtConfirmPass.Text;

            string department =
                cmbDepartment.SelectedItem?.ToString() ?? "";

            string coordinatorRole =
                cmbCoordinator.SelectedItem?.ToString() ?? "";

            // Validate required fields.
            if (string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(staffNumber) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(phone) ||
                string.IsNullOrWhiteSpace(department) ||
                string.IsNullOrWhiteSpace(coordinatorRole) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show(
                    "Please complete all fields and select a department and role.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Basic email validation.
            if (!System.Text.RegularExpressions.Regex.IsMatch(
                email,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show(
                    "Please enter a valid email address.",
                    "Invalid Email",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtEmail.Focus();
                return;
            }

            // Validate password length.
            if (password.Length < 8)
            {
                MessageBox.Show(
                    "Your password must contain at least 8 characters.",
                    "Weak Password",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPass.Focus();
                return;
            }

            // Confirm passwords match.
            if (password != confirmPassword)
            {
                MessageBox.Show(
                    "The passwords do not match.",
                    "Password Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtConfirmPass.Clear();
                txtConfirmPass.Focus();
                return;
            }

            btnRegister.Enabled = false;

            try
            {
                // Save account and coordinator details to SQL Server.
                repository.RegisterCoordinator(
                    firstName,
                    lastName,
                    staffNumber,
                    email,
                    phone,
                    department,
                    password
                );

                MessageBox.Show(
                    "Coordinator registered successfully!",
                    "Registration Successful",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Clear fields after successful registration.
                txtFirstName.Clear();
                txtLastName.Clear();
                txtStaffNumber.Clear();
                txtEmail.Clear();
                txtPhoneNumber.Clear();
                txtPass.Clear();
                txtConfirmPass.Clear();

                cmbDepartment.SelectedIndex = -1;
                cmbCoordinator.SelectedIndex = -1;

                txtFirstName.Focus();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    "The database could not complete registration. " +
                    "Check whether the email or staff number already exists.\n\n" +
                    "Database details: " + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Registration failed because of an unexpected error. " +
                    "Please try again.",
                    "Registration Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                btnRegister.Enabled = true;
            }
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            // No action required.
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var login = new LoginForm();
            login.Show();
            this.Close();
        }
    }
}
