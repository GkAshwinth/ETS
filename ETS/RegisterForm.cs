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
            string username = txtNewUsername.Text;
            string password = txtNewPassword.Text;

            if (FakeDatabase.Users.ContainsKey(username))
            {
                MessageBox.Show("Username already exists!");
            }
            else
            {
                FakeDatabase.Users.Add(username, password); // Store plain password (not secure)
                MessageBox.Show("Registration success!");
                this.Close();
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
