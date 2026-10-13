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
    public partial class CoordinatorDashboard : Form
    {
        private readonly WIL__.AuthenticatedUser user;
        private readonly WIL__.OpportunitiesRepository repo = new WIL__.OpportunitiesRepository();
        // Parameterless constructor kept for designer and legacy callers
        public CoordinatorDashboard()
        {
            InitializeComponent();
        }

        // Runtime constructor used when a coordinator logs in
        public CoordinatorDashboard(WIL__.AuthenticatedUser user) : this()
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user));
            LoadOpportunities();
        }

        private void LoadOpportunities()
        {
            try
            {
                var list = repo.GetByCompanyUserId(user.UserID);
                // If the designer has a DataGridView named dataGridView1, bind to it
                var dg = this.Controls.Find("dataGridView1", true).FirstOrDefault() as DataGridView;
                if (dg != null)
                {
                    dg.DataSource = new BindingSource { DataSource = list };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to load coordinator opportunities: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
