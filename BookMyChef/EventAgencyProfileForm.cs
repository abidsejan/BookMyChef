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
    public partial class EventAgencyProfileForm : Form
    {
        string username;
        public EventAgencyProfileForm(string userName)
        {
            this.username = userName;
            InitializeComponent();

            LoadDetails();
        }

        string connectionString = "data source=NISHAD\\SQLEXPRESS; database=BookMyChef; integrated security=SSPI";

        private void LoadDetails()
        {
            string query = "SELECT UserName, Phone, Name, Address From Users WHERE UserName = @UserName";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", username);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        
                        richTextBox1.Text = reader["UserName"].ToString();

                      
                        richTextBox1.ReadOnly = true;

                        NameField.Text = reader["Name"].ToString();
                        PhoneField.Text = reader["Phone"].ToString();
                        AddressField.Text = reader["Address"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("No details found for the given ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Close(); 
                    }
                }
            }
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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new EventAgencyHomeForm(username).Show();
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

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            string newName = NameField.Text.Trim();
            string newPhone = PhoneField.Text.Trim();
            string newAddress = AddressField.Text.Trim();

            
            if (string.IsNullOrWhiteSpace(newName) || string.IsNullOrWhiteSpace(newPhone) || string.IsNullOrWhiteSpace(newAddress))
            {
                MessageBox.Show("Name, Phone, and Address cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string updateQuery = "UPDATE Users SET Name = @Name, Phone = @Phone, Address = @Address WHERE UserName = @UserName";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    
                    command.Parameters.AddWithValue("@Name", newName);
                    command.Parameters.AddWithValue("@Phone", newPhone);
                    command.Parameters.AddWithValue("@Address", newAddress);
                    command.Parameters.AddWithValue("@UserName", username); 

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Profile updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Update failed. User not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}