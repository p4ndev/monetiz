namespace ERP.Account
{
    partial class Search
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
            txtId = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtEmail = new TextBox();
            btnSearch = new Button();
            SuspendLayout();
            // 
            // txtId
            // 
            txtId.Location = new Point(39, 20);
            txtId.Name = "txtId";
            txtId.Size = new Size(90, 23);
            txtId.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 23);
            label1.Name = "label1";
            label1.Size = new Size(21, 15);
            label1.TabIndex = 2;
            label1.Text = "ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(146, 24);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 4;
            label2.Text = "EMAIL:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(196, 20);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(285, 23);
            txtEmail.TabIndex = 3;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.Purple;
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(487, 13);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(85, 37);
            btnSearch.TabIndex = 5;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // Search
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 61);
            Controls.Add(btnSearch);
            Controls.Add(label2);
            Controls.Add(txtEmail);
            Controls.Add(label1);
            Controls.Add(txtId);
            MaximizeBox = false;
            MaximumSize = new Size(600, 100);
            MinimumSize = new Size(600, 100);
            Name = "Search";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "User List";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtId;
        private Label label1;
        private Label label2;
        private TextBox txtEmail;
        private Button btnSearch;
    }
}