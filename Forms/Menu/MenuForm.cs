using CafeManagement.Helpers;
using CafeManagement.Models;
using CafeManagement.Repositories;
using System.Xml.Linq;

namespace CafeManagement.Forms.Menu
{
    public partial class MenuForm : Form
    {
        private readonly MenuRepository _repo = new MenuRepository();
        private int _selectedId = -1; // Id món đang được chọn, -1 là chưa chọn

        public MenuForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadData();
        }

        // Load danh sách món vào DataGridView
        private void LoadData(string keyword = "")
        {
            var list = string.IsNullOrEmpty(keyword)
                ? _repo.GetAll()
                : _repo.Search(keyword);

            dgvMenu.Rows.Clear();
            foreach (var item in list)
            {
                dgvMenu.Rows.Add(
                    item.Id,
                    item.Name,
                    item.Price.ToString("N0"),
                    item.Category,
                    item.IsAvailable ? "Yes" : "No"
                );
            }

            lblCount.Text = $"Total: {list.Count} items";
        }

        // Click vào dòng trong DataGridView → điền vào form bên phải
        private void dgvMenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvMenu.Rows[e.RowIndex];
            _selectedId = Convert.ToInt32(row.Cells[0].Value);
            txtName.Text = row.Cells[1].Value.ToString();
            txtPrice.Text = row.Cells[2].Value.ToString().Replace(",", "");
            txtCategory.Text = row.Cells[3].Value.ToString();
            chkAvailable.Checked = row.Cells[4].Value.ToString() == "Yes";
        }

        // Nút Add
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;

            var item = new MenuItem
            {
                Name = txtName.Text.Trim(),
                Price = decimal.Parse(txtPrice.Text.Trim()),
                Category = txtCategory.Text.Trim(),
                IsAvailable = chkAvailable.Checked,
            };

            _repo.Add(item);
            ToastForm.Success("Item added successfully!");
            LoadData();
            ClearForm();
        }

        // Nút Update
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedId == -1)
            {
                ToastForm.Warning("Please select an item to update.");
                return;
            }

            if (!ValidateInput()) return;

            var item = new MenuItem
            {
                Id = _selectedId,
                Name = txtName.Text.Trim(),
                Price = decimal.Parse(txtPrice.Text.Trim()),
                Category = txtCategory.Text.Trim(),
                IsAvailable = chkAvailable.Checked,
            };

            _repo.Update(item);
            ToastForm.Success("Item updated successfully!");
            LoadData();
            ClearForm();
        }

        // Nút Delete
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedId == -1)
            {
                ToastForm.Warning("Please select an item to delete.");
                return;
            }

            var confirm = MessageBox.Show(
                "Are you sure you want to delete this item?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm == DialogResult.Yes)
            {
                _repo.Delete(_selectedId);
                ToastForm.Success("Item deleted successfully!");
                LoadData();
                ClearForm();
            }
        }

        // Nút Clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        // Tìm kiếm
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData(txtSearch.Text.Trim());
        }

        // Xóa form bên phải
        private void ClearForm()
        {
            _selectedId = -1;
            txtName.Text = "";
            txtPrice.Text = "";
            txtCategory.Text = "";
            chkAvailable.Checked = true;
        }

        // Validate input
        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                ToastForm.Warning("Please enter item name.");
                return false;
            }

            if (!decimal.TryParse(txtPrice.Text.Trim(), out _))
            {
                ToastForm.Warning("Price must be a number.");
                return false;
            }

            if (string.IsNullOrEmpty(txtCategory.Text.Trim()))
            {
                ToastForm.Warning("Please enter category.");
                return false;
            }

            return true;
        }

        private void pnlRight_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
