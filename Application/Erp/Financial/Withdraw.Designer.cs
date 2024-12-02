namespace ERP.Financial
{
    partial class Withdraw
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
            dgvList = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvList).BeginInit();
            SuspendLayout();
            // 
            // dgvList
            // 
            dgvList.AllowUserToAddRows = false;
            dgvList.AllowUserToDeleteRows = false;
            dgvList.AllowUserToResizeRows = false;
            dgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvList.Dock = DockStyle.Fill;
            dgvList.Location = new Point(0, 0);
            dgvList.Name = "dgvList";
            dgvList.ReadOnly = true;
            dgvList.Size = new Size(684, 461);
            dgvList.TabIndex = 0;
            dgvList.CellDoubleClick += dgvList_CellDoubleClick;
            // 
            // Withdraw
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 461);
            Controls.Add(dgvList);
            MaximizeBox = false;
            MaximumSize = new Size(700, 500);
            MdiChildrenMinimizedAnchorBottom = false;
            MinimumSize = new Size(700, 500);
            Name = "Withdraw";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Withdraw";
            Load += Withdraw_Load;
            ((System.ComponentModel.ISupportInitialize)dgvList).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvList;
    }
}