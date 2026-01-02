using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BookMyChef
{
    public partial class ForgotPasswordForm : Form
    {
        public ForgotPasswordForm()
        {
            InitializeComponent();
            PasswordTextBox.UseSystemPasswordChar = true;
        }

        string connectionString =
            "data source=NISHAD\\SQLEXPRESS; database=BookMyChef; integrated security=SSPI";

        private void ShowPasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PasswordTextBox.UseSystemPasswordChar = !ShowPasswordCheckBox.Checked;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            new SignInForm().Show();
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            string userName = UserNameTextBox.Text.Trim();
            string newPassword = PasswordTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(userName) ||
                string.IsNullOrWhiteSpace(newPassword))
            {
                MessageBox.Show("All fields are required.");
                return;
            }

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string checkQuery = "SELECT COUNT(*) FROM Users WHERE UserName=@UserName";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, con))
                {
                    checkCmd.Parameters.AddWithValue("@UserName", userName);
                    int userExists = (int)checkCmd.ExecuteScalar();

                    if (userExists == 0)
                    {
                        MessageBox.Show("User not found!");
                        return;
                    }
                }

                string updateQuery =
                    "UPDATE Users SET Password=@Password WHERE UserName=@UserName";

                using (SqlCommand updateCmd = new SqlCommand(updateQuery, con))
                {
                    updateCmd.Parameters.AddWithValue("@Password", newPassword);
                    updateCmd.Parameters.AddWithValue("@UserName", userName);
                    updateCmd.ExecuteNonQuery();
                }

                MessageBox.Show("Password updated successfully!");
                this.Hide();
                new SignInForm().Show();
            }
        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}