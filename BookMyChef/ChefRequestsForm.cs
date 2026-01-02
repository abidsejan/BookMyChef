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
    public partial class ChefRequestsForm : Form
    {
        string username;

        public ChefRequestsForm(string userName)
        {
            this.username = userName;
            InitializeComponent();
            LoadBookingHistory();
        }
        private string connectionString =
            "data source=NISHAD\\SQLEXPRESS; database=BookMyChef; integrated security=SSPI";
        private void LoadBookingHistory()
        {
            string query = @"
                SELECT BookingId,ClientUserName,
                    ServiceProviderId,ServiceType,
                    BookingDate,
                    NoOfPersons,
                    TotalAmount,
                    BookingStatus
                FROM Bookings
                WHERE ServiceProviderId = (
                    SELECT ChefId 
                    FROM Chef
                    WHERE UserName = @ChefUserName
                ) AND ServiceType = 'Private Chef' AND BookingStatus = 'Requested' ";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ChefUserName", username);

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
            new ChefHomeForm(username).Show();
        }

        private void History_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ChefHistoryForm(username).Show();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ChefHomeForm(username).Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            UpdateBookingStatus("Confirmed");
        }

        private void RejectButton_Click(object sender, EventArgs e)
        {
            UpdateBookingStatus("Rejected");
        }

        private void Profile_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ChefProfileForm(username).Show();
        }

        private void Requests_Click(object sender, EventArgs e)
        {

        }
    }
}
