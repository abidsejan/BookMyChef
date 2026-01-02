using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BookMyChef
{
    public partial class EventAgencyViewPackageForm : Form
    {
        string username;

        string connectionString =
            "data source=NISHAD\\SQLEXPRESS; database=BookMyChef; integrated security=SSPI";

        public EventAgencyViewPackageForm(string userName)
        {
            this.username = userName;
            InitializeComponent();
            LoadPackages();
        }

        
        private void LoadPackages()
        {
            string query = @"
                SELECT *
                FROM EventAgencyPackage
                WHERE AgencyId = (
                    SELECT AgencyId
                    FROM EventAgency
                    WHERE UserName = @UserName
                )";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@UserName", username);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.DataSource = dt;

                
                if (dataGridView1.Columns.Contains("PackageId"))
                    dataGridView1.Columns["PackageId"].Visible = false;
            }
        }

        
        private void AddButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Please select a package to delete.",
                    "Selection Required",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int packageId = Convert.ToInt32(
                dataGridView1.SelectedRows[0].Cells["PackageId"].Value
            );

            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to delete this package?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            string deleteQuery =
                "DELETE FROM EventAgencyPackage WHERE PackageId = @PackageId";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
            {
                cmd.Parameters.AddWithValue("@PackageId", packageId);
                con.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    MessageBox.Show(
                        "Package deleted successfully.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadPackages(); 
                }
                else
                {
                    MessageBox.Show(
                        "Failed to delete package.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

       
        private void Home_Click(object sender, EventArgs e)
        {
            this.Hide();
            new EventAgencyHomeForm(username).Show();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new EventAgencyHomeForm(username).Show();
        }

        private void Requests_Click(object sender, EventArgs e)
        {
            this.Hide();
            new EventAgencyRequestForm(username).Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}
