using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WIL__;

namespace WILL__
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        private void pnlLogin_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Get values from the form
            string userType = cmbUserType.Text.Trim();
            string studentNumber = txtStudentNumber.Text.Trim();
            string password = txtPassword.Text;

            // Validate User Type
            if (string.IsNullOrEmpty(userType))
            {
                MessageBox.Show("Please select a user type.",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                cmbUserType.Focus();
                return;
            }
            // Validate Student Number
            if (string.IsNullOrEmpty(studentNumber))
            {
                MessageBox.Show("Please enter your student number.",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                txtStudentNumber.Focus();
                return;
            }
            // Validate password
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter your password.",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                txtPassword.Focus();
                return;
            }
            // Validate password length
            if (password.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 characters.",
                                "Validation Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                txtPassword.Focus();
                return;
            }
            if (userType == "Student")
            {
                if (string.IsNullOrEmpty(studentNumber))
                {
                    MessageBox.Show("Student number is required for students.");
                    txtStudentNumber.Focus();
                    return;
                }
            }

            try
            {
                UserRepository userRepository = new UserRepository();

                bool loginSuccessful = userRepository.Login(studentNumber, password);

                if (loginSuccessful)
                {
                    MessageBox.Show(
                        "Login successful!",
                        "WIL++",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    StudentDashboard dashboard = new StudentDashboard();
                    dashboard.Show();

                    this.Hide();
                }
                else
                {
                    MessageBox.Show(
                        "Invalid email or password.",
                        "Login Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to connect to the database.\n\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            CreateAccountForm createAccount = new CreateAccountForm();
            createAccount.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            string userType = cmbUserType.Text.Trim();
            string studentNumber = txtStudentNumber.Text.Trim();


            // Validate User Type
            if (string.IsNullOrEmpty(userType))
            {
                MessageBox.Show(
                    "Please select a user type.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbUserType.Focus();
                return;
            }
            //  Validate Student Number
            if (string.IsNullOrEmpty(studentNumber))
            {
                MessageBox.Show(
                    "Please enter your student number.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtStudentNumber.Focus();
                return;
            }

            //  Check Student Number contains numbers only
            if (!studentNumber.All(char.IsDigit))
            {
                MessageBox.Show(
                    "Student number must contain numbers only.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtStudentNumber.Focus();
                return;
            }

            //  Validate Email

            {
                MessageBox.Show(
                    "Please enter your email address.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);


                return;
            }

            //  Validation successful

            MessageBox.Show(
            "If the account details are correct, password reset instructions will be sent to your email.",
            "Password Reset",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
        }
            

        private void chkRemember_CheckedChanged(object sender, EventArgs e)
        {

        }
    }

    internal class CreateAccountForm
    {
        internal void Show()
        {
            CreateAccountForm createAccount = new CreateAccountForm();

        }
    }
}
