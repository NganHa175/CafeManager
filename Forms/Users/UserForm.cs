using System;
using System.Data;
using System.Windows.Forms;
using CafeManagement.Repositories;

namespace CafeManagement.Forms.Users
{
    public partial class UserForm : Form
    {
        private readonly UserRepository _userRepository = new UserRepository();
        private string currentLoginRole = "Admin";
        private string oldUsername = "";

        public UserForm()
        {
            InitializeComponent();
        }

        // Sự kiện chạy khi Form vừa được bật lên
        private void UserForm_Load_1(object sender, EventArgs e)
        {
            LoadUserList();
            LoadRoleComboBox();
        }
        // Load dữ liệu thật từ file SQLite lên DataGridView
        private void LoadUserList()
        {
            try
            {
                DataTable dt = _userRepository.GetAllUsers();
                UserData.DataSource = dt;

                //Tiêu đề các cột trên DataGridView
                if (UserData.Columns["Username"] != null) UserData.Columns["Username"].HeaderText = "Tài khoản";
                if (UserData.Columns["Password"] != null) UserData.Columns["Password"].HeaderText = "Mật khẩu";
                if (UserData.Columns["FullName"] != null) UserData.Columns["FullName"].HeaderText = "Tên hiển thị";
                if (UserData.Columns["Role"] != null) UserData.Columns["Role"].HeaderText = "Quyền hạn";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRoleComboBox()
        {
            AuthorityComboBox.Items.Clear();
            AuthorityComboBox.Items.Add("Admin");
            AuthorityComboBox.Items.Add("Staff");
            if (AuthorityComboBox.Items.Count > 0)
                AuthorityComboBox.SelectedIndex = 0;
        }

        // Click chọn dòng trên DataGridView màu đen, đẩy thông tin ngược lên ô nhập liệu
        private void UserData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && UserData.Rows[e.RowIndex].Cells["Username"].Value != null && !string.IsNullOrWhiteSpace(UserData.Rows[e.RowIndex].Cells["Username"].Value.ToString()))
            {
                DataGridViewRow row = UserData.Rows[e.RowIndex];

                AccountName.Text = row.Cells["Username"].Value?.ToString();
                Password.Text = row.Cells["Password"].Value?.ToString();
                UsernameDisplay.Text = row.Cells["FullName"].Value?.ToString();
                AuthorityComboBox.SelectedItem = row.Cells["Role"].Value?.ToString();

                // Ghi nhớ tên tài khoản cũ trước khi gõ sửa chữ
                oldUsername = AccountName.Text;

                // MỞ KHÓA HOÀN TOÀN
                AccountName.ReadOnly = false;
            }
            else
            {
                ClearFields();
            }
        }


        // NÚT THÊM
        private void AddButton_Click(object sender, EventArgs e)
        {
            if (currentLoginRole != "Admin")
            {
                MessageBox.Show("Chỉ có tài khoản quyền Admin mới được phép thêm tài khoản mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(AccountName.Text) || string.IsNullOrWhiteSpace(Password.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Tài khoản và Mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isSuccess = _userRepository.AddUser(
                AccountName.Text,
                Password.Text,
                UsernameDisplay.Text,
                AuthorityComboBox.SelectedItem.ToString()
            );

            if (isSuccess)
            {
                MessageBox.Show("Thêm tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUserList();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Thêm thất bại! Tài khoản này có thể đã tồn tại trong hệ thống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // NÚT SỬA
        private void ChangeButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AccountName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Thực hiện lệnh cập nhật trong file SQLite
                using (var cmd = CafeManagement.Data.Database.Connection.CreateCommand())
                {
                    // Lệnh SQL: Cập nhật lại toàn bộ thông tin dựa theo tên tài khoản gốc ban đầu
                    cmd.CommandText = @"
                        UPDATE Users 
                        SET Username = $newUsername, FullName = $fullName, Role = $role, Password = $password
                        WHERE Username = $oldUsername";

                    cmd.Parameters.AddWithValue("$newUsername", AccountName.Text.Trim());
                    cmd.Parameters.AddWithValue("$fullName", UsernameDisplay.Text);
                    cmd.Parameters.AddWithValue("$role", AuthorityComboBox.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("$password", Password.Text);
                    cmd.Parameters.AddWithValue("$oldUsername", oldUsername);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật và đổi tên tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadUserList();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy tài khoản cũ để cập nhật!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // NÚT ĐỔI MẬT KHẨU
        private void ChangePasswordButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AccountName.Text) || string.IsNullOrWhiteSpace(Password.Text))
            {
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu mới cần đổi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isSuccess = _userRepository.ChangePassword(AccountName.Text, Password.Text);

            if (isSuccess)
            {
                MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUserList();
                ClearFields();
            }
            else
            {
                MessageBox.Show("Đổi mật khẩu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // NÚT XÓA
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AccountName.Text))
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra ràng buộc không cho xóa tài khoản Admin
            if (AuthorityComboBox.SelectedItem?.ToString() == "Admin")
            {
                MessageBox.Show("Không được phép xóa tài khoản thuộc nhóm quyền Admin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dialogResult = MessageBox.Show($"Bạn có chắc chắn muốn xóa tài khoản {AccountName.Text}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                bool isSuccess = _userRepository.DeleteUser(AccountName.Text);
                if (isSuccess)
                {
                    MessageBox.Show("Xóa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadUserList();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Xóa tài khoản thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ClearFields()
        {
            AccountName.Text = "";
            Password.Text = "";
            UsernameDisplay.Text = "";
            if (AuthorityComboBox.Items.Count > 0) AuthorityComboBox.SelectedIndex = 0;
            AccountName.ReadOnly = false;
        }

        // --- Giữ nguyên các hàm trống tránh lỗi liên kết Designer ---
        private void AccountLabel_Click(object sender, EventArgs e) { }
        private void AccountName_TextChanged(object sender, EventArgs e) { }
        private void PasswordLabel_Click(object sender, EventArgs e) { }
        private void Password_TextChanged(object sender, EventArgs e) { }
        private void UsernameDisplayLabel_Click(object sender, EventArgs e) { }
        private void UsernameDisplay_TextChanged(object sender, EventArgs e) { }
        private void AuthorityLabel_Click(object sender, EventArgs e) { }
        private void AuthorityComboBox_SelectedIndexChanged(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
    }
}
