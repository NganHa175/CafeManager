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
