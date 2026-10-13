using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace WIL__
{
    public class ApplicationRecord
    {
        public int ApplicationID { get; set; }
        public int OpportunityID { get; set; }
        public int StudentUserID { get; set; }
        public DateTime AppliedAt { get; set; }
        public string Status { get; set; } = string.Empty;
    }

    public class ApplicationsRepository
    {
        private readonly DbConnection db = new DbConnection();

        public class ApplicationDetails
        {
            public int ApplicationID { get; set; }
            public int OpportunityID { get; set; }
            public int StudentUserID { get; set; }
            public DateTime AppliedAt { get; set; }
            public string Status { get; set; } = string.Empty;
            public string OpportunityTitle { get; set; } = string.Empty;
            public string CompanyName { get; set; } = string.Empty;
            public DateTime? ClosingDate { get; set; }
        }

        public int CreateApplication(int opportunityId, int studentUserId)
        {
            const string sql = @"INSERT INTO dbo.Applications (OpportunityID, StudentUserID, AppliedAt, Status) VALUES (@OpportunityID, @StudentUserID, GETDATE(), 'Applied'); SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using (SqlConnection con = db.GetConnection())
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@OpportunityID", opportunityId);
                    cmd.Parameters.AddWithValue("@StudentUserID", studentUserId);
                    object res = cmd.ExecuteScalar();
                    return Convert.ToInt32(res);
                }
            }
        }

        // Returns application rows joined to opportunity title and company name for display
        public List<ApplicationDetails> GetApplicationsWithDetails(int studentUserId)
        {
            var list = new List<ApplicationDetails>();
            const string sql = @"
                SELECT a.ApplicationID, a.OpportunityID, a.StudentUserID, a.AppliedAt, a.Status,
                       o.Title AS OpportunityTitle, c.CompanyName, o.ClosingDate
                FROM dbo.Applications a
                LEFT JOIN dbo.Opportunities o ON a.OpportunityID = o.OpportunityID
                LEFT JOIN dbo.Companies c ON o.UserID = c.UserID
                WHERE a.StudentUserID = @StudentUserID
                ORDER BY a.AppliedAt DESC";

            using (SqlConnection con = db.GetConnection())
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@StudentUserID", studentUserId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new ApplicationDetails
                            {
                                ApplicationID = reader.GetInt32(reader.GetOrdinal("ApplicationID")),
                                OpportunityID = reader.GetInt32(reader.GetOrdinal("OpportunityID")),
                                StudentUserID = reader.GetInt32(reader.GetOrdinal("StudentUserID")),
                                AppliedAt = reader.GetDateTime(reader.GetOrdinal("AppliedAt")),
                                Status = reader.IsDBNull(reader.GetOrdinal("Status")) ? string.Empty : reader.GetString(reader.GetOrdinal("Status")),
                                OpportunityTitle = reader.IsDBNull(reader.GetOrdinal("OpportunityTitle")) ? string.Empty : reader.GetString(reader.GetOrdinal("OpportunityTitle")),
                                CompanyName = reader.IsDBNull(reader.GetOrdinal("CompanyName")) ? string.Empty : reader.GetString(reader.GetOrdinal("CompanyName")),
                                ClosingDate = reader.IsDBNull(reader.GetOrdinal("ClosingDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("ClosingDate"))
                            });
                        }
                    }
                }
            }

            return list;
        }

        public List<ApplicationRecord> GetByStudentUserId(int studentUserId)
        {
            var list = new List<ApplicationRecord>();
            const string sql = @"SELECT ApplicationID, OpportunityID, StudentUserID, AppliedAt, Status FROM dbo.Applications WHERE StudentUserID = @StudentUserID ORDER BY AppliedAt DESC";

            using (SqlConnection con = db.GetConnection())
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@StudentUserID", studentUserId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new ApplicationRecord
                            {
                                ApplicationID = reader.GetInt32(reader.GetOrdinal("ApplicationID")),
                                OpportunityID = reader.GetInt32(reader.GetOrdinal("OpportunityID")),
                                StudentUserID = reader.GetInt32(reader.GetOrdinal("StudentUserID")),
                                AppliedAt = reader.GetDateTime(reader.GetOrdinal("AppliedAt")),
                                Status = reader.IsDBNull(reader.GetOrdinal("Status")) ? string.Empty : reader.GetString(reader.GetOrdinal("Status"))
                            });
                        }
                    }
                }
            }

            return list;
        }
    }
}
