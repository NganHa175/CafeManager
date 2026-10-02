using CafeManagement.Data;
using CafeManagement.Forms.Dashboard;
using CafeManagement.Helpers;
using Microsoft.Data.Sqlite;

namespace CafeManagement.Forms.Auth
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Kiểm tra không được để trống
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblError.Text = "Please enter your username and password.";
                return;
            }

            // Kết nối database và kiểm tra tài khoản
            using var connection = new SqliteConnection(Database.ConnectionString);
            connection.Open();

            var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                SELECT Id, FullName, Role 
                FROM Users 
                WHERE Username = @username AND Password = @password
            ";
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                // Đăng nhập thành công → mở MainForm trước, Toast hiện sau
                string fullName = reader.GetString(1);
                string role = reader.GetString(2);

                this.Hide();
                new MainForm(fullName, role).ShowDialog();
                this.Close();
            }
            else
            {
                // Sai tài khoản hoặc mật khẩu
                lblError.Text = "Invalid username or password.";
                ToastForm.Error("Login failed. Please try again.");
            }
        }
    }
}
