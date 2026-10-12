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
    public partial class Admin_register : Form
    {
        public Admin_register()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string adminID = txtAdminID.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            // Validate empty fields
            if (string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(phone) ||
                string.IsNullOrWhiteSpace(adminID) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                MessageBox.Show(
                    "Please complete all fields.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Validate full name
            if (!System.Text.RegularExpressions.Regex.IsMatch(
                fullName,
                @"^[\p{L}]+(?:[ '-][\p{L}]+)*$"))
            {
                MessageBox.Show(
                    "Please enter a valid full name.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtFullName.Focus();
                return;
            }

            // Validate email address
            try
            {
                var emailAddress = new System.Net.Mail.MailAddress(email);

                if (emailAddress.Address != email)
                {
                    throw new FormatException();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Please enter a valid email address.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtEmail.Focus();
                return;
            }

            // Validate phone number
            if (!System.Text.RegularExpressions.Regex.IsMatch(
                phone,
                @"^\d{10}$"))
            {
                MessageBox.Show(
                    "The phone number must contain exactly 10 digits.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPhone.Focus();
                return;
            }

            // Validate Admin ID
            if (adminID.Length < 3 || adminID.Length > 20)
            {
                MessageBox.Show(
                    "The Admin ID must contain between 3 and 20 characters.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtAdminID.Focus();
                return;
            }

            // Validate password length
            if (password.Length < 8)
            {
                MessageBox.Show(
                    "The password must contain at least 8 characters.",
                    "Weak Password",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPassword.Focus();
                return;
            }

            // Validate password complexity
            if (!System.Text.RegularExpressions.Regex.IsMatch(password, @"[A-Z]") ||
                !System.Text.RegularExpressions.Regex.IsMatch(password, @"[a-z]") ||
                !System.Text.RegularExpressions.Regex.IsMatch(password, @"\d") ||
                !System.Text.RegularExpressions.Regex.IsMatch(password, @"[^a-zA-Z0-9]"))
            {
                MessageBox.Show(
                    "Your password must contain an uppercase letter, " +
                    "a lowercase letter, a number and a special character.",
                    "Weak Password",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtPassword.Focus();
                return;
            }

            // Validate matching passwords
            if (password != confirmPassword)
            {
                MessageBox.Show(
                    "The passwords do not match.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtConfirmPassword.Clear();
                txtConfirmPassword.Focus();
                return;
            }

            // Registration validation successful
            MessageBox.Show(
                "All validations passed! The admin details are valid.",
                "Registration Successful",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnregister_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
