using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace BookMyChef
{
    public partial class PaymentForm : Form
    {
        string username;
        decimal totalAmount;
        string paymentMethod;

        public PaymentForm(string userName, decimal amount, string method)
        {
            this.username = userName;
            this.totalAmount = amount;
            this.paymentMethod = method;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void PhoneLabel_Click(object sender, EventArgs e) { }
        private void NameLabel_Click(object sender, EventArgs e) { }
        private void PasswordLabel_Click(object sender, EventArgs e) { }
        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void PhoneField_TextChanged(object sender, EventArgs e) { }

        
        private void History_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ClientHistoryForm(username).Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ClientProfileForm(username).Show();
        }

        private void Requests_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ClientBookingForm(username).Show();
        }

        private void Home_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ClientHomeForm(username).Show();
        }

        
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            
            string enteredAmountText = NameField.Text.Trim();

           
            decimal enteredAmount;
            if (!decimal.TryParse(enteredAmountText, out enteredAmount) || enteredAmount != totalAmount)
            {
                MessageBox.Show("Invalid Amount! Please enter the correct amount: " + totalAmount.ToString());
                return;
            }

            
            string enteredPassword = PasswordField.Text.Trim();

            
            string connectionString =
                 "data source=NISHAD\\SQLEXPRESS; database=BookMyChef; integrated security=SSPI";
            string dbPassword = "";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    
                    string query = "SELECT Password FROM Users WHERE UserName = @UserName";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        
                        cmd.Parameters.AddWithValue("@UserName", this.username);

                        
                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            dbPassword = result.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message);
                    return;
                }
            }

           
            if (enteredPassword != dbPassword)
            {
                MessageBox.Show("Invalid Password!");
                return;
            }

           
            MessageBox.Show("Payment of " + totalAmount.ToString("0.00") + " BDT via " + paymentMethod + " Successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            
            this.DialogResult = DialogResult.OK;
            this.Hide();
            new ClientHomeForm(username).Show();
        }
        
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = totalAmount.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            new ClientHomeForm(username).Show();
        }
    }
}