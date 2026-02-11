using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Steam_Desktop_Authenticator
{
    /// <summary>
    /// Applies a consistent dark theme to forms and controls.
    /// </summary>
    public static class DarkTheme
    {
        public static readonly Color Back = Color.FromArgb(45, 45, 48);
        public static readonly Color Surface = Color.FromArgb(37, 37, 38);
        public static readonly Color Fore = Color.FromArgb(212, 212, 212);
        public static readonly Color ButtonFace = Color.FromArgb(52, 52, 54);
        public static readonly Color ButtonBorder = Color.FromArgb(45, 45, 48);
        public static readonly Color InputBack = Color.FromArgb(30, 30, 30);
        public static readonly Color Link = Color.FromArgb(86, 156, 214);
        public static readonly Color AcceptButton = Color.FromArgb(0, 122, 61);
        public static readonly Color DenyButton = Color.FromArgb(163, 38, 38);

        /// <summary>When false, Apply() does nothing and ApplyLight can be used. Set from Manifest.</summary>
        public static bool Enabled { get; set; } = true;

        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;

        [DllImport("dwmapi.dll", CharSet = CharSet.Unicode, PreserveSig = true)]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int value, int size);

        public static void UseDarkTitleBar(Form form)
        {
            if (form == null || !form.IsHandleCreated) return;
            try
            {
                int useDark = 1;
                DwmSetWindowAttribute(form.Handle, DWMWA_USE_IMMERSIVE_DARK_MODE, ref useDark, sizeof(int));
            }
            catch { }
        }

        public static void UseLightTitleBar(Form form)
        {
            if (form == null || !form.IsHandleCreated) return;
            try
            {
                int useDark = 0;
                DwmSetWindowAttribute(form.Handle, DWMWA_USE_IMMERSIVE_DARK_MODE, ref useDark, sizeof(int));
            }
            catch { }
        }

        public static void Apply(Control control)
        {
            if (control == null || !Enabled) return;

            if (control is Form form)
            {
                form.BackColor = Back;
                form.ForeColor = Fore;
                if (form.IsHandleCreated)
                    UseDarkTitleBar(form);
                else
                    form.HandleCreated += (s, _) => UseDarkTitleBar((Form)s);
            }
            else if (control is Panel panel)
            {
                if (panel.BackColor != Color.Transparent)
                    panel.BackColor = Surface;
                panel.ForeColor = Fore;
            }
            else if (control is GroupBox groupBox)
            {
                groupBox.BackColor = Surface;
                groupBox.ForeColor = Fore;
            }
            else if (control is Button button)
            {
                button.BackColor = ButtonFace;
                button.ForeColor = Fore;
                button.FlatStyle = FlatStyle.Flat;
                button.FlatAppearance.BorderSize = 0;
                button.FlatAppearance.BorderColor = ButtonBorder;
                button.FlatAppearance.MouseOverBackColor = Color.FromArgb(62, 62, 66);
            }
            else if (control is TextBox textBox)
            {
                textBox.BackColor = InputBack;
                textBox.ForeColor = Fore;
                textBox.BorderStyle = BorderStyle.FixedSingle;
            }
            else if (control is MaskedTextBox maskedTextBox)
            {
                maskedTextBox.BackColor = InputBack;
                maskedTextBox.ForeColor = Fore;
                maskedTextBox.BorderStyle = BorderStyle.FixedSingle;
            }
            else if (control is ListBox listBox)
            {
                listBox.BackColor = InputBack;
                listBox.ForeColor = Fore;
                listBox.BorderStyle = BorderStyle.FixedSingle;
            }
            else if (control is Label label)
            {
                label.ForeColor = Fore;
                if (label.BackColor != Color.Transparent)
                    label.BackColor = Surface;
            }
            else if (control is LinkLabel linkLabel)
            {
                linkLabel.ForeColor = Fore;
                linkLabel.LinkColor = Link;
                linkLabel.VisitedLinkColor = Link;
                if (linkLabel.BackColor != Color.Transparent)
                    linkLabel.BackColor = Surface;
            }
            else if (control is ProgressBar progressBar)
            {
                // ProgressBar has limited theming; set what we can
                progressBar.BackColor = Surface;
            }
            else if (control is CheckBox checkBox)
            {
                checkBox.ForeColor = Fore;
                checkBox.BackColor = Color.Transparent;
            }
            else if (control is NumericUpDown num)
            {
                num.BackColor = InputBack;
                num.ForeColor = Fore;
                num.BorderStyle = BorderStyle.FixedSingle;
            }
            else if (control is ComboBox combo)
            {
                combo.BackColor = InputBack;
                combo.ForeColor = Fore;
                combo.FlatStyle = FlatStyle.Flat;
            }
            else if (control is SplitContainer split)
            {
                split.BackColor = Back;
                split.Panel1.BackColor = Surface;
                split.Panel2.BackColor = Surface;
            }
            else if (control is MenuStrip menuStrip)
            {
                menuStrip.BackColor = Surface;
                menuStrip.ForeColor = Fore;
                menuStrip.Renderer = new DarkToolStripRenderer();
            }
            else if (control is ContextMenuStrip contextMenu)
            {
                contextMenu.BackColor = Surface;
                contextMenu.ForeColor = Fore;
                contextMenu.Renderer = new DarkToolStripRenderer();
            }
            else if (control is ToolStrip toolStrip)
            {
                toolStrip.BackColor = Surface;
                toolStrip.ForeColor = Fore;
                toolStrip.Renderer = new DarkToolStripRenderer();
            }

            foreach (Control child in control.Controls)
                Apply(child);

            if (control is SplitContainer sc)
            {
                Apply(sc.Panel1);
                Apply(sc.Panel2);
            }
        }

        /// <summary>Reverts controls to system default (light) appearance. Call when switching from dark to light.</summary>
        public static void ApplyLight(Control control)
        {
            if (control == null) return;

            if (control is Form form)
            {
                form.BackColor = SystemColors.Control;
                form.ForeColor = SystemColors.ControlText;
                UseLightTitleBar(form);
            }
            else if (control is Panel panel)
            {
                panel.BackColor = SystemColors.Control;
                panel.ForeColor = SystemColors.ControlText;
            }
            else if (control is GroupBox groupBox)
            {
                groupBox.BackColor = SystemColors.Control;
                groupBox.ForeColor = SystemColors.ControlText;
            }
            else if (control is Button button)
            {
                button.BackColor = SystemColors.Control;
                button.ForeColor = SystemColors.ControlText;
                button.FlatStyle = FlatStyle.Standard;
                button.FlatAppearance.BorderSize = 1;
            }
            else if (control is TextBox textBox)
            {
                textBox.BackColor = SystemColors.Window;
                textBox.ForeColor = SystemColors.WindowText;
            }
            else if (control is MaskedTextBox maskedTextBox)
            {
                maskedTextBox.BackColor = SystemColors.Window;
                maskedTextBox.ForeColor = SystemColors.WindowText;
            }
            else if (control is ListBox listBox)
            {
                listBox.BackColor = SystemColors.Window;
                listBox.ForeColor = SystemColors.WindowText;
            }
            else if (control is Label label)
            {
                label.ForeColor = SystemColors.ControlText;
                label.BackColor = SystemColors.Control;
            }
            else if (control is LinkLabel linkLabel)
            {
                linkLabel.ForeColor = SystemColors.ControlText;
                linkLabel.LinkColor = SystemColors.HotTrack;
                linkLabel.VisitedLinkColor = SystemColors.HotTrack;
                linkLabel.BackColor = SystemColors.Control;
            }
            else if (control is MenuStrip menuStrip)
            {
                menuStrip.BackColor = SystemColors.Control;
                menuStrip.ForeColor = SystemColors.ControlText;
                menuStrip.Renderer = null;
            }
            else if (control is ContextMenuStrip contextMenu)
            {
                contextMenu.BackColor = SystemColors.Control;
                contextMenu.ForeColor = SystemColors.ControlText;
                contextMenu.Renderer = null;
            }
            else if (control is ToolStrip toolStrip)
            {
                toolStrip.BackColor = SystemColors.Control;
                toolStrip.ForeColor = SystemColors.ControlText;
                toolStrip.Renderer = null;
            }
            else if (control is CheckBox checkBox)
            {
                checkBox.ForeColor = SystemColors.ControlText;
                checkBox.BackColor = SystemColors.Control;
            }
            else if (control is NumericUpDown num)
            {
                num.BackColor = SystemColors.Window;
                num.ForeColor = SystemColors.WindowText;
            }
            else if (control is ComboBox combo)
            {
                combo.BackColor = SystemColors.Window;
                combo.ForeColor = SystemColors.WindowText;
                combo.FlatStyle = FlatStyle.Standard;
            }
            else if (control is SplitContainer split)
            {
                split.BackColor = SystemColors.Control;
                split.Panel1.BackColor = SystemColors.Control;
                split.Panel2.BackColor = SystemColors.Control;
            }
            else if (control is ProgressBar progressBar)
            {
                progressBar.BackColor = SystemColors.Control;
            }

            foreach (Control child in control.Controls)
                ApplyLight(child);

            if (control is SplitContainer sc)
            {
                ApplyLight(sc.Panel1);
                ApplyLight(sc.Panel2);
            }
        }

        private sealed class DarkToolStripRenderer : ToolStripProfessionalRenderer
        {
            protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
            {
                e.Graphics.Clear(Surface);
            }

            protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
            {
                using (var pen = new Pen(ButtonBorder, 1f))
                    e.Graphics.DrawRectangle(pen, 0, 0, e.ToolStrip.Width - 1, e.ToolStrip.Height - 1);
            }

            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                var rect = new Rectangle(Point.Empty, e.Item.Size);
                var color = (e.Item.Selected || e.Item.Pressed) ? ButtonFace : Surface;
                e.Graphics.FillRectangle(new SolidBrush(color), rect);
            }

            protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
            {
                e.TextColor = Fore;
                base.OnRenderItemText(e);
            }

            protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
            {
                using (var pen = new Pen(ButtonBorder, 1f))
                {
                    int y = e.Item.Height / 2;
                    e.Graphics.DrawLine(pen, 0, y, e.Item.Width, y);
                }
            }

            protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
            {
                var rect = new Rectangle(Point.Empty, e.Item.Size);
                var color = (e.Item.Selected || e.Item.Pressed) ? ButtonFace : Surface;
                e.Graphics.FillRectangle(new SolidBrush(color), rect);
            }

            protected override void OnRenderImageMargin(ToolStripRenderEventArgs e)
            {
                e.Graphics.Clear(Surface);
            }
        }
    }
}
