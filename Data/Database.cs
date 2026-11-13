using Microsoft.Data.Sqlite;

namespace CafeManagement.Data
{
    public static class Database
    {
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
                    Price       INTEGER NOT NULL DEFAULT 0,
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
                    TotalAmount INTEGER NOT NULL DEFAULT 0
                );
                CREATE TABLE IF NOT EXISTS OrderItems (
                    Id           INTEGER PRIMARY KEY AUTOINCREMENT,
                    OrderId      INTEGER NOT NULL,
                    MenuItemId   INTEGER NOT NULL,
                    MenuItemName TEXT    NOT NULL,
                    Price        INTEGER NOT NULL,
                    Quantity     INTEGER NOT NULL DEFAULT 1
                );
            ";
            cmd.ExecuteNonQuery();

            SeedDefaultAdmin();
            SeedDefaultStaff();
            SeedDefaultTables();
            SeedDefaultMenuItems();
        }

        private static void SeedDefaultAdmin()
        {
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();
            var check = connection.CreateCommand();
            check.CommandText = "SELECT COUNT(*) FROM Users WHERE Username = 'admin'";
            if ((long)(check.ExecuteScalar() ?? 0) > 0) return;

            var insert = connection.CreateCommand();
            insert.CommandText = @"
                INSERT INTO Users (Username, Password, Role, FullName)
                VALUES ('admin', 'admin123', 'Admin', 'Administrator')
            ";
            insert.ExecuteNonQuery();
        }

        private static void SeedDefaultStaff()
        {
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();
            var check = connection.CreateCommand();
            check.CommandText = "SELECT COUNT(*) FROM Users WHERE Username = 'staff'";
            if ((long)(check.ExecuteScalar() ?? 0) > 0) return;

            var insert = connection.CreateCommand();
            insert.CommandText = @"
                INSERT INTO Users (Username, Password, Role, FullName)
                VALUES ('staff', 'staff123', 'Staff', 'Staff Member')
            ";
            insert.ExecuteNonQuery();
        }

        private static void SeedDefaultTables()
        {
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();
            var check = connection.CreateCommand();
            check.CommandText = "SELECT COUNT(*) FROM CafeTables";
            if ((long)(check.ExecuteScalar() ?? 0) > 0) return;

            var insert = connection.CreateCommand();
            insert.CommandText = @"
                INSERT INTO CafeTables (TableName, Status) VALUES ('Bàn 1', 'Empty');
                INSERT INTO CafeTables (TableName, Status) VALUES ('Bàn 2', 'Empty');
                INSERT INTO CafeTables (TableName, Status) VALUES ('Bàn 3', 'Empty');
                INSERT INTO CafeTables (TableName, Status) VALUES ('Bàn 4', 'Empty');
                INSERT INTO CafeTables (TableName, Status) VALUES ('Bàn 5', 'Empty');
                INSERT INTO CafeTables (TableName, Status) VALUES ('Bàn 6', 'Empty');
                INSERT INTO CafeTables (TableName, Status) VALUES ('Bàn 7', 'Empty');
                INSERT INTO CafeTables (TableName, Status) VALUES ('Bàn 8', 'Empty');
            ";
            insert.ExecuteNonQuery();
        }

        private static void SeedDefaultMenuItems()
        {
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();
            var check = connection.CreateCommand();
            check.CommandText = "SELECT COUNT(*) FROM MenuItems";
            if ((long)(check.ExecuteScalar() ?? 0) > 0) return;

            var insert = connection.CreateCommand();
            insert.CommandText = @"
                INSERT INTO MenuItems (Name, Price, Category, IsAvailable) VALUES ('Cà phê đen',     25000, 'Cà phê',   1);
                INSERT INTO MenuItems (Name, Price, Category, IsAvailable) VALUES ('Cà phê sữa',     30000, 'Cà phê',   1);
                INSERT INTO MenuItems (Name, Price, Category, IsAvailable) VALUES ('Cappuccino',      45000, 'Cà phê',   1);
                INSERT INTO MenuItems (Name, Price, Category, IsAvailable) VALUES ('Latte',           45000, 'Cà phê',   1);
                INSERT INTO MenuItems (Name, Price, Category, IsAvailable) VALUES ('Trà xanh',        30000, 'Trà',      1);
                INSERT INTO MenuItems (Name, Price, Category, IsAvailable) VALUES ('Trà sữa',         45000, 'Trà',      1);
                INSERT INTO MenuItems (Name, Price, Category, IsAvailable) VALUES ('Sinh tố xoài',    50000, 'Sinh tố',  1);
                INSERT INTO MenuItems (Name, Price, Category, IsAvailable) VALUES ('Nước cam',        40000, 'Nước ép',  1);
                INSERT INTO MenuItems (Name, Price, Category, IsAvailable) VALUES ('Bánh croissant',  35000, 'Bánh',     1);
                INSERT INTO MenuItems (Name, Price, Category, IsAvailable) VALUES ('Cheesecake',      55000, 'Bánh',     1);
            ";
            insert.ExecuteNonQuery();
        }
    }
}
