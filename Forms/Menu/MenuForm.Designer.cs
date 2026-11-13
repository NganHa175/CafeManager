using CafeManagement.Helpers;

namespace CafeManagement.Forms.Menu
{
    partial class MenuForm
    {
        private System.ComponentModel.IContainer components = null;

        private DataGridView dgvMenu;
        private TextBox txtSearch;
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
            this.BackColor = Theme.Cream;
            this.Padding = new Padding(28, 20, 28, 20);

            lblTitle = new Label
            {
                Text = "Menu",
                Font = Theme.MakeFont(20, FontStyle.Bold),
                ForeColor = Theme.TextDark,
                Dock = DockStyle.Top,
                Height = 44,
                TextAlign = ContentAlignment.MiddleLeft,
            };

            var pnlTop = new Panel
            {
                Dock = DockStyle.Top,
                Height = 52,
                BackColor = Theme.Cream,
            };

            txtSearch = new TextBox
            {
                Font = Theme.MakeFont(10.5f),
                Location = new Point(0, 10),
                Width = 300,
                BorderStyle = BorderStyle.FixedSingle,
                PlaceholderText = "Search by name...",
            };
            txtSearch.TextChanged += new EventHandler(txtSearch_TextChanged);
            pnlTop.Controls.Add(txtSearch);

            var pnlMain = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Theme.Cream,
            };

