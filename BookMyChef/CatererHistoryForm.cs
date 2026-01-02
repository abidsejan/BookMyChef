using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BookMyChef
{
    public partial class CatererHistoryForm : Form
    {
        private string username;
        private string connectionString =
            "data source=NISHAD\\SQLEXPRESS; database=BookMyChef; integrated security=SSPI";

        public CatererHistoryForm(string userName)
        {
            InitializeComponent();
            username = userName;
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
                    SELECT CatererId 
                    FROM Caterer 
                    WHERE UserName = @CatererUserName
                ) AND B.ServiceType = 'Caterer' AND B.BookingStatus != 'Requested'";

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

        private void Home_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CatererHomeForm(username).Show();
        }

        private void Requests_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CatererRequestsForm(username).Show();
        }

        private void History_Click(object sender, EventArgs e)
        {
           
            
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
