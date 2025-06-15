using System;
using System.Windows.Forms;

namespace ETS
{
    public partial class AdminTrackSalesForm : Form
    {
        private User loggedInUser;
        private AdminController adminController;

        public AdminTrackSalesForm(User user)
        {
            InitializeComponent();
            loggedInUser = user;
            adminController = new AdminController();
        }

        private void AdminTrackSalesForm_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridViewSales.DataSource = adminController.GetSalesReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load sales report: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
