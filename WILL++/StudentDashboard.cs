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
    public partial class StudentDashboard : Form
    {
        private readonly WIL__.AuthenticatedUser studentUser;

        public StudentDashboard()
        {
            InitializeComponent();
        }

        // Runtime constructor used when a student logs in
        public StudentDashboard(WIL__.AuthenticatedUser user) : this()
        {
            studentUser = user;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You are already on the Dashboard.");
        }

        private void btnFindOpportunities_Click(object sender, EventArgs e)
        {
            // Pass authenticated student to the finder so they can apply
            FindOpportunitiesForms form = new FindOpportunitiesForms(studentUser);
            form.Show();
        }

        private void btnMyApplications_Click(object sender, EventArgs e)
        {
            // Open MyApplications and load current student's applications
            var form = new MyApplications();
            // provide a simple method to load by student id if available
            if (studentUser != null)
            {
                try
                {
                    var repo = new WIL__.ApplicationsRepository();
                    var apps = repo.GetByStudentUserId(studentUser.UserID);
                    // if MyApplications has a public method to accept data, call it
                    var mi = form.GetType().GetMethod("LoadApplications");
                    if (mi != null)
                    {
                        mi.Invoke(form, new object[] { apps });
                    }
                }
                catch
                {
                    // ignore – the form can load independently
                }
            }

            form.Show();
        }

        private void btnMyProfile_Click(object sender, EventArgs e)
        {
            StudentProfileForm form = new StudentProfileForm();
            // If we have the authenticated student, we can try to populate the profile
            try
            {
                var mi = form.GetType().GetMethod("LoadProfile");
                if (mi != null && studentUser != null)
                {
                    mi.Invoke(form, new object[] { studentUser.UserID });
                }
            }
            catch { }
            form.Show();
        }

        private void btnNotifications_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Notifications page selected.");
        }


        // The FindOpportunitiesForms type is defined in its own file (FindOpportunitiesForms.cs).

        private void btnFindOpportunities_Click_1(object sender, EventArgs e)
        {
            // Designer event fallback – pass the student if available
            FindOpportunitiesForms form = new FindOpportunitiesForms(studentUser);
            form.Show();
        }

        private void btnMyApplications_Click_1(object sender, EventArgs e)
        {
            MyApplications form = new MyApplications();
            if (studentUser != null)
            {
                try
                {
                    var repo = new WIL__.ApplicationsRepository();
                    var apps = repo.GetByStudentUserId(studentUser.UserID);
                    var mi = form.GetType().GetMethod("LoadApplications");
                    if (mi != null)
                    {
                        mi.Invoke(form, new object[] { apps });
                    }
                }
                catch { }
            }
            form.Show();
            this.Hide();
        }

        private void btnMyProfile_Click_1(object sender, EventArgs e)
        {
            StudentProfileForm form = new StudentProfileForm();
            try
            {
                var mi = form.GetType().GetMethod("LoadProfile");
                if (mi != null && studentUser != null)
                {
                    mi.Invoke(form, new object[] { studentUser.UserID });
                }
            }
            catch { }
            form.Show();
            this.Hide();
        }
    }
}

    


    

