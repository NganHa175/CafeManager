using CafeManagement.Data;
using CafeManagement.Models;

namespace CafeManagement.Repositories
{
    public class MenuRepository
    {
        public List<MenuItem> GetAll()
        {
            var list = new List<MenuItem>();
            var cmd = Database.Connection.CreateCommand();
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

        public List<MenuItem> Search(string keyword)
        {
            var list = new List<MenuItem>();
            var cmd = Database.Connection.CreateCommand();
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

        public void Add(MenuItem item)
        {
            var cmd = Database.Connection.CreateCommand();
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

        public void Update(MenuItem item)
        {
            var cmd = Database.Connection.CreateCommand();
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

        public void Delete(int id)
        {
            var cmd = Database.Connection.CreateCommand();
            cmd.CommandText = "DELETE FROM MenuItems WHERE Id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
