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
    public partial class EventAgencyHistoryForm : Form
    {
        string username;
        private string connectionString =
            "data source=NISHAD\\SQLEXPRESS; database=BookMyChef; integrated security=SSPI";
        public EventAgencyHistoryForm(string userName)
        {
            this.username = userName;
            InitializeComponent();
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
                ) AND B.ServiceType = 'Event Agency'AND B.BookingStatus != 'Requested'";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@EventAgencyUserName", username);

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

        public EventAgencyHistoryForm()
        {
            InitializeComponent();
        }

        private void Home_Click(object sender, EventArgs e)
        {
            this.Hide();
            new EventAgencyHomeForm(username).Show();
        }

        private void Requests_Click(object sender, EventArgs e)
        {
            this.Hide();
            new EventAgencyRequestForm(username).Show();
        }

        private void Profile_Click(object sender, EventArgs e)
        {
            this.Hide();
            new EventAgencyProfileForm(username).Show();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new EventAgencyHomeForm(username).Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
