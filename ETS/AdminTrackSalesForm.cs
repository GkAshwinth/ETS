using System;
using System.Windows.Forms;
using ETS.Models;

namespace ETS
{
    public partial class AdminTrackSalesForm : Form
    {
        private User loggedInUser;

        public AdminTrackSalesForm(User user)
        {
            InitializeComponent();
            loggedInUser = user;
        }
    }
}
