namespace CafeManagement.Helpers
{
    public static class ToastForm
    {
        private const int ToastWidth = 340;
        private const int ToastHeight = 78;
        private const int ScreenMargin = 16;
        private const int Gap = 10;

        private static readonly List<Form> _open = new();

        private sealed class ToastWindow : Form
        {
            protected override bool ShowWithoutActivation => true;

            protected override CreateParams CreateParams
            {
                get
                {
                    var cp = base.CreateParams;
                    cp.ExStyle |= 0x08000000 | 0x00000080;
                    return cp;
                }
            }
        }

        private static void Display(string message, string title, int seconds, Color accent, string glyph)
        {
            var form = new ToastWindow
            {
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.Manual,
                ShowInTaskbar = false,
                TopMost = true,
                Size = new Size(ToastWidth, ToastHeight),
                BackColor = Color.White,
            };

            form.Paint += (s, e) =>
            {
                using var border = new Pen(Theme.Border);
                e.Graphics.DrawRectangle(border, 0, 0, form.Width - 1, form.Height - 1);
                using var bar = new SolidBrush(accent);
                e.Graphics.FillRectangle(bar, 0, 0, 6, form.Height);
            };

            var lblGlyph = new Label
            {
                Text = glyph,
                Font = Theme.MakeFont(18, FontStyle.Bold),
                ForeColor = accent,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(18, 17),
                Size = new Size(44, 44),
            };

            var lblTitle = new Label
            {
                Text = title,
                Font = Theme.MakeFont(10, FontStyle.Bold),
                ForeColor = Theme.TextDark,
                Location = new Point(68, 13),
                Size = new Size(260, 22),
            };

            var lblMessage = new Label
            {
                Text = message,
                Font = Theme.MakeFont(9.5f),
                ForeColor = Theme.TextMuted,
                Location = new Point(68, 35),
                Size = new Size(260, 36),
            };

            form.Controls.AddRange(new Control[] { lblGlyph, lblTitle, lblMessage });

            form.Click += (s, e) => form.Close();
            foreach (Control c in form.Controls)
                c.Click += (s, e) => form.Close();

            var timer = new System.Windows.Forms.Timer { Interval = Math.Max(1, seconds) * 1000 };
            timer.Tick += (s, e) =>
            {
                timer.Stop();
                form.Close();
            };

            form.FormClosed += (s, e) =>
            {
                timer.Dispose();
                _open.Remove(form);
                Reposition();
            };

            _open.Add(form);
            Reposition();
            form.Show();
            timer.Start();
        }

        private static void Reposition()
        {
            var area = (Screen.PrimaryScreen ?? Screen.AllScreens[0]).WorkingArea;
            for (int i = 0; i < _open.Count; i++)
            {
                int x = area.Right - ScreenMargin - ToastWidth;
                int y = area.Bottom - ScreenMargin - (i + 1) * ToastHeight - i * Gap;
                _open[i].Location = new Point(x, y);
            }
        }

        public static void Show(string message, string title = "Notice", int seconds = 3)
            => Display(message, title, seconds, Theme.Caramel, "i");

        public static void Success(string message, int seconds = 3)
            => Display(message, "Success", seconds, Theme.Success, "✓");

        public static void Error(string message, int seconds = 3)
            => Display(message, "Error", seconds, Theme.Danger, "✕");

        public static void Warning(string message, int seconds = 3)
            => Display(message, "Warning", seconds, Theme.Warning, "!");

        public static void Info(string message, int seconds = 3)
            => Display(message, "Notice", seconds, Theme.Caramel, "i");
    }
}
