using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BookMyChef
{
    public partial class EventAgencyRequestForm : Form
    {
        string username;

        private string connectionString =
            "data source=NISHAD\\SQLEXPRESS; database=BookMyChef; integrated security=SSPI";

        public EventAgencyRequestForm(string userName)
        {
            InitializeComponent();
            this.username = userName;
            LoadBookingHistory();
        }

        
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
                    SELECT AgencyId
                    FROM EventAgency
                    WHERE UserName = @EventAgencyUserName
                )
                AND B.ServiceType = 'Event Agency'
                AND B.BookingStatus = 'Requested'";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@EventAgencyUserName", username);

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

       
        private void button1_Click(object sender, EventArgs e)
        {
            UpdateBookingStatus("Confirmed");
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            UpdateBookingStatus("Rejected");
        }

        private void Home_Click(object sender, EventArgs e)
        {
            this.Hide();
            new EventAgencyHomeForm(username).Show();
        }

        private void Profile_Click(object sender, EventArgs e)
        {
            this.Hide();
            new EventAgencyProfileForm(username).Show();
        }

        private void History_Click(object sender, EventArgs e)
        {
            this.Hide();
            new EventAgencyHistoryForm(username).Show();
        }

        private void Requests_Click(object sender, EventArgs e)
        {
            this.Hide();
            new EventAgencyRequestForm(username).Show();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new EventAgencyHomeForm(username).Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }
    }
}
