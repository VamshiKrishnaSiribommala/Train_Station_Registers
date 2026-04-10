using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TMS
{
    public class Form_Reg041_DynamicReports : Form
    {
        private TextBox txtReportID;
        private ComboBox cmbReportCategory;
        private RichTextBox txtRegistersSelected;
        private RichTextBox txtParamSelection;
        private ComboBox cmbFilterStation;
        private DateTimePicker dtpDateFrom;
        private DateTimePicker dtpDateTo;
        private ComboBox cmbAggregationType;
        private ComboBox cmbReportFormat;
        private TextBox txtGeneratedBy;
        private TextBox txtSubmittedBy;
        private DatabaseHelper db = new DatabaseHelper();
        

        public Form_Reg041_DynamicReports()
        {
            this.Text = "Dynamic Reports (REG-041)";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            this.Size = new System.Drawing.Size(850, 850);
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = System.Drawing.Color.White;
            
            CreateControls();
            GenerateReportID();
        }

        private void CreateControls()
        {
            Panel headerPanel = new Panel();
            headerPanel.BackColor = System.Drawing.Color.FromArgb(0, 51, 102);
            headerPanel.Size = new System.Drawing.Size(850, 80);
            headerPanel.Dock = DockStyle.Top;
            this.Controls.Add(headerPanel);
            
            Label lblPath = new Label();
            lblPath.Text = "?? Home > Admin List > Dynamic Reports";
            lblPath.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Italic);
            lblPath.ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
            lblPath.Size = new System.Drawing.Size(800, 25);
            lblPath.Location = new System.Drawing.Point(25, 15);
            headerPanel.Controls.Add(lblPath);
            
            Label lblTitle = new Label();
            lblTitle.Text = "DYNAMIC REPORT CREATION MODULE";
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 16, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblTitle.Size = new System.Drawing.Size(800, 35);
            lblTitle.Location = new System.Drawing.Point(25, 40);
            headerPanel.Controls.Add(lblTitle);
            
            int y = 110;
            
            Label lblReportID = new Label();
            lblReportID.Text = "Report ID (System Generated):";
            lblReportID.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            lblReportID.Location = new System.Drawing.Point(30, y);
            lblReportID.Size = new System.Drawing.Size(220, 30);
            this.Controls.Add(lblReportID);
            
            txtReportID = new TextBox();
            txtReportID.Location = new System.Drawing.Point(260, y);
            txtReportID.Size = new System.Drawing.Size(300, 30);
            txtReportID.ReadOnly = true;
            txtReportID.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(txtReportID);
            
            y += 50;
            
            Label lblReportCategory = new Label();
            lblReportCategory.Text = "Report Category *";
            lblReportCategory.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            lblReportCategory.Location = new System.Drawing.Point(30, y);
            lblReportCategory.Size = new System.Drawing.Size(130, 30);
            this.Controls.Add(lblReportCategory);
            
            cmbReportCategory = new ComboBox();
            cmbReportCategory.Location = new System.Drawing.Point(170, y);
            cmbReportCategory.Size = new System.Drawing.Size(200, 30);
            cmbReportCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbReportCategory.Items.AddRange(new string[] { "Safety", "Operational", "Technical", "HR", "Custom" });
            this.Controls.Add(cmbReportCategory);
            
            y += 80;
            
            Label lblRegistersSelected = new Label();
            lblRegistersSelected.Text = "Registers Selected *";
            lblRegistersSelected.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            lblRegistersSelected.Location = new System.Drawing.Point(30, y);
            lblRegistersSelected.Size = new System.Drawing.Size(150, 30);
            this.Controls.Add(lblRegistersSelected);
            
            txtRegistersSelected = new RichTextBox();
            txtRegistersSelected.Location = new System.Drawing.Point(30, y + 40);
            txtRegistersSelected.Size = new System.Drawing.Size(770, 80);
            txtRegistersSelected.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(txtRegistersSelected);
            
            y += 140;
            
            Label lblParamSelection = new Label();
            lblParamSelection.Text = "Parameter Selection *";
            lblParamSelection.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            lblParamSelection.Location = new System.Drawing.Point(30, y);
            lblParamSelection.Size = new System.Drawing.Size(160, 30);
            this.Controls.Add(lblParamSelection);
            
            txtParamSelection = new RichTextBox();
            txtParamSelection.Location = new System.Drawing.Point(30, y + 40);
            txtParamSelection.Size = new System.Drawing.Size(770, 80);
            txtParamSelection.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(txtParamSelection);
            
            y += 140;
            
            Label lblFilterStation = new Label();
            lblFilterStation.Text = "Filter: Station *";
            lblFilterStation.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            lblFilterStation.Location = new System.Drawing.Point(30, y);
            lblFilterStation.Size = new System.Drawing.Size(140, 30);
            this.Controls.Add(lblFilterStation);
            
            cmbFilterStation = new ComboBox();
            cmbFilterStation.Location = new System.Drawing.Point(180, y);
            cmbFilterStation.Size = new System.Drawing.Size(200, 30);
            cmbFilterStation.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilterStation.Items.AddRange(new string[] { "All Stations", "Station A", "Station B", "Station C", "Station D", "Station E" });
            this.Controls.Add(cmbFilterStation);
            
            y += 50;
            
            Label lblDateRange = new Label();
            lblDateRange.Text = "Date Range *";
            lblDateRange.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            lblDateRange.Location = new System.Drawing.Point(30, y);
            lblDateRange.Size = new System.Drawing.Size(120, 30);
            this.Controls.Add(lblDateRange);
            
            Label lblFrom = new Label();
            lblFrom.Text = "From:";
            lblFrom.Location = new System.Drawing.Point(160, y);
            lblFrom.Size = new System.Drawing.Size(40, 30);
            this.Controls.Add(lblFrom);
            
            dtpDateFrom = new DateTimePicker();
            dtpDateFrom.Location = new System.Drawing.Point(200, y);
            dtpDateFrom.Size = new System.Drawing.Size(130, 30);
            dtpDateFrom.Format = DateTimePickerFormat.Short;
            this.Controls.Add(dtpDateFrom);
            
            Label lblTo = new Label();
            lblTo.Text = "To:";
            lblTo.Location = new System.Drawing.Point(340, y);
            lblTo.Size = new System.Drawing.Size(30, 30);
            this.Controls.Add(lblTo);
            
            dtpDateTo = new DateTimePicker();
            dtpDateTo.Location = new System.Drawing.Point(370, y);
            dtpDateTo.Size = new System.Drawing.Size(130, 30);
            dtpDateTo.Format = DateTimePickerFormat.Short;
            this.Controls.Add(dtpDateTo);
            
            y += 50;
            
            Label lblAggregationType = new Label();
            lblAggregationType.Text = "Aggregation Type *";
            lblAggregationType.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            lblAggregationType.Location = new System.Drawing.Point(30, y);
            lblAggregationType.Size = new System.Drawing.Size(140, 30);
            this.Controls.Add(lblAggregationType);
            
            cmbAggregationType = new ComboBox();
            cmbAggregationType.Location = new System.Drawing.Point(180, y);
            cmbAggregationType.Size = new System.Drawing.Size(150, 30);
            cmbAggregationType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAggregationType.Items.AddRange(new string[] { "Count", "Sum", "Average", "Group By" });
            this.Controls.Add(cmbAggregationType);
            
            y += 50;
            
            Label lblReportFormat = new Label();
            lblReportFormat.Text = "Report Format *";
            lblReportFormat.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            lblReportFormat.Location = new System.Drawing.Point(30, y);
            lblReportFormat.Size = new System.Drawing.Size(120, 30);
            this.Controls.Add(lblReportFormat);
            
            cmbReportFormat = new ComboBox();
            cmbReportFormat.Location = new System.Drawing.Point(160, y);
            cmbReportFormat.Size = new System.Drawing.Size(150, 30);
            cmbReportFormat.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbReportFormat.Items.AddRange(new string[] { "PDF", "Excel", "CSV" });
            this.Controls.Add(cmbReportFormat);
            
            y += 50;
            
            Label lblGeneratedBy = new Label();
            lblGeneratedBy.Text = "Generated By *";
            lblGeneratedBy.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            lblGeneratedBy.Location = new System.Drawing.Point(30, y);
            lblGeneratedBy.Size = new System.Drawing.Size(120, 30);
            this.Controls.Add(lblGeneratedBy);
            
            txtGeneratedBy = new TextBox();
            txtGeneratedBy.Location = new System.Drawing.Point(160, y);
            txtGeneratedBy.Size = new System.Drawing.Size(200, 30);
            this.Controls.Add(txtGeneratedBy);
            
            y += 80;
            
            Button btnGenerate = new Button();
            btnGenerate.Text = "?? GENERATE REPORT";
            btnGenerate.Size = new System.Drawing.Size(180, 50);
            btnGenerate.Location = new System.Drawing.Point(180, y);
            btnGenerate.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            btnGenerate.ForeColor = System.Drawing.Color.White;
            btnGenerate.Font = new System.Drawing.Font("Segoe UI", 11, System.Drawing.FontStyle.Bold);
            btnGenerate.FlatStyle = FlatStyle.Flat;
            btnGenerate.Click += BtnGenerate_Click;
            this.Controls.Add(btnGenerate);
            
            Button btnView = new Button();
            btnView.Text = "VIEW REPORTS";
            btnView.Size = new System.Drawing.Size(150, 45);
            btnView.Location = new System.Drawing.Point(380, y);
            btnView.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            btnView.ForeColor = System.Drawing.Color.White;
            btnView.Font = new System.Drawing.Font("Segoe UI", 11, System.Drawing.FontStyle.Bold);
            btnView.FlatStyle = FlatStyle.Flat;
            btnView.Click += (s, e) => new ViewRecordsForm("Reg041_DynamicReports", "Dynamic Reports").ShowDialog();
            this.Controls.Add(btnView);
            
            Button btnClear = new Button();
            btnClear.Text = "CLEAR";
            btnClear.Size = new System.Drawing.Size(120, 45);
            btnClear.Location = new System.Drawing.Point(550, y);
            btnClear.BackColor = System.Drawing.Color.FromArgb(241, 196, 15);
            btnClear.ForeColor = System.Drawing.Color.Black;
            btnClear.Font = new System.Drawing.Font("Segoe UI", 11, System.Drawing.FontStyle.Bold);
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Click += (s, e) => ClearForm();
            this.Controls.Add(btnClear);
            
            Button btnBack = new Button();
            btnBack.Text = "BACK";
            btnBack.Size = new System.Drawing.Size(100, 45);
            btnBack.Location = new System.Drawing.Point(680, y);
            btnBack.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            btnBack.ForeColor = System.Drawing.Color.White;
            btnBack.Font = new System.Drawing.Font("Segoe UI", 11, System.Drawing.FontStyle.Bold);
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Click += (s, e) => this.Close();
            this.Controls.Add(btnBack);
        }
        
        private void GenerateReportID()
        {
            string datePart = DateTime.Now.ToString("yyyyMMdd");
            string query = $"SELECT COUNT(*) FROM Reg041_DynamicReports WHERE ReportID LIKE 'TMS-REP-{datePart}-%'";
            int count = Convert.ToInt32(db.ExecuteScalar(query));
            txtReportID.Text = $"TMS-REP-{datePart}-{(count + 1).ToString("D3")}";
        }
        
        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            if (!ValidationHelper.IsSelected(cmbReportCategory, "Report Category")) return;
            if (!ValidationHelper.IsNotEmpty(txtRegistersSelected.Text, "Registers Selected")) return;
            if (!ValidationHelper.IsNotEmpty(txtParamSelection.Text, "Parameter Selection")) return;
            if (!ValidationHelper.IsSelected(cmbFilterStation, "Filter Station")) return;
            if (!ValidationHelper.IsSelected(cmbAggregationType, "Aggregation Type")) return;
            if (!ValidationHelper.IsSelected(cmbReportFormat, "Report Format")) return;
            if (!ValidationHelper.IsNotEmpty(txtGeneratedBy.Text, "Generated By")) return;
            if (!ValidationHelper.IsEndAfterStart(dtpDateFrom.Value, dtpDateTo.Value, "Start Date", "End Date")) return;
            
            string query = $@"
                INSERT INTO Reg041_DynamicReports (ReportID, ReportCategory, RegistersSelected, ParamSelection, FilterStation, DateRange, AggregationType, ReportFormat, GeneratedBy, GeneratedAt, SubmittedBy)
                VALUES ('{txtReportID.Text}', '{cmbReportCategory.SelectedItem}', 
                        '{txtRegistersSelected.Text.Replace("'", "''")}', '{txtParamSelection.Text.Replace("'", "''")}', 
                        '{cmbFilterStation.SelectedItem}', 'From {dtpDateFrom.Value:dd/MM/yyyy} To {dtpDateTo.Value:dd/MM/yyyy}', 
                        '{cmbAggregationType.SelectedItem}', '{cmbReportFormat.SelectedItem}', 
                        '{txtGeneratedBy.Text}', GETDATE(), {txtSubmittedBy.Text})";

            
            
            try
            {
                db.ExecuteNonQuery(query);
                MessageBox.Show($"? Report Generated Successfully!\n\n?? Report ID: {txtReportID.Text}\n?? Format: {cmbReportFormat.SelectedItem}\n?? Date Range: {dtpDateFrom.Value:dd/MM/yyyy} to {dtpDateTo.Value:dd/MM/yyyy}\n?? Generated By: {txtGeneratedBy.Text}\n\n?? Report will be available in the selected format.", 
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                GenerateReportID();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"? Error: {ex.Message}", "Database Error");
            }
        }
        
        
            private void ClearForm()
        {
        
        
            if (txtSubmittedBy != null) txtSubmittedBy.Clear();
            cmbReportCategory.SelectedIndex = -1;
            txtRegistersSelected.Clear();
            txtParamSelection.Clear();
            cmbFilterStation.SelectedIndex = -1;
            dtpDateFrom.Value = DateTime.Now.AddDays(-30);
            dtpDateTo.Value = DateTime.Now;
            cmbAggregationType.SelectedIndex = -1;
            cmbReportFormat.SelectedIndex = -1;
            txtGeneratedBy.Clear();
        }
    
        protected override void OnHandleCreated(System.EventArgs e) { base.OnHandleCreated(e); TMS.ThemeManager.ApplyTheme(this); }
    }
}
