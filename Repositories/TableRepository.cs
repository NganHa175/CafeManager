using CafeManagement.Data;
using CafeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeManagement.Repositories
{
    internal class TableRepository
    {
        public List<CafeTable> GetAll()
        {
            var list = new List<CafeTable>();
            var cmd = Database.Connection.CreateCommand();
            cmd.CommandText = "SELECT Id, TableName, Status FROM CafeTables";

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new CafeTable
                {
                    Id = reader.GetInt32(0),
                    TableName = reader.GetString(1),
                    Status = reader.GetString(2),
                });
            }
            return list;
        }

        public List<CafeTable> Search(string keyword)
        {
            var list = new List<CafeTable>();
            var cmd = Database.Connection.CreateCommand();
            cmd.CommandText = @"
                SELECT Id, TableName, Status 
                FROM CafeTables
                WHERE TableName LIKE @keyword
            ";
            cmd.Parameters.AddWithValue("@keyword", $"%{keyword}%");

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new CafeTable
                {
                    Id = reader.GetInt32(0),
                    TableName = reader.GetString(1),
                    Status = reader.GetString(2),
                });
            }
            return list;
        }

        public void Add(CafeTable item)
        {
            var cmd = Database.Connection.CreateCommand();
            cmd.CommandText = @"
                INSERT INTO CafeTables (TableName, Status)
                VALUES (@tablename, @status)
            ";
            cmd.Parameters.AddWithValue("@tablename", item.TableName);
            cmd.Parameters.AddWithValue("@status", item.Status);
            cmd.ExecuteNonQuery();
        }

        public void Update(CafeTable item)
        {
            var cmd = Database.Connection.CreateCommand();
            cmd.CommandText = @"
                UPDATE CafeTables 
                SET TableName    = @tablename,
                    Status       = @status
                WHERE Id = @id
            ";
            cmd.Parameters.AddWithValue("@id", item.Id);
            cmd.Parameters.AddWithValue("@tablename", item.TableName);
            cmd.Parameters.AddWithValue("@status", item.Status);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            var cmd = Database.Connection.CreateCommand();
            cmd.CommandText = "DELETE FROM CafeTables WHERE Id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
