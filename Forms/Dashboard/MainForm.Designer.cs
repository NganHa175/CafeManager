using CafeManagement.Helpers;

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
            this.ClientSize = new Size(1100, 680);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(960, 600);
            this.BackColor = Theme.Cream;

            pnlSidebar = new Panel
            {
                Dock = DockStyle.Left,
                Width = 230,
                BackColor = Theme.Espresso,
            };

            lblAppTitle = new Label
            {
                Text = "☕  Cafe Manager",
                Font = Theme.MakeFont(15, FontStyle.Bold),
                ForeColor = Color.White,
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Top,
                Height = 84,
                Padding = new Padding(22, 0, 0, 0),
            };

            lblCurrentUser = new Label
            {
                Text = "",
                Font = Theme.MakeFont(9.5f),
                ForeColor = Color.FromArgb(200, 180, 165),
                TextAlign = ContentAlignment.MiddleLeft,
                Dock = DockStyle.Top,
                Height = 56,
                Padding = new Padding(22, 0, 0, 0),
            };

            var divider = new Panel
            {
                Dock = DockStyle.Top,
                Height = 1,
                BackColor = Theme.EspressoLight,
            };

            var spacer = new Panel
            {
                Dock = DockStyle.Top,
                Height = 12,
                BackColor = Theme.Espresso,
            };

            btnMenu = CreateSidebarButton("🍽   Menu");
            btnTables = CreateSidebarButton("🪑   Tables");
            btnOrders = CreateSidebarButton("📋   Orders");
            btnStatistics = CreateSidebarButton("📊   Statistics");

            btnLogout = new Button
            {
                Text = "←   Logout",
                Font = Theme.MakeFont(10),
                ForeColor = Color.FromArgb(220, 180, 160),
                BackColor = Theme.Espresso,
                FlatStyle = FlatStyle.Flat,
                Dock = DockStyle.Bottom,
                Height = 54,
                Cursor = Cursors.Hand,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(22, 0, 0, 0),
            };
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatAppearance.MouseOverBackColor = Theme.EspressoLight;
            btnLogout.Click += new EventHandler(btnLogout_Click);

            pnlSidebar.Controls.Add(btnStatistics);
            pnlSidebar.Controls.Add(btnOrders);
            pnlSidebar.Controls.Add(btnTables);
            pnlSidebar.Controls.Add(btnMenu);
            pnlSidebar.Controls.Add(spacer);
            pnlSidebar.Controls.Add(divider);
            pnlSidebar.Controls.Add(lblCurrentUser);
            pnlSidebar.Controls.Add(lblAppTitle);
            pnlSidebar.Controls.Add(btnLogout);

            pnlContent = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Theme.Cream,
                Padding = new Padding(0),
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
                Font = Theme.MakeFont(10.5f),
                ForeColor = Color.FromArgb(225, 210, 198),
                BackColor = Theme.Espresso,
                FlatStyle = FlatStyle.Flat,
                Dock = DockStyle.Top,
                Height = 50,
                Cursor = Cursors.Hand,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(24, 0, 0, 0),
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Theme.EspressoLight;

            btn.Paint += (s, e) =>
            {
                if (btn.Tag as string == "active")
                {
                    using var brush = new SolidBrush(Theme.Caramel);
                    e.Graphics.FillRectangle(brush, 0, 0, 4, btn.Height);
                }
            };
            return btn;
        }
    }
}
