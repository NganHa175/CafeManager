using CafeManagement.Forms.Auth;
using CafeManagement.Helpers;

namespace CafeManagement.Forms.Dashboard
{
    public partial class MainForm : Form
    {
        private readonly string _currentUserName;
        private readonly string _currentUserRole;

        public MainForm(string fullName, string role)
        {
            InitializeComponent();
            _currentUserName = fullName;
            _currentUserRole = role;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            lblCurrentUser.Text = $"{_currentUserName}\n{_currentUserRole}";
            ToastForm.Success($"Welcome, {_currentUserName}!");
            NavigateTo("menu");
        }

        private void ClearContent()
        {
            foreach (var c in pnlContent.Controls.Cast<Control>().ToList())
            {
                pnlContent.Controls.Remove(c);
                c.Dispose();
            }
        }

        private void NavigateTo(string section)
        {
            ClearContent();

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
                    pnlContent.Controls.Add(MakePlaceholder("Tables"));
                    SetActiveButton(btnTables);
                    break;

                case "orders":
                    pnlContent.Controls.Add(MakePlaceholder("Orders"));
                    SetActiveButton(btnOrders);
                    break;

                case "statistics":
                    pnlContent.Controls.Add(MakePlaceholder("Statistics"));
                    SetActiveButton(btnStatistics);
                    break;
                case "users":
                    var userForm = new CafeManagement.Forms.Users.UserForm
                    {
                        TopLevel = false,
                        FormBorderStyle = FormBorderStyle.None,
                        Dock = DockStyle.Fill,
                    };
                    pnlContent.Controls.Add(userForm);
                    userForm.Show();
                    SetActiveButton(btnUsers);
                    break;
            }
        }

        private Label MakePlaceholder(string text)
        {
            return new Label
            {
                Text = $"{text}\nComing soon",
                Font = Theme.MakeFont(16),
                ForeColor = Theme.TextMuted,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
            };
        }

        private void SetActiveButton(Button activeBtn)
        {
            var sidebarButtons = new[] { btnMenu, btnTables, btnOrders, btnStatistics, btnUsers };
            foreach (var btn in sidebarButtons)
            {
                btn.BackColor = Theme.Espresso;
                btn.ForeColor = Color.FromArgb(225, 210, 198);
                btn.Tag = null;
                btn.Invalidate();
            }
            activeBtn.BackColor = Theme.EspressoLight;
            activeBtn.ForeColor = Color.White;
            activeBtn.Tag = "active";
            activeBtn.Invalidate();
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
