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
    public partial class AttendeeUI: Form
    {
        public AttendeeUI()
        {
            InitializeComponent();
        }

        private void ViewAndRegisterButton_Click(object sender, EventArgs e)
        {
            AttendeeViewAndRegisterUI viewAndRegisterUI = new AttendeeViewAndRegisterUI();
            viewAndRegisterUI.Show();
            this.Hide();
        }
    }
}
