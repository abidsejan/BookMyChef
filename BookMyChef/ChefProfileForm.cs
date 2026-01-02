using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace BookMyChef
{
    public partial class ChefProfileForm : Form
    {
        string username;

        string connectionString =
            "data source=NISHAD\\SQLEXPRESS; database=BookMyChef; integrated security=SSPI";

        public ChefProfileForm(string userName)
        {
            InitializeComponent();
            this.username = userName;
            LoadDetails();

           
            UsernameField.ReadOnly = true;
        }

        private void LoadDetails()
        {
            string query = @"SELECT UserName, Phone, Name, Address 
                             FROM Users 
                             WHERE UserName = @UserName";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserName", username);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    UsernameField.Text = reader["UserName"].ToString();
                    NameField.Text = reader["Name"].ToString();
                    PhoneField.Text = reader["Phone"].ToString();
                    AddressField.Text = reader["Address"].ToString();
                }
                else
                {
                    MessageBox.Show(
                        "No details found for the given user.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = NameField.Text.Trim();
            string phone = PhoneField.Text.Trim();
            string address = AddressField.Text.Trim();

            
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(phone) ||
                string.IsNullOrWhiteSpace(address))
            {
                MessageBox.Show(
                    "Please fill all fields before updating.",
                    "Validation Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string query = @"UPDATE Users
                             SET Name = @Name,
                                 Phone = @Phone,
                                 Address = @Address
                             WHERE UserName = @UserName";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@Address", address);
                    command.Parameters.AddWithValue("@UserName", username);

                    connection.Open();
                    int rows = command.ExecuteNonQuery();

                    if (rows > 0)
                    {
                        MessageBox.Show(
                            "Profile updated successfully!",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(
                            "Profile update failed.",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error updating profile:\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }
    }
}
