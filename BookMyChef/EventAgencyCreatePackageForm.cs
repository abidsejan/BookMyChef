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
    public partial class EventAgencyCreatePackageForm : Form
    {
        string username;
        public EventAgencyCreatePackageForm(string userName)
        {
            this.username = userName;
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void ServiceArea_Click(object sender, EventArgs e)
        {

        }

        private void YOE_Click(object sender, EventArgs e)
        {

        }

        private void Speciality_Click(object sender, EventArgs e)
        {

        }

        private void CuisinesField_TextChanged(object sender, EventArgs e)
        {

        }

        private void ServiceAreaField_TextChanged(object sender, EventArgs e)
        {

        }

        private void YOEfield_TextChanged(object sender, EventArgs e)
        {

        }

        private void SpecialityField_TextChanged(object sender, EventArgs e)
        {

        }

        private void History_Click(object sender, EventArgs e)
        {
            this.Hide();
            new EventAgencyHistoryForm(username).Show();
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
                        "SELECT AgencyId FROM EventAgency WHERE UserName = @UserName";

                    int catererId;

                    using (SqlCommand idCmd = new SqlCommand(catererIdQuery, con))
                    {
                        idCmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 50).Value = username;

                        object result = idCmd.ExecuteScalar();
                        if (result == null)
                        {
                            MessageBox.Show("Event Agency profile not found.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        catererId = Convert.ToInt32(result);
                    }

                    string insertQuery = @"INSERT INTO EventAgencyPackage
                                           (AgencyId, ServiceArea , PackageName, PackageItems, PricePerHead)
                                           VALUES
                                           (@AgencyId, @ServiceArea,  @PackageName, @PackageItems, @PricePerHead)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, con))
                    {
                        cmd.Parameters.Add("@ServiceArea", SqlDbType.NVarChar, 100).Value = serviceArea;
                        cmd.Parameters.Add("@AgencyId", SqlDbType.Int).Value = catererId;
                        cmd.Parameters.Add("@PackageName", SqlDbType.NVarChar, 100).Value = menuName;
                        cmd.Parameters.Add("@PackageItems", SqlDbType.NVarChar, 500).Value = menuItems;
                        cmd.Parameters.Add("@PricePerHead", SqlDbType.Decimal).Value = price;

                        int rows = cmd.ExecuteNonQuery();

                        if (rows > 0)
                        {
                            MessageBox.Show("Package created successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.Hide();
                            new EventAgencyHomeForm(username).Show();
                        }
                        else
                        {
                            MessageBox.Show("Failed to create Package.", "Error",
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

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new EventAgencyHomeForm(username).Show();
        }

        private void Cuisines_Click(object sender, EventArgs e)
        {

        }

        private void Profile_Click(object sender, EventArgs e)
        {
            this.Hide();
            new EventAgencyProfileForm(username).Show();
        }

        private void Requests_Click(object sender, EventArgs e)
        {
            this.Hide();
            new EventAgencyRequestForm(username).Show();
        }

        private void Home_Click(object sender, EventArgs e)
        {
            this.Hide();
            new EventAgencyHomeForm(username).Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
