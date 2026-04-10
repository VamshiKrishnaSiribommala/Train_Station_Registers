using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TMS
{
    public static class ThemeManager
    {
        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        
        private const int GWL_EXSTYLE = -20;
        private const int WS_EX_COMPOSITED = 0x02000000;
        public const int WM_SETREDRAW = 11;

        [StructLayout(LayoutKind.Sequential)]
        public struct MARGINS
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }

        private static Image backgroundImage = null;

        static ThemeManager()
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Resources\vande_bharat_bg.png");
                if (File.Exists(path))
                    backgroundImage = Image.FromFile(path);
                else if (File.Exists("Resources\\vande_bharat_bg.png"))
                    backgroundImage = Image.FromFile("Resources\\vande_bharat_bg.png");
            }
            catch { }
        }

        public static void ApplyTheme(Form form)
        {
            // 1. Prevent Handle Recreation: Set BorderStyle BEFORE attempting to capture the Window Handle or attach attributes!
            form.FormBorderStyle = FormBorderStyle.None;
            
            // 2. Prevent White Flashing: Halt all low-level OS painting commands for this window while we construct the DOM
            SendMessage(form.Handle, WM_SETREDRAW, 0, 0);
            
            form.SuspendLayout();

            try
            {
                // Absolute hardware-level zero-flicker compositing for the entire application natively!
                int exStyle = GetWindowLong(form.Handle, GWL_EXSTYLE);
                SetWindowLong(form.Handle, GWL_EXSTYLE, exStyle | WS_EX_COMPOSITED);

                EnableDoubleBuffering(form);

                // Only enable AutoScroll on physical Input Register forms to prevent breaking DataGridView grid scaling in View Forms
                if (form.GetType().Name.StartsWith("Form_Reg")) 
                {
                    form.AutoScroll = true; 
                }
                
                // Fix Maximize bounds so it doesn't spill over monitor or taskbar
                form.MaximumSize = Screen.FromControl(form).WorkingArea.Size;
                
                // User requested that every form opens Maximized by default!
                form.WindowState = FormWindowState.Maximized;

                form.Resize += (s, e) =>
                {
                    if (form.WindowState == FormWindowState.Maximized)
                    {
                        form.MaximumSize = Screen.FromControl(form).WorkingArea.Size;
                    }
                };
                
                // Fix hiding bug: when a form is closed via 'X', unhide any deliberately hidden parent forms (like MainClassesForm)
                form.FormClosed += (s, e) => {
                    if (!form.Modal)
                    {
                        foreach (Form openForm in Application.OpenForms)
                        {
                            if (openForm != form && !openForm.Visible)
                            {
                                openForm.Show();
                            }
                        }
                    }
                };

                // Base Form Setup
                form.BackColor = Color.FromArgb(18, 22, 34); // React dark mode
                if (backgroundImage != null)
                {
                    form.BackgroundImage = backgroundImage;
                    form.BackgroundImageLayout = ImageLayout.Stretch;
                }

                InjectCustomTitleBar(form);

                // Iterate and apply styles
                foreach (Control control in form.Controls)
                {
                    // Skip the title bar we just injected
                    if (control.Name == "CustomWebTitleBar") continue;
                    ApplyStyleToControl(control);
                    if (control.HasChildren)
                    {
                        ApplyStylesRecursive(control);
                    }
                }

                // Bring custom titlebar to top of Z-order for Docking (SendToBack)
                Control tBar = form.Controls["CustomWebTitleBar"];
                if (tBar != null) tBar.SendToBack();

                // Shift all non-docked elements down by 35px so they are not overwritten by the TitleBar
                foreach (Control control in form.Controls)
                {
                    if (control.Name != "CustomWebTitleBar" && control.Dock == DockStyle.None)
                    {
                        control.Top += 35;
                    }
                }
            }
            finally
            {
                form.ResumeLayout(true);
                
                // 3. Re-enable OS Painting and force an immediate refresh of the now fully-styled window buffer!
                SendMessage(form.Handle, WM_SETREDRAW, 1, 0);
                form.Refresh();
            }
        }

        private static void InjectCustomTitleBar(Form form)
        {
            Panel titleBar = new Panel();
            titleBar.Name = "CustomWebTitleBar";
            titleBar.Height = 35;
            titleBar.Dock = DockStyle.Top;
            titleBar.BackColor = Color.FromArgb(220, 15, 23, 42); // Transparent Slate 900
            
            string safeTitle = string.IsNullOrEmpty(form.Text) ? "" : form.Text.Replace("???", "").Replace("??", "").Replace("?", "").Trim();
            form.Text = safeTitle; // Apply clean text natively

            Label title = new Label();
            title.Text = safeTitle;
            title.ForeColor = Color.White;
            title.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            title.AutoSize = true;
            title.Location = new Point(15, 8);
            titleBar.Controls.Add(title);

            // Drag Functionality
            titleBar.MouseDown += (s, e) => {
                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(form.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            };
            title.MouseDown += (s, e) => {
                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(form.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            };

            // Buttons
            Button btnClose = new Button();
            btnClose.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            btnClose.Text = "\u2715"; // X symbol
            btnClose.Size = new Size(40, 35);
            btnClose.Dock = DockStyle.Right;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.ForeColor = Color.White;
            btnClose.BackColor = Color.Transparent;
            btnClose.Cursor = Cursors.Hand;
            btnClose.Click += (s, e) => { form.Close(); };
            btnClose.MouseEnter += (s, e) => { btnClose.BackColor = Color.Red; };
            btnClose.MouseLeave += (s, e) => { btnClose.BackColor = Color.Transparent; };

            Button btnMax = new Button();
            btnMax.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
            btnMax.Text = "\u25A1"; // Square symbol
            btnMax.Size = new Size(40, 35);
            btnMax.Dock = DockStyle.Right;
            btnMax.FlatStyle = FlatStyle.Flat;
            btnMax.FlatAppearance.BorderSize = 0;
            btnMax.ForeColor = Color.White;
            btnMax.BackColor = Color.Transparent;
            btnMax.Cursor = Cursors.Hand;
            btnMax.Click += (s, e) => { 
                if (form.WindowState == FormWindowState.Normal) { form.WindowState = FormWindowState.Maximized; }
                else { form.WindowState = FormWindowState.Normal; }
            };
            btnMax.MouseEnter += (s, e) => { btnMax.BackColor = Color.FromArgb(50, 255, 255, 255); };
            btnMax.MouseLeave += (s, e) => { btnMax.BackColor = Color.Transparent; };

            Button btnMin = new Button();
            btnMin.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
            btnMin.Text = "\u2014"; // Em-dash symbol
            btnMin.Size = new Size(40, 35);
            btnMin.Dock = DockStyle.Right;
            btnMin.FlatStyle = FlatStyle.Flat;
            btnMin.FlatAppearance.BorderSize = 0;
            btnMin.ForeColor = Color.White;
            btnMin.BackColor = Color.Transparent;
            btnMin.Cursor = Cursors.Hand;
            btnMin.Click += (s, e) => { form.WindowState = FormWindowState.Minimized; };
            btnMin.MouseEnter += (s, e) => { btnMin.BackColor = Color.FromArgb(50, 255, 255, 255); };
            btnMin.MouseLeave += (s, e) => { btnMin.BackColor = Color.Transparent; };

            titleBar.Controls.Add(btnMin);
            titleBar.Controls.Add(btnMax);
            titleBar.Controls.Add(btnClose);

            form.Controls.Add(titleBar);
        }

        private static void ApplyStylesRecursive(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                ApplyStyleToControl(control);
                if (control.HasChildren)
                {
                    ApplyStylesRecursive(control);
                }
            }
        }

        private static void ApplyStyleToControl(Control control)
        {
            if (!string.IsNullOrEmpty(control.Text))
            {
                if (control.Text.Contains("??"))
                {
                    control.Text = control.Text.Replace("???", "").Replace("??", "").Trim();
                }
                if (control.Text.StartsWith("?"))
                {
                    control.Text = control.Text.TrimStart('?').Trim();
                }
            }

            // Inject performance tracking for the elements (Zero-Blink)
            EnableDoubleBuffering(control);

            if (control is Panel panel)
            {
                // If it's the old header panel, make it transparent or style it nicely
                if (panel.Dock == DockStyle.Top)
                {
                    panel.BackColor = Color.FromArgb(150, 15, 23, 42); // Glass effect overlay for headers
                }
                else
                {
                    panel.BackColor = Color.Transparent;
                }
            }
            else if (control is Label label)
            {
                label.BackColor = Color.Transparent; // Glass effect
                label.ForeColor = Color.FromArgb(241, 245, 249); // Tailwind Slate 100
                EnsureModernFont(label);
            }
            else if (control is Button button)
            {
                StyleModernButton(button);
                EnsureModernFont(button);
            }
            else if (control is TextBox textBox)
            {
                textBox.BackColor = Color.FromArgb(30, 41, 59); // Slate 800
                textBox.ForeColor = Color.White;
                textBox.BorderStyle = BorderStyle.FixedSingle;
                EnsureModernFont(textBox);
            }
            else if (control is RichTextBox richTextBox)
            {
                richTextBox.BackColor = Color.FromArgb(30, 41, 59);
                richTextBox.ForeColor = Color.White;
                richTextBox.BorderStyle = BorderStyle.None;
                EnsureModernFont(richTextBox);
            }
            else if (control is ComboBox comboBox)
            {
                comboBox.BackColor = Color.FromArgb(30, 41, 59);
                comboBox.ForeColor = Color.White;
                comboBox.FlatStyle = FlatStyle.Flat;
                EnsureModernFont(comboBox);
            }
            else if (control is DataGridView dgv)
            {
                dgv.BackgroundColor = Color.FromArgb(30, 41, 59);
                dgv.ForeColor = Color.White;
                dgv.GridColor = Color.FromArgb(50, 60, 80);
                dgv.BorderStyle = BorderStyle.None;
                
                // Completely fix data truncation so text expands exactly like SSMS natively!
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                
                // CRITICAL: Cell background colors must be explicitly set so text doesn't blend into white
                dgv.DefaultCellStyle.BackColor = Color.FromArgb(30, 41, 59);
                dgv.DefaultCellStyle.ForeColor = Color.White;
                dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(59, 130, 246);
                dgv.DefaultCellStyle.SelectionForeColor = Color.White;
                
                // Header style
                dgv.EnableHeadersVisualStyles = false;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42);
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgv.RowHeadersDefaultCellStyle.BackColor = Color.FromArgb(15, 23, 42);

                EnsureModernFont(dgv);

                // Smart anchor to perfectly stretch the grid and immediately apply width sizes
                dgv.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                
                Form parentForm = dgv.FindForm();
                if (parentForm != null)
                {
                    dgv.Width = parentForm.ClientSize.Width - 40;
                    dgv.Height = parentForm.ClientSize.Height - dgv.Top - 80;
                }

                Action formatGrid = () => {
                    if (dgv.Columns.Count == 0) return;

                    // Check if we need to insert the generic SL No column
                    if (!dgv.Columns.Contains("SlNo"))
                    {
                        DataGridViewTextBoxColumn slCol = new DataGridViewTextBoxColumn();
                        slCol.Name = "SlNo";
                        slCol.HeaderText = "Sl. No";
                        slCol.ReadOnly = true;
                        dgv.Columns.Insert(0, slCol);
                    }

                    // Loop through to assign SL numbers
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        dgv.Rows[i].Cells["SlNo"].Value = (i + 1).ToString();
                    }

                    // Force SSMS-style precision timestamps natively!
                    foreach (DataGridViewColumn col in dgv.Columns)
                    {
                        if (col.ValueType == typeof(DateTime) || col.Name.Contains("Time") || col.Name.Contains("At") || col.Name.Contains("Date"))
                        {
                            col.DefaultCellStyle.Format = "yyyy-MM-dd HH:mm:ss.fff";
                        }
                    }
                };

                // Apply immediately because the ViewRecordsForm binds its data inside its constructor BEFORE ThemeManager runs!
                formatGrid();

                // And hook for future dynamic data regenerations
                dgv.DataBindingComplete += (s, e) => formatGrid();

                // Also anchor the Close button that sits below the grid so it stays at the bottom gracefully
                foreach (Control sibling in control.Parent.Controls)
                {
                    if (sibling is Button btn && sibling.Text.ToUpper() == "CLOSE" && sibling.Top > dgv.Bottom)
                    {
                        sibling.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
                    }
                }
            }
            else if (control is DateTimePicker dtp)
            {
                EnsureModernFont(dtp);
            }
        }

        private static void EnsureModernFont(Control control)
        {
            try
            {
                float newSize = control.Font.Size < 11f ? 11f : control.Font.Size;
                control.Font = new Font("Segoe UI", newSize, FontStyle.Bold);
            }
            catch { }
        }

        private static void EnableDoubleBuffering(Control control)
        {
            try
            {
                typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                    ?.SetValue(control, true, null);
            }
            catch { }
        }

        private static void StyleModernButton(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Cursor = Cursors.Hand;
            button.Paint += ModernButton_Paint;
            
            // Normalize Colors
            if (button.BackColor == Color.Empty || button.BackColor.Name == "Control" || button.BackColor == Color.White)
            {
                button.BackColor = Color.FromArgb(59, 130, 246); // Blue 500
            }
            else
            {
                button.BackColor = AdaptColor(button.BackColor);
            }
            button.ForeColor = Color.White;

            button.MouseEnter += (s, e) => {
                Button btn = s as Button;
                btn.Tag = btn.BackColor; // Store original
                btn.BackColor = LightenColor(btn.BackColor, 0.15f);
            };
            button.MouseLeave += (s, e) => {
                Button btn = s as Button;
                if (btn.Tag != null) btn.BackColor = (Color)btn.Tag; 
            };
        }

        private static void ModernButton_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            Rectangle rect = new Rectangle(0, 0, btn.Width, btn.Height);
            
            GraphicsPath path = new GraphicsPath();
            int radius = 8;
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(rect.Width - radius - 1, 0, radius, radius, 270, 90);
            path.AddArc(rect.Width - radius - 1, rect.Height - radius - 1, radius, radius, 0, 90);
            path.AddArc(0, rect.Height - radius - 1, radius, radius, 90, 90);
            path.CloseAllFigures();

            btn.Region = new Region(path);
        }

        private static Color AdaptColor(Color c)
        {
            if (c == Color.FromArgb(52, 152, 219)) return Color.FromArgb(59, 130, 246); // Blue
            if (c == Color.FromArgb(46, 204, 113)) return Color.FromArgb(16, 185, 129); // Green
            if (c == Color.FromArgb(241, 196, 15)) return Color.FromArgb(245, 158, 11); // Amber
            if (c == Color.FromArgb(231, 76, 60)) return Color.FromArgb(239, 68, 68); // Red
            if (c == Color.FromArgb(155, 89, 182)) return Color.FromArgb(139, 92, 246); // Purple
            return c;
        }

        private static Color LightenColor(Color color, float factor)
        {
            float r = color.R + (255 - color.R) * factor;
            float g = color.G + (255 - color.G) * factor;
            float b = color.B + (255 - color.B) * factor;
            return Color.FromArgb(color.A, Math.Min((int)r, 255), Math.Min((int)g, 255), Math.Min((int)b, 255));
        }
    }
}
