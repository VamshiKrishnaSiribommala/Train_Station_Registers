using System;
using System.Windows.Forms;

namespace TMS
{
    public class MainClassesForm : Form
    {
        public MainClassesForm()
        {
            this.Text = "Train Management System";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            this.Size = new System.Drawing.Size(650, 700);
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = System.Drawing.Color.White;
            
            Panel headerPanel = new Panel();
            headerPanel.BackColor = System.Drawing.Color.FromArgb(0, 51, 102);
            headerPanel.Size = new System.Drawing.Size(650, 120);
            headerPanel.Dock = DockStyle.Top;
            this.Controls.Add(headerPanel);
            
            Label title = new Label();
            title.Text = "?? TRAIN MANAGEMENT SYSTEM";
            title.Font = new System.Drawing.Font("Segoe UI", 18, System.Drawing.FontStyle.Bold);
            title.ForeColor = System.Drawing.Color.White;
            title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            title.Size = new System.Drawing.Size(650, 50);
            title.Location = new System.Drawing.Point(0, 25);
            headerPanel.Controls.Add(title);
            
            Label subtitle = new Label();
            subtitle.Text = "Indian Railways - Station Registers Management";
            subtitle.Font = new System.Drawing.Font("Segoe UI", 11, System.Drawing.FontStyle.Italic);
            subtitle.ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
            subtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            subtitle.Size = new System.Drawing.Size(650, 30);
            subtitle.Location = new System.Drawing.Point(0, 75);
            headerPanel.Controls.Add(subtitle);
            
            int y = 150;
            
            Button btn1 = CreateButton("?? OPERATIONAL LIST\n(14 Registers)", System.Drawing.Color.FromArgb(52, 152, 219), 1, "Operational List");
            btn1.Location = new System.Drawing.Point(75, y);
            this.Controls.Add(btn1);
            
            Button btn2 = CreateButton("?? MAINTENANCE SUB\n(13 Registers)", System.Drawing.Color.FromArgb(46, 204, 113), 2, "Maintenance Sub");
            btn2.Location = new System.Drawing.Point(75, y + 95);
            this.Controls.Add(btn2);
            
            Button btn3 = CreateButton("??? INFRASTRUCTURE SUB\n(6 Registers)", System.Drawing.Color.FromArgb(241, 196, 15), 3, "Infrastructure Sub");
            btn3.Location = new System.Drawing.Point(75, y + 190);
            this.Controls.Add(btn3);
            
            Button btn4 = CreateButton("??? SAFETY LIST\n(7 Registers)", System.Drawing.Color.FromArgb(231, 76, 60), 4, "Safety List");
            btn4.Location = new System.Drawing.Point(75, y + 285);
            this.Controls.Add(btn4);
            
            Button btn5 = CreateButton("?? ADMIN LIST\n(1 Register)", System.Drawing.Color.FromArgb(155, 89, 182), 5, "Admin List");
            btn5.Location = new System.Drawing.Point(75, y + 380);
            this.Controls.Add(btn5);
        }
        
        private Button CreateButton(string text, System.Drawing.Color color, int moduleId, string moduleName)
        {
            Button btn = new Button();
            btn.Text = text;
            btn.Size = new System.Drawing.Size(500, 80);
            btn.Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold);
            btn.BackColor = color;
            btn.ForeColor = System.Drawing.Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.Click += (s, e) => {
                RegisterSelectionForm form = new RegisterSelectionForm(moduleId, moduleName);
                form.Show();
                this.Hide();
            };
            return btn;
        }
    
        protected override void OnHandleCreated(System.EventArgs e) { base.OnHandleCreated(e); TMS.ThemeManager.ApplyTheme(this); }
    }
}