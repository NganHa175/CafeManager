using CafeManagement.Helpers;
using CafeManagement.Models;
using CafeManagement.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CafeManagement.Forms.Tables
{
    public partial class TableForm : Form
    {
        List<CafeTable> lsTables;
        List<string> lsStatus = new List<string>() { "Empty", "Occupied", "Paid" };
        TableRepository _tableRepo = new TableRepository();
        CafeTable tableSelected;
        public TableForm()
        {
            InitializeComponent();
        }

        public void LoadData()
        {
            lsTables = _tableRepo.GetAll();
            if (lsTables != null && lsTables.Count > 0)
            {
                int maxID = lsTables.Max(table => table.Id);
                int nextID = maxID + 1;
                tbTbID.Text = nextID.ToString();
            }
            else
                tbTbID.Text = "1";

            dgvTable.DataSource = null;
            dgvTable.DataSource = lsTables;
            dgvTable.Columns["Id"].Visible = false;

            lbTbCount.Text = $"Total: {lsTables.Count} table(s)";

            BindData(null);
        }

        public void BindData(CafeTable table)
        {
            if (table != null)
            {
                tbTbID.Text = table.Id.ToString();
                tbTbName.Text = table.TableName;
                cbbStatus.Text = table.Status;
            }
            else
            {
                tbTbName.Text = "";
                cbbStatus.SelectedIndex = 0;
            }
        }

        public CafeTable GetTable()
        {
            CafeTable table = new CafeTable();
            table.Id = Convert.ToInt32(tbTbID.Text);
            table.TableName = tbTbName.Text;
            table.Status = cbbStatus.Text;
            return table;
        }

        private void TableForm_Load(object sender, EventArgs e)
        {
            cbbStatus.DataSource = lsStatus;
            LoadData();
        }

        private void btnAddTb_Click(object sender, EventArgs e)
        {
            try
            {
                CafeTable table = GetTable();
                if (!ValidateInput())
                    return;
                _tableRepo.Add(table);
                ToastForm.Success("Table added successfully!");
                LoadData();
            }
            catch (Exception ex)
            {
                ToastForm.Error(ex.ToString());
            }
        }

        private void dgvTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            tableSelected = lsTables[e.RowIndex];
            BindData(tableSelected);
        }

        private void btnUpdateTb_Click(object sender, EventArgs e)
        {
            try
            {
                if (tableSelected == null)
                {
                    ToastForm.Warning("Please select a table to update."); 
                    return;
                }
                CafeTable table = GetTable();
                if (!ValidateInput())
                    return;
                _tableRepo.Update(table);
                ToastForm.Success("Table updated successfully!");
                LoadData();
            }
            catch (Exception ex)
            {
                ToastForm.Error(ex.ToString());
            }
        }

        private void btnDeleteTb_Click(object sender, EventArgs e)
        {
            try
            {
                if (tableSelected == null)
                {
                    ToastForm.Warning("Please select a table to delete.");
                    return;
                }
                var confirm = MessageBox.Show
                (
                    "Are you sure you want to delete this table?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );
                if (confirm == DialogResult.Yes)
                {
                    _tableRepo.Delete(tableSelected);
                    ToastForm.Success("Table deleted successfully!");
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                ToastForm.Error(ex.ToString());
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = tbSearch.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadData();
            }
            else
            {
                lsTables = _tableRepo.Search(keyword);

                dgvTable.DataSource = null;
                dgvTable.DataSource = lsTables;
                dgvTable.Columns["Id"].Visible = false;


                lbTbCount.Text = $"Total: {lsTables.Count} table(s)";

                BindData(null);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(tbTbName.Text.Trim()))
            {
                ToastForm.Warning("Please enter table name.");
                return false;
            }
            return true;
        }
    }
}