            dgvMenu = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AllowUserToResizeRows = false,
                MultiSelect = false,
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                Font = Theme.MakeFont(10),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                EnableHeadersVisualStyles = false,
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                GridColor = Theme.Border,
                ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing,
                ColumnHeadersHeight = 42,
            };
            dgvMenu.RowTemplate.Height = 40;

            dgvMenu.Columns.Add("Id", "ID");
            dgvMenu.Columns.Add("Name", "Name");
            dgvMenu.Columns.Add("Price", "Price");
            dgvMenu.Columns.Add("Category", "Category");
            dgvMenu.Columns.Add("Available", "Available");

            dgvMenu.Columns["Id"].Visible = false;
            dgvMenu.Columns["Name"].FillWeight = 40;
            dgvMenu.Columns["Price"].FillWeight = 22;
            dgvMenu.Columns["Category"].FillWeight = 22;
            dgvMenu.Columns["Available"].FillWeight = 16;

            dgvMenu.Columns["Price"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvMenu.Columns["Price"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvMenu.ColumnHeadersDefaultCellStyle.BackColor = Theme.HeaderBack;
            dgvMenu.ColumnHeadersDefaultCellStyle.ForeColor = Theme.TextMuted;
            dgvMenu.ColumnHeadersDefaultCellStyle.SelectionBackColor = Theme.HeaderBack;
            dgvMenu.ColumnHeadersDefaultCellStyle.SelectionForeColor = Theme.TextMuted;
            dgvMenu.ColumnHeadersDefaultCellStyle.Font = Theme.MakeFont(9.5f, FontStyle.Bold);
            dgvMenu.ColumnHeadersDefaultCellStyle.Padding = new Padding(12, 0, 12, 0);
            dgvMenu.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvMenu.DefaultCellStyle.ForeColor = Theme.TextDark;
            dgvMenu.DefaultCellStyle.SelectionBackColor = Theme.SelectedRow;
            dgvMenu.DefaultCellStyle.SelectionForeColor = Theme.TextDark;
            dgvMenu.DefaultCellStyle.Padding = new Padding(12, 0, 12, 0);

            dgvMenu.CellClick += new DataGridViewCellEventHandler(dgvMenu_CellClick);

            var pnlBottom = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 40,
                BackColor = Color.White,
            };

            lblCount = new Label
            {
                Text = "0 items",
                Font = Theme.MakeFont(9),
                ForeColor = Theme.TextMuted,
                Location = new Point(14, 12),
                AutoSize = true,
            };
            pnlBottom.Controls.Add(lblCount);

            var pnlLeft = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Theme.Border,
                Padding = new Padding(1),
            };
            pnlLeft.Controls.Add(dgvMenu);
            pnlLeft.Controls.Add(pnlBottom);

            var spacer = new Panel
            {
                Dock = DockStyle.Right,
                Width = 18,
                BackColor = Theme.Cream,
            };

            pnlRight = new Panel
            {
                Dock = DockStyle.Right,
                Width = 310,
                BackColor = Theme.Border,
                Padding = new Padding(1),
            };

            var pnlForm = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
            };

            var lblForm = new Label
            {
                Text = "Item details",
                Font = Theme.MakeFont(12, FontStyle.Bold),
                ForeColor = Theme.TextDark,
                Location = new Point(24, 20),
                AutoSize = true,
            };

            lblName = new Label
            {
                Text = "Name",
                Font = Theme.MakeFont(9),
                ForeColor = Theme.TextMuted,
                Location = new Point(24, 62),
                AutoSize = true,
            };
            txtName = new TextBox
            {
                Font = Theme.MakeFont(10.5f),
                Location = new Point(24, 84),
                Width = 260,
                BorderStyle = BorderStyle.FixedSingle,
            };

            lblCategory = new Label
            {
                Text = "Category",
                Font = Theme.MakeFont(9),
                ForeColor = Theme.TextMuted,
                Location = new Point(24, 126),
                AutoSize = true,
            };
            txtCategory = new TextBox
            {
                Font = Theme.MakeFont(10.5f),
                Location = new Point(24, 148),
                Width = 260,
                BorderStyle = BorderStyle.FixedSingle,
            };

            lblPrice = new Label
            {
                Text = "Price (₫)",
                Font = Theme.MakeFont(9),
                ForeColor = Theme.TextMuted,
                Location = new Point(24, 190),
                AutoSize = true,
            };
            txtPrice = new TextBox
            {
                Font = Theme.MakeFont(10.5f),
                Location = new Point(24, 212),
                Width = 260,
                BorderStyle = BorderStyle.FixedSingle,
            };

            chkAvailable = new CheckBox
            {
                Text = "Available",
                Font = Theme.MakeFont(10),
                ForeColor = Theme.TextDark,
                Location = new Point(24, 260),
                AutoSize = true,
                Checked = true,
            };

            btnAdd = new Button { Text = "Add", Location = new Point(24, 306), Size = new Size(125, 38) };
            Theme.Primary(btnAdd);
            btnAdd.Click += new EventHandler(btnAdd_Click);

            btnUpdate = new Button { Text = "Update", Location = new Point(159, 306), Size = new Size(125, 38) };
            Theme.Outline(btnUpdate, Theme.Caramel);
            btnUpdate.Click += new EventHandler(btnUpdate_Click);

            btnClear = new Button { Text = "Clear", Location = new Point(24, 352), Size = new Size(125, 38) };
            Theme.Outline(btnClear, Theme.TextMuted);
            btnClear.Click += new EventHandler(btnClear_Click);

            btnDelete = new Button { Text = "Delete", Location = new Point(159, 352), Size = new Size(125, 38) };
            Theme.Outline(btnDelete, Theme.Danger);
            btnDelete.Click += new EventHandler(btnDelete_Click);

            pnlForm.Controls.AddRange(new Control[]
            {
                lblForm,
                lblName,     txtName,
                lblCategory, txtCategory,
                lblPrice,    txtPrice,
                chkAvailable,
                btnAdd, btnUpdate, btnClear, btnDelete,
            });
            pnlRight.Controls.Add(pnlForm);

            pnlMain.Controls.Add(pnlLeft);
            pnlMain.Controls.Add(spacer);
            pnlMain.Controls.Add(pnlRight);

            this.Controls.Add(pnlMain);
            this.Controls.Add(pnlTop);
            this.Controls.Add(lblTitle);
        }
    }
}
