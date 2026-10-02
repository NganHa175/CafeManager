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

            // Hiển thị tên người dùng trên sidebar
            lblCurrentUser.Text = $"{_currentUserName}\n({_currentUserRole})";

            // Toast chào mừng hiện sau khi MainForm đã mở
            ToastForm.Success($"Welcome, {_currentUserName}!");

            // Mặc định mở Menu khi vào app
            NavigateTo("menu");
            SetActiveButton(btnMenu);
        }

        // Điều hướng sang form tương ứng
        private void NavigateTo(string section)
        {
            // Xóa nội dung cũ
            pnlContent.Controls.Clear();

            // Placeholder tạm thời
            var placeholder = new Label
            {
                Text = $"[ {section.ToUpper()} —  ]",
                Font = new Font("Segoe UI", 14),
                ForeColor = Color.FromArgb(101, 67, 33),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
            };

            pnlContent.Controls.Add(placeholder);

            switch (section)
            {
                case "menu": SetActiveButton(btnMenu); break;
                case "tables": SetActiveButton(btnTables); break;
                case "orders": SetActiveButton(btnOrders); break;
                case "statistics": SetActiveButton(btnStatistics); break;
            }
        }

        // Highlight nút sidebar đang được chọn
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

        // Logout
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
