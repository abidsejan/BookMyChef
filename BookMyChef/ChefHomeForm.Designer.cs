namespace BookMyChef
{
    partial class ChefHomeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ViewProfileButton = new System.Windows.Forms.Button();
            this.CreateProfileButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Profile = new System.Windows.Forms.Button();
            this.History = new System.Windows.Forms.Button();
            this.Requests = new System.Windows.Forms.Button();
            this.Home = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::BookMyChef.Properties.Resources.ChefHome;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1262, 673);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ViewProfileButton
            // 
            this.ViewProfileButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(205)))), ((int)(((byte)(180)))));
            this.ViewProfileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewProfileButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(104)))), ((int)(((byte)(67)))));
            this.ViewProfileButton.Location = new System.Drawing.Point(633, 288);
            this.ViewProfileButton.Name = "ViewProfileButton";
            this.ViewProfileButton.Size = new System.Drawing.Size(115, 115);
            this.ViewProfileButton.TabIndex = 25;
            this.ViewProfileButton.Text = "View Profile";
            this.ViewProfileButton.UseVisualStyleBackColor = false;
            this.ViewProfileButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // CreateProfileButton
            // 
            this.CreateProfileButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(205)))), ((int)(((byte)(180)))));
            this.CreateProfileButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CreateProfileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateProfileButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(104)))), ((int)(((byte)(67)))));
            this.CreateProfileButton.Location = new System.Drawing.Point(443, 288);
            this.CreateProfileButton.Name = "CreateProfileButton";
            this.CreateProfileButton.Size = new System.Drawing.Size(115, 115);
            this.CreateProfileButton.TabIndex = 24;
            this.CreateProfileButton.Text = "Create Profile";
            this.CreateProfileButton.UseVisualStyleBackColor = false;
            this.CreateProfileButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(205)))), ((int)(((byte)(180)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(104)))), ((int)(((byte)(67)))));
            this.label1.Location = new System.Drawing.Point(550, 166);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 29);
            this.label1.TabIndex = 23;
            this.label1.Text = "Services";
            // 
            // Profile
            // 
            this.Profile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(176)))), ((int)(((byte)(149)))));
            this.Profile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Profile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(104)))), ((int)(((byte)(67)))));
            this.Profile.Location = new System.Drawing.Point(734, 36);
            this.Profile.Name = "Profile";
            this.Profile.Size = new System.Drawing.Size(115, 40);
            this.Profile.TabIndex = 22;
            this.Profile.Text = "Profile";
            this.Profile.UseVisualStyleBackColor = false;
            this.Profile.Click += new System.EventHandler(this.Profile_Click);
            // 
            // History
            // 
            this.History.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(176)))), ((int)(((byte)(149)))));
            this.History.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.History.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(104)))), ((int)(((byte)(67)))));
            this.History.Location = new System.Drawing.Point(613, 36);
            this.History.Name = "History";
            this.History.Size = new System.Drawing.Size(115, 40);
            this.History.TabIndex = 21;
            this.History.Text = "History";
            this.History.UseVisualStyleBackColor = false;
            this.History.Click += new System.EventHandler(this.History_Click);
            // 
            // Requests
            // 
            this.Requests.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(176)))), ((int)(((byte)(149)))));
            this.Requests.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Requests.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(104)))), ((int)(((byte)(67)))));
            this.Requests.Location = new System.Drawing.Point(492, 36);
            this.Requests.Name = "Requests";
            this.Requests.Size = new System.Drawing.Size(115, 40);
            this.Requests.TabIndex = 20;
            this.Requests.Text = "Requests";
            this.Requests.UseVisualStyleBackColor = false;
            this.Requests.Click += new System.EventHandler(this.Bookings_Click);
            // 
            // Home
            // 
            this.Home.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(176)))), ((int)(((byte)(149)))));
            this.Home.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Home.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Home.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(104)))), ((int)(((byte)(67)))));
            this.Home.Location = new System.Drawing.Point(371, 36);
            this.Home.Name = "Home";
            this.Home.Size = new System.Drawing.Size(115, 40);
            this.Home.TabIndex = 19;
            this.Home.Text = "Home";
            this.Home.UseVisualStyleBackColor = false;
            this.Home.Click += new System.EventHandler(this.Home_Click);
            // 
            // ChefHomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.ViewProfileButton);
            this.Controls.Add(this.CreateProfileButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Profile);
            this.Controls.Add(this.History);
            this.Controls.Add(this.Requests);
            this.Controls.Add(this.Home);
            this.Controls.Add(this.pictureBox1);
            this.Name = "ChefHomeForm";
            this.Text = "ChefHomeForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button ViewProfileButton;
        private System.Windows.Forms.Button CreateProfileButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Profile;
        private System.Windows.Forms.Button History;
        private System.Windows.Forms.Button Requests;
        private System.Windows.Forms.Button Home;
    }
}