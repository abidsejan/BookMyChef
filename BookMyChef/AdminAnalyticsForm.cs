using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BookMyChef
{
    public partial class AdminAnalyticsForm : Form
    {
        string connectionString =
            "data source=NISHAD\\SQLEXPRESS; database=BookMyChef; integrated security=SSPI";

        public AdminAnalyticsForm()
        {
            InitializeComponent();

            LoadPaymentTable();
            LoadTotalPaidAmount();
        }

        
        private void LoadPaymentTable()
        {
            string query = "SELECT * FROM Payment";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        
        private void LoadTotalPaidAmount()
        {
            string query = "SELECT ISNULL(SUM(PaidAmount), 0) FROM Payment";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    object result = cmd.ExecuteScalar();

                    
                    UserNameTextBox.Text =  result.ToString();
                }
            }
        }

       
        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AdminForm().Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void UserNameTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM Payment ORDER BY PaidAmount DESC";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    dataGridView1.DataSource = dt;
                }
            }
        }

    }
}
