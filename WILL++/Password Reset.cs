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
    public partial class Password_Reset : Form
    {
        public Password_Reset()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            string userType = cmbUserType.Text.Trim();
            string studentNumber = txtStudentNumber.Text.Trim();
            string email = txtEmail.Text.Trim();
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            // Check User Type
            if (string.IsNullOrEmpty(userType))
            {
                MessageBox.Show("Please select a user type.");
                cmbUserType.Focus();
                return;
            }

            // Check Student Number
            if (string.IsNullOrEmpty(studentNumber))
            {
                MessageBox.Show("Please enter your student number.");
                txtStudentNumber.Focus();
                return;
            }
            // Student number validation
            if (userType == "Student" &&
                !studentNumber.All(char.IsDigit))
            {
                MessageBox.Show("Student number must contain numbers only.");
                txtStudentNumber.Focus();
                return;
            }

            // Check Email
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please enter your email address.");
                txtEmail.Focus();
                return;
            }
            // Check New Password
            if (string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Please enter a new password.");
                txtNewPassword.Focus();
                return;
            }

            // Password length
            if (newPassword.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters.");
                txtNewPassword.Focus();
                return;
            }

            // Check Confirm Password
            if (string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Please confirm your password.");
                txtConfirmPassword.Focus();
                return;
            }
            // Check passwords match
            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
                txtConfirmPassword.Clear();
                txtConfirmPassword.Focus();
                return;
            }

            // Everything is valid
            MessageBox.Show(
                "Your password has been reset successfully!",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void cmbUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbUserType.Items.Add("Student");
            cmbUserType.Items.Add("Coordinator");
            cmbUserType.Items.Add("Company");

            cmbUserType.SelectedIndex = -1;
        }
    }
}
