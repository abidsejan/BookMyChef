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
    public partial class ClientForm : Form
    {
        string username;

        public ClientForm(string userName)
        {
            InitializeComponent();
            this.username = userName;
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Home_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ClientHomeForm(username).Show();
        }

        private void Bookings_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ClientBookingForm(username).Show();
        }

        private void History_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ClientHistoryForm(username).Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ClientProfileForm(username).Show();
        }
    }
}
