namespace ERP
{
    partial class Stage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Stage));
            pictureBox1 = new PictureBox();
            msItems = new MenuStrip();
            msAccount = new ToolStripMenuItem();
            msUserSearch = new ToolStripMenuItem();
            msExit = new ToolStripMenuItem();
            msLobby = new ToolStripMenuItem();
            msRoom = new ToolStripMenuItem();
            msAction = new ToolStripMenuItem();
            msAnswers = new ToolStripMenuItem();
            msFinancial = new ToolStripMenuItem();
            msWithdraw = new ToolStripMenuItem();
            lblUser = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            msItems.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(60, 51);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(302, 161);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // msItems
            // 
            msItems.BackColor = Color.LavenderBlush;
            msItems.GripMargin = new Padding(5);
            msItems.Items.AddRange(new ToolStripItem[] { msAccount, msLobby, msRoom, msFinancial });
            msItems.Location = new Point(0, 0);
            msItems.Name = "msItems";
            msItems.Size = new Size(424, 24);
            msItems.TabIndex = 1;
            msItems.Text = "menuStrip1";
            // 
            // msAccount
            // 
            msAccount.DropDownItems.AddRange(new ToolStripItem[] { msUserSearch, msExit });
            msAccount.Name = "msAccount";
            msAccount.Size = new Size(64, 20);
            msAccount.Text = "Account";
            // 
            // msUserSearch
            // 
            msUserSearch.Name = "msUserSearch";
            msUserSearch.Size = new Size(109, 22);
            msUserSearch.Text = "Search";
            msUserSearch.Click += searchToolStripMenuItem_Click;
            // 
            // msExit
            // 
            msExit.Name = "msExit";
            msExit.Size = new Size(109, 22);
            msExit.Text = "Exit";
            msExit.Click += msExit_Click;
            // 
            // msLobby
            // 
            msLobby.Name = "msLobby";
            msLobby.Size = new Size(52, 20);
            msLobby.Text = "Lobby";
            // 
            // msRoom
            // 
            msRoom.DropDownItems.AddRange(new ToolStripItem[] { msAction, msAnswers });
            msRoom.Name = "msRoom";
            msRoom.Size = new Size(51, 20);
            msRoom.Text = "Room";
            // 
            // msAction
            // 
            msAction.Name = "msAction";
            msAction.Size = new Size(180, 22);
            msAction.Text = "New Action";
            msAction.Click += msAction_Click;
            // 
            // msAnswers
            // 
            msAnswers.Name = "msAnswers";
            msAnswers.Size = new Size(180, 22);
            msAnswers.Text = "Answers";
            msAnswers.Click += msAnswers_Click;
            // 
            // msFinancial
            // 
            msFinancial.DropDownItems.AddRange(new ToolStripItem[] { msWithdraw });
            msFinancial.Name = "msFinancial";
            msFinancial.Size = new Size(66, 20);
            msFinancial.Text = "Financial";
            // 
            // msWithdraw
            // 
            msWithdraw.Name = "msWithdraw";
            msWithdraw.Size = new Size(125, 22);
            msWithdraw.Text = "Withdraw";
            msWithdraw.Click += msWithdraw_Click;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.BackColor = Color.Transparent;
            lblUser.ForeColor = Color.DarkOrchid;
            lblUser.Location = new Point(12, 237);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(0, 15);
            lblUser.TabIndex = 2;
            lblUser.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Stage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(424, 261);
            Controls.Add(lblUser);
            Controls.Add(pictureBox1);
            Controls.Add(msItems);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = msItems;
            MaximizeBox = false;
            MaximumSize = new Size(440, 300);
            MinimumSize = new Size(440, 300);
            Name = "Stage";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Monetização";
            Load += Stage_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            msItems.ResumeLayout(false);
            msItems.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private MenuStrip msItems;
        private Label lblUser;
        private ToolStripMenuItem msAccount;
        private ToolStripMenuItem msExit;
        private ToolStripMenuItem msFinancial;
        private ToolStripMenuItem msWithdraw;
        private ToolStripMenuItem msLobby;
        private ToolStripMenuItem msRoom;
        private ToolStripMenuItem msUserSearch;
        private ToolStripMenuItem msAction;
        private ToolStripMenuItem msAnswers;
    }
}