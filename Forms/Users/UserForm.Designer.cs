namespace CafeManagement.Forms.Users
{
    partial class UserForm
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
            AccountLabel = new Label();
            PasswordLabel = new Label();
            UsernameDisplayLabel = new Label();
            AccountName = new TextBox();
            Password = new TextBox();
            UsernameDisplay = new TextBox();
            AuthorityComboBox = new ComboBox();
            AddButton = new Button();
            DeleteButton = new Button();
            ChangeButton = new Button();
            ChangePasswordButton = new Button();
            UserData = new DataGridView();
            AuthorityLabel = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)UserData).BeginInit();
            SuspendLayout();
            // 
            // AccountLabel
            // 
            AccountLabel.AutoSize = true;
            AccountLabel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AccountLabel.Location = new Point(404, 15);
            AccountLabel.Name = "AccountLabel";
            AccountLabel.Size = new Size(99, 28);
            AccountLabel.TabIndex = 0;
            AccountLabel.Text = "Tài khoản";
            AccountLabel.Click += AccountLabel_Click;
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PasswordLabel.Location = new Point(405, 66);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(98, 28);
            PasswordLabel.TabIndex = 1;
            PasswordLabel.Text = "Mật khẩu";
            PasswordLabel.Click += PasswordLabel_Click;
            // 
            // UsernameDisplayLabel
            // 
            UsernameDisplayLabel.AutoSize = true;
            UsernameDisplayLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UsernameDisplayLabel.Location = new Point(405, 117);
            UsernameDisplayLabel.Name = "UsernameDisplayLabel";
            UsernameDisplayLabel.Size = new Size(109, 25);
            UsernameDisplayLabel.TabIndex = 2;
            UsernameDisplayLabel.Text = "Tên hiển thị";
            UsernameDisplayLabel.Click += UsernameDisplayLabel_Click;
            // 
            // AccountName
            // 
            AccountName.BackColor = SystemColors.Info;
            AccountName.BorderStyle = BorderStyle.FixedSingle;
            AccountName.Location = new Point(509, 12);
            AccountName.Name = "AccountName";
            AccountName.Size = new Size(177, 31);
            AccountName.TabIndex = 3;
            AccountName.TextChanged += AccountName_TextChanged;
            // 
            // Password
            // 
            Password.BackColor = SystemColors.Info;
            Password.BorderStyle = BorderStyle.FixedSingle;
            Password.Location = new Point(509, 63);
            Password.Name = "Password";
            Password.Size = new Size(177, 31);
            Password.TabIndex = 4;
            Password.TextChanged += Password_TextChanged;
            // 
            // UsernameDisplay
            // 
            UsernameDisplay.BackColor = SystemColors.Info;
            UsernameDisplay.BorderStyle = BorderStyle.FixedSingle;
            UsernameDisplay.Location = new Point(509, 115);
            UsernameDisplay.Name = "UsernameDisplay";
            UsernameDisplay.Size = new Size(177, 31);
            UsernameDisplay.TabIndex = 5;
            UsernameDisplay.TextChanged += UsernameDisplay_TextChanged;
            // 
            // AuthorityComboBox
            // 
            AuthorityComboBox.BackColor = SystemColors.Info;
            AuthorityComboBox.FormattingEnabled = true;
            AuthorityComboBox.Location = new Point(509, 166);
            AuthorityComboBox.Name = "AuthorityComboBox";
            AuthorityComboBox.Size = new Size(177, 33);
            AuthorityComboBox.TabIndex = 6;
            AuthorityComboBox.SelectedIndexChanged += AuthorityComboBox_SelectedIndexChanged;
            // 
            // AddButton
            // 
            AddButton.BackColor = Color.FromArgb(101, 67, 33);
            AddButton.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddButton.ForeColor = Color.White;
            AddButton.Location = new Point(405, 299);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(137, 83);
            AddButton.TabIndex = 7;
            AddButton.Text = "Thêm";
            AddButton.UseVisualStyleBackColor = false;
            AddButton.Click += AddButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.BackColor = Color.FromArgb(101, 67, 33);
            DeleteButton.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DeleteButton.ForeColor = Color.White;
            DeleteButton.Location = new Point(548, 299);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(137, 83);
            DeleteButton.TabIndex = 8;
            DeleteButton.Text = "Xóa";
            DeleteButton.UseVisualStyleBackColor = false;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // ChangeButton
            // 
            ChangeButton.BackColor = Color.FromArgb(101, 67, 33);
            ChangeButton.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ChangeButton.ForeColor = Color.White;
            ChangeButton.Location = new Point(405, 388);
            ChangeButton.Name = "ChangeButton";
            ChangeButton.Size = new Size(137, 83);
            ChangeButton.TabIndex = 9;
            ChangeButton.Text = "Sửa";
            ChangeButton.UseVisualStyleBackColor = false;
            ChangeButton.Click += ChangeButton_Click;
            // 
            // ChangePasswordButton
            // 
            ChangePasswordButton.BackColor = Color.FromArgb(101, 67, 33);
            ChangePasswordButton.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ChangePasswordButton.ForeColor = Color.White;
            ChangePasswordButton.Location = new Point(548, 388);
            ChangePasswordButton.Name = "ChangePasswordButton";
            ChangePasswordButton.Size = new Size(138, 83);
            ChangePasswordButton.TabIndex = 10;
            ChangePasswordButton.Text = "Đổi mật khẩu";
            ChangePasswordButton.UseVisualStyleBackColor = false;
            ChangePasswordButton.Click += ChangePasswordButton_Click;
            // 
            // UserData
            // 
            UserData.BackgroundColor = SystemColors.Info;
            UserData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            UserData.GridColor = Color.Wheat;
            UserData.Location = new Point(12, 12);
            UserData.Name = "UserData";
            UserData.RowHeadersWidth = 62;
            UserData.Size = new Size(387, 480);
            UserData.TabIndex = 11;
            UserData.CellClick += UserData_CellClick;
            // 
            // AuthorityLabel
            // 
            AuthorityLabel.AutoSize = true;
            AuthorityLabel.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AuthorityLabel.Location = new Point(405, 166);
            AuthorityLabel.Name = "AuthorityLabel";
            AuthorityLabel.Size = new Size(102, 25);
            AuthorityLabel.TabIndex = 12;
            AuthorityLabel.Text = "Quyền hạn";
            AuthorityLabel.Click += AuthorityLabel_Click;
            // 
            // label5
            // 
            label5.Font = new Font("Freestyle Script", 28F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(101, 67, 33);
            label5.Location = new Point(462, 218);
            label5.Name = "label5";
            label5.Size = new Size(194, 69);
            label5.TabIndex = 13;
            label5.Text = "Coffee☕";
            label5.Click += label5_Click;
            // 
            // UserForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 240, 235);
            ClientSize = new Size(698, 504);
            Controls.Add(label5);
            Controls.Add(AuthorityLabel);
            Controls.Add(UserData);
            Controls.Add(ChangePasswordButton);
            Controls.Add(ChangeButton);
            Controls.Add(DeleteButton);
            Controls.Add(AddButton);
            Controls.Add(AuthorityComboBox);
            Controls.Add(UsernameDisplay);
            Controls.Add(Password);
            Controls.Add(AccountName);
            Controls.Add(UsernameDisplayLabel);
            Controls.Add(PasswordLabel);
            Controls.Add(AccountLabel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "UserForm";
            Text = "UserForm";
            Load += UserForm_Load_1;
            ((System.ComponentModel.ISupportInitialize)UserData).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label AccountLabel;
        private Label PasswordLabel;
        private Label UsernameDisplayLabel;
        private TextBox AccountName;
        private TextBox Password;
        private TextBox UsernameDisplay;
        private ComboBox AuthorityComboBox;
        private Button AddButton;
        private Button DeleteButton;
        private Button ChangeButton;
        private Button ChangePasswordButton;
        private DataGridView UserData;
        private Label AuthorityLabel;
        private Label label5;
    }
}