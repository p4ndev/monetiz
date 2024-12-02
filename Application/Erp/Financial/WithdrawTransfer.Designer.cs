namespace ERP.Financial
{
    partial class WithdrawTransfer
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
            label1 = new Label();
            txtTransactionId = new TextBox();
            txtReceiptUrl = new TextBox();
            label2 = new Label();
            txtMessage = new TextBox();
            label3 = new Label();
            btnTransfer = new Button();
            btnDecline = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 14);
            label1.Name = "label1";
            label1.Size = new Size(91, 15);
            label1.TabIndex = 0;
            label1.Text = "Transaction Id *:";
            // 
            // txtTransactionId
            // 
            txtTransactionId.Location = new Point(12, 38);
            txtTransactionId.Name = "txtTransactionId";
            txtTransactionId.Size = new Size(340, 23);
            txtTransactionId.TabIndex = 1;
            // 
            // txtReceiptUrl
            // 
            txtReceiptUrl.Location = new Point(12, 98);
            txtReceiptUrl.Name = "txtReceiptUrl";
            txtReceiptUrl.Size = new Size(340, 23);
            txtReceiptUrl.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 74);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 2;
            label2.Text = "Receipt Url:";
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(12, 163);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(340, 88);
            txtMessage.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 139);
            label3.Name = "label3";
            label3.Size = new Size(119, 15);
            label3.TabIndex = 4;
            label3.Text = "Reason / Description:";
            // 
            // btnTransfer
            // 
            btnTransfer.BackColor = Color.Purple;
            btnTransfer.Cursor = Cursors.Hand;
            btnTransfer.ForeColor = Color.White;
            btnTransfer.Location = new Point(267, 262);
            btnTransfer.Name = "btnTransfer";
            btnTransfer.Size = new Size(85, 37);
            btnTransfer.TabIndex = 6;
            btnTransfer.Text = "Approved";
            btnTransfer.UseVisualStyleBackColor = false;
            btnTransfer.Click += btnTransfer_Click;
            // 
            // btnDecline
            // 
            btnDecline.BackColor = Color.Red;
            btnDecline.Cursor = Cursors.Hand;
            btnDecline.ForeColor = Color.White;
            btnDecline.Location = new Point(176, 262);
            btnDecline.Name = "btnDecline";
            btnDecline.Size = new Size(85, 37);
            btnDecline.TabIndex = 7;
            btnDecline.Text = "Decline";
            btnDecline.UseVisualStyleBackColor = false;
            btnDecline.Click += btnDecline_Click;
            // 
            // WithdrawTransfer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(364, 311);
            Controls.Add(btnDecline);
            Controls.Add(btnTransfer);
            Controls.Add(txtMessage);
            Controls.Add(label3);
            Controls.Add(txtReceiptUrl);
            Controls.Add(label2);
            Controls.Add(txtTransactionId);
            Controls.Add(label1);
            MaximizeBox = false;
            MaximumSize = new Size(380, 350);
            MinimizeBox = false;
            MinimumSize = new Size(380, 350);
            Name = "WithdrawTransfer";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Bank Transfer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtTransactionId;
        private TextBox txtReceiptUrl;
        private Label label2;
        private TextBox txtMessage;
        private Label label3;
        private Button btnTransfer;
        private Button btnDecline;
    }
}