using System;
using System.Windows.Forms;

namespace ETS
{
    public partial class AdminViewEventsForm : Form
    {
        private User loggedInUser;

        public AdminViewEventsForm(User user)
        {
            InitializeComponent();
            loggedInUser = user;
        }
    }
}
