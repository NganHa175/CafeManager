using CafeManagement.Data;
using CafeManagement.Models;
using Microsoft.Data.Sqlite;

namespace CafeManagement.Repositories
{
    public class MenuRepository
    {
        // Lấy tất cả món
        public List<MenuItem> GetAll()
        {
            var list = new List<MenuItem>();

            using var connection = new SqliteConnection(Database.ConnectionString);
            connection.Open();

            var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT Id, Name, Price, Category, IsAvailable FROM MenuItems";

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new MenuItem
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Price = reader.GetDecimal(2),
                    Category = reader.GetString(3),
                    IsAvailable = reader.GetInt32(4) == 1,
                });
            }

            return list;
        }

        // Tìm kiếm theo tên
        public List<MenuItem> Search(string keyword)
        {
            var list = new List<MenuItem>();

            using var connection = new SqliteConnection(Database.ConnectionString);
            connection.Open();

            var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                SELECT Id, Name, Price, Category, IsAvailable 
                FROM MenuItems 
                WHERE Name LIKE @keyword
            ";
            cmd.Parameters.AddWithValue("@keyword", $"%{keyword}%");

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new MenuItem
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Price = reader.GetDecimal(2),
                    Category = reader.GetString(3),
                    IsAvailable = reader.GetInt32(4) == 1,
                });
            }

            return list;
        }

        // Thêm món mới
        public void Add(MenuItem item)
        {
            using var connection = new SqliteConnection(Database.ConnectionString);
            connection.Open();

            var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                INSERT INTO MenuItems (Name, Price, Category, IsAvailable)
                VALUES (@name, @price, @category, @isAvailable)
            ";
            cmd.Parameters.AddWithValue("@name", item.Name);
            cmd.Parameters.AddWithValue("@price", item.Price);
            cmd.Parameters.AddWithValue("@category", item.Category);
            cmd.Parameters.AddWithValue("@isAvailable", item.IsAvailable ? 1 : 0);

            cmd.ExecuteNonQuery();
        }

        // Cập nhật món
        public void Update(MenuItem item)
        {
            using var connection = new SqliteConnection(Database.ConnectionString);
            connection.Open();

            var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                UPDATE MenuItems 
                SET Name        = @name, 
                    Price       = @price, 
                    Category    = @category, 
                    IsAvailable = @isAvailable
                WHERE Id = @id
            ";
            cmd.Parameters.AddWithValue("@id", item.Id);
            cmd.Parameters.AddWithValue("@name", item.Name);
            cmd.Parameters.AddWithValue("@price", item.Price);
            cmd.Parameters.AddWithValue("@category", item.Category);
            cmd.Parameters.AddWithValue("@isAvailable", item.IsAvailable ? 1 : 0);

            cmd.ExecuteNonQuery();
        }

        // Xóa món
        public void Delete(int id)
        {
            using var connection = new SqliteConnection(Database.ConnectionString);
            connection.Open();

            var cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM MenuItems WHERE Id = @id";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }
    }
}
