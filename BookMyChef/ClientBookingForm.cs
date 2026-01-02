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
    public partial class ClientBookingForm : Form
    {
        string username;
        private string connectionString =
            "data source=NISHAD\\SQLEXPRESS; database=BookMyChef; integrated security=SSPI";

        public ClientBookingForm(string userName)
        {
            InitializeComponent();
            this.username = userName;
            LoadBookingHistory();
        }
        private void LoadBookingHistory()
        {
            string query = "SELECT * FROM Bookings WHERE ClientUserName = @ClientUserName AND BOOKINGSTATUS = 'Requested'";

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

        private void ClientBookingForm_Load(object sender, EventArgs e)
        {

        }

        private void Home_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ClientHomeForm(username).Show();
        }

        private void Bookings_Click(object sender, EventArgs e)
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ClientHomeForm(username).Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
