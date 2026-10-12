using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WILL__
{
    public partial class Opportunities_Coordinator : Form
    {
        public Opportunities_Coordinator()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Placements_coordinator placements = new Placements_coordinator();
            placements.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CoordinatorDashboard dashboard = new CoordinatorDashboard();
            dashboard.Show();
            this.Hide();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Student_for_coodinator students = new Student_for_coodinator();
            students.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Opportunities_Coordinator opportunities = new Opportunities_Coordinator();
            opportunities.Show();
            this.Hide();
        }

        private void Opportunities_Coordinator_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Applications_coordinator applications = new Applications_coordinator();
            applications.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Notifications_coordinator notifications = new Notifications_coordinator();
            notifications.Show();
            this.Hide();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void SearchOpportunities()
        {
            string searchText = txtSearch.Text.Trim();

            if (dataGridView1.DataSource is DataTable table)
            {
                table.DefaultView.RowFilter =
                    "Company LIKE '%" + searchText.Replace("", "") +
                    "%'OR [Opportunity Title] LIKE '%" +
                    searchText.Replace("", "") +
                    "%' OR Programme LIKE '%" +
                    searchText.Replace("", "") +
                    "$' OR location LIKE '%" +
                    searchText.Replace("", "") + "%'";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();

            this.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ApplyFilters();
        }

        private void ApplyFilters()
        {
            if (dataGridView1.DataSource is DataTable dt)
            {
                DataView view = dt.DefaultView;
                List<string> filters = new List<string>();

                if (comboBox1.SelectedIndex > 0)
                {
                    filters.Add("[Programme] = '" + comboBox1.Text.Replace("'", "''") + "'");
                }

                view.RowFilter = string.Join(" AND", filters);
            }
        }
    }
  }


