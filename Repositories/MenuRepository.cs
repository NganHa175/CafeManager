using CafeManagement.Data;
using CafeManagement.Models;
using Microsoft.Data.Sqlite;

namespace CafeManagement.Repositories
{
    public class MenuRepository
    {
        public List<MenuItem> GetAll()
        {
            var list = new List<MenuItem>();
            using var connection = new SqliteConnection(Database.ConnectionString);
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT Id, Name, Price, Category, IsAvailable FROM MenuItems ORDER BY Category, Name";
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                list.Add(Read(reader));
            return list;
        }

        public List<MenuItem> Search(string keyword)
        {
            var list = new List<MenuItem>();
            using var connection = new SqliteConnection(Database.ConnectionString);
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                SELECT Id, Name, Price, Category, IsAvailable
                FROM MenuItems
                WHERE Name LIKE @kw OR Category LIKE @kw
                ORDER BY Category, Name
            ";
            cmd.Parameters.AddWithValue("@kw", $"%{keyword}%");
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                list.Add(Read(reader));
            return list;
        }

        public void Add(MenuItem item)
        {
            using var connection = new SqliteConnection(Database.ConnectionString);
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                INSERT INTO MenuItems (Name, Price, Category, IsAvailable)
                VALUES (@name, @price, @category, @available)
            ";
            cmd.Parameters.AddWithValue("@name", item.Name);
            cmd.Parameters.AddWithValue("@price", item.Price);
            cmd.Parameters.AddWithValue("@category", item.Category);
            cmd.Parameters.AddWithValue("@available", item.IsAvailable ? 1 : 0);
            cmd.ExecuteNonQuery();
        }

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
                    IsAvailable = @available
                WHERE Id = @id
            ";
            cmd.Parameters.AddWithValue("@id", item.Id);
            cmd.Parameters.AddWithValue("@name", item.Name);
            cmd.Parameters.AddWithValue("@price", item.Price);
            cmd.Parameters.AddWithValue("@category", item.Category);
            cmd.Parameters.AddWithValue("@available", item.IsAvailable ? 1 : 0);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var connection = new SqliteConnection(Database.ConnectionString);
            connection.Open();
            var cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM MenuItems WHERE Id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        private static MenuItem Read(SqliteDataReader r) => new MenuItem
        {
            Id = r.GetInt32(0),
            Name = r.GetString(1),
            Price = r.GetInt64(2),
            Category = r.GetString(3),
            IsAvailable = r.GetInt32(4) == 1,
        };
    }
}
