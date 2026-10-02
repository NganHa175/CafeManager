namespace CafeManagement.Helpers
{
    public static class ToastForm
    {
        public static void Show(string message, string title = "Notice", int seconds = 3)
        {
            var form = new Form
            {
                Text = title,
                ClientSize = new Size(320, 130),
                StartPosition = FormStartPosition.CenterScreen,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                TopMost = true,
            };

            var picIcon = new PictureBox
            {
                Image = SystemIcons.Information.ToBitmap(),
                Location = new Point(20, 30),
                Size = new Size(32, 32),
            };

            var lblMessage = new Label
            {
                Text = message,
                Font = new Font("Segoe UI", 10),
                Location = new Point(65, 25),
                Size = new Size(235, 50),
                TextAlign = ContentAlignment.MiddleLeft,
            };

            var lblCountdown = new Label
            {
                Text = $"Closing in {seconds}s...",
                Font = new Font("Segoe UI", 8),
                ForeColor = Color.Gray,
                Location = new Point(20, 80),
                AutoSize = true,
            };

            var btnOK = new Button
            {
                Text = "OK",
                Size = new Size(75, 26),
                Location = new Point(225, 75),
                Cursor = Cursors.Hand,
            };
            btnOK.Click += (s, e) => form.Close();

            form.Controls.AddRange(new Control[]
            {
                picIcon, lblMessage, lblCountdown, btnOK
            });

            int remaining = seconds;
            var timer = new System.Windows.Forms.Timer { Interval = 1000 };
            timer.Tick += (s, e) =>
            {
                remaining--;
                lblCountdown.Text = $"Closing in {remaining}s...";
                if (remaining <= 0)
                {
                    timer.Stop();
                    form.Close();
                }
            };

            form.Shown += (s, e) => timer.Start();
            form.FormClosed += (s, e) => timer.Dispose();

            form.Show();
        }

        public static void Success(string message, int seconds = 3)
            => Show(message, "Success", seconds);

        public static void Error(string message, int seconds = 3)
            => Show(message, "Error", seconds);

        public static void Warning(string message, int seconds = 3)
            => Show(message, "Warning", seconds);

        public static void Info(string message, int seconds = 3)
            => Show(message, "Notice", seconds);
    }
}
