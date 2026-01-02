using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BookMyChef
{
    public partial class ClientHistoryForm : Form
    {
      
        private string username;

        
        private string connectionString =
            "data source=NISHAD\\SQLEXPRESS; database=BookMyChef; integrated security=SSPI";

        
        public ClientHistoryForm(string userName)
        {
            InitializeComponent();
            this.username = userName;

            
            LoadBookingHistory();
        }

        private void LoadBookingHistory()
        {
            string query = "SELECT * FROM Bookings WHERE ClientUserName = @ClientUserName AND BOOKINGSTATUS != 'Requested'";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                
                cmd.Parameters.AddWithValue("@ClientUserName", username);

                DataTable dt = new DataTable();

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);

                    dataGridView1.DataSource = dt;

                  
                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No booking history found.",
                            "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading booking history:\n" + ex.Message);
                }
            }
        }

       
        private void Bookings_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ClientBookingForm(username).Show();
        }

        private void Home_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ClientHomeForm(username).Show();
        }

        private void ProfileButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ClientProfileForm(username).Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void History_Click(object sender, EventArgs e)
        {

        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ClientHomeForm(username).Show();
        }
    }
}
