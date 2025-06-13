using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            string username = txtNewUsername.Text.Trim(); // Used as email
            string password = txtNewPassword.Text;

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
