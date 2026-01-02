using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BookMyChef
{
    public partial class ChefShowDetailsForm : Form
    {
        string username;

        string connectionString =
            "data source=NISHAD\\SQLEXPRESS; database=BookMyChef; integrated security=SSPI";

        public ChefShowDetailsForm(string userName)
        {
            this.username = userName;
            InitializeComponent();
            LoadDetails();
        }

       
        private void LoadDetails()
        {
            string query = @"SELECT UserName, Specialty, YOE, ServiceArea, 
                                    Cuisines, PricePerHead 
                             FROM Chef 
                             WHERE UserName = @UserName";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserName", username);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    SpecialityField.Text = reader["Specialty"].ToString();
                    YOEfield.Text = reader["YOE"].ToString();
                    ServiceAreaField.Text = reader["ServiceArea"].ToString();
                    CuisinesField.Text = reader["Cuisines"].ToString();
                    priceperheadfield.Text = reader["PricePerHead"].ToString();
                }
                else
                {
                    MessageBox.Show("No profile found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
        }

        
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to delete your profile?\nThis action cannot be undone.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            string deleteQuery = "DELETE FROM Chef WHERE UserName = @UserName";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(deleteQuery, connection))
            {
                command.Parameters.AddWithValue("@UserName", username);
                connection.Open();

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Profile deleted successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    this.Hide();
                    new ChefHomeForm(username).Show();
                }
                else
                {
                    MessageBox.Show("Failed to delete profile.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        
        private void Home_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ChefHomeForm(username).Show();
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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ChefHomeForm(username).Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ChefProfileForm(username).Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e) { }
    }
}
