# Project Source

## Structure

```text
.gitattributes
.gitignore
CafeManagement.csproj
CafeManagement.csproj.user
CafeManagement.sln
Program.cs
Data\Database.cs
Forms\Auth\LoginForm.cs
Forms\Auth\LoginForm.Designer.cs
Forms\Auth\LoginForm.resx
Forms\Dashboard\MainForm.cs
Forms\Dashboard\MainForm.Designer.cs
Forms\Dashboard\MainForm.resx
Forms\Menu\MenuForm.cs
Forms\Menu\MenuForm.Designer.cs
Forms\Menu\MenuForm.resx
Helpers\ToastForm.cs
Models\CafeTable.cs
Models\MenuItem.cs
Models\Order.cs
Models\OrderItem.cs
Models\User.cs
Repositories\MenuRepository.cs
```

## Program.cs

```csharp
using CafeManagement.Data;
using CafeManagement.Forms.Auth;

namespace CafeManagement
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Database.Initialize();
            Application.Run(new LoginForm());
        }
    }
}
```

## Data\Database.cs

```csharp
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
                if (_connection == null)
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
```

## Forms\Auth\LoginForm.cs

```csharp
using CafeManagement.Data;
using CafeManagement.Forms.Dashboard;
using CafeManagement.Helpers;
using Microsoft.Data.Sqlite;

namespace CafeManagement.Forms.Auth
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Kiểm tra không được để trống
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblError.Text = "Please enter your username and password.";
                return;
            }

            // Kết nối database và kiểm tra tài khoản
            using var connection = new SqliteConnection(Database.ConnectionString);
            connection.Open();

            var cmd = connection.CreateCommand();
            cmd.CommandText = @"
                SELECT Id, FullName, Role 
                FROM Users 
                WHERE Username = @username AND Password = @password
            ";
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                // Đăng nhập thành công → mở MainForm trước, Toast hiện sau
                string fullName = reader.GetString(1);
                string role = reader.GetString(2);

                this.Hide();
                new MainForm(fullName, role).ShowDialog();
                this.Close();
            }
            else
            {
                // Sai tài khoản hoặc mật khẩu
                lblError.Text = "Invalid username or password.";
                ToastForm.Error("Login failed. Please try again.");
            }
        }
    }
}
```

## Forms\Auth\LoginForm.Designer.cs

```csharp
namespace CafeManagement.Forms.Auth
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private Label lblUsername;
        private Label lblPassword;
        private Label lblError;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // ── Form ──────────────────────────────────────────
            this.Text = "Cafe Manager - Login";
            this.ClientSize = new Size(420, 320);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.FromArgb(245, 240, 235); // cream

            // ── Title ─────────────────────────────────────────
            lblTitle = new Label
            {
                Text = "☕ CAFE MANAGER",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.FromArgb(101, 67, 33),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 65,
                Padding = new Padding(0, 12, 0, 0),
            };

            // ── Username label ────────────────────────────────
            lblUsername = new Label
            {
                Text = "Username",
                Location = new Point(80, 90),
                AutoSize = true,
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(80, 50, 20),
            };

            // ── Username textbox ──────────────────────────────
            txtUsername = new TextBox
            {
                Name = "txtUsername",
                Location = new Point(80, 112),
                Size = new Size(250, 30),
                Font = new Font("Segoe UI", 11),
                BorderStyle = BorderStyle.FixedSingle,
            };

            // ── Password label ────────────────────────────────
            lblPassword = new Label
            {
                Text = "Password",
                Location = new Point(80, 152),
                AutoSize = true,
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(80, 50, 20),
            };

            // ── Password textbox ──────────────────────────────
            txtPassword = new TextBox
            {
                Name = "txtPassword",
                Location = new Point(80, 174),
                Size = new Size(250, 30),
                Font = new Font("Segoe UI", 11),
                PasswordChar = '*',
                BorderStyle = BorderStyle.FixedSingle,
            };

            // ── Error label ───────────────────────────────────
            lblError = new Label
            {
                Text = "",
                Location = new Point(80, 212),
                Size = new Size(250, 20),
                ForeColor = Color.Red,
                Font = new Font("Segoe UI", 9),
            };

            // ── Login button ──────────────────────────────────
            btnLogin = new Button
            {
                Name = "btnLogin",
                Text = "Login",
                Location = new Point(80, 238),
                Size = new Size(250, 38),
                BackColor = Color.FromArgb(101, 67, 33),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
            };
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Click += new EventHandler(btnLogin_Click);

            // ── Thêm controls vào form ────────────────────────
            this.Controls.AddRange(new Control[]
            {
                lblTitle,
                lblUsername, txtUsername,
                lblPassword, txtPassword,
                lblError,
                btnLogin,
            });
        }
    }
}
```

