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
    public partial class EventAgencyForm : Form
    {
        string username;

        public EventAgencyForm(string userName)
        {
            this.username = userName;
            InitializeComponent();
        }

        private void EventAgency_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Home_Click(object sender, EventArgs e)
        {
            this.Hide();
            new EventAgencyHomeForm(username).Show();
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
