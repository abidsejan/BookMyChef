using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BookMyChef
{
    public partial class ClientCatererConfirmBookingForm : Form
    {
        string username;
        int catererId;
        string menuName;
        string serviceArea;
        decimal price;
        string connectionString = "data source=NISHAD\\SQLEXPRESS; database=BookMyChef; integrated security=SSPI";

        public ClientCatererConfirmBookingForm(string username, int catererId, string menuName, string serviceArea, decimal price)
        {
            this.username = username;
            this.catererId = catererId;
            this.menuName = menuName;
            this.serviceArea = serviceArea;
            this.price = price;

            InitializeComponent();
        }

        private void Requests_Click(object sender, EventArgs e)
        {

        }

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

        private void button3_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(NameField.Text, out int guests))
            {
                MessageBox.Show("Please enter a valid number of guests.", "Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                NameField.Focus();
                return;
            }

            if (guests <= 0)
            {
                MessageBox.Show("Number of guests must be greater than 0.", "Input Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime eventDate = dateTimePicker1.Value;
            if (eventDate.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Event date cannot be in the past.", "Date Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string paymentMethod = "";
            if (radioButton1.Checked) 
            {
                paymentMethod = "Bkash";
            }
            else if (radioButton2.Checked) 
            {
                paymentMethod = "Nagad";
            }
            else
            {
                MessageBox.Show("Please select a payment method.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

          
            decimal totalPrice = guests * price;
            this.Hide();

           
            PaymentForm paymentForm = new PaymentForm(username, totalPrice, paymentMethod);

         
            if (paymentForm.ShowDialog() == DialogResult.OK)
            {
                
                button2_Click(username, catererId, guests, eventDate, totalPrice, paymentMethod);
            }
        }

        private void button2_Click(string clientUser, int serviceProviderId, int noOfPersons, DateTime bookingDate, decimal totalAmount, string paymentMethod)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
               
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    int newBookingId;

                 
                    string bookingQuery = @"INSERT INTO Bookings
                             (ClientUserName, ServiceProviderId, ServiceType, BookingDate, NoOfPersons, TotalAmount, BookingStatus)
                             VALUES
                             (@ClientUserName, @ServiceProviderId, 'Caterer', @BookingDate, @NoOfPersons, @TotalAmount, 'Requested');
                             SELECT CAST(scope_identity() AS int);";

                    using (SqlCommand cmd = new SqlCommand(bookingQuery, con, transaction))
                    {
                        cmd.Parameters.AddWithValue("@ClientUserName", clientUser);
                        cmd.Parameters.AddWithValue("@ServiceProviderId", serviceProviderId);
                        cmd.Parameters.AddWithValue("@BookingDate", bookingDate);
                        cmd.Parameters.AddWithValue("@NoOfPersons", noOfPersons);
                        cmd.Parameters.AddWithValue("@TotalAmount", totalAmount);

                        
                        newBookingId = (int)cmd.ExecuteScalar();
                    }

                   
                    string paymentQuery = @"INSERT INTO Payment
                             (BookingId, PaymentMethod, PaidAmount, PlatformFee, PaymentStatus)
                             VALUES
                             (@BookingId, @PaymentMethod, @PaidAmount, 0, 'Paid')";

                    using (SqlCommand cmd = new SqlCommand(paymentQuery, con, transaction))
                    {
                        cmd.Parameters.AddWithValue("@BookingId", newBookingId);
                        cmd.Parameters.AddWithValue("@PaymentMethod", paymentMethod);
                        cmd.Parameters.AddWithValue("@PaidAmount", totalAmount);

                        cmd.ExecuteNonQuery();
                    }

                    
                    transaction.Commit();

                    MessageBox.Show("Booking confirmed and payment recorded successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    
                    transaction.Rollback();
                    MessageBox.Show("An error occurred while saving booking: " + ex.Message, "Database Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ClientCatererForm(username).Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
