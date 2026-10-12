using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WILL__
{
    public partial class Student_register : Form
    {
        public Student_register()
        {
            InitializeComponent();

            // Course drop-down options
            cmbCourse.Items.Clear();
            cmbCourse.Items.AddRange(new object[]
            {
                "Electrical Engineering",
                "Civil Engineering",
                "Mechanical Engineering"
            });
            cmbCourse.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCourse.SelectedIndex = -1;

            // Year of study drop-down options
            cmbYearOfStudy.Items.Clear();
            cmbYearOfStudy.Items.AddRange(new object[]
            {
                "1st Year",
                "2nd Year",
                "3rd Year",
                "4th Year",
                "5th Year"
            });
            cmbYearOfStudy.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbYearOfStudy.SelectedIndex = -1;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string studentNumber = txtStudentNo.Text.Trim();

            // 1. Validate student number: exactly 9 digits
            if (!Regex.IsMatch(studentNumber, @"^[0-9]{9}$"))
            {
                MessageBox.Show(
                    "Student number must contain exactly 9 digits.",
                    "Invalid Student Number",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtStudentNo.Focus();
                return;
            }

            // 2. Validate required text fields
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtSurname.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                MessageBox.Show(
                    "Please complete all required fields.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // 3. Validate course selection
            if (cmbCourse.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select your course or qualification.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbCourse.Focus();
                return;
            }

            // 4. Validate year of study
            if (cmbYearOfStudy.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Please select your year of study.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbYearOfStudy.Focus();
                return;
            }

            // 5. Validate password confirmation
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show(
                    "Passwords do not match.",
                    "Password Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtConfirmPassword.Focus();
                return;
            }

            // 6. Get selected values
            string course = cmbCourse.SelectedItem.ToString();
            string yearOfStudy = cmbYearOfStudy.SelectedItem.ToString();

            // IMPORTANT:
            // Save the student details to your database here.
            // Do not show success until the database save succeeds.

            MessageBox.Show(
                "Student registration details validated successfully!",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            // 7. Return to Login Form
            LoginForm login = new LoginForm();
            login.Show();

            this.Close();
        }


    }
}

       

