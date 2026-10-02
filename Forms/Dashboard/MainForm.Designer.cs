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
            // ── Form ──────────────────────────────────────────
            this.Text = "Cafe Manager";
            this.ClientSize = new Size(900, 560);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(900, 560);
            this.BackColor = Color.FromArgb(245, 240, 235);

            // ── Sidebar ───────────────────────────────────────
            pnlSidebar = new Panel
            {
                Dock = DockStyle.Left,
                Width = 180,
                BackColor = Color.FromArgb(101, 67, 33),
            };

            // App title
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

            // Tên người dùng đang đăng nhập
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

            // Các nút điều hướng
            btnMenu = CreateSidebarButton("🍽  Menu");
            btnTables = CreateSidebarButton("🪑  Tables");
            btnOrders = CreateSidebarButton("📋  Orders");
            btnStatistics = CreateSidebarButton("📊  Statistics");

            // Nút logout ở dưới cùng
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

            // Thêm vào sidebar
            // Dock.Top: Add sau → hiện trên cùng
            pnlSidebar.Controls.Add(btnStatistics);
            pnlSidebar.Controls.Add(btnOrders);
            pnlSidebar.Controls.Add(btnTables);
            pnlSidebar.Controls.Add(btnMenu);
            pnlSidebar.Controls.Add(lblCurrentUser);
            pnlSidebar.Controls.Add(lblAppTitle);
            pnlSidebar.Controls.Add(btnLogout);

            // ── Content panel ─────────────────────────────────
            pnlContent = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(245, 240, 235),
                Padding = new Padding(20),
            };

            // ── Thêm vào form ─────────────────────────────────
            this.Controls.Add(pnlContent);
            this.Controls.Add(pnlSidebar);

            // ── Gắn sự kiện nút sidebar ───────────────────────
            btnMenu.Click += (s, e) => NavigateTo("menu");
            btnTables.Click += (s, e) => NavigateTo("tables");
            btnOrders.Click += (s, e) => NavigateTo("orders");
            btnStatistics.Click += (s, e) => NavigateTo("statistics");
        }

        // Hàm tạo nút sidebar
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
