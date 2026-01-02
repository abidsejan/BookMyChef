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
    public partial class ChefHistoryForm : Form
    {
        string username;
        private string connectionString =
            "data source=NISHAD\\SQLEXPRESS; database=BookMyChef; integrated security=SSPI";


        public ChefHistoryForm(string userName)
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
                    SELECT ChefId 
                    FROM Chef
                    WHERE UserName = @ChefUserName
                ) AND B.ServiceType = 'Private Chef'";

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

        private void Home_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ChefHomeForm(username).Show();
        }

        private void Requests_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ChefRequestsForm(username).Show();
        }

        private void Profile_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ChefProfileForm(username).Show();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ChefHomeForm(username).Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
