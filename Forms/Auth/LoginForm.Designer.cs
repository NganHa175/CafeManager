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
