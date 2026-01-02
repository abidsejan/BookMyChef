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
    public partial class AdminForm : Form
    {
        public AdminForm(int v)
        {
            InitializeComponent();
        }
        public AdminForm()
        {
            InitializeComponent();
        }

        public AdminForm(string userName)
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to log out?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                this.Hide();
                new SignInForm().Show();
            }
        }

        private void CreateMenuButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AdminControlForm().Show();
        }

        private void ViewmenuButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AdminAnalyticsForm().Show();
        }
    }
}