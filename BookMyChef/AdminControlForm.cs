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
    public partial class AdminControlForm : Form
    {
        public AdminControlForm()
        {
            InitializeComponent();
            string query = "SELECT * FROM Users" + " WHERE Type != 'Admin'";
            FillDataGridView(query);
        }
        string connectionString = "data source=NISHAD\\SQLEXPRESS; database=BookMyChef; integrated security=SSPI";


        private void FillDataGridView(string query)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a user to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

            
            object cellValue = selectedRow.Cells["Username"].Value;

            if (cellValue == null)
            {
                MessageBox.Show("Could not identify the user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string usernameToDelete = cellValue.ToString();

           
            DialogResult confirmResult = MessageBox.Show("Are you sure you want to delete user: " + usernameToDelete + "?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
               
                string deleteQuery = "DELETE FROM Users WHERE Username = @username";

                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    using (SqlCommand cmd = new SqlCommand(deleteQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@username", usernameToDelete);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("User deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    
                    string refreshQuery = "SELECT * FROM Users" + " WHERE Type != 'Admin'";
                    FillDataGridView(refreshQuery);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting user: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}