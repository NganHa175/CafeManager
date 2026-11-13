using CafeManagement.Helpers;
using CafeManagement.Models;
using CafeManagement.Repositories;

namespace CafeManagement.Forms.Menu
{
    public partial class MenuForm : Form
    {
        private readonly MenuRepository _repo = new MenuRepository();
        private int _selectedId = -1;

        public MenuForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadData();
        }

        private void LoadData(string keyword = "")
        {
            var list = string.IsNullOrEmpty(keyword)
                ? _repo.GetAll()
                : _repo.Search(keyword);

            dgvMenu.Rows.Clear();
            foreach (var item in list)
            {
                int idx = dgvMenu.Rows.Add(
                    item.Id,
                    item.Name,
                    item.Price.ToString("N0") + " ₫",
                    item.Category,
                    item.IsAvailable ? "Yes" : "No"
                );
                var row = dgvMenu.Rows[idx];
                row.Tag = item;
                if (!item.IsAvailable)
                    row.DefaultCellStyle.ForeColor = Theme.TextMuted;
            }
            dgvMenu.ClearSelection();
            lblCount.Text = $"{list.Count} items";
        }

        private void dgvMenu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvMenu.Rows[e.RowIndex].Tag is not MenuItem item) return;

            _selectedId = item.Id;
            txtName.Text = item.Name;
            txtPrice.Text = item.Price.ToString();
            txtCategory.Text = item.Category;
            chkAvailable.Checked = item.IsAvailable;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            _repo.Add(new MenuItem
            {
                Name = txtName.Text.Trim(),
                Price = long.Parse(txtPrice.Text.Trim()),
                Category = txtCategory.Text.Trim(),
                IsAvailable = chkAvailable.Checked,
            });
            ToastForm.Success("Item added successfully!");
            LoadData();
            ClearForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedId == -1) { ToastForm.Warning("Please select an item to update."); return; }
            if (!ValidateInput()) return;
            _repo.Update(new MenuItem
            {
                Id = _selectedId,
                Name = txtName.Text.Trim(),
                Price = long.Parse(txtPrice.Text.Trim()),
                Category = txtCategory.Text.Trim(),
                IsAvailable = chkAvailable.Checked,
            });
            ToastForm.Success("Item updated successfully!");
            LoadData();
            ClearForm();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedId == -1) { ToastForm.Warning("Please select an item to delete."); return; }
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
            dgvMenu.ClearSelection();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
            => LoadData(txtSearch.Text.Trim());

        private void ClearForm()
        {
            _selectedId = -1;
            txtName.Text = "";
            txtPrice.Text = "";
            txtCategory.Text = "";
            chkAvailable.Checked = true;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                ToastForm.Warning("Please enter item name.");
                return false;
            }
            if (!long.TryParse(txtPrice.Text.Trim(), out var price) || price < 0)
            {
                ToastForm.Warning("Price must be a non-negative number.");
                return false;
            }
            if (string.IsNullOrEmpty(txtCategory.Text.Trim()))
            {
                ToastForm.Warning("Please enter category.");
                return false;
            }
            return true;
        }
    }
}
