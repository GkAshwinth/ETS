using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ETS
{
    public class Database
    {
        private readonly string connectionString = "server=localhost;port=3306;uid=root;pwd=;database=event_ticketing_system;";
        private MySqlConnection connection;

        public Database()
        {
            connection = new MySqlConnection(connectionString);
        }

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
                MessageBox.Show("❌ Failed to open MySQL connection: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return connection;
        }

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
                MessageBox.Show("❌ Failed to close MySQL connection: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
                MessageBox.Show("❌ Query execution failed: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseConnection();
            }
            return dt;
        }

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
                MessageBox.Show("❌ Command execution failed: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

        public MySqlConnection GetRawConnection()
        {
            return connection;
        }
    }
}