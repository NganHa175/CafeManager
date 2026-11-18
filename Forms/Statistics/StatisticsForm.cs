using System;
using System.Data;
using System.Windows.Forms;
using CafeManagement.Repositories;

namespace CafeManagement.Forms.Statistics
{
    public partial class StatisticsForm : Form
    {
        private readonly StatisticsRepository _repo = new StatisticsRepository();

        public StatisticsForm()
        {
            InitializeComponent();
            this.Load += StatisticsForm_Load;
            btnFilter.Click += btnFilter_Click;
            btnRefresh.Click += btnRefresh_Click;
        }

        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            ResetFilter();
        }

        private void LoadStatistics()
        {
            try
            {
                if (dtpFrom.Value.Date > dtpTo.Value.Date)
                {
                    MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable dt = _repo.GetPaidOrders(dtpFrom.Value, dtpTo.Value);
                dgvStatistics.DataSource = dt;

                if (dgvStatistics.Columns["Tổng Tiền"] != null)
                {
                    dgvStatistics.Columns["Tổng Tiền"].DefaultCellStyle.Format = "N0";
                }

                long totalRevenue = 0;
                foreach (DataRow row in dt.Rows)
                {
                    totalRevenue += Convert.ToInt64(row["Tổng Tiền"]);
                }

                lblTotalRevenue.Text = $"Tổng doanh thu: {totalRevenue:N0} VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu thống kê: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetFilter()
        {
            DateTime today = DateTime.Now;
            dtpFrom.Value = new DateTime(today.Year, today.Month, 1);
            dtpTo.Value = today;
            LoadStatistics();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadStatistics();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ResetFilter();
        }
    }
}