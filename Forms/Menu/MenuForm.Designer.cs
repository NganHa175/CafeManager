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
