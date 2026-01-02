using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookMyChef
{
    public partial class ClientHomeForm : Form
    {
        string username;

        public ClientHomeForm(string userName)
        {
            this.username = userName;
            InitializeComponent();
            
        }
        private void ClientHomeForm_Load(object sender, EventArgs e)
        {

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

        private void Home_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ClientPrivateChefForm(username).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ClientCatererForm(username).Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ClientEventForm(username).Show();
        }
    }
}