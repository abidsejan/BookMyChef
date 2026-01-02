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
    public partial class CatererRequestsForm : Form
    {
        string username;
        public CatererRequestsForm(string userName)
        {
            InitializeComponent();
            this.username = userName;
            LoadBookingHistory();
        }
        private string connectionString =
            "data source=NISHAD\\SQLEXPRESS; database=BookMyChef; integrated security=SSPI";

        private void LoadBookingHistory()
        {
            string query = @"
                SELECT 
                    B.BookingId,
                    B.ClientUserName,
                    B.ServiceProviderId,
                    B.ServiceType,
                    B.BookingDate,
                    B.NoOfPersons,
                    B.TotalAmount,
                    B.BookingStatus
                FROM Bookings B
                WHERE B.ServiceProviderId = (
                    SELECT CatererId 
                    FROM Caterer 
                    WHERE UserName = @CatererUserName
                ) AND B.ServiceType = 'Caterer' AND B.BookingStatus = 'Requested'";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@CatererUserName", username);

                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading data: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private void UpdateBookingStatus(string status)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a booking first.");
                return;
            }

            int bookingId = Convert.ToInt32(
                dataGridView1.SelectedRows[0].Cells["BookingId"].Value
            );

            string query = "UPDATE Bookings SET BookingStatus = @Status WHERE BookingId = @BookingId";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@BookingId", bookingId);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show(
                    $"Booking {status} successfully!",
                    "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                LoadBookingHistory(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error updating booking: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private void Home_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CatererHomeForm(username).Show();
        }

        private void History_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CatererHistoryForm(username).Show();
        }

        private void Profile_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CatererProfileForm(username).Show();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CatererHomeForm(username).Show();
        }

        private void Requests_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateBookingStatus("Confirmed");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateBookingStatus("Rejected");
        }
    }
}
