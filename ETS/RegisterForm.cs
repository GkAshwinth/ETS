using ETS.Controllers;
using ETS.Models;
using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ETS
{
    public partial class RegisterForm : Form
    {
        private readonly UserController userController = new UserController();

        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Validate input (optional but recommended)
            if (string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text) ||
                string.IsNullOrWhiteSpace(cmbRole.Text))
            {
                MessageBox.Show("⚠️ Please fill in all fields", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newUser = new User
            {
                Email = txtEmail.Text.Trim(),
                Name = txtName.Text.Trim(),
                Password = txtPassword.Text,
                PhoneNumber = txtPhone.Text.Trim(),
                Role = cmbRole.Text
            };


            if (userController.Register(newUser))
            {
                MessageBox.Show("✅ Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                new LoginForm().Show();
            }
            else
            {
                MessageBox.Show("❌ Email already exists", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
