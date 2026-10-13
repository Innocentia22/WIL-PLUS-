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
    public partial class StudentProfileForm : Form
    {

        private TextBox txtFullName, txtStudentNumber;
        private TextBox txtEmail, txtPhone;
        private ComboBox cmbDiscipline;
        private Button btnSave, btnCancel;

        private readonly Color navy = Color.FromArgb(18, 35, 65);
        private readonly Color blue = Color.FromArgb(0, 105, 230);
        private readonly Color cyan = Color.FromArgb(0, 164, 220);
        private readonly Color pageColor = Color.FromArgb(246, 249, 253);

        public StudentProfileForm()
        {
            InitializeComponent();
            BuildProfilePage();
        }

        // Public method used by StudentDashboard to load and display student profile
        public void LoadProfile(int studentUserId)
        {
            try
            {
                var auth = new WIL__.AuthRepository();
                // attempt to locate student personal details in dbo.Students
                using (var con = new WIL__.DbConnection().GetConnection())
                {
                    con.Open();
                    using (var cmd = con.CreateCommand())
                    {
                        cmd.CommandText = @"SELECT s.FirstName, s.LastName, s.StudentNumber, s.PhoneNumber, u.Email, s.Discipline, s.YearOfStudy
FROM dbo.Students s
LEFT JOIN dbo.Users u ON s.UserID = u.UserID
WHERE s.UserID = @UserID";
                        var p = cmd.CreateParameter();
                        p.ParameterName = "@UserID";
                        p.Value = studentUserId;
                        cmd.Parameters.Add(p);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string first = reader.IsDBNull(reader.GetOrdinal("FirstName")) ? string.Empty : reader.GetString(reader.GetOrdinal("FirstName"));
                                string last = reader.IsDBNull(reader.GetOrdinal("LastName")) ? string.Empty : reader.GetString(reader.GetOrdinal("LastName"));
                                txtFullName.Text = (first + " " + last).Trim();
                                txtStudentNumber.Text = reader.IsDBNull(reader.GetOrdinal("StudentNumber")) ? string.Empty : reader.GetString(reader.GetOrdinal("StudentNumber"));
                                txtPhone.Text = reader.IsDBNull(reader.GetOrdinal("PhoneNumber")) ? string.Empty : reader.GetString(reader.GetOrdinal("PhoneNumber"));
                                txtEmail.Text = reader.IsDBNull(reader.GetOrdinal("Email")) ? string.Empty : reader.GetString(reader.GetOrdinal("Email"));
                                string discipline = reader.IsDBNull(reader.GetOrdinal("Discipline")) ? string.Empty : reader.GetString(reader.GetOrdinal("Discipline"));
                                if (!string.IsNullOrWhiteSpace(discipline) && cmbDiscipline.Items.Contains(discipline))
                                    cmbDiscipline.SelectedItem = discipline;
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private void BuildProfilePage()
        {
            Text = "WIL++ - My Profile";
            Size = new Size(1350, 850);
            MinimumSize = new Size(1050, 700);
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = pageColor;

            // Sidebar
            Panel sidebar = new Panel();
            sidebar.Dock = DockStyle.Left;
            sidebar.Width = 300;
            sidebar.BackColor = navy;
            Controls.Add(sidebar);

            Label logo = new Label();
            logo.Text = "WIL++";
            logo.Font = new Font("Segoe UI", 30, FontStyle.Bold);
            logo.ForeColor = Color.White;
            logo.Location = new Point(35, 25);
            logo.AutoSize = true;
            sidebar.Controls.Add(logo);

            Label tagline = new Label();
            tagline.Text = "Work-Integrated\nLearning Plus";
            tagline.Font = new Font("Segoe UI", 11, FontStyle.Italic);
            tagline.ForeColor = Color.LightSteelBlue;
            tagline.Location = new Point(40, 85);
            tagline.AutoSize = true;
            sidebar.Controls.Add(tagline);

            string[] menuItems =
            {
                "Dashboard",
                "Find Opportunities",
                "My Applications",
                "My Profile",
                "Notifications",
                "Messages",
                "Resources",
                "Logout"
            };

            int y = 150;

            foreach (string item in menuItems)
            {
                Button menuButton = new Button();
                menuButton.Text = item;
                menuButton.Location = new Point(20, y);
                menuButton.Size = new Size(250, 45);
                menuButton.BackColor =
                    item == "My Profile" ? cyan : blue;
                menuButton.ForeColor = Color.White;
                menuButton.FlatStyle = FlatStyle.Flat;
                menuButton.Font = new Font("Segoe UI", 10);
                menuButton.Cursor = Cursors.Hand;

                menuButton.Click += (sender, e) =>
                {
                    if (item == "Logout")
                    {
                        Close();
                    }
                    else if (item != "My Profile")
                    {
                        MessageBox.Show(
                            item + " page can be connected here.",
                            "WIL++");
                    }
                };

                sidebar.Controls.Add(menuButton);
                y += 65;
            }

            // Main content area
            Panel main = new Panel();
            main.Dock = DockStyle.Fill;
            main.AutoScroll = true;
            main.BackColor = pageColor;
            Controls.Add(main);
            main.BringToFront();

            // Page heading
            Label heading = new Label();
            heading.Text = "My Profile";
            heading.Font = new Font("Segoe UI", 25, FontStyle.Bold);
            heading.ForeColor = navy;
            heading.Location = new Point(430, 20);
            heading.AutoSize = true;
            main.Controls.Add(heading);

            Label subtitle = new Label();
            subtitle.Text = "Manage your student information\nand documents";
            subtitle.Font = new Font("Segoe UI", 11, FontStyle.Italic);
            subtitle.ForeColor = Color.SlateGray;
            subtitle.Location = new Point(400, 75);
            subtitle.Size = new Size(350, 50);
            main.Controls.Add(subtitle);

            // Student summary
            Panel summary = new Panel();
            summary.Location = new Point(100, 140);
            summary.Size = new Size(800, 100);
            summary.BackColor = Color.White;
            summary.BorderStyle = BorderStyle.FixedSingle;
            main.Controls.Add(summary);

            Panel photoBox = new Panel();
            photoBox.Location = new Point(15, 10);
            photoBox.Size = new Size(130, 78);
            photoBox.BackColor = Color.FromArgb(235, 240, 247);
            photoBox.BorderStyle = BorderStyle.FixedSingle;
            summary.Controls.Add(photoBox);

            Label photoText = new Label();
            photoText.Text = "Student Photo";
            photoText.Dock = DockStyle.Fill;
            photoText.TextAlign = ContentAlignment.MiddleCenter;
            photoText.ForeColor = Color.Gray;
            photoBox.Controls.Add(photoText);

            Label studentSummary = new Label();
            studentSummary.Text =
                "Manyano Vuso\n" +
                "240937775\n" +
                "Diploma in Electrical Engineering";
            studentSummary.Location = new Point(200, 20);
            studentSummary.Size = new Size(550, 70);
            studentSummary.Font = new Font("Segoe UI", 10);
            studentSummary.ForeColor = navy;
            summary.Controls.Add(studentSummary);

            // Personal Information
            AddHeading(main, "Personal Information", 250);

            txtFullName = AddTextField(
                main, "Full Name", "Manyano Vuso", 250, 295);

            txtStudentNumber = AddTextField(
                main, "Student Number", "240937775", 590, 295);

            txtEmail = AddTextField(
                main, "Email Address",
                "240937775@mywsu.ac.za", 250, 370);

            txtPhone = AddTextField(
                main, "Phone Number", "079 XXX XXXX", 590, 370);

            // Academic Information
            AddHeading(main, "Academic Information", 445);

            AddLabel(main, "Discipline", 250, 490);
            // use Designer-declared cmbDiscipline control; configure and ensure it's parented to 'main'
            cmbDiscipline.Location = new Point(250, 520);
            cmbDiscipline.Size = new Size(310, 32);
            cmbDiscipline.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbDiscipline.Items.Clear();
            cmbDiscipline.Items.AddRange(new string[]
            {
                "Electrical Engineering",
                "Mechanical Engineering",
                "Civil Engineering",
                "Information Technology",
                "Computer Science"
            });

            cmbDiscipline.SelectedItem = "Electrical Engineering";
            if (cmbDiscipline.Parent != main)
                main.Controls.Add(cmbDiscipline);

            AddLabel(main, "Year of Study", 590, 490);
            // use Designer-declared cmbYear control; configure and ensure it's parented to 'main'
            cmbYear.Location = new Point(590, 520);
            cmbYear.Size = new Size(310, 32);
            cmbYear.DropDownStyle = ComboBoxStyle.DropDownList;

            cmbYear.Items.Clear();
            cmbYear.Items.AddRange(new string[]
            {
                "1st Year",
                "2nd Year",
                "3rd Year",
                "4th Year"
            });

            cmbYear.SelectedIndex = 1;
            if (cmbYear.Parent != main)
                main.Controls.Add(cmbYear);

            // Save button
            btnSave = new Button();
            btnSave.Text = "Save Changes";
            btnSave.Location = new Point(250, 590);
            btnSave.Size = new Size(180, 45);
            btnSave.BackColor = blue;
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Click += BtnSave_Click;
            main.Controls.Add(btnSave);

            // Cancel button
            btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.Location = new Point(450, 590);
            btnCancel.Size = new Size(140, 45);
            btnCancel.BackColor = Color.LightGray;
            btnCancel.ForeColor = Color.Black;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Click += (sender, e) => Close();
            main.Controls.Add(btnCancel);
        }

        private void AddHeading(
            Panel parent, string text, int y)
        {
            Label label = new Label();
            label.Text = text;
            label.Location = new Point(100, y);
            label.AutoSize = true;
            label.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            label.ForeColor = Color.FromArgb(55, 85, 125);
            parent.Controls.Add(label);
        }

        private void AddLabel(
            Panel parent, string text, int x, int y)
        {
            Label label = new Label();
            label.Text = text;
            label.Location = new Point(x, y);
            label.AutoSize = true;
            label.Font = new Font("Segoe UI", 10);
            label.ForeColor = Color.SlateGray;
            parent.Controls.Add(label);
        }

        private TextBox AddTextField(
            Panel parent, string labelText,
            string defaultValue, int x, int y)
        {
            AddLabel(parent, labelText, x, y);

            TextBox textBox = new TextBox();
            textBox.Text = defaultValue;
            textBox.Location = new Point(x, y + 25);
            textBox.Size = new Size(310, 30);
            textBox.Font = new Font("Segoe UI", 10);

            parent.Controls.Add(textBox);
            return textBox;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtStudentNumber.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show(
                    "Please complete all personal information fields.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            MessageBox.Show(
                "Profile information saved for this session.\n\n" +
                "Name: " + txtFullName.Text + "\n" +
                "Student Number: " + txtStudentNumber.Text + "\n" +
                "Email: " + txtEmail.Text + "\n" +
                "Phone: " + txtPhone.Text + "\n" +
                "Discipline: " + cmbDiscipline.Text + "\n" +
                "Year of Study: " + cmbYear.Text,
                "My Profile",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void StudentProfileForm_Load(object sender, EventArgs e)
        {

        }
    }
}

