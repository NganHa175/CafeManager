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

            dgvTable.DataSource = null;
            dgvTable.DataSource = lsTables;

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
                tbTbID.Text = "";
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
    }
}
