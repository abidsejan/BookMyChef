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
    public partial class ChefForm : Form
    {
        string username;
        public ChefForm(string userName)
        {
            this.username = userName;
            InitializeComponent();
            
        }
        public ChefForm()
        {
            InitializeComponent();
        }

        private void ChefForm_Load(object sender, EventArgs e)
        {
            WelcomeLabel.Text = "Welcome, " + username;

        }

        private void Bookings_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ChefRequestsForm(username).Show();
        }

        private void Home_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ChefHomeForm(username).Show();
        }

        private void History_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ChefHistoryForm(username).Show();
        }

        private void Profile_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ChefProfileForm(username).Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
