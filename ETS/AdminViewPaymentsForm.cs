using System;
using System.Windows.Forms;

namespace ETS
{
    public partial class AdminViewPaymentsForm : Form
    {
        private User loggedInUser;

        public AdminViewPaymentsForm(User user)
        {
            InitializeComponent();
            loggedInUser = user;
        }
    }
}
