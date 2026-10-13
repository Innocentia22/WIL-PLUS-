using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

namespace WIL__
{
    public class Opportunity
    {
        public int OpportunityID { get; set; }
        public int UserID { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public string Course { get; set; } = "";
        public string Location { get; set; } = "";
        public string Industry { get; set; } = "";
        public DateTime PostedAt { get; set; }
        public DateTime? ClosingDate { get; set; }
        public bool IsActive { get; set; }
    }

    public class OpportunitiesRepository
    {
        private readonly DbConnection db = new DbConnection();

        public List<Opportunity> GetAllActive()
        {
            var list = new List<Opportunity>();
            const string sql = @"
                SELECT OpportunityID, UserID, Title, Description, Course, Location, Industry, PostedAt, ClosingDate, IsActive
                FROM dbo.Opportunities
                WHERE IsActive = 1
                ORDER BY PostedAt DESC";

            using (SqlConnection con = db.GetConnection())
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var opp = new Opportunity
                            {
                                OpportunityID = reader.GetInt32(reader.GetOrdinal("OpportunityID")),
                                UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                                Title = reader.GetString(reader.GetOrdinal("Title")),
                                Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? "" : reader.GetString(reader.GetOrdinal("Description")),
                                Course = reader.IsDBNull(reader.GetOrdinal("Course")) ? "" : reader.GetString(reader.GetOrdinal("Course")),
                                Location = reader.IsDBNull(reader.GetOrdinal("Location")) ? "" : reader.GetString(reader.GetOrdinal("Location")),
                                Industry = reader.IsDBNull(reader.GetOrdinal("Industry")) ? "" : reader.GetString(reader.GetOrdinal("Industry")),
                                PostedAt = reader.GetDateTime(reader.GetOrdinal("PostedAt")),
                                ClosingDate = reader.IsDBNull(reader.GetOrdinal("ClosingDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("ClosingDate")),
                                IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"))
                            };

                            list.Add(opp);
                        }
                    }
                }
            }

            return list;
        }

        public int CreateOpportunity(Opportunity opp)
        {
            const string sql = @"
                INSERT INTO dbo.Opportunities
                (UserID, Title, Description, Course, Location, Industry, PostedAt, ClosingDate, IsActive)
                VALUES
                (@UserID, @Title, @Description, @Course, @Location, @Industry, @PostedAt, @ClosingDate, @IsActive);
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using (SqlConnection con = db.GetConnection())
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@UserID", opp.UserID);
                    cmd.Parameters.AddWithValue("@Title", opp.Title);
                    cmd.Parameters.AddWithValue("@Description", (object)opp.Description ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Course", (object)opp.Course ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Location", (object)opp.Location ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Industry", (object)opp.Industry ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@PostedAt", opp.PostedAt);
                    cmd.Parameters.AddWithValue("@ClosingDate", opp.ClosingDate.HasValue ? (object)opp.ClosingDate.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsActive", opp.IsActive ? 1 : 0);

                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        public List<Opportunity> GetByCompanyUserId(int userId)
        {
            var list = new List<Opportunity>();
            const string sql = @"
                SELECT OpportunityID, UserID, Title, Description, Course, Location, Industry, PostedAt, ClosingDate, IsActive
                FROM dbo.Opportunities
                WHERE UserID = @UserID
                ORDER BY PostedAt DESC";

            using (SqlConnection con = db.GetConnection())
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var opp = new Opportunity
                            {
                                OpportunityID = reader.GetInt32(reader.GetOrdinal("OpportunityID")),
                                UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                                Title = reader.GetString(reader.GetOrdinal("Title")),
                                Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? "" : reader.GetString(reader.GetOrdinal("Description")),
                                Course = reader.IsDBNull(reader.GetOrdinal("Course")) ? "" : reader.GetString(reader.GetOrdinal("Course")),
                                Location = reader.IsDBNull(reader.GetOrdinal("Location")) ? "" : reader.GetString(reader.GetOrdinal("Location")),
                                Industry = reader.IsDBNull(reader.GetOrdinal("Industry")) ? "" : reader.GetString(reader.GetOrdinal("Industry")),
                                PostedAt = reader.GetDateTime(reader.GetOrdinal("PostedAt")),
                                ClosingDate = reader.IsDBNull(reader.GetOrdinal("ClosingDate")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("ClosingDate")),
                                IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive"))
                            };

                            list.Add(opp);
                        }
                    }
                }
            }

            return list;
        }
    }
}
