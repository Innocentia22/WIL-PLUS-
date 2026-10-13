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
    public partial class MyApplications : Form
    {
        public MyApplications()
        {
            InitializeComponent();
        }

        private void btnMyApplications_Click(object sender, EventArgs e)
        {

        }

        // Optional method used by StudentDashboard to supply application records
        public void LoadApplications(System.Collections.Generic.List<WIL__.ApplicationRecord> apps)
        {
            try
            {
                dataGridView1.Rows.Clear();
                if (apps == null) return;

                var oppRepo = new WIL__.OpportunitiesRepository();
                foreach (var a in apps)
                {
                    string company = "";
                    string title = "";
                    try
                    {
                        // Use ApplicationsRepository helper to get joined details when available
                        var appsRepo = new WIL__.ApplicationsRepository();
                        var details = appsRepo.GetApplicationsWithDetails(a.StudentUserID);
                        var d = details.Find(x => x.ApplicationID == a.ApplicationID);
                        if (d != null)
                        {
                            title = d.OpportunityTitle;
                            company = d.CompanyName;
                        }
                    }
                    catch { }

                    dataGridView1.Rows.Add(company, title, "WIL", a.AppliedAt.ToString("yyyy/MM/dd"), a.Status, "");
                }
            }
            catch { }
        }
    }
}