## Forms\Dashboard\MainForm.cs

```csharp
using CafeManagement.Forms.Auth;
using CafeManagement.Helpers;

namespace CafeManagement.Forms.Dashboard
{
    public partial class MainForm : Form
    {
        private string _currentUserName;
        private string _currentUserRole;

        public MainForm(string fullName, string role)
        {
            InitializeComponent();
            _currentUserName = fullName;
            _currentUserRole = role;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            lblCurrentUser.Text = $"{_currentUserName}\n({_currentUserRole})";
            ToastForm.Success($"Welcome, {_currentUserName}!");
            NavigateTo("menu");
        }

        private void NavigateTo(string section)
        {
            pnlContent.Controls.Clear();

            switch (section)
            {
                case "menu":
                    var menuForm = new CafeManagement.Forms.Menu.MenuForm
                    {
                        TopLevel = false,
                        FormBorderStyle = FormBorderStyle.None,
                        Dock = DockStyle.Fill,
                    };
                    pnlContent.Controls.Add(menuForm);
                    menuForm.Show();
                    SetActiveButton(btnMenu);
                    break;

                case "tables":
                    pnlContent.Controls.Add(MakePlaceholder("TABLES"));
                    SetActiveButton(btnTables);
                    break;

                case "orders":
                    pnlContent.Controls.Add(MakePlaceholder("ORDERS"));
                    SetActiveButton(btnOrders);
                    break;

                case "statistics":
                    pnlContent.Controls.Add(MakePlaceholder("STATISTICS"));
                    SetActiveButton(btnStatistics);
                    break;
            }
        }

        private Label MakePlaceholder(string text)
        {
            return new Label
            {
                Text = $"[ {text} — Coming soon ]",
                Font = new Font("Segoe UI", 14),
                ForeColor = Color.FromArgb(101, 67, 33),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
            };
        }

        private void SetActiveButton(Button activeBtn)
        {
            var sidebarButtons = new[] { btnMenu, btnTables, btnOrders, btnStatistics };
            foreach (var btn in sidebarButtons)
            {
                btn.BackColor = Color.Transparent;
                btn.ForeColor = Color.White;
            }
            activeBtn.BackColor = Color.FromArgb(80, 50, 20);
            activeBtn.ForeColor = Color.White;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "Are you sure you want to logout?",
                "Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                this.Hide();
                new LoginForm().ShowDialog();
                this.Close();
            }
        }
    }
}
```

## Forms\Dashboard\MainForm.Designer.cs

