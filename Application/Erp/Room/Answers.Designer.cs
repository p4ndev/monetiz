namespace ERP.Room
{
    partial class Answers
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
            cbGame = new ComboBox();
            label2 = new Label();
            btnSearch = new Button();
            dgvAction = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvAction).BeginInit();
            SuspendLayout();
            // 
            // cbGame
            // 
            cbGame.FormattingEnabled = true;
            cbGame.Location = new Point(56, 12);
            cbGame.Name = "cbGame";
            cbGame.Size = new Size(707, 23);
            cbGame.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 15);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 3;
            label2.Text = "Game:";
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.Purple;
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(769, 3);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(60, 37);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // dgvAction
            // 
            dgvAction.AllowUserToAddRows = false;
            dgvAction.AllowUserToDeleteRows = false;
            dgvAction.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAction.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAction.Location = new Point(-1, 46);
            dgvAction.Name = "dgvAction";
            dgvAction.ReadOnly = true;
            dgvAction.Size = new Size(838, 616);
            dgvAction.TabIndex = 4;
            dgvAction.CellDoubleClick += dgvAction_CellDoubleClick;
            // 
            // Answers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(834, 661);
            Controls.Add(dgvAction);
            Controls.Add(btnSearch);
            Controls.Add(label2);
            Controls.Add(cbGame);
            MaximizeBox = false;
            MaximumSize = new Size(850, 700);
            MinimumSize = new Size(850, 700);
            Name = "Answers";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Action / Answers";
            Load += Action_Load;
            ((System.ComponentModel.ISupportInitialize)dgvAction).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbGame;
        private Label label2;
        private Button btnSearch;
        private DataGridView dgvAction;
    }
}