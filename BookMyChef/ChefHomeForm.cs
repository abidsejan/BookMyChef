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
    public partial class ChefHomeForm : Form
    {
       string username;

        public ChefHomeForm(string userName)
        {
            this.username = userName;
            InitializeComponent();
            
        }

        private void Bookings_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ChefRequestsForm(username).Show();
        }

        private void History_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ChefHistoryForm(username).Show();
        }

        private void Home_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ChefCreateProfileForm(username).Show();
        }
         
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ChefShowDetailsForm(username).Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Profile_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ChefProfileForm(username).Show();
        }
    }
}