```csharp
namespace CafeManagement.Forms.Dashboard
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel pnlSidebar;
        private Label lblAppTitle;
        private Label lblCurrentUser;
        private Button btnMenu;
        private Button btnTables;
        private Button btnOrders;
        private Button btnStatistics;
        private Button btnLogout;
        private Panel pnlContent;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.Text = "Cafe Manager";
            this.ClientSize = new Size(900, 560);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(900, 560);
            this.BackColor = Color.FromArgb(245, 240, 235);

            pnlSidebar = new Panel
            {
                Dock = DockStyle.Left,
                Width = 180,
                BackColor = Color.FromArgb(101, 67, 33),
            };

            lblAppTitle = new Label
            {
                Text = "☕ CAFE\nMANAGER",
                Font = new Font("Segoe UI", 13, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 80,
                Padding = new Padding(0, 15, 0, 0),
            };

            lblCurrentUser = new Label
            {
                Text = "",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(220, 200, 180),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 35,
                Padding = new Padding(0, 5, 0, 5),
            };

            btnMenu = CreateSidebarButton("🍽  Menu");
            btnTables = CreateSidebarButton("🪑  Tables");
            btnOrders = CreateSidebarButton("📋  Orders");
            btnStatistics = CreateSidebarButton("📊  Statistics");

            btnLogout = new Button
            {
                Text = "⬅  Logout",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(220, 180, 160),
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                Dock = DockStyle.Bottom,
                Height = 45,
                Cursor = Cursors.Hand,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(20, 0, 0, 0),
            };
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatAppearance.MouseOverBackColor = Color.FromArgb(80, 50, 20);
            btnLogout.Click += new EventHandler(btnLogout_Click);

            pnlSidebar.Controls.Add(btnStatistics);
            pnlSidebar.Controls.Add(btnOrders);
            pnlSidebar.Controls.Add(btnTables);
            pnlSidebar.Controls.Add(btnMenu);
            pnlSidebar.Controls.Add(lblCurrentUser);
            pnlSidebar.Controls.Add(lblAppTitle);
            pnlSidebar.Controls.Add(btnLogout);

            pnlContent = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(245, 240, 235),
                Padding = new Padding(0),
                AutoScroll = true,
            };

            this.Controls.Add(pnlContent);
            this.Controls.Add(pnlSidebar);

            btnMenu.Click += (s, e) => NavigateTo("menu");
            btnTables.Click += (s, e) => NavigateTo("tables");
            btnOrders.Click += (s, e) => NavigateTo("orders");
            btnStatistics.Click += (s, e) => NavigateTo("statistics");
        }

        private Button CreateSidebarButton(string text)
        {
            var btn = new Button
            {
                Text = text,
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                Dock = DockStyle.Top,
                Height = 45,
                Cursor = Cursors.Hand,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(20, 0, 0, 0),
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(80, 50, 20);
            return btn;
        }
    }
}
```

## Forms\Menu\MenuForm.cs

```csharp
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
```

## Forms\Menu\MenuForm.Designer.cs

