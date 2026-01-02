using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookMyChef
{
    public partial class EventAgencyHomeForm : Form
    {
        string username;

        public EventAgencyHomeForm(string userName)
        {
            InitializeComponent();
            this.username = userName;
        }

        private void CreateMenuButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new EventAgencyCreatePackageForm(username).Show();
        }

        private void ViewmenuButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new EventAgencyViewPackageForm(username).Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void Bookings_Click(object sender, EventArgs e)
        {
            this.Hide();
            new EventAgencyRequestForm(username).Show();
        }

        private void History_Click(object sender, EventArgs e)
        {
            this.Hide();
            new EventAgencyHistoryForm(username).Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new EventAgencyProfileForm(username).Show();
        }

    }
}
       