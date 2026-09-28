namespace CafeManagement.Helpers
{
    public class ToastForm : Form
    {
        private Label lblMessage;
        private System.Windows.Forms.Timer timer;

        // Màu theo loại thông báo
        public enum ToastType { Info, Success, Warning, Error }

        private ToastForm(string message, ToastType type, int durationMs)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(340, 80);
            this.TopMost = true;

            // Màu nền theo loại
            this.BackColor = type switch
            {
                ToastType.Success => Color.FromArgb(101, 67, 33),  // brown
                ToastType.Warning => Color.FromArgb(200, 140, 30), // orange
                ToastType.Error => Color.FromArgb(180, 40, 40),  // red
                _ => Color.FromArgb(80, 50, 20),   // dark brown (info)
            };

            lblMessage = new Label
            {
                Text = message,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Padding = new Padding(10),
            };

            this.Controls.Add(lblMessage);

            timer = new System.Windows.Forms.Timer();
            timer.Interval = durationMs;
            timer.Tick += (s, e) =>
            {
                timer.Stop();
                this.Close();
            };
            timer.Start();
        }


        public static void Show(string message, ToastType type = ToastType.Info, int seconds = 5)
        {
            var toast = new ToastForm(message, type, seconds * 1000);
            toast.Show();
        }

        public static void Success(string message, int seconds = 5)
            => Show(message, ToastType.Success, seconds);

        public static void Error(string message, int seconds = 5)
            => Show(message, ToastType.Error, seconds);

        public static void Warning(string message, int seconds = 5)
            => Show(message, ToastType.Warning, seconds);

        public static void Info(string message, int seconds = 5)
            => Show(message, ToastType.Info, seconds);
    }
}
