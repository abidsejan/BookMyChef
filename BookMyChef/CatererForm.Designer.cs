namespace BookMyChef
{
    partial class CatererForm
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
            this.Profile = new System.Windows.Forms.Button();
            this.History = new System.Windows.Forms.Button();
            this.Requests = new System.Windows.Forms.Button();
            this.Home = new System.Windows.Forms.Button();
            this.WelcomeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::BookMyChef.Properties.Resources.Catering;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1262, 673);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Profile
            // 
            this.Profile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(176)))), ((int)(((byte)(149)))));
            this.Profile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Profile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(104)))), ((int)(((byte)(67)))));
            this.Profile.Location = new System.Drawing.Point(739, 35);
            this.Profile.Name = "Profile";
            this.Profile.Size = new System.Drawing.Size(115, 40);
            this.Profile.TabIndex = 8;
            this.Profile.Text = "Profile";
            this.Profile.UseVisualStyleBackColor = false;
            this.Profile.Click += new System.EventHandler(this.Profile_Click);
            // 
            // History
            // 
            this.History.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(176)))), ((int)(((byte)(149)))));
            this.History.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.History.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(104)))), ((int)(((byte)(67)))));
            this.History.Location = new System.Drawing.Point(618, 35);
            this.History.Name = "History";
            this.History.Size = new System.Drawing.Size(115, 40);
            this.History.TabIndex = 7;
            this.History.Text = "History";
            this.History.UseVisualStyleBackColor = false;
            this.History.Click += new System.EventHandler(this.History_Click);
            // 
            // Requests
            // 
            this.Requests.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(176)))), ((int)(((byte)(149)))));
            this.Requests.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Requests.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(104)))), ((int)(((byte)(67)))));
            this.Requests.Location = new System.Drawing.Point(497, 35);
            this.Requests.Name = "Requests";
            this.Requests.Size = new System.Drawing.Size(115, 40);
            this.Requests.TabIndex = 6;
            this.Requests.Text = "Requests";
            this.Requests.UseVisualStyleBackColor = false;
            this.Requests.Click += new System.EventHandler(this.Requests_Click);
            // 
            // Home
            // 
            this.Home.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(176)))), ((int)(((byte)(149)))));
            this.Home.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Home.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Home.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(104)))), ((int)(((byte)(67)))));
            this.Home.Location = new System.Drawing.Point(376, 35);
            this.Home.Name = "Home";
            this.Home.Size = new System.Drawing.Size(115, 40);
            this.Home.TabIndex = 5;
            this.Home.Text = "Home";
            this.Home.UseVisualStyleBackColor = false;
            this.Home.Click += new System.EventHandler(this.Home_Click);
            // 
            // WelcomeLabel
            // 
            this.WelcomeLabel.AutoSize = true;
            this.WelcomeLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(104)))), ((int)(((byte)(67)))));
            this.WelcomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WelcomeLabel.ForeColor = System.Drawing.SystemColors.Info;
            this.WelcomeLabel.Location = new System.Drawing.Point(465, 292);
            this.WelcomeLabel.Name = "WelcomeLabel";
            this.WelcomeLabel.Size = new System.Drawing.Size(180, 42);
            this.WelcomeLabel.TabIndex = 17;
            this.WelcomeLabel.Text = "Welcome";
            // 
            // CatererForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.WelcomeLabel);
            this.Controls.Add(this.Profile);
            this.Controls.Add(this.History);
            this.Controls.Add(this.Requests);
            this.Controls.Add(this.Home);
            this.Controls.Add(this.pictureBox1);
            this.Name = "CatererForm";
            this.Text = "CatererForm";
            this.Load += new System.EventHandler(this.CatererForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Profile;
        private System.Windows.Forms.Button History;
        private System.Windows.Forms.Button Requests;
        private System.Windows.Forms.Button Home;
        private System.Windows.Forms.Label WelcomeLabel;
    }
}