using ETS.Models;
using System;
using System.Windows.Forms;

namespace ETS
{
    public partial class MainForm : Form
    {
        private readonly User currentUser;

        public MainForm(User user)
        {
            InitializeComponent();
            currentUser = user;

            // Set welcome message
            lblWelcome.Text = $"Welcome, {currentUser.Name}!";
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            new LoginForm().Show();
        }
    }
}
