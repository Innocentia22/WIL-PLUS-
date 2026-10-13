
using System;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using WIL__;

namespace WILL__
{
    public partial class LoginForm : Form
    {
        private readonly AuthRepository authRepository =
            new AuthRepository();

        public LoginForm()
        {
            InitializeComponent();

            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmailInput.Text.Trim();
            string password = txtPassword.Text;
            string selectedRole = cmbRole.Text.Trim();

            if (string.IsNullOrWhiteSpace(selectedRole))
            {
                MessageBox.Show(
                    "Please select your account type.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                cmbRole.Focus();
                return;
            }

                if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show(
                    "Please enter your registered email address.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtEmailInput.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show(
                    "Please enter your password.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            try
            {
                AuthenticatedUser user =
                    authRepository.Login(email, password);

                if (user == null)
                {
                    MessageBox.Show(
                        "Invalid email or password, or the account is inactive.",
                        "Login Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                // Confirm the selected role matches the account in the database.
                string databaseRole = user.UserType.Trim();

                bool roleMatches =
                    (selectedRole.Equals("Student",
                        StringComparison.OrdinalIgnoreCase)
                        && databaseRole.Equals("Student",
                            StringComparison.OrdinalIgnoreCase))
                    ||
                    ((selectedRole.Equals("Department/Coordinator",
                        StringComparison.OrdinalIgnoreCase)
                        || selectedRole.Equals("Coordinator",
                            StringComparison.OrdinalIgnoreCase))
                        && databaseRole.Equals("Coordinator",
                            StringComparison.OrdinalIgnoreCase))
                    ||
                    (selectedRole.Equals("Company", StringComparison.OrdinalIgnoreCase)
                        && databaseRole.Equals("Company", StringComparison.OrdinalIgnoreCase))
                    ||
                    ((selectedRole.Equals("Administrator",
                        StringComparison.OrdinalIgnoreCase)
                        || selectedRole.Equals("Admin",
                            StringComparison.OrdinalIgnoreCase))
                        && (databaseRole.Equals("Administrator",
                            StringComparison.OrdinalIgnoreCase)
                            || databaseRole.Equals("Admin",
                                StringComparison.OrdinalIgnoreCase)));

                if (!roleMatches)
                {
                    MessageBox.Show(
                        "The selected account type does not match your registered account.",
                        "Account Type Mismatch",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                Form dashboard;

                switch (databaseRole.ToLowerInvariant())
                {
                    case "student":
                        dashboard = new StudentDashboard(user);
                        break;

                    case "coordinator":
                        dashboard = new CoordinatorDashboard(user);
                        break;

                    case "company":
                        dashboard = new CompanyDashboard(user);
                        break;

                    case "administrator":
                    case "admin":
                        dashboard = new AdminDashboard();
                        break;

                    default:
                        MessageBox.Show(
                            "This account type does not have a supported login dashboard yet.",
                            "Unsupported Account Type",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                        return;
                }

                MessageBox.Show(
                    "Login successful!",
                    "WIL++",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                dashboard.FormClosed += (s, args) => this.Close();
                dashboard.Show();
                this.Hide();
            }
            catch (SqlException)
            {
                MessageBox.Show(
                    "The database could not complete the login. Please check the database connection.",
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Login could not be completed: " + ex.Message,
                    "Login Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (cmbRole.SelectedItem == null)
            {
                MessageBox.Show("Please select an account type first.");
                return;
            }

            string role = cmbRole.SelectedItem.ToString();

            if (role.Equals("Student", StringComparison.OrdinalIgnoreCase))
            {
                new Student_register().Show();
                this.Hide();
            }
            else if (role.Equals("Company", StringComparison.OrdinalIgnoreCase))
            {
                new Company_register().Show();
                this.Hide();
            }
            else if (
                role.Equals("Department/Coordinator",
                    StringComparison.OrdinalIgnoreCase)
                || role.Equals("Coordinator",
                    StringComparison.OrdinalIgnoreCase))
            {
                new coordinator_register().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(
                    "Administrator accounts must be created through an authorized setup process.",
                    "Registration Restricted",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void pnlLogin_Paint(object sender, PaintEventArgs e)
        {
            // Intentionally empty.
        }

        private void label10_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Please contact your WIL++ administrator to reset your password.",
                "Password Reset",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void chkRemember_CheckedChanged(object sender, EventArgs e)
        {
            // Remember-me functionality can be implemented later.
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DatabaseTest.Run();
        }
    }
}
