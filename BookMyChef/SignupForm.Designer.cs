namespace BookMyChef
{
    partial class SignupForm
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
            this.NameField = new System.Windows.Forms.RichTextBox();
            this.PhoneField = new System.Windows.Forms.RichTextBox();
            this.PasswordField = new System.Windows.Forms.RichTextBox();
            this.AddressField = new System.Windows.Forms.RichTextBox();
            this.Signupas = new System.Windows.Forms.ComboBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.PhoneLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.AddressLabel = new System.Windows.Forms.Label();
            this.SignupasLabel = new System.Windows.Forms.Label();
            this.Signup = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.UserNameField = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // NameField
            // 
            this.NameField.BackColor = System.Drawing.SystemColors.Info;
            this.NameField.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameField.Location = new System.Drawing.Point(614, 185);
            this.NameField.Name = "NameField";
            this.NameField.Size = new System.Drawing.Size(270, 40);
            this.NameField.TabIndex = 1;
            this.NameField.Text = "";
            // 
            // PhoneField
            // 
            this.PhoneField.BackColor = System.Drawing.SystemColors.Info;
            this.PhoneField.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PhoneField.Location = new System.Drawing.Point(614, 248);
            this.PhoneField.Name = "PhoneField";
            this.PhoneField.Size = new System.Drawing.Size(270, 40);
            this.PhoneField.TabIndex = 2;
            this.PhoneField.Text = "";
            // 
            // PasswordField
            // 
            this.PasswordField.BackColor = System.Drawing.SystemColors.Info;
            this.PasswordField.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordField.Location = new System.Drawing.Point(614, 312);
            this.PasswordField.Name = "PasswordField";
            this.PasswordField.Size = new System.Drawing.Size(270, 40);
            this.PasswordField.TabIndex = 3;
            this.PasswordField.Text = "";
            // 
            // AddressField
            // 
            this.AddressField.BackColor = System.Drawing.SystemColors.Info;
            this.AddressField.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddressField.Location = new System.Drawing.Point(614, 372);
            this.AddressField.Name = "AddressField";
            this.AddressField.Size = new System.Drawing.Size(270, 40);
            this.AddressField.TabIndex = 4;
            this.AddressField.Text = "";
            // 
            // Signupas
            // 
            this.Signupas.BackColor = System.Drawing.SystemColors.Info;
            this.Signupas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Signupas.ForeColor = System.Drawing.SystemColors.InfoText;
            this.Signupas.FormattingEnabled = true;
            this.Signupas.Items.AddRange(new object[] {
            "Client",
            "Chef",
            "Caterer",
            "Event Agency"});
            this.Signupas.Location = new System.Drawing.Point(614, 434);
            this.Signupas.Name = "Signupas";
            this.Signupas.Size = new System.Drawing.Size(270, 28);
            this.Signupas.TabIndex = 5;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(56)))), ((int)(((byte)(14)))));
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLabel.ForeColor = System.Drawing.SystemColors.Info;
            this.NameLabel.Location = new System.Drawing.Point(408, 185);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(133, 29);
            this.NameLabel.TabIndex = 6;
            this.NameLabel.Text = "Full Name";
            this.NameLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // PhoneLabel
            // 
            this.PhoneLabel.AutoSize = true;
            this.PhoneLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(56)))), ((int)(((byte)(14)))));
            this.PhoneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PhoneLabel.ForeColor = System.Drawing.SystemColors.Info;
            this.PhoneLabel.Location = new System.Drawing.Point(408, 248);
            this.PhoneLabel.Name = "PhoneLabel";
            this.PhoneLabel.Size = new System.Drawing.Size(88, 29);
            this.PhoneLabel.TabIndex = 7;
            this.PhoneLabel.Text = "Phone";
            this.PhoneLabel.Click += new System.EventHandler(this.label2_Click);
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(56)))), ((int)(((byte)(14)))));
            this.PasswordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLabel.ForeColor = System.Drawing.SystemColors.Info;
            this.PasswordLabel.Location = new System.Drawing.Point(408, 312);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(128, 29);
            this.PasswordLabel.TabIndex = 8;
            this.PasswordLabel.Text = "Password";
            this.PasswordLabel.Click += new System.EventHandler(this.label3_Click);
            // 
            // AddressLabel
            // 
            this.AddressLabel.AutoSize = true;
            this.AddressLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(56)))), ((int)(((byte)(14)))));
            this.AddressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddressLabel.ForeColor = System.Drawing.SystemColors.Info;
            this.AddressLabel.Location = new System.Drawing.Point(408, 372);
            this.AddressLabel.Name = "AddressLabel";
            this.AddressLabel.Size = new System.Drawing.Size(109, 29);
            this.AddressLabel.TabIndex = 9;
            this.AddressLabel.Text = "Address";
            // 
            // SignupasLabel
            // 
            this.SignupasLabel.AutoSize = true;
            this.SignupasLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(56)))), ((int)(((byte)(14)))));
            this.SignupasLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignupasLabel.ForeColor = System.Drawing.SystemColors.Info;
            this.SignupasLabel.Location = new System.Drawing.Point(408, 430);
            this.SignupasLabel.Name = "SignupasLabel";
            this.SignupasLabel.Size = new System.Drawing.Size(136, 29);
            this.SignupasLabel.TabIndex = 10;
            this.SignupasLabel.Text = "Sing up as";
            // 
            // Signup
            // 
            this.Signup.BackColor = System.Drawing.SystemColors.Info;
            this.Signup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Signup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(32)))), ((int)(((byte)(10)))));
            this.Signup.Location = new System.Drawing.Point(683, 508);
            this.Signup.Name = "Signup";
            this.Signup.Size = new System.Drawing.Size(114, 35);
            this.Signup.TabIndex = 11;
            this.Signup.Text = "Sign up";
            this.Signup.UseVisualStyleBackColor = false;
            this.Signup.Click += new System.EventHandler(this.Signup_Click);
            // 
            // Back
            // 
            this.Back.BackColor = System.Drawing.SystemColors.Info;
            this.Back.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Back.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(32)))), ((int)(((byte)(10)))));
            this.Back.Location = new System.Drawing.Point(533, 508);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(114, 35);
            this.Back.TabIndex = 12;
            this.Back.Text = "Back";
            this.Back.UseVisualStyleBackColor = false;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::BookMyChef.Properties.Resources.SignUp1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1262, 673);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(56)))), ((int)(((byte)(14)))));
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox2.Image = global::BookMyChef.Properties.Resources.bookchef;
            this.pictureBox2.Location = new System.Drawing.Point(1123, 57);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(61, 49);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(56)))), ((int)(((byte)(14)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(408, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 29);
            this.label1.TabIndex = 15;
            this.label1.Text = "Username";
            // 
            // UserNameField
            // 
            this.UserNameField.BackColor = System.Drawing.SystemColors.Info;
            this.UserNameField.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNameField.Location = new System.Drawing.Point(614, 122);
            this.UserNameField.Name = "UserNameField";
            this.UserNameField.Size = new System.Drawing.Size(270, 40);
            this.UserNameField.TabIndex = 14;
            this.UserNameField.Text = "";
            this.UserNameField.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // SignupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UserNameField);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.Signup);
            this.Controls.Add(this.SignupasLabel);
            this.Controls.Add(this.AddressLabel);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.PhoneLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.Signupas);
            this.Controls.Add(this.AddressField);
            this.Controls.Add(this.PasswordField);
            this.Controls.Add(this.PhoneField);
            this.Controls.Add(this.NameField);
            this.Controls.Add(this.pictureBox1);
            this.Name = "SignupForm";
            this.Text = "SignupForm";
            this.Load += new System.EventHandler(this.SignupForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox NameField;
        private System.Windows.Forms.RichTextBox PhoneField;
        private System.Windows.Forms.RichTextBox PasswordField;
        private System.Windows.Forms.RichTextBox AddressField;
        private System.Windows.Forms.ComboBox Signupas;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label PhoneLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label AddressLabel;
        private System.Windows.Forms.Label SignupasLabel;
        private System.Windows.Forms.Button Signup;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox UserNameField;
    }
}