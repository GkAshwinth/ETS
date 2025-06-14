using ETS.Models;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace ETS.Controllers
{
    public class UserController
    {
        private readonly Database db = new Database();

        // Register a new user
        public bool Register(User newUser)
        {
            try
            {
                using (var conn = db.OpenConnection())
                {
                    // Check if email already exists
                    string checkQuery = "SELECT COUNT(*) FROM users WHERE email = @Email";
                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@Email", newUser.Email);
                    long count = (long)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("⚠️ Email already exists!", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    // Insert new user
                    string insertQuery = @"
                        INSERT INTO users (email, name, password, phone, role)
                        VALUES (@Email, @Name, @Password, @PhoneNumber, @Role)";
                    MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@Email", newUser.Email);
                    insertCmd.Parameters.AddWithValue("@Name", newUser.Name);
                    insertCmd.Parameters.AddWithValue("@Password", newUser.Password);
                    insertCmd.Parameters.AddWithValue("@PhoneNumber", newUser.PhoneNumber);
                    insertCmd.Parameters.AddWithValue("@Role", newUser.Role);

                    int result = insertCmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Registration failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                db.CloseConnection();
            }
        }

        // Login user
        public User Login(string email, string password)
        {
            try
            {
                using (var conn = db.OpenConnection())
                {
                    string query = @"
                        SELECT * FROM users
                        WHERE email = @Email AND password = @Password";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Email = reader["email"].ToString(),
                                Name = reader["name"].ToString(),
                                Password = reader["password"].ToString(),
                                PhoneNumber = reader["phone"].ToString(),
                                Role = reader["role"].ToString()
                            };
                        }
                        else
                        {
                            return null; // Invalid credentials
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Login failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                db.CloseConnection();
            }
        }

        // Get user by ID
        public User GetUserById(int id)
        {
            try
            {
                using (var conn = db.OpenConnection())
                {
                    string query = "SELECT * FROM users WHERE id = @Id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Id", id);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                Email = reader["email"].ToString(),
                                Name = reader["name"].ToString(),
                                Password = reader["password"].ToString(),
                                PhoneNumber = reader["phone"].ToString(),
                                Role = reader["role"].ToString()
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Failed to get user: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                db.CloseConnection();
            }
        }
    }
}
