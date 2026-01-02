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
    public partial class SignInForm : Form
    {
        public SignInForm()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Signin_Click(object sender, EventArgs e)
        {
            string userName = UserNameTextBox.Text.Trim();
            string userPassword = PasswordTextBox.Text.Trim();
            string type = signInAscomboBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(userName) ||
                string.IsNullOrWhiteSpace(userPassword) ||
                string.IsNullOrWhiteSpace(type))
            {
                MessageBox.Show("All fields are required.");
                return;
            }

            string connectionString =
                "data source=NISHAD\\SQLEXPRESS; database=BookMyChef; integrated security=SSPI";

            string query =
                "SELECT COUNT(*) FROM [Users] WHERE UserName=@UserName AND Password=@Password AND Type=@Type";

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserName", userName);
                command.Parameters.AddWithValue("@Password", userPassword);
                command.Parameters.AddWithValue("@Type", type);

                connection.Open();
                int count = (int)command.ExecuteScalar();

                if (count > 0)
                {
                    MessageBox.Show("Login successful!");
                    this.Hide();

                    switch (type)
                    {
                        case "Client":
                            new ClientForm(userName).Show();
                            break;
                        case "Chef":
                            new ChefForm(userName).Show();
                            break;
                        case "Caterer":
                            new CatererForm(userName).Show();
                            break;
                        case "Event Agency":
                            new EventAgencyForm(userName).Show();
                            break;
                        case "Admin":
                            new AdminForm(userName).Show();
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid phone, password, or role.");
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new SignupForm().Show();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void ShowPasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PasswordTextBox.UseSystemPasswordChar = !ShowPasswordCheckBox.Checked;
        }

        private void ForgetPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            new ForgotPasswordForm().Show();
        }
    }
}