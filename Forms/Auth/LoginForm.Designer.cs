using CafeManagement.Helpers;

namespace CafeManagement.Forms.Auth
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

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
            this.AutoScaleDimensions = new SizeF(96F, 96F);
            this.AutoScaleMode = AutoScaleMode.Dpi;

            this.Text = "Cafe Manager - Login";
            this.ClientSize = new Size(760, 440);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.BackColor = Color.White;

            var pnlBrand = new Panel
            {
                Dock = DockStyle.Left,
                Width = 320,
                BackColor = Theme.Espresso,
            };

            var lblCup = new Label
            {
                Text = "☕",
                Font = new Font("Segoe UI Emoji", 36, FontStyle.Regular, GraphicsUnit.Point),
                ForeColor = Theme.Caramel,
                Location = new Point(20, 60),
                AutoSize = true,
            };

            var lblBrand = new Label
            {
                Text = "Cafe Manager",
                Font = Theme.MakeFont(20, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(36, 150),
                AutoSize = true,
            };

            var lblTagline = new Label
            {
                Text = "Menu, tables and orders, all in one place.",
                Font = Theme.MakeFont(10.5f),
                ForeColor = Color.FromArgb(200, 180, 165),
                Location = new Point(34, 215),
                AutoSize = true,
                MaximumSize = new Size(260, 0),
            };

            pnlBrand.Controls.AddRange(new Control[] { lblCup, lblBrand, lblTagline });


            var pnlLogin = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
            };

            var lblWelcome = new Label
            {
                Text = "Welcome back",
                Font = Theme.MakeFont(20, FontStyle.Bold),
                ForeColor = Theme.TextDark,
                Location = new Point(60, 60),
                AutoSize = true,
            };

            var lblHint = new Label
            {
                Text = "Sign in to your account",
                Font = Theme.MakeFont(10),
                ForeColor = Theme.TextMuted,
                Location = new Point(62, 108),
                AutoSize = true,
            };

            lblUsername = new Label
            {
                Text = "Username",
                Font = Theme.MakeFont(9.5f, FontStyle.Bold),
                ForeColor = Theme.TextDark,
                Location = new Point(60, 160),
                AutoSize = true,
            };

            txtUsername = new TextBox
            {
                Name = "txtUsername",
                Location = new Point(60, 184),
                Width = 340,
                Font = Theme.MakeFont(11),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Theme.Cream,
            };

            lblPassword = new Label
            {
                Text = "Password",
                Font = Theme.MakeFont(9.5f, FontStyle.Bold),
                ForeColor = Theme.TextDark,
                Location = new Point(60, 232),
                AutoSize = true,
            };

            txtPassword = new TextBox
            {
                Name = "txtPassword",
                Location = new Point(60, 256),
                Width = 340,
                Font = Theme.MakeFont(11),
                PasswordChar = '●',
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Theme.Cream,
            };

            lblError = new Label
            {
                Text = "",
                Location = new Point(60, 298),
                Size = new Size(340, 22),
                ForeColor = Theme.Danger,
                Font = Theme.MakeFont(9),
            };

            btnLogin = new Button
            {
                Name = "btnLogin",
                Text = "Login",
                Location = new Point(60, 328),
                Size = new Size(340, 44),
            };
            Theme.Primary(btnLogin);
            btnLogin.Font = Theme.MakeFont(11, FontStyle.Bold);
            btnLogin.Click += new EventHandler(btnLogin_Click);

            pnlLogin.Controls.AddRange(new Control[]
            {
                lblWelcome, lblHint,
                lblUsername, txtUsername,
                lblPassword, txtPassword,
                lblError,
                btnLogin,
            });

            this.Controls.Add(pnlLogin);
            this.Controls.Add(pnlBrand);

            this.AcceptButton = btnLogin;
            this.ActiveControl = txtUsername;
        }
    }
}
