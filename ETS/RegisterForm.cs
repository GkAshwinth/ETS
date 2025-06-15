using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ETS
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtNewUsername.Text.Trim(); // Used as both name and email
            string password = txtNewPassword.Text;

            // Email format validation
            if (!Regex.IsMatch(username, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Please enter a valid email address.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Name validation (should not contain numbers)
            if (Regex.IsMatch(username, @"\d"))
            {
                MessageBox.Show("Username (name/email) should not contain numbers.", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Database db = new Database();

            try
            {
                // Check if the email already exists
                string checkQuery = $"SELECT * FROM Users WHERE email = '{username}'";
                DataTable result = db.ExecuteQuery(checkQuery);

                if (result.Rows.Count > 0)
                {
                    MessageBox.Show("Username (email) already exists!");
                }
                else
                {
                    // Default role: Attendee
                    string insertQuery = $"INSERT INTO Users (name, email, password, phone, role) " +
                                         $"VALUES ('{username}', '{username}', '{password}', '', 'Attendee')";

                    bool success = db.ExecuteNonQuery(insertQuery);

                    if (success)
                    {
                        MessageBox.Show("Registration success!");
                        this.Close(); // Close the registration form
                    }
                    else
                    {
                        MessageBox.Show("Registration failed. Try again.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during registration: " + ex.Message);
            }
        }

        private void linkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }
    }
}
