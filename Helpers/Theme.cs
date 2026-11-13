namespace CafeManagement.Helpers
{
    public static class Theme
    {
        public static readonly Color Espresso = Color.FromArgb(44, 30, 24);
        public static readonly Color EspressoLight = Color.FromArgb(72, 50, 40);
        public static readonly Color Caramel = Color.FromArgb(193, 125, 60);
        public static readonly Color CaramelDark = Color.FromArgb(160, 98, 42);
        public static readonly Color Cream = Color.FromArgb(250, 246, 240);
        public static readonly Color HeaderBack = Color.FromArgb(246, 238, 228);
        public static readonly Color SelectedRow = Color.FromArgb(250, 235, 218);
        public static readonly Color Border = Color.FromArgb(232, 223, 212);
        public static readonly Color TextDark = Color.FromArgb(52, 37, 30);
        public static readonly Color TextMuted = Color.FromArgb(125, 108, 96);
        public static readonly Color Danger = Color.FromArgb(192, 57, 43);
        public static readonly Color Success = Color.FromArgb(46, 139, 87);
        public static readonly Color Warning = Color.FromArgb(214, 137, 16);

        public const string FontName = "Segoe UI";

        public static Font MakeFont(float size, FontStyle style = FontStyle.Regular)
            => new Font(FontName, size, style);

        public static void Primary(Button b)
        {
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.BackColor = Caramel;
            b.ForeColor = Color.White;
            b.FlatAppearance.MouseOverBackColor = CaramelDark;
            b.Font = MakeFont(10, FontStyle.Bold);
            b.Cursor = Cursors.Hand;
        }

        public static void Outline(Button b, Color accent)
        {
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 1;
            b.FlatAppearance.BorderColor = accent;
            b.BackColor = Color.White;
            b.ForeColor = accent;
            b.FlatAppearance.MouseOverBackColor = Color.FromArgb(250, 243, 236);
            b.Font = MakeFont(10, FontStyle.Bold);
            b.Cursor = Cursors.Hand;
        }
    }
}
