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
    public partial class Coordinator_Account : Form
    {
        public Coordinator_Account()
        {
            InitializeComponent();
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            string email = txtEmailAddress.Text.Trim();
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string phoneNumber = txtPhoneNumber.Text.Trim();
            string department = cmbDepartment.Text.Trim();
            string coordinatorRole = cmbCoordinatorRole.Text.Trim();
            string staffNumber = txtStaffNumber.Text.Trim();

            // Validate Email
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please enter your email address.");
                txtEmailAddress.Focus();
                return;
            }
            // Validate First Name
            if (string.IsNullOrEmpty(firstName))
            {
                MessageBox.Show("Please enter your first name.");
                txtFirstName.Focus();
                return;
            }

            if (!firstName.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
            {
                MessageBox.Show("First name must contain letters only.");
                txtFirstName.Focus();
                return;
            }

            // Validate Last Name
            if (string.IsNullOrEmpty(lastName))
            {
                MessageBox.Show("Please enter your last name.");
                txtLastName.Focus();
                return;
            }

            if (!lastName.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
            {
                MessageBox.Show("Last name must contain letters only.");
                txtLastName.Focus();
                return;
            }

            // Validate Phone Number
            if (string.IsNullOrEmpty(phoneNumber))
            {
                MessageBox.Show("Please enter your phone number.");
                txtPhoneNumber.Focus();
                return;
            }
            if (phoneNumber.Length < 10)
            {
                MessageBox.Show("Please enter a valid phone number.");
                txtPhoneNumber.Focus();
                return;
            }

            // Validate Department
            if (string.IsNullOrEmpty(department))
            {
                MessageBox.Show("Please select a department.");
                cmbDepartment.Focus();
                return;
            }

            // Validate Coordinator Role
            if (string.IsNullOrEmpty(coordinatorRole))
            {
                MessageBox.Show("Please select a coordinator role.");
                cmbCoordinatorRole.Focus();
                return;
            }
            // Validate Staff Number
            if (string.IsNullOrEmpty(staffNumber))
            {
                MessageBox.Show("Please enter your staff number.");
                txtStaffNumber.Focus();
                return;
            }

            if (!staffNumber.All(char.IsLetterOrDigit))
            {
                MessageBox.Show("Staff number must contain letters and numbers only.");
                txtStaffNumber.Focus();
                return;
            }
            // All validation passed
            MessageBox.Show(
                "Coordinator account created successfully!",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            // Database INSERT code goes here
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtEmailAddress.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtPhoneNumber.Clear();
            txtStaffNumber.Clear();

            cmbDepartment.SelectedIndex = -1;
            cmbCoordinatorRole.SelectedIndex = -1;
            txtEmailAddress.Focus();
        }
    }
    }

