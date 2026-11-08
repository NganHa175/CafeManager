namespace CafeManagement.Forms.Tables
{
    partial class TableForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pnlMain = new Panel();
            dgvTable = new DataGridView();
            TableID = new DataGridViewTextBoxColumn();
            TableName = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            pnlLeft = new Panel();
            btnUpdateTb = new Button();
            btnDeleteTb = new Button();
            btnAddTb = new Button();
            lbStatus = new Label();
            cbbStatus = new ComboBox();
            lbTbName = new Label();
            tbTbName = new TextBox();
            lbTbID = new Label();
            tbTbID = new TextBox();
            pnlBottom = new Panel();
            lbTbCount = new Label();
            lbTitle = new Label();
            pnlTop = new Panel();
            textBox1 = new TextBox();
            lbSearch = new Label();
            pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTable).BeginInit();
            pnlLeft.SuspendLayout();
            pnlBottom.SuspendLayout();
            pnlTop.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(dgvTable);
            pnlMain.Location = new Point(0, 80);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(571, 330);
            pnlMain.TabIndex = 3;
            // 
            // dgvTable
            // 
            dgvTable.AllowUserToAddRows = false;
            dgvTable.AllowUserToDeleteRows = false;
            dgvTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTable.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(101, 67, 33);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(200, 190, 180);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTable.Columns.AddRange(new DataGridViewColumn[] { TableID, TableName, Status });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(200, 190, 180);
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvTable.DefaultCellStyle = dataGridViewCellStyle2;
            dgvTable.Dock = DockStyle.Fill;
            dgvTable.EnableHeadersVisualStyles = false;
            dgvTable.Location = new Point(0, 0);
            dgvTable.Name = "dgvTable";
            dgvTable.ReadOnly = true;
            dgvTable.RowHeadersWidth = 51;
            dgvTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTable.Size = new Size(571, 330);
            dgvTable.TabIndex = 1;
            // 
            // TableID
            // 
            TableID.DataPropertyName = "TableID";
            TableID.HeaderText = "Table ID";
            TableID.MinimumWidth = 6;
            TableID.Name = "TableID";
            TableID.ReadOnly = true;
            // 
            // TableName
            // 
            TableName.DataPropertyName = "TableName";
            TableName.HeaderText = "Table Name";
            TableName.MinimumWidth = 6;
            TableName.Name = "TableName";
            TableName.ReadOnly = true;
            // 
            // Status
            // 
            Status.DataPropertyName = "Status";
            Status.HeaderText = "Status";
            Status.MinimumWidth = 6;
            Status.Name = "Status";
            Status.ReadOnly = true;
            // 
            // pnlLeft
            // 
            pnlLeft.Controls.Add(btnUpdateTb);
            pnlLeft.Controls.Add(btnDeleteTb);
            pnlLeft.Controls.Add(btnAddTb);
            pnlLeft.Controls.Add(lbStatus);
            pnlLeft.Controls.Add(cbbStatus);
            pnlLeft.Controls.Add(lbTbName);
            pnlLeft.Controls.Add(tbTbName);
            pnlLeft.Controls.Add(lbTbID);
            pnlLeft.Controls.Add(tbTbID);
            pnlLeft.Dock = DockStyle.Right;
            pnlLeft.Location = new Point(571, 80);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(229, 370);
            pnlLeft.TabIndex = 4;
            // 
            // btnUpdateTb
            // 
            btnUpdateTb.BackColor = Color.FromArgb(101, 67, 33);
            btnUpdateTb.Cursor = Cursors.Hand;
            btnUpdateTb.FlatStyle = FlatStyle.Flat;
            btnUpdateTb.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdateTb.ForeColor = Color.White;
            btnUpdateTb.Location = new Point(117, 244);
            btnUpdateTb.Name = "btnUpdateTb";
            btnUpdateTb.Size = new Size(100, 32);
            btnUpdateTb.TabIndex = 16;
            btnUpdateTb.Text = "Update";
            btnUpdateTb.UseVisualStyleBackColor = false;
            // 
            // btnDeleteTb
            // 
            btnDeleteTb.BackColor = Color.FromArgb(180, 40, 40);
            btnDeleteTb.Cursor = Cursors.Hand;
            btnDeleteTb.FlatStyle = FlatStyle.Flat;
            btnDeleteTb.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeleteTb.ForeColor = Color.White;
            btnDeleteTb.Location = new Point(66, 280);
            btnDeleteTb.Name = "btnDeleteTb";
            btnDeleteTb.Size = new Size(100, 32);
            btnDeleteTb.TabIndex = 15;
            btnDeleteTb.Text = "Delete";
            btnDeleteTb.UseVisualStyleBackColor = false;
            // 
            // btnAddTb
            // 
            btnAddTb.BackColor = Color.FromArgb(101, 67, 33);
            btnAddTb.Cursor = Cursors.Hand;
            btnAddTb.FlatStyle = FlatStyle.Flat;
            btnAddTb.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAddTb.ForeColor = Color.White;
            btnAddTb.Location = new Point(14, 244);
            btnAddTb.Name = "btnAddTb";
            btnAddTb.Size = new Size(100, 32);
            btnAddTb.TabIndex = 14;
            btnAddTb.Text = "Add";
            btnAddTb.UseVisualStyleBackColor = false;
            // 
            // lbStatus
            // 
            lbStatus.AutoSize = true;
            lbStatus.Font = new Font("Segoe UI", 10F);
            lbStatus.Location = new Point(17, 160);
            lbStatus.Name = "lbStatus";
            lbStatus.Size = new Size(56, 23);
            lbStatus.TabIndex = 13;
            lbStatus.Text = "Status";
            // 
            // cbbStatus
            // 
            cbbStatus.Font = new Font("Segoe UI", 10F);
            cbbStatus.FormattingEnabled = true;
            cbbStatus.Location = new Point(13, 181);
            cbbStatus.Name = "cbbStatus";
            cbbStatus.Size = new Size(204, 31);
            cbbStatus.TabIndex = 11;
            // 
            // lbTbName
            // 
            lbTbName.AutoSize = true;
            lbTbName.Font = new Font("Segoe UI", 10F);
            lbTbName.Location = new Point(18, 88);
            lbTbName.Name = "lbTbName";
            lbTbName.Size = new Size(100, 23);
            lbTbName.TabIndex = 10;
            lbTbName.Text = "Table Name";
            // 
            // tbTbName
            // 
            tbTbName.Font = new Font("Segoe UI", 10F);
            tbTbName.Location = new Point(14, 109);
            tbTbName.Name = "tbTbName";
            tbTbName.Size = new Size(203, 30);
            tbTbName.TabIndex = 9;
            // 
            // lbTbID
            // 
            lbTbID.AutoSize = true;
            lbTbID.Font = new Font("Segoe UI", 10F);
            lbTbID.Location = new Point(18, 19);
            lbTbID.Name = "lbTbID";
            lbTbID.Size = new Size(71, 23);
            lbTbID.TabIndex = 8;
            lbTbID.Text = "Table ID";
            // 
            // tbTbID
            // 
            tbTbID.Font = new Font("Segoe UI", 10F);
            tbTbID.Location = new Point(14, 40);
            tbTbID.Name = "tbTbID";
            tbTbID.Size = new Size(203, 30);
            tbTbID.TabIndex = 7;
            // 
            // pnlBottom
            // 
            pnlBottom.Controls.Add(lbTbCount);
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Location = new Point(0, 410);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Size = new Size(571, 40);
            pnlBottom.TabIndex = 5;
            // 
            // lbTbCount
            // 
            lbTbCount.AutoSize = true;
            lbTbCount.Location = new Point(26, 11);
            lbTbCount.Name = "lbTbCount";
            lbTbCount.Size = new Size(111, 20);
            lbTbCount.TabIndex = 0;
            lbTbCount.Text = "Total: 0 table(s)";
            // 
            // lbTitle
            // 
            lbTitle.AutoSize = true;
            lbTitle.Dock = DockStyle.Top;
            lbTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTitle.ForeColor = Color.FromArgb(101, 67, 33);
            lbTitle.Location = new Point(0, 0);
            lbTitle.Name = "lbTitle";
            lbTitle.Padding = new Padding(10, 0, 0, 0);
            lbTitle.Size = new Size(273, 31);
            lbTitle.TabIndex = 3;
            lbTitle.Text = " \U0001fa91 Table Management";
            lbTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlTop
            // 
            pnlTop.Controls.Add(textBox1);
            pnlTop.Controls.Add(lbSearch);
            pnlTop.Controls.Add(lbTitle);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(800, 80);
            pnlTop.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 10F);
            textBox1.Location = new Point(89, 38);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(184, 30);
            textBox1.TabIndex = 5;
            // 
            // lbSearch
            // 
            lbSearch.AutoSize = true;
            lbSearch.Font = new Font("Segoe UI", 10F);
            lbSearch.Location = new Point(26, 41);
            lbSearch.Name = "lbSearch";
            lbSearch.Size = new Size(65, 23);
            lbSearch.TabIndex = 4;
            lbSearch.Text = "Search:";
            // 
            // TableForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 240, 235);
            ClientSize = new Size(800, 450);
            Controls.Add(pnlBottom);
            Controls.Add(pnlLeft);
            Controls.Add(pnlMain);
            Controls.Add(pnlTop);
            Name = "TableForm";
            Text = "Table Management";
            pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTable).EndInit();
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            pnlBottom.ResumeLayout(false);
            pnlBottom.PerformLayout();
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlMain;
        private Panel pnlLeft;
        private Panel pnlBottom;
        private Label lbTitle;
        private Panel pnlTop;
        private Label lbSearch;
        private TextBox textBox1;
        private TextBox tbTbID;
        private Label lbTbID;
        private Label lbStatus;
        private ComboBox cbbStatus;
        private Label lbTbName;
        private TextBox tbTbName;
        private Button btnAddTb;
        private Button btnUpdateTb;
        private Button btnDeleteTb;
        private Label lbTbCount;
        private DataGridView dgvTable;
        private DataGridViewTextBoxColumn TableID;
        private DataGridViewTextBoxColumn TableName;
        private DataGridViewTextBoxColumn Status;
    }
}