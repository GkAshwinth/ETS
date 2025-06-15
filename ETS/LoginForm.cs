using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ETS
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogic_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();  // This is actually email
            string password = txtPassword.Text;

            // Email format validation using regex
            if (!Regex.IsMatch(username, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Please enter a valid email address.", "Invalid Email Format", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Database db = new Database();
            string query = $"SELECT * FROM Users WHERE email = '{username}'";

            try
            {
                DataTable result = db.ExecuteQuery(query);

                if (result.Rows.Count == 1)
                {
                    string savedPassword = result.Rows[0]["password"].ToString();

                    if (password == savedPassword)
                    {
                        MessageBox.Show("Login success!");
                        this.Hide();

                        string role = result.Rows[0]["role"].ToString();
                        int loggedInUserId = Convert.ToInt32(result.Rows[0]["id"]); //REMEMBER

                        if (role == "Attendee")
                        {
                            new AttendeeUI(loggedInUserId).Show();
                        }
                        else if (role == "Admin")
                        {
                            int id = Convert.ToInt32(result.Rows[0]["id"]);
                            string name = result.Rows[0]["name"].ToString();
                            string email = result.Rows[0]["email"].ToString();

                            User loggedInUser = new User(id, name, email, role);
                            new AdminForm(loggedInUser).Show();
                        }
                        else if (role == "EventManager")
                        {
                            new EventOrganizerForm().Show();
                        }
                        else
                        {
                            MessageBox.Show($"Logged in as {role}.");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Wrong password!");
                    }
                }
                else
                {
                    MessageBox.Show("Username not found!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during login: " + ex.Message);
            }
        }

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
            this.Hide();
        }
    }
}
