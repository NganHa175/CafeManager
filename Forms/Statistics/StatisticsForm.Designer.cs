using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace CafeManagement.Forms.Statistics
{
    partial class StatisticsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvStatistics;
        private System.Windows.Forms.Label lblTotalRevenue;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dtpFrom = new System.Windows.Forms.DateTimePicker();
            dtpTo = new System.Windows.Forms.DateTimePicker();
            btnFilter = new System.Windows.Forms.Button();
            btnRefresh = new System.Windows.Forms.Button();
            dgvStatistics = new System.Windows.Forms.DataGridView();
            lblTotalRevenue = new System.Windows.Forms.Label();
            lblFrom = new System.Windows.Forms.Label();
            lblTo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)dgvStatistics).BeginInit();
            SuspendLayout();

            // lblFrom
            lblFrom.AutoSize = true;
            lblFrom.Location = new System.Drawing.Point(20, 24);
            lblFrom.Name = "lblFrom";
            lblFrom.Size = new System.Drawing.Size(55, 15);
            lblFrom.Text = "Từ ngày:";

            // dtpFrom
            dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpFrom.Location = new System.Drawing.Point(81, 20);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new System.Drawing.Size(130, 23);

            // lblTo
            lblTo.AutoSize = true;
            lblTo.Location = new System.Drawing.Point(230, 24);
            lblTo.Name = "lblTo";
            lblTo.Size = new System.Drawing.Size(61, 15);
            lblTo.Text = "Đến ngày:";

            // dtpTo
            dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpTo.Location = new System.Drawing.Point(297, 20);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new System.Drawing.Size(130, 23);

            // btnFilter
            btnFilter.Location = new System.Drawing.Point(450, 19);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new System.Drawing.Size(95, 25);
            btnFilter.Text = "Thống kê";

            // btnRefresh
            btnRefresh.Location = new System.Drawing.Point(555, 19);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new System.Drawing.Size(95, 25);
            btnRefresh.Text = "Refresh";

            // dgvStatistics
            dgvStatistics.AllowUserToAddRows = false;
            dgvStatistics.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvStatistics.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvStatistics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStatistics.Location = new System.Drawing.Point(20, 60);
            dgvStatistics.Name = "dgvStatistics";
            dgvStatistics.ReadOnly = true;
            dgvStatistics.Size = new System.Drawing.Size(760, 340);

            // lblTotalRevenue
            lblTotalRevenue.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            lblTotalRevenue.AutoSize = true;
            lblTotalRevenue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblTotalRevenue.Location = new System.Drawing.Point(530, 415);
            lblTotalRevenue.Name = "lblTotalRevenue";
            lblTotalRevenue.Size = new System.Drawing.Size(220, 21);
            lblTotalRevenue.Text = "Tổng doanh thu: 0 VNĐ";

            // StatisticsForm
            ClientSize = new System.Drawing.Size(800, 460);
            Controls.Add(lblFrom);
            Controls.Add(dtpFrom);
            Controls.Add(lblTo);
            Controls.Add(dtpTo);
            Controls.Add(btnFilter);
            Controls.Add(btnRefresh);
            Controls.Add(dgvStatistics);
            Controls.Add(lblTotalRevenue);
            Name = "StatisticsForm";
            Text = "Thống kê doanh thu";
            ((System.ComponentModel.ISupportInitialize)dgvStatistics).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}