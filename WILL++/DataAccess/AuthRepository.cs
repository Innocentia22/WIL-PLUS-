using System;
using System.Security.Cryptography;
using Microsoft.Data.SqlClient;

namespace WIL__
{
    public sealed class AuthenticatedUser
    {
        public int UserID { get; set; }
        public string Email { get; set; } = string.Empty;
        public string UserType { get; set; } = string.Empty;
    }

    public class CompanyProfile
    {
        public int UserID { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string ContactPerson { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Industry { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }

    public class AuthRepository
    {
        private readonly DbConnection db = new DbConnection();

        public void RegisterStudent(string firstName, string lastName, string studentNumber, string email, string phone, string password, string discipline, int yearOfStudy)
        {
            using (SqlConnection con = db.GetConnection())
            {
                con.Open();
                using (SqlTransaction tx = con.BeginTransaction())
                {
                    try
                    {
                        int userId = InsertUser(con, tx, email, password, "Student");
                        string sql = @"INSERT INTO dbo.Students (UserID, StudentNumber, FirstName, LastName, PhoneNumber, Discipline, YearOfStudy) VALUES (@UserID, @StudentNumber, @FirstName, @LastName, @Phone, @Discipline, @YearOfStudy);";
                        using (SqlCommand cmd = new SqlCommand(sql, con, tx))
                        {
                            cmd.Parameters.AddWithValue("@UserID", userId);
                            cmd.Parameters.AddWithValue("@StudentNumber", studentNumber ?? string.Empty);
                            cmd.Parameters.AddWithValue("@FirstName", firstName ?? string.Empty);
                            cmd.Parameters.AddWithValue("@LastName", lastName ?? string.Empty);
                            cmd.Parameters.AddWithValue("@Phone", phone ?? string.Empty);
                            cmd.Parameters.AddWithValue("@Discipline", discipline ?? string.Empty);
                            cmd.Parameters.AddWithValue("@YearOfStudy", yearOfStudy);
                            cmd.ExecuteNonQuery();
                        }
                        tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }

        public void RegisterCoordinator(string firstName, string lastName, string staffNumber, string email, string phone, string department, string password)
        {
            using (SqlConnection con = db.GetConnection())
            {
                con.Open();
                using (SqlTransaction tx = con.BeginTransaction())
                {
                    try
                    {
                        int userId = InsertUser(con, tx, email, password, "Coordinator");
                        string sql = @"INSERT INTO dbo.Coordinators (UserID, FirstName, LastName, StaffNumber, Department, PhoneNumber) VALUES (@UserID, @FirstName, @LastName, @StaffNumber, @Department, @Phone);";
                        using (SqlCommand cmd = new SqlCommand(sql, con, tx))
                        {
                            cmd.Parameters.AddWithValue("@UserID", userId);
                            cmd.Parameters.AddWithValue("@FirstName", firstName ?? string.Empty);
                            cmd.Parameters.AddWithValue("@LastName", lastName ?? string.Empty);
                            cmd.Parameters.AddWithValue("@StaffNumber", staffNumber ?? string.Empty);
                            cmd.Parameters.AddWithValue("@Department", department ?? string.Empty);
                            cmd.Parameters.AddWithValue("@Phone", phone ?? string.Empty);
                            cmd.ExecuteNonQuery();
                        }
                        tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }

        public void RegisterCompany(string companyName, string contactPerson, string phone, string industry, string email, string password, string website, string address)
        {
            using (SqlConnection con = db.GetConnection())
            {
                con.Open();
                using (SqlTransaction tx = con.BeginTransaction())
                {
                    try
                    {
                        int userId = InsertUser(con, tx, email, password, "Company");
                        string sql = @"INSERT INTO dbo.Companies (UserID, CompanyName, ContactPerson, PhoneNumber, Industry, Website, Address) VALUES (@UserID, @CompanyName, @ContactPerson, @Phone, @Industry, @Website, @Address);";
                        using (SqlCommand cmd = new SqlCommand(sql, con, tx))
                        {
                            cmd.Parameters.AddWithValue("@UserID", userId);
                            cmd.Parameters.AddWithValue("@CompanyName", companyName ?? string.Empty);
                            cmd.Parameters.AddWithValue("@ContactPerson", contactPerson ?? string.Empty);
                            cmd.Parameters.AddWithValue("@Phone", phone ?? string.Empty);
                            cmd.Parameters.AddWithValue("@Industry", industry ?? string.Empty);
                            cmd.Parameters.AddWithValue("@Website", website ?? string.Empty);
                            cmd.Parameters.AddWithValue("@Address", address ?? string.Empty);
                            cmd.ExecuteNonQuery();
                        }
                        tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }

        public void RegisterAdministrator(string email, string password)
        {
            using (SqlConnection con = db.GetConnection())
            {
                con.Open();
                using (SqlTransaction tx = con.BeginTransaction())
                {
                    try
                    {
                        InsertUser(con, tx, email, password, "Administrator");
                        tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }

        private int InsertUser(SqlConnection con, SqlTransaction tx, string email, string password, string userType)
        {
            string sql = @"INSERT INTO dbo.Users (Email, PasswordHash, UserType, IsActive, CreatedAt) VALUES (@Email, @PasswordHash, @UserType, 1, GETDATE()); SELECT CAST(SCOPE_IDENTITY() AS INT);";
            using (SqlCommand cmd = new SqlCommand(sql, con, tx))
            {
                cmd.Parameters.AddWithValue("@Email", email?.Trim() ?? string.Empty);
                cmd.Parameters.AddWithValue("@PasswordHash", HashPassword(password));
                cmd.Parameters.AddWithValue("@UserType", userType ?? string.Empty);
                object res = cmd.ExecuteScalar();
                return Convert.ToInt32(res);
            }
        }

        private static string HashPassword(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(16);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password ?? string.Empty, salt, 100_000, HashAlgorithmName.SHA256, 32);
            return Convert.ToBase64String(salt) + "." + Convert.ToBase64String(hash);
        }

        private static bool VerifyPassword(string password, string storedValue)
        {
            var parts = storedValue?.Split('.') ?? Array.Empty<string>();
            if (parts.Length != 2) return false;
            byte[] salt = Convert.FromBase64String(parts[0]);
            byte[] expected = Convert.FromBase64String(parts[1]);
            byte[] actual = Rfc2898DeriveBytes.Pbkdf2(password ?? string.Empty, salt, 100_000, HashAlgorithmName.SHA256, 32);
            return CryptographicOperations.FixedTimeEquals(actual, expected);
        }

        public AuthenticatedUser Login(string email, string password)
        {
            using (SqlConnection con = db.GetConnection())
            {
                con.Open();
                string sql = @"SELECT UserID, Email, PasswordHash, UserType, IsActive FROM dbo.Users WHERE Email = @Email";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email?.Trim() ?? string.Empty);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            bool isActive = !reader.IsDBNull(reader.GetOrdinal("IsActive")) && reader.GetBoolean(reader.GetOrdinal("IsActive"));
                            if (!isActive) return null;
                            string stored = reader.GetString(reader.GetOrdinal("PasswordHash"));
                            if (VerifyPassword(password, stored))
                            {
                                return new AuthenticatedUser
                                {
                                    UserID = reader.GetInt32(reader.GetOrdinal("UserID")),
                                    Email = reader.GetString(reader.GetOrdinal("Email")),
                                    UserType = reader.GetString(reader.GetOrdinal("UserType"))
                                };
                            }
                        }
                    }
                }
            }
            return null;
        }

        public CompanyProfile GetCompanyByUserId(int userId)
        {
            using (SqlConnection con = db.GetConnection())
            {
                con.Open();
                string sql = @"SELECT CompanyName, ContactPerson, PhoneNumber, Industry, Website, Address FROM dbo.Companies WHERE UserID = @UserID";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@UserID", userId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new CompanyProfile
                            {
                                UserID = userId,
                                CompanyName = reader.IsDBNull(0) ? string.Empty : reader.GetString(0),
                                ContactPerson = reader.IsDBNull(1) ? string.Empty : reader.GetString(1),
                                PhoneNumber = reader.IsDBNull(2) ? string.Empty : reader.GetString(2),
                                Industry = reader.IsDBNull(3) ? string.Empty : reader.GetString(3),
                                Website = reader.IsDBNull(4) ? string.Empty : reader.GetString(4),
                                Address = reader.IsDBNull(5) ? string.Empty : reader.GetString(5)
                            };
                        }
                    }
                }
            }
            return null;
        }

        public void UpdateCompanyProfile(CompanyProfile profile)
        {
            using (SqlConnection con = db.GetConnection())
            {
                con.Open();
                string sql = @"UPDATE dbo.Companies SET CompanyName = @CompanyName, ContactPerson = @ContactPerson, PhoneNumber = @PhoneNumber, Industry = @Industry, Website = @Website, Address = @Address WHERE UserID = @UserID";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@CompanyName", profile.CompanyName ?? string.Empty);
                    cmd.Parameters.AddWithValue("@ContactPerson", profile.ContactPerson ?? string.Empty);
                    cmd.Parameters.AddWithValue("@PhoneNumber", profile.PhoneNumber ?? string.Empty);
                    cmd.Parameters.AddWithValue("@Industry", profile.Industry ?? string.Empty);
                    cmd.Parameters.AddWithValue("@Website", profile.Website ?? string.Empty);
                    cmd.Parameters.AddWithValue("@Address", profile.Address ?? string.Empty);
                    cmd.Parameters.AddWithValue("@UserID", profile.UserID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
