using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace BookMyChef
{
    public partial class ChefCreateProfileForm : Form
    {
        string username;
        public ChefCreateProfileForm(string userName)
        {
            this.username = userName;
            InitializeComponent();
        }

        public ChefCreateProfileForm()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connectionString =
                "data source=NISHAD\\SQLEXPRESS; database=BookMyChef; integrated security=SSPI";

            string specialty = SpecialityField.Text.Trim();
            string yoeText = YOEfield.Text.Trim();
            string serviceArea = ServiceAreaField.Text.Trim();
            string cuisines = CuisinesField.Text.Trim();
            string priceText = priceperheadfield.Text.Trim();

            if (string.IsNullOrWhiteSpace(specialty) ||
                string.IsNullOrWhiteSpace(yoeText) ||
                string.IsNullOrWhiteSpace(serviceArea) ||
                string.IsNullOrWhiteSpace(cuisines) ||
                string.IsNullOrWhiteSpace(priceText))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(yoeText, out int yoe))
            {
                MessageBox.Show("Years of experience must be a valid number.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(priceText, out decimal pricePerHead))
            {
                MessageBox.Show("Price per head must be a valid amount.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"INSERT INTO Chef (UserName, Specialty, YOE, ServiceArea, Cuisines, PricePerHead) VALUES (@UserName, @Specialty, @YOE, @ServiceArea, @Cuisines, @PricePerHead)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.Add("@UserName", SqlDbType.NVarChar, 50).Value = username;
                command.Parameters.Add("@Specialty", SqlDbType.NVarChar, 100).Value = specialty;
                command.Parameters.Add("@YOE", SqlDbType.Int).Value = yoe;
                command.Parameters.Add("@ServiceArea", SqlDbType.NVarChar, 100).Value = serviceArea;
                command.Parameters.Add("@Cuisines", SqlDbType.NVarChar, 200).Value = cuisines;
                command.Parameters.Add("@PricePerHead", SqlDbType.Decimal).Value = pricePerHead;

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Chef profile created successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();
                    new ChefHomeForm(username).Show();
                }
                else
                {
                    MessageBox.Show("Failed to create profile.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Profile_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ChefProfileForm(username).Show();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ChefHomeForm(username).Show();
        }
    }
}
