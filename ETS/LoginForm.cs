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

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
