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
            SeedDefaultStaff();
            SeedDefaultTables();
            SeedDefaultMenuItems();
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

        private static void SeedDefaultStaff()
        {
            var check = Connection.CreateCommand();
            check.CommandText = "SELECT COUNT(*) FROM Users WHERE Username = 'staff'";
            var count = (long)(check.ExecuteScalar() ?? 0);

            if (count == 0)
            {
                var insert = Connection.CreateCommand();
                insert.CommandText = @"
                    INSERT INTO Users (Username, Password, Role, FullName)
                    VALUES ('staff', 'staff123', 'Staff', 'Staff Member')
                ";
                insert.ExecuteNonQuery();
            }
        }

        private static void SeedDefaultTables()
        {
            var check = Connection.CreateCommand();
            check.CommandText = "SELECT COUNT(*) FROM CafeTables";
            var count = (long)(check.ExecuteScalar() ?? 0);

            if (count == 0)
            {
                var insert = Connection.CreateCommand();
                insert.CommandText = @"
                    INSERT INTO CafeTables (TableName, Status) VALUES ('Table 1', 'Empty');
                    INSERT INTO CafeTables (TableName, Status) VALUES ('Table 2', 'Empty');
                    INSERT INTO CafeTables (TableName, Status) VALUES ('Table 3', 'Empty');
                    INSERT INTO CafeTables (TableName, Status) VALUES ('Table 4', 'Empty');
                    INSERT INTO CafeTables (TableName, Status) VALUES ('Table 5', 'Empty');
                    INSERT INTO CafeTables (TableName, Status) VALUES ('Table 6', 'Empty');
                    INSERT INTO CafeTables (TableName, Status) VALUES ('Table 7', 'Empty');
                    INSERT INTO CafeTables (TableName, Status) VALUES ('Table 8', 'Empty');
                ";
                insert.ExecuteNonQuery();
            }
        }

        private static void SeedDefaultMenuItems()
        {
            var check = Connection.CreateCommand();
            check.CommandText = "SELECT COUNT(*) FROM MenuItems";
            var count = (long)(check.ExecuteScalar() ?? 0);

            if (count == 0)
            {
                var insert = Connection.CreateCommand();
                insert.CommandText = @"
                    INSERT INTO MenuItems (Name, Price, Category, IsAvailable) VALUES ('Black Coffee',    25000, 'Coffee',    1);
                    INSERT INTO MenuItems (Name, Price, Category, IsAvailable) VALUES ('Milk Coffee',     30000, 'Coffee',    1);
                    INSERT INTO MenuItems (Name, Price, Category, IsAvailable) VALUES ('Cappuccino',      45000, 'Coffee',    1);
                    INSERT INTO MenuItems (Name, Price, Category, IsAvailable) VALUES ('Latte',           45000, 'Coffee',    1);
                    INSERT INTO MenuItems (Name, Price, Category, IsAvailable) VALUES ('Americano',       40000, 'Coffee',    1);
                    INSERT INTO MenuItems (Name, Price, Category, IsAvailable) VALUES ('Green Tea',       30000, 'Tea',       1);
                    INSERT INTO MenuItems (Name, Price, Category, IsAvailable) VALUES ('Milk Tea',        45000, 'Tea',       1);
                    INSERT INTO MenuItems (Name, Price, Category, IsAvailable) VALUES ('Peach Tea',       40000, 'Tea',       1);
                    INSERT INTO MenuItems (Name, Price, Category, IsAvailable) VALUES ('Mango Smoothie',  50000, 'Smoothie',  1);
                    INSERT INTO MenuItems (Name, Price, Category, IsAvailable) VALUES ('Strawberry Smoothie', 50000, 'Smoothie', 1);
                    INSERT INTO MenuItems (Name, Price, Category, IsAvailable) VALUES ('Orange Juice',    40000, 'Juice',     1);
                    INSERT INTO MenuItems (Name, Price, Category, IsAvailable) VALUES ('Watermelon Juice',35000, 'Juice',     1);
                    INSERT INTO MenuItems (Name, Price, Category, IsAvailable) VALUES ('Croissant',       35000, 'Food',      1);
                    INSERT INTO MenuItems (Name, Price, Category, IsAvailable) VALUES ('Cheesecake',      55000, 'Food',      1);
                    INSERT INTO MenuItems (Name, Price, Category, IsAvailable) VALUES ('Tiramisu',        60000, 'Food',      1);
                ";
                insert.ExecuteNonQuery();
            }
        }
    }
}
