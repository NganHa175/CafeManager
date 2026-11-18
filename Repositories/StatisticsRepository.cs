using System;
using System.Data;
using Microsoft.Data.Sqlite;
using CafeManagement.Data;

namespace CafeManagement.Repositories
{
    public class StatisticsRepository
    {
        public DataTable GetPaidOrders(DateTime fromDate, DateTime toDate)
        {
            DataTable dt = new DataTable();
            using (var connection = new SqliteConnection(Database.ConnectionString))
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT 
                            o.Id AS [Mã Đơn], 
                            t.TableName AS [Tên Bàn], 
                            o.TotalAmount AS [Tổng Tiền], 
                            o.CreatedAt AS [Ngày Thanh Toán]
                        FROM Orders o
                        JOIN CafeTables t ON o.TableId = t.Id
                        WHERE o.Status = 'Paid'
                        AND date(o.CreatedAt) BETWEEN date($from) AND date($to)
                        ORDER BY o.CreatedAt DESC";

                    cmd.Parameters.AddWithValue("$from", fromDate.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("$to", toDate.ToString("yyyy-MM-dd"));

                    using (var reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            return dt;
        }
    }
}