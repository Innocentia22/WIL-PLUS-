
using System;
using System.Windows.Forms;

namespace WIL__
{
    public static class DatabaseTest
    {
        public static void Run()
        {
            DbConnection db = new DbConnection();

            if (db.TestConnection())
            {
                MessageBox.Show(
                    "Connected successfully to WILPlusDB!",
                    "Database Connection",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }
    }
}
