using System;
using System.Windows.Forms;
using ETS.Controllers;

namespace ETS
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            new LoginForm(new UserController()).Show();
        }
    }
}