using Microsoft.Data.Sqlite;

namespace CafeManagement.Data
{
    public static class Database
    {
        private static readonly string DbPath = "cafe.db";
        private static SqliteConnection? _connection;

        public static SqliteConnection Connection
        {
            get
            {
                if (_connection == null || _connection.State != System.Data.ConnectionState.Open)
                {
                    _connection = new SqliteConnection($"Data Source={DbPath}");
                    _connection.Open();
                }
                return _connection;
            }
        }

        public static void Initialize()
        {
            var cmd = Connection.CreateCommand();
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
            SeedDefaultAdmin();
        }

        private static void SeedDefaultAdmin()
        {
            var check = Connection.CreateCommand();
            check.CommandText = "SELECT COUNT(*) FROM Users WHERE Username = 'admin'";
            var count = (long)(check.ExecuteScalar() ?? 0);

            if (count == 0)
            {
                var insert = Connection.CreateCommand();
                insert.CommandText = @"
                    INSERT INTO Users (Username, Password, Role, FullName)
                    VALUES ('admin', 'admin123', 'Admin', 'Administrator')
                ";
                insert.ExecuteNonQuery();
            }
        }
    }
}
