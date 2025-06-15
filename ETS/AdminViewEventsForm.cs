using System;
using System.Windows.Forms;

namespace ETS
{
    public partial class AdminViewEventsForm : Form
    {
        private User loggedInUser;
        private AdminController adminController;

        public AdminViewEventsForm(User user)
        {
            InitializeComponent();
            loggedInUser = user;
            adminController = new AdminController();
        }

        private void AdminViewEventsForm_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridViewEvents.DataSource = adminController.GetAllEvents();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load events: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
