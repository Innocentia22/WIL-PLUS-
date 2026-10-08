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
    public partial class Create_Account : Form
    {
        public Create_Account()
        {
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string userType = cmbUserType.Text.Trim();
            string studentNumber = txtStudentNumber.Text.Trim();
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            // 1. Validate User Type
            if (string.IsNullOrEmpty(userType))
            {
                MessageBox.Show("Please select a user type.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbUserType.Focus();
                return;
            }
            // 2. Validate Full Name
            if (string.IsNullOrEmpty(fullName))
            {
                MessageBox.Show("Please enter your full name.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtFullName.Focus();
                return;
            }
            // 3. Validate Student Number
            if (userType == "Student")
            {
                if (string.IsNullOrEmpty(studentNumber))
                {
                    MessageBox.Show("Please enter your student number.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtStudentNumber.Focus();
                    return;
                }
               if(!studentNumber.All(char.IsDigit))
        {
                    MessageBox.Show("Student number must contain numbers only.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtStudentNumber.Focus();
                    return;
                }
                // 4. Validate Email
                if (string.IsNullOrEmpty(email))
                {
                    MessageBox.Show("Please enter your email address.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtEmail.Focus();
                    return;
                }
                // 5. Validate Password
                if (string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Please enter a password.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtPassword.Focus();
                    return;
                }

                if (password.Length < 8)
                {
                    MessageBox.Show("Password must be at least 8 characters long.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtPassword.Focus();
                    return;
                }
                // 6. Validate Confirm Password
                if (string.IsNullOrEmpty(confirmPassword))
                {
                    MessageBox.Show("Please confirm your password.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtConfirmPassword.Focus();
                    return;
                }
                // 7. Check passwords match
                if (password != confirmPassword)
                {
                    MessageBox.Show("Passwords do not match.",
                        "Validation Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    txtConfirmPassword.Clear();
                    txtConfirmPassword.Focus();
                    return;
                }
                // 8. Everything is valid
                MessageBox.Show("Account created successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // Add database INSERT code here
            }
        }
        }
        }
    }

