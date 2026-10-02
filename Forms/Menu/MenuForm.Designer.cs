namespace CafeManagement.Forms.Menu
{
    partial class MenuForm
    {
        private System.ComponentModel.IContainer components = null;

        // Controls bên trái
        private DataGridView dgvMenu;
        private TextBox txtSearch;
        private Label lblSearch;
        private Label lblCount;
        private Button btnDelete;

        // Controls bên phải
        private Panel pnlRight;
        private Label lblTitle;
        private Label lblName;
        private Label lblPrice;
        private Label lblCategory;
        private Label lblAvailable;
        private TextBox txtName;
        private TextBox txtPrice;
        private TextBox txtCategory;
        private CheckBox chkAvailable;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnClear;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            lblTitle = new Label();
            lblSearch = new Label();
            txtSearch = new TextBox();
            dgvMenu = new DataGridView();
            lblCount = new Label();
            btnDelete = new Button();
            pnlRight = new Panel();
            lblName = new Label();
            txtName = new TextBox();
            lblCategory = new Label();
            txtCategory = new TextBox();
            lblPrice = new Label();
            txtPrice = new TextBox();
            chkAvailable = new CheckBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnClear = new Button();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvMenu).BeginInit();
            pnlRight.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(100, 23);
            lblTitle.TabIndex = 0;
            // 
            // lblSearch
            // 
            lblSearch.Location = new Point(0, 0);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(100, 23);
            lblSearch.TabIndex = 1;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(0, 0);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(100, 31);
            txtSearch.TabIndex = 2;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // dgvMenu
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(101, 67, 33);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvMenu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvMenu.ColumnHeadersHeight = 34;
            dgvMenu.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5 });
            dgvMenu.EnableHeadersVisualStyles = false;
            dgvMenu.Location = new Point(59, 64);
            dgvMenu.Name = "dgvMenu";
            dgvMenu.RowHeadersWidth = 62;
            dgvMenu.Size = new Size(769, 467);
            dgvMenu.TabIndex = 3;
            dgvMenu.CellClick += dgvMenu_CellClick;
            // 
            // lblCount
            // 
            lblCount.Location = new Point(0, 0);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(100, 23);
            lblCount.TabIndex = 4;
            // 
            // btnDelete
            // 
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.Location = new Point(0, 0);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 5;
            btnDelete.Click += btnDelete_Click;
            // 
            // pnlRight
            // 
            pnlRight.Controls.Add(lblName);
            pnlRight.Controls.Add(txtName);
            pnlRight.Controls.Add(lblCategory);
            pnlRight.Controls.Add(txtCategory);
            pnlRight.Controls.Add(lblPrice);
            pnlRight.Controls.Add(txtPrice);
            pnlRight.Controls.Add(chkAvailable);
            pnlRight.Controls.Add(btnAdd);
            pnlRight.Controls.Add(btnUpdate);
            pnlRight.Controls.Add(btnClear);
            pnlRight.Location = new Point(0, 0);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(200, 100);
            pnlRight.TabIndex = 6;
            pnlRight.Paint += pnlRight_Paint;
            // 
            // lblName
            // 
            lblName.Location = new Point(0, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(100, 23);
            lblName.TabIndex = 0;
            // 
            // txtName
            // 
            txtName.Location = new Point(0, 0);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 31);
            txtName.TabIndex = 1;
            // 
            // lblCategory
            // 
            lblCategory.Location = new Point(0, 0);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(100, 23);
            lblCategory.TabIndex = 2;
            // 
            // txtCategory
            // 
            txtCategory.Location = new Point(0, 0);
            txtCategory.Name = "txtCategory";
            txtCategory.Size = new Size(100, 31);
            txtCategory.TabIndex = 3;
            // 
            // lblPrice
            // 
            lblPrice.Location = new Point(0, 0);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(100, 23);
            lblPrice.TabIndex = 4;
            // 
            // txtPrice
            // 
            txtPrice.Location = new Point(0, 0);
            txtPrice.Name = "txtPrice";
            txtPrice.Size = new Size(100, 31);
            txtPrice.TabIndex = 5;
            // 
            // chkAvailable
            // 
            chkAvailable.Location = new Point(0, 0);
            chkAvailable.Name = "chkAvailable";
            chkAvailable.Size = new Size(104, 24);
            chkAvailable.TabIndex = 6;
            // 
            // btnAdd
            // 
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.Location = new Point(0, 0);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 7;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.Location = new Point(0, 0);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 8;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnClear
            // 
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.Location = new Point(0, 0);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(75, 23);
            btnClear.TabIndex = 9;
            btnClear.Click += btnClear_Click;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "ID";
            dataGridViewTextBoxColumn1.MinimumWidth = 8;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Name";
            dataGridViewTextBoxColumn2.MinimumWidth = 8;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Price";
            dataGridViewTextBoxColumn3.MinimumWidth = 8;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Category";
            dataGridViewTextBoxColumn4.MinimumWidth = 8;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.Width = 150;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Available";
            dataGridViewTextBoxColumn5.MinimumWidth = 8;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.Width = 150;
            // 
            // MenuForm
            // 
            BackColor = Color.FromArgb(245, 240, 235);
            ClientSize = new Size(860, 520);
            Controls.Add(lblTitle);
            Controls.Add(lblSearch);
            Controls.Add(txtSearch);
            Controls.Add(dgvMenu);
            Controls.Add(lblCount);
            Controls.Add(btnDelete);
            Controls.Add(pnlRight);
            Name = "MenuForm";
            Text = "Menu Management";
            ((System.ComponentModel.ISupportInitialize)dgvMenu).EndInit();
            pnlRight.ResumeLayout(false);
            pnlRight.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    }
}