```csharp
namespace CafeManagement.Forms.Menu
{
    partial class MenuForm
    {
        private System.ComponentModel.IContainer components = null;

        private DataGridView dgvMenu;
        private TextBox txtSearch;
        private Label lblSearch;
        private Label lblCount;
        private Button btnDelete;
        private Panel pnlRight;
        private Label lblTitle;
        private Label lblName;
        private Label lblPrice;
        private Label lblCategory;
        private TextBox txtName;
        private TextBox txtPrice;
        private TextBox txtCategory;
        private CheckBox chkAvailable;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnClear;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.Text = "Menu Management";
            this.BackColor = Color.FromArgb(245, 240, 235);

            lblTitle = new Label
            {
                Text = "🍽  Menu Management",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(101, 67, 33),
                Dock = DockStyle.Top,
                Height = 45,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(10, 0, 0, 0),
            };

            var pnlTop = new Panel
            {
                Dock = DockStyle.Top,
                Height = 40,
                BackColor = Color.FromArgb(245, 240, 235),
            };

            lblSearch = new Label
            {
                Text = "Search:",
                Font = new Font("Segoe UI", 10),
                Location = new Point(10, 8),
                AutoSize = true,
            };

            txtSearch = new TextBox
            {
                Font = new Font("Segoe UI", 10),
                Location = new Point(75, 5),
                Size = new Size(200, 28),
            };
            txtSearch.TextChanged += new EventHandler(txtSearch_TextChanged);

            pnlTop.Controls.AddRange(new Control[] { lblSearch, txtSearch });

            var pnlMain = new Panel
            {
                Dock = DockStyle.Fill,
            };

            dgvMenu = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                Font = new Font("Segoe UI", 9),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            };
            dgvMenu.Columns.Add("Id", "ID");
            dgvMenu.Columns.Add("Name", "Name");
            dgvMenu.Columns.Add("Price", "Price");
            dgvMenu.Columns.Add("Category", "Category");
            dgvMenu.Columns.Add("Available", "Available");
            dgvMenu.Columns["Id"].Visible = false;
            dgvMenu.EnableHeadersVisualStyles = false;
            dgvMenu.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(101, 67, 33);
            dgvMenu.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvMenu.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgvMenu.CellClick += new DataGridViewCellEventHandler(dgvMenu_CellClick);

            var pnlLeft = new Panel
            {
                Dock = DockStyle.Fill,
            };

            var pnlBottom = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 40,
                BackColor = Color.FromArgb(245, 240, 235),
            };

            lblCount = new Label
            {
                Text = "Total: 0 items",
                Font = new Font("Segoe UI", 9),
                Location = new Point(10, 10),
                AutoSize = true,
            };

            btnDelete = new Button
            {
                Text = "Delete",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = Color.FromArgb(180, 40, 40),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(310, 5),
                Size = new Size(100, 30),
                Cursor = Cursors.Hand,
            };
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.Click += new EventHandler(btnDelete_Click);

            pnlBottom.Controls.AddRange(new Control[] { lblCount, btnDelete });

            pnlLeft.Controls.Add(dgvMenu);
            pnlLeft.Controls.Add(pnlBottom);

            pnlRight = new Panel
            {
                Dock = DockStyle.Right,
                Width = 310,
                BackColor = Color.White,
                Padding = new Padding(15),
            };

            lblName = new Label
            {
                Text = "Name",
                Font = new Font("Segoe UI", 10),
                Location = new Point(15, 20),
                AutoSize = true,
            };
            txtName = new TextBox
            {
                Font = new Font("Segoe UI", 10),
                Location = new Point(15, 42),
                Size = new Size(270, 28),
            };

            lblCategory = new Label
            {
                Text = "Category",
                Font = new Font("Segoe UI", 10),
                Location = new Point(15, 82),
                AutoSize = true,
            };
            txtCategory = new TextBox
            {
                Font = new Font("Segoe UI", 10),
                Location = new Point(15, 104),
                Size = new Size(270, 28),
            };

            lblPrice = new Label
            {
                Text = "Price",
                Font = new Font("Segoe UI", 10),
                Location = new Point(15, 144),
                AutoSize = true,
            };
            txtPrice = new TextBox
            {
                Font = new Font("Segoe UI", 10),
                Location = new Point(15, 166),
                Size = new Size(270, 28),
            };

            chkAvailable = new CheckBox
            {
                Text = "Available",
                Font = new Font("Segoe UI", 10),
                Location = new Point(15, 210),
                AutoSize = true,
                Checked = true,
            };

            btnAdd = new Button
            {
                Text = "Add",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = Color.FromArgb(101, 67, 33),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(15, 260),
                Size = new Size(80, 32),
                Cursor = Cursors.Hand,
            };
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.Click += new EventHandler(btnAdd_Click);

            btnUpdate = new Button
            {
                Text = "Update",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = Color.FromArgb(101, 67, 33),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(105, 260),
                Size = new Size(80, 32),
                Cursor = Cursors.Hand,
            };
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.Click += new EventHandler(btnUpdate_Click);

            btnClear = new Button
            {
                Text = "Clear",
                Font = new Font("Segoe UI", 10),
                BackColor = Color.FromArgb(200, 190, 180),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(195, 260),
                Size = new Size(80, 32),
                Cursor = Cursors.Hand,
            };
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.Click += new EventHandler(btnClear_Click);

            pnlRight.Controls.AddRange(new Control[]
            {
                lblName,     txtName,
                lblCategory, txtCategory,
                lblPrice,    txtPrice,
                chkAvailable,
                btnAdd, btnUpdate, btnClear,
            });

            pnlMain.Controls.Add(pnlLeft);
            pnlMain.Controls.Add(pnlRight);

            this.Controls.Add(pnlMain);
            this.Controls.Add(pnlTop);
            this.Controls.Add(lblTitle);
        }
    }
}
```

## Helpers\ToastForm.cs

