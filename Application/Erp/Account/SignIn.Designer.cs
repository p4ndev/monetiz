namespace ERP.Account
{
    partial class SignIn
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
            txtEmail = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtPassword = new TextBox();
            btnLogIn = new Button();
            btnExit = new Button();
            SuspendLayout();
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.WhiteSmoke;
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Location = new Point(25, 64);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(258, 23);
            txtEmail.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 40);
            label1.Name = "label1";
            label1.Size = new Size(36, 15);
            label1.TabIndex = 1;
            label1.Text = "Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 103);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 3;
            label2.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.WhiteSmoke;
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Location = new Point(25, 126);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(258, 23);
            txtPassword.TabIndex = 2;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnLogIn
            // 
            btnLogIn.BackColor = Color.Purple;
            btnLogIn.Cursor = Cursors.Hand;
            btnLogIn.ForeColor = Color.White;
            btnLogIn.Location = new Point(198, 165);
            btnLogIn.Name = "btnLogIn";
            btnLogIn.Size = new Size(85, 37);
            btnLogIn.TabIndex = 4;
            btnLogIn.Text = "Log in";
            btnLogIn.UseVisualStyleBackColor = false;
            btnLogIn.Click += btnLogIn_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.LightGray;
            btnExit.Cursor = Cursors.Hand;
            btnExit.ForeColor = Color.DimGray;
            btnExit.Location = new Point(107, 165);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(85, 37);
            btnExit.TabIndex = 5;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // SignIn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(324, 241);
            ControlBox = false;
            Controls.Add(btnExit);
            Controls.Add(btnLogIn);
            Controls.Add(label2);
            Controls.Add(txtPassword);
            Controls.Add(label1);
            Controls.Add(txtEmail);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MaximumSize = new Size(340, 280);
            MinimizeBox = false;
            MinimumSize = new Size(340, 280);
            Name = "SignIn";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sign In";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtEmail;
        private Label label1;
        private Label label2;
        private TextBox txtPassword;
        private Button btnLogIn;
        private Button btnExit;
    }
}