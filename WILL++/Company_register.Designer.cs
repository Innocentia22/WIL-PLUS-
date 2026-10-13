namespace WILL__
{
    partial class Company_register
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            label1 = new Label();
            txtCompanyName = new TextBox();
            label2 = new Label();
            txtContactName = new TextBox();
            label3 = new Label();
            txtEmail = new TextBox();
            label4 = new Label();
            txtPhone = new TextBox();
            label5 = new Label();
            cmbIndustry = new ComboBox();
            label6 = new Label();
            txtPassword = new TextBox();
            label7 = new Label();
            txtConfirmPassword = new TextBox();
            btnRegister = new Button();
            txtWebsite = new TextBox();
            labelWebsite = new Label();
            txtAddress = new TextBox();
            labelAddress = new Label();
            btnBack = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(24, 18);
            label1.Name = "label1";
            label1.Size = new Size(253, 25);
            label1.TabIndex = 18;
            label1.Text = "Register Company Account";
            // 
            // txtCompanyName
            // 
            txtCompanyName.Location = new Point(24, 70);
            txtCompanyName.Name = "txtCompanyName";
            txtCompanyName.Size = new Size(360, 23);
            txtCompanyName.TabIndex = 16;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 52);
            label2.Name = "label2";
            label2.Size = new Size(94, 15);
            label2.TabIndex = 17;
            label2.Text = "Company Name";
            // 
            // txtContactName
            // 
            txtContactName.Location = new Point(24, 132);
            txtContactName.Name = "txtContactName";
            txtContactName.Size = new Size(360, 23);
            txtContactName.TabIndex = 14;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(24, 114);
            label3.Name = "label3";
            label3.Size = new Size(88, 15);
            label3.TabIndex = 15;
            label3.Text = "Contact Person";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(24, 194);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(360, 23);
            txtEmail.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(24, 176);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 13;
            label4.Text = "Email";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(24, 256);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(200, 23);
            txtPhone.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(24, 238);
            label5.Name = "label5";
            label5.Size = new Size(41, 15);
            label5.TabIndex = 11;
            label5.Text = "Phone";
            // 
            // cmbIndustry
            // 
            cmbIndustry.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbIndustry.FormattingEnabled = true;
            cmbIndustry.Items.AddRange(new object[] { "Information Technology", "Engineering", "Finance", "Other" });
            cmbIndustry.Location = new Point(24, 332);
            cmbIndustry.Name = "cmbIndustry";
            cmbIndustry.Size = new Size(220, 23);
            cmbIndustry.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(24, 314);
            label6.Name = "label6";
            label6.Size = new Size(50, 15);
            label6.TabIndex = 7;
            label6.Text = "Industry";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(24, 420);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(200, 23);
            txtPassword.TabIndex = 2;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(24, 402);
            label7.Name = "label7";
            label7.Size = new Size(57, 15);
            label7.TabIndex = 3;
            label7.Text = "Password";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(240, 420);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(144, 23);
            txtConfirmPassword.TabIndex = 1;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(24, 460);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(120, 30);
            btnRegister.TabIndex = 0;
            btnRegister.Text = "Register";
            btnRegister.Click += btnRegister_Click;
            // 
            // txtWebsite
            // 
            txtWebsite.Location = new Point(24, 288);
            txtWebsite.Name = "txtWebsite";
            txtWebsite.Size = new Size(360, 23);
            txtWebsite.TabIndex = 8;
            // 
            // labelWebsite
            // 
            labelWebsite.AutoSize = true;
            labelWebsite.Location = new Point(24, 270);
            labelWebsite.Name = "labelWebsite";
            labelWebsite.Size = new Size(104, 15);
            labelWebsite.TabIndex = 9;
            labelWebsite.Text = "Website (optional)";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(24, 376);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(360, 23);
            txtAddress.TabIndex = 4;
            // 
            // labelAddress
            // 
            labelAddress.AutoSize = true;
            labelAddress.Location = new Point(24, 358);
            labelAddress.Name = "labelAddress";
            labelAddress.Size = new Size(104, 15);
            labelAddress.TabIndex = 5;
            labelAddress.Text = "Address (optional)";
            // 
            // btnBack
            // 
            btnBack.Location = new Point(160, 460);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(120, 30);
            btnBack.TabIndex = 0;
            btnBack.Text = "Back";
            btnBack.Click += btnBack_Click;
            // 
            // Company_register
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 540);
            Controls.Add(btnRegister);
            Controls.Add(txtConfirmPassword);
            Controls.Add(txtPassword);
            Controls.Add(label7);
            Controls.Add(txtAddress);
            Controls.Add(labelAddress);
            Controls.Add(cmbIndustry);
            Controls.Add(label6);
            Controls.Add(txtWebsite);
            Controls.Add(labelWebsite);
            Controls.Add(txtPhone);
            Controls.Add(label5);
            Controls.Add(txtEmail);
            Controls.Add(label4);
            Controls.Add(txtContactName);
            Controls.Add(label3);
            Controls.Add(txtCompanyName);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Company_register";
            Text = "Company Register";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private TextBox txtCompanyName;
        private Label label2;
        private TextBox txtContactName;
        private Label label3;
        private TextBox txtEmail;
        private Label label4;
        private TextBox txtPhone;
        private Label label5;
        private ComboBox cmbIndustry;
        private Label label6;
        private TextBox txtPassword;
        private Label label7;
        private TextBox txtConfirmPassword;
        private Button btnRegister;
        private Button btnBack;
        private TextBox txtWebsite;
        private Label labelWebsite;
        private TextBox txtAddress;
        private Label labelAddress;
    }
}
