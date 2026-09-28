using Microsoft.Data.Sqlite;

namespace CafeManagement.Data
{
    public static class Database
    {
        // File .db sẽ được tạo cạnh file .exe khi chạy
        private static readonly string DbPath = "cafe.db";
        public static string ConnectionString => $"Data Source={DbPath}";

        public static void Initialize()
        {
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS Users (
                    Id       INTEGER PRIMARY KEY AUTOINCREMENT,
                    Username TEXT    NOT NULL UNIQUE,
                    Password TEXT    NOT NULL,
                    Role     TEXT    NOT NULL DEFAULT 'Staff',
                    FullName TEXT    NOT NULL DEFAULT ''
                );

                CREATE TABLE IF NOT EXISTS MenuItems (
                    Id          INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name        TEXT    NOT NULL,
                    Price       REAL    NOT NULL DEFAULT 0,
                    Category    TEXT    NOT NULL DEFAULT '',
                    IsAvailable INTEGER NOT NULL DEFAULT 1
                );

                CREATE TABLE IF NOT EXISTS CafeTables (
                    Id        INTEGER PRIMARY KEY AUTOINCREMENT,
                    TableName TEXT    NOT NULL,
                    Status    TEXT    NOT NULL DEFAULT 'Empty'
                );

                CREATE TABLE IF NOT EXISTS Orders (
                    Id          INTEGER PRIMARY KEY AUTOINCREMENT,
                    TableId     INTEGER NOT NULL,
                    CreatedAt   TEXT    NOT NULL,
                    Status      TEXT    NOT NULL DEFAULT 'Open',
                    TotalAmount REAL    NOT NULL DEFAULT 0
                );

                CREATE TABLE IF NOT EXISTS OrderItems (
                    Id           INTEGER PRIMARY KEY AUTOINCREMENT,
                    OrderId      INTEGER NOT NULL,
                    MenuItemId   INTEGER NOT NULL,
                    MenuItemName TEXT    NOT NULL,
                    Price        REAL    NOT NULL,
                    Quantity     INTEGER NOT NULL DEFAULT 1
                );
            ";
            cmd.ExecuteNonQuery();

            // Tạo tài khoản admin mặc định nếu chưa có
            SeedDefaultAdmin(connection);
        }

        private static void SeedDefaultAdmin(SqliteConnection connection)
        {
            var check = connection.CreateCommand();
            check.CommandText = "SELECT COUNT(*) FROM Users WHERE Username = 'admin'";
            var count = (long)(check.ExecuteScalar() ?? 0);

            if (count == 0)
            {
                var insert = connection.CreateCommand();
                insert.CommandText = @"
                    INSERT INTO Users (Username, Password, Role, FullName)
                    VALUES ('admin', 'admin123', 'Admin', 'Administrator')
                ";
                insert.ExecuteNonQuery();
            }
        }
    }
}
