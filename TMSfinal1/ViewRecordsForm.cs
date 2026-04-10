using System;
using System.Data;
using System.Windows.Forms;

namespace TMS
{
    public class ViewRecordsForm : Form
    {
        private DataGridView dataGridView;
        private string tableName;
        private string title;
        private DatabaseHelper db = new DatabaseHelper();

        public ViewRecordsForm(string tableName, string title)
        {
            this.tableName = tableName;
            this.title = title;
            this.Text = title + " - View Records";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            this.Size = new System.Drawing.Size(1100, 600);
            this.BackColor = System.Drawing.Color.White;
            
            CreateControls();
            LoadData();
        }
        
        private void CreateControls()
        {
            Panel headerPanel = new Panel();
            headerPanel.BackColor = System.Drawing.Color.FromArgb(0, 51, 102);
            headerPanel.Size = new System.Drawing.Size(1100, 60);
            headerPanel.Dock = DockStyle.Top;
            this.Controls.Add(headerPanel);
            
            Label lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblTitle.Size = new System.Drawing.Size(1100, 40);
            lblTitle.Location = new System.Drawing.Point(0, 10);
            headerPanel.Controls.Add(lblTitle);
            
            dataGridView = new DataGridView();
            dataGridView.Location = new System.Drawing.Point(20, 80);
            dataGridView.Size = new System.Drawing.Size(1050, 430);
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.ReadOnly = true;
            dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.Controls.Add(dataGridView);
            
            Button btnClose = new Button();
            btnClose.Text = "CLOSE";
            btnClose.Size = new System.Drawing.Size(120, 45);
            btnClose.Location = new System.Drawing.Point(490, 530);
            btnClose.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            btnClose.ForeColor = System.Drawing.Color.White;
            btnClose.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Click += (s, e) => this.Close();
            this.Controls.Add(btnClose);
        }
        
        private void LoadData()
        {
            try
            {
                string query = $"SELECT * FROM {tableName} ORDER BY SubmittedAt DESC";
                DataTable dt = db.ExecuteQuery(query);
                dataGridView.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error");
            }
        }
    
        protected override void OnHandleCreated(System.EventArgs e) { base.OnHandleCreated(e); TMS.ThemeManager.ApplyTheme(this); }
    }
}