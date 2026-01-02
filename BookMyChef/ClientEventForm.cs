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
    public partial class ClientEventForm : Form
    {
        string username;
        int agencyId;
        decimal pricePerHead;
        string packageName;
        string serviceArea;
        
        public ClientEventForm(string userName)
        {
            this.username = userName;
            InitializeComponent();
            string query = "SELECT * FROM EventAgencyPackage";
            FillDataGridView(query);
        }
        string connectionString = "data source=NISHAD\\SQLEXPRESS; database=BookMyChef; integrated security=SSPI";

        private void FillDataGridView(string query)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    dataGridView1.DataSource = dataTable;
                   
                }
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ClientHomeForm(username).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM EventAgencyPackage";
            FillDataGridView(query);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string searchValue = richTextBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchValue))
            {
                MessageBox.Show("Please enter a search term.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"SELECT * FROM EventAgencyPackage
                     WHERE ServiceArea LIKE @searchTerm
                        OR PackageName LIKE @searchTerm
                        OR PackageItems LIKE @searchTerm
                        OR PricePerHead LIKE @searchTerm";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@searchTerm", "%" + searchValue + "%");

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        DataTable dataTable = new DataTable();
                        dataTable.Load(reader);
                        dataGridView1.DataSource = dataTable;

                        if (dataTable.Rows.Count == 0)
                        {
                            MessageBox.Show("No matching rows found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Search failed: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an event first.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];

                int agencyId = Convert.ToInt32(row.Cells["AgencyId"].Value);
                string packageName = row.Cells["PackageName"].Value.ToString();
                string serviceArea = row.Cells["ServiceArea"].Value.ToString();
                decimal pricePerHead = Convert.ToDecimal(row.Cells["PricePerHead"].Value);

               
                string clientAddress = GetClientAddress();

              
                if (!string.Equals(clientAddress, serviceArea, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show(
                        "You cannot book this event.\nClient address and event service area do not match.",
                        "Not in the Same Area",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                
                this.Hide();
                new ClientEventConfirmBookingForm(
                    username,
                    agencyId,
                    packageName,
                    serviceArea,
                    pricePerHead
                ).Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error processing selection: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ClientProfileForm(username).Show();
        }

        private void History_Click(object sender, EventArgs e)
        {
            this.Hide();
            new ClientHistoryForm(username).Show();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private string GetClientAddress()
        {
            string address = "";

            string query = "SELECT Address FROM Users WHERE UserName = @UserName";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@UserName", username);
                con.Open();

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    address = result.ToString();
                }
            }

            return address;
        }

    }
}