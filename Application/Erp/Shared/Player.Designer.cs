namespace ERP.Shared
{
    partial class Player
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
            tvPix = new TreeView();
            SuspendLayout();
            // 
            // tvPix
            // 
            tvPix.Dock = DockStyle.Fill;
            tvPix.FullRowSelect = true;
            tvPix.Location = new Point(0, 0);
            tvPix.Name = "tvPix";
            tvPix.Size = new Size(484, 361);
            tvPix.TabIndex = 2;
            tvPix.AfterExpand += tvPix_AfterExpand;
            tvPix.DoubleClick += tvPix_DoubleClick;
            // 
            // Player
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 361);
            Controls.Add(tvPix);
            MaximizeBox = false;
            MaximumSize = new Size(500, 400);
            MinimumSize = new Size(500, 400);
            Name = "Player";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Player";
            Load += Pix_Load;
            ResumeLayout(false);
        }

        #endregion

        private TreeView tvPix;
    }
}