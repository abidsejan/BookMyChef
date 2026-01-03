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
    public partial class CatererForm : Form
    {
        string username;

        public CatererForm(string userName)
        {
            this.username = userName;
            InitializeComponent();
        }

        private void CatererForm_Load(object sender, EventArgs e)
        {
            WelcomeLabel.Text = "Welcome, " + username;

        }

        private void Requests_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CatererRequestsForm(username).Show();
        }

        private void Home_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CatererHomeForm(username).Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Profile_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CatererProfileForm(username).Show();
        }

        private void History_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CatererHistoryForm(username).Show();
        }
    }
}
