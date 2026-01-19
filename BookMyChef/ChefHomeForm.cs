using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
            string connectionString =
                "data source=NISHAD\\SQLEXPRESS; database=BookMyChef; integrated security=SSPI";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string checkQuery = "SELECT COUNT(*) FROM Chef WHERE UserName = @UserName";

                using (SqlCommand command = new SqlCommand(checkQuery, connection))
                {
                    command.Parameters.AddWithValue("@UserName", username);

                    connection.Open();
                    int profileCount = (int)command.ExecuteScalar();

                    if (profileCount == 0)
                    {
                        MessageBox.Show(
                            "There is no profile. Please create a profile.",
                            "Profile Not Found",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );

                        this.Hide();
                        new ChefCreateProfileForm(username).Show();
                    }
                    else
                    {
                        this.Hide();
                        new ChefShowDetailsForm(username).Show();
                    }
                }
            }
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