using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BookMyChef
{
    public partial class CatererCreateMenuForm : Form
    {
        string username;

        public CatererCreateMenuForm(string userName)
        {
            this.username = userName;
            InitializeComponent();
        }

        string connectionString =
            "data source=NISHAD\\SQLEXPRESS; database=BookMyChef; integrated security=SSPI";

        private void AddButton_Click(object sender, EventArgs e)
        {
            string menuName = SpecialityField.Text.Trim();
            string menuItems = YOEfield.Text.Trim();
            string serviceArea = ServiceAreaField.Text.Trim();
            string priceText = CuisinesField.Text.Trim();

           
            if (string.IsNullOrWhiteSpace(menuName) ||
                string.IsNullOrWhiteSpace(menuItems) ||
                string.IsNullOrWhiteSpace(serviceArea) ||
                string.IsNullOrWhiteSpace(priceText))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(priceText, out decimal price))
            {
                MessageBox.Show("Price must be a valid number.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    
                    string catererIdQuery =
                        "SELECT CatererId FROM Caterer WHERE UserName = @UserName";

                    int catererId;

                    using (SqlCommand idCmd = new SqlCommand(catererIdQuery, con))
                    {
                        idCmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 50).Value = username;

                        object result = idCmd.ExecuteScalar();
                        if (result == null)
                        {
                            MessageBox.Show("Caterer profile not found.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        catererId = Convert.ToInt32(result);
                    }

                    
                    string insertQuery = @"INSERT INTO CatererMenu
                                           (ServiceArea, CatererId, MenuName, MenuItems, Price)
                                           VALUES
                                           (@ServiceArea, @CatererId, @MenuName, @MenuItems, @Price)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                    {
                        cmd.Parameters.Add("@ServiceArea", SqlDbType.NVarChar, 100).Value = serviceArea;
                        cmd.Parameters.Add("@CatererId", SqlDbType.Int).Value = catererId;
                        cmd.Parameters.Add("@MenuName", SqlDbType.NVarChar, 100).Value = menuName;
                        cmd.Parameters.Add("@MenuItems", SqlDbType.NVarChar, 500).Value = menuItems;
                        cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = price;

                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            MessageBox.Show("Menu created successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.Hide();
                            new CatererHomeForm(username).Show();
                        }
                        else
                        {
                            MessageBox.Show("Failed to create menu.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Home_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CatererHomeForm(username).Show();
        }

        private void BackButton_Click(object sender, EventArgs e)
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
            this.Hide();
            new CatererHistoryForm(username).Show();
        }

        private void Profile_Click(object sender, EventArgs e)
        {
            this.Hide();
            new CatererProfileForm(username).Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void SpecialityField_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
