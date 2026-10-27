using System;
using System.Data;
using Microsoft.Data.Sqlite;
using CafeManagement.Data;

namespace CafeManagement.Repositories
{
    public class UserRepository
    {
        // 1. Lấy toàn bộ danh sách tài khoản đổ vào bảng DataTable
        public DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();
            using (var cmd = Database.Connection.CreateCommand())
            {
                cmd.CommandText = "SELECT Username, Password, FullName, Role FROM Users";
                using (var reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
            }
            return dt;
        }

        // 2. Thêm một tài khoản mới
        public bool AddUser(string username, string password, string fullName, string role)
        {
            // Kiểm tra trùng tài khoản trước khi thêm
            if (IsUsernameExists(username)) return false;

            using (var cmd = Database.Connection.CreateCommand())
            {
                cmd.CommandText = @"
                    INSERT INTO Users (Username, Password, Role, FullName) 
                    VALUES ($username, $password, $role, $fullName)";

                cmd.Parameters.AddWithValue("$username", username.Trim());
                cmd.Parameters.AddWithValue("$password", password);
                cmd.Parameters.AddWithValue("$role", role);
                cmd.Parameters.AddWithValue("$fullName", fullName);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // 3. Sửa Tên hiển thị và Quyền hạn
        public bool UpdateUser(string username, string fullName, string role)
        {
            using (var cmd = Database.Connection.CreateCommand())
            {
                cmd.CommandText = @"
                    UPDATE Users 
                    SET FullName = $fullName, Role = $role 
                    WHERE Username = $username";

                cmd.Parameters.AddWithValue("$fullName", fullName);
                cmd.Parameters.AddWithValue("$role", role);
                cmd.Parameters.AddWithValue("$username", username);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // 4. Đổi mật khẩu tài khoản
        public bool ChangePassword(string username, string newPassword)
        {
            using (var cmd = Database.Connection.CreateCommand())
            {
                cmd.CommandText = "UPDATE Users SET Password = $password WHERE Username = $username";
                cmd.Parameters.AddWithValue("$password", newPassword);
                cmd.Parameters.AddWithValue("$username", username);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // 5. Xóa tài khoản
        public bool DeleteUser(string username)
        {
            using (var cmd = Database.Connection.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM Users WHERE Username = $username";
                cmd.Parameters.AddWithValue("$username", username);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Kiểm tra xem tên tài khoản đã tồn tại hay chưa
        private bool IsUsernameExists(string username)
        {
            using (var cmd = Database.Connection.CreateCommand())
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Users WHERE Username = $username";
                cmd.Parameters.AddWithValue("$username", username.Trim());
                long count = (long)(cmd.ExecuteScalar() ?? 0);
                return count > 0;
            }
        }
    }
}
