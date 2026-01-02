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
    public partial class CatererHomeForm : Form
    {
        string username;
        public CatererHomeForm(string userName)
        {
            this.username = userName;
            InitializeComponent();
        }

        private void CreateMenuButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CatererCreateMenuForm(username).Show();
        }

        private void ViewmenuButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CatererViewMenuForm(username).Show();
        }

        private void Home_Click(object sender, EventArgs e)
        {

        }

        private void Requests_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CatererRequestsForm(username).Show();
        }

        private void History_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CatererHistoryForm(username).Show();
        }

        private void Profile_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CatererProfileForm(username).Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