```csharp
namespace CafeManagement.Helpers
{
    public static class ToastForm
    {
        public static void Show(string message, string title = "Notice", int seconds = 3)
        {
            var form = new Form
            {
                Text = title,
                ClientSize = new Size(320, 130),
                StartPosition = FormStartPosition.CenterScreen,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                TopMost = true,
            };

            var picIcon = new PictureBox
            {
                Image = SystemIcons.Information.ToBitmap(),
                Location = new Point(20, 30),
                Size = new Size(32, 32),
            };

            var lblMessage = new Label
            {
                Text = message,
                Font = new Font("Segoe UI", 10),
                Location = new Point(65, 25),
                Size = new Size(235, 50),
                TextAlign = ContentAlignment.MiddleLeft,
            };

            var lblCountdown = new Label
            {
                Text = $"Closing in {seconds}s...",
                Font = new Font("Segoe UI", 8),
                ForeColor = Color.Gray,
                Location = new Point(20, 80),
                AutoSize = true,
            };

            var btnOK = new Button
            {
                Text = "OK",
                Size = new Size(75, 26),
                Location = new Point(225, 75),
                Cursor = Cursors.Hand,
            };
            btnOK.Click += (s, e) => form.Close();

            form.Controls.AddRange(new Control[]
            {
                picIcon, lblMessage, lblCountdown, btnOK
            });

            int remaining = seconds;
            var timer = new System.Windows.Forms.Timer { Interval = 1000 };
            timer.Tick += (s, e) =>
            {
                remaining--;
                lblCountdown.Text = $"Closing in {remaining}s...";
                if (remaining <= 0)
                {
                    timer.Stop();
                    form.Close();
                }
            };

            form.Shown += (s, e) => timer.Start();
            form.FormClosed += (s, e) => timer.Dispose();

            form.Show();
        }

        public static void Success(string message, int seconds = 3)
            => Show(message, "Success", seconds);

        public static void Error(string message, int seconds = 3)
            => Show(message, "Error", seconds);

        public static void Warning(string message, int seconds = 3)
            => Show(message, "Warning", seconds);

        public static void Info(string message, int seconds = 3)
            => Show(message, "Notice", seconds);
    }
}
```

## Models\CafeTable.cs

```csharp
namespace CafeManagement.Models
{
    public class CafeTable
    {
        public int Id { get; set; }
        public string TableName { get; set; } = "";
        public string Status { get; set; } = "Empty"; // "Empty", "Occupied", "Paid"
    }
}
```

## Models\MenuItem.cs

```csharp
namespace CafeManagement.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public decimal Price { get; set; }
        public string Category { get; set; } = "";
        public bool IsAvailable { get; set; } = true;
    }
}
```

## Models\Order.cs

```csharp
namespace CafeManagement.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string Status { get; set; } = "Open"; // "Open", "Paid"
        public decimal TotalAmount { get; set; }
    }
}
```

## Models\OrderItem.cs

```csharp
namespace CafeManagement.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int MenuItemId { get; set; }
        public string MenuItemName { get; set; } = "";
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Subtotal => Price * Quantity;
    }
}
```

## Models\User.cs

```csharp
namespace CafeManagement.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string Role { get; set; } = "Staff"; // "Admin" hoặc "Staff"
        public string FullName { get; set; } = "";
    }
}
```

## Repositories\MenuRepository.cs

```csharp
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
            using (var connection = new SqliteConnection(Database.ConnectionString))
            {
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
            }
            return list;
        }

        public List<MenuItem> Search(string keyword)
        {
            var list = new List<MenuItem>();
            using (var connection = new SqliteConnection(Database.ConnectionString))
            {
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
            }
            return list;
        }

        public void Add(MenuItem item)
        {
            using (var connection = new SqliteConnection(Database.ConnectionString))
            {
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
        }

        public void Update(MenuItem item)
        {
            using (var connection = new SqliteConnection(Database.ConnectionString))
            {
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
        }

        public void Delete(int id)
        {
            using (var connection = new SqliteConnection(Database.ConnectionString))
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.CommandText = "DELETE FROM MenuItems WHERE Id = @id";
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
```
