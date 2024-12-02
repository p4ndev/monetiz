namespace ERP.Room
{
    partial class ActionNewManual
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
            cbGames = new ComboBox();
            btnSubmit = new Button();
            txtAction = new TextBox();
            label2 = new Label();
            label3 = new Label();
            txtImage = new TextBox();
            dtpStarts = new DateTimePicker();
            label4 = new Label();
            label5 = new Label();
            dtpEnds = new DateTimePicker();
            label6 = new Label();
            mtbStarts = new MaskedTextBox();
            mtbEnds = new MaskedTextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 18);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 0;
            label1.Text = "Game:";
            // 
            // cbGames
            // 
            cbGames.FormattingEnabled = true;
            cbGames.Location = new Point(58, 15);
            cbGames.Name = "cbGames";
            cbGames.Size = new Size(392, 23);
            cbGames.TabIndex = 0;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = Color.Purple;
            btnSubmit.Cursor = Cursors.Hand;
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Location = new Point(355, 111);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(95, 53);
            btnSubmit.TabIndex = 7;
            btnSubmit.Text = "Save";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // txtAction
            // 
            txtAction.Location = new Point(58, 44);
            txtAction.Name = "txtAction";
            txtAction.Size = new Size(392, 23);
            txtAction.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 47);
            label2.Name = "label2";
            label2.Size = new Size(45, 15);
            label2.TabIndex = 5;
            label2.Text = "Action:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 80);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 7;
            label3.Text = "Image:";
            // 
            // txtImage
            // 
            txtImage.Location = new Point(58, 77);
            txtImage.Name = "txtImage";
            txtImage.Size = new Size(392, 23);
            txtImage.TabIndex = 2;
            // 
            // dtpStarts
            // 
            dtpStarts.Format = DateTimePickerFormat.Short;
            dtpStarts.Location = new Point(59, 108);
            dtpStarts.Name = "dtpStarts";
            dtpStarts.Size = new Size(113, 23);
            dtpStarts.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 114);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 10;
            label4.Text = "Starts:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 146);
            label5.Name = "label5";
            label5.Size = new Size(35, 15);
            label5.TabIndex = 13;
            label5.Text = "Ends:";
            // 
            // dtpEnds
            // 
            dtpEnds.Format = DateTimePickerFormat.Short;
            dtpEnds.Location = new Point(59, 141);
            dtpEnds.Name = "dtpEnds";
            dtpEnds.Size = new Size(113, 23);
            dtpEnds.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            label6.ForeColor = SystemColors.ControlDark;
            label6.Location = new Point(250, 130);
            label6.Name = "label6";
            label6.Size = new Size(27, 15);
            label6.TabIndex = 16;
            label6.Text = "BRT";
            // 
            // mtbStarts
            // 
            mtbStarts.Location = new Point(178, 108);
            mtbStarts.Mask = "00:00:00";
            mtbStarts.Name = "mtbStarts";
            mtbStarts.Size = new Size(61, 23);
            mtbStarts.TabIndex = 4;
            // 
            // mtbEnds
            // 
            mtbEnds.Location = new Point(178, 141);
            mtbEnds.Mask = "00:00:00";
            mtbEnds.Name = "mtbEnds";
            mtbEnds.Size = new Size(61, 23);
            mtbEnds.TabIndex = 6;
            // 
            // ActionNewManual
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(464, 181);
            Controls.Add(mtbEnds);
            Controls.Add(mtbStarts);
            Controls.Add(label6);
            Controls.Add(dtpEnds);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(dtpStarts);
            Controls.Add(label3);
            Controls.Add(txtImage);
            Controls.Add(label2);
            Controls.Add(txtAction);
            Controls.Add(btnSubmit);
            Controls.Add(cbGames);
            Controls.Add(label1);
            MaximizeBox = false;
            MaximumSize = new Size(480, 220);
            MinimumSize = new Size(480, 220);
            Name = "ActionNewManual";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Action > New (Manual)";
            Load += ActionNewManual_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cbGames;
        private Button btnSubmit;
        private TextBox txtAction;
        private Label label2;
        private Label label3;
        private TextBox txtImage;
        private DateTimePicker dtpStarts;
        private Label label4;
        private Label label5;
        private DateTimePicker dtpEnds;
        private Label label6;
        private MaskedTextBox mtbStarts;
        private MaskedTextBox mtbEnds;
    }
}