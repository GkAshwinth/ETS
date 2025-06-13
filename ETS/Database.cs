using System;
<<<<<<< HEAD
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETS
{
    class Database
    {
=======
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ETS
{
    public class Database
    {
        // Connection string for connecting to MySQL (update credentials/database name if needed)
        private readonly string connectionString = "server=localhost;port=3306;uid=root;pwd=;database=event_ticketing_system;";
        private MySqlConnection connection;

        // Constructor
        public Database()
        {
            connection = new MySqlConnection(connectionString);
        }

        // Open the database connection
        public MySqlConnection OpenConnection()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to open MySQL connection: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return connection;
        }

        // Close the database connection
        public void CloseConnection()
        {
            try
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to close MySQL connection: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Execute SELECT queries and return results as DataTable
        public DataTable ExecuteQuery(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, OpenConnection());
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Query execution failed: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseConnection();
            }
            return dt;
        }

        // Execute INSERT, UPDATE, DELETE queries
        public bool ExecuteNonQuery(string query)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, OpenConnection());
                int result = cmd.ExecuteNonQuery();
                return result > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Command execution failed: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

        // Return the raw connection if needed externally
        public MySqlConnection GetRawConnection()
        {
            return connection;
        }
>>>>>>> 3d206b5a789be2524e67117460c6bb69055b4620
    }
}
