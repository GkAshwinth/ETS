using ETS.Controllers;
using ETS.Models;
using System;
using System.Windows.Forms;

namespace ETS
{
    public partial class LoginForm : Form
    {
        private readonly UserController userController = new UserController();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            // Attempt login using UserController
            User loggedInUser = userController.Login(email, password);

            if (loggedInUser != null)
            {
                MessageBox.Show("✅ Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();

                // Optional: Pass loggedInUser to MainForm if needed
                new MainForm(loggedInUser).Show();
            }
            else
            {
                MessageBox.Show("❌ Invalid credentials", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            new RegisterForm().Show();  // No need to pass controller if it is created internally
        }
    }
}
