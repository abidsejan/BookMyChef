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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BookMyChef
{
    public partial class SignupForm : Form
    {
        public SignupForm()
        {
            InitializeComponent();

        }

        private void SignupForm_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignInForm f1 = new SignInForm();
            f1.Show();

        }

        private void Signup_Click(object sender, EventArgs e)
        {
            string connectionString = "data source=NISHAD\\SQLEXPRESS; database=BookMyChef; integrated security=SSPI";
            string username = UserNameField.Text.Trim();
            string name = NameField.Text.Trim();
            string phone = PhoneField.Text.Trim();
            string password = PasswordField.Text.Trim();
            string address = AddressField.Text.Trim();
            string type = Signupas.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) ||string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(phone) ||
                string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(address) ||
                string.IsNullOrWhiteSpace(type))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!long.TryParse(phone, out _))
            {
                MessageBox.Show("Phone must be a valid number.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "INSERT INTO [Users] (UserName,Phone, Password, Name, Address, Type) " +
                           "VALUES (@UserName,@Phone, @Password, @Name, @Address, @Type)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", username);
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Address", address);
                    command.Parameters.AddWithValue("@Type", type);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Profile created successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Hide();
                        SignInForm f1 = new SignInForm();
                        f1.Show();
                    }
                    else
                    {
                        MessageBox.Show("Failed to create the profile. Please try again.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
