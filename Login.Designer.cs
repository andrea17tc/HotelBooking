namespace HotelBooking
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonLogin = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBoxUsername = new TextBox();
            textBoxPassword = new TextBox();
            label4 = new Label();
            buttonCreateAccount = new Button();
            SuspendLayout();
            // 
            // buttonLogin
            // 
            buttonLogin.Location = new Point(208, 285);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(94, 29);
            buttonLogin.TabIndex = 0;
            buttonLogin.Text = "Login";
            buttonLogin.UseVisualStyleBackColor = true;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(218, 38);
            label1.Name = "label1";
            label1.Size = new Size(51, 20);
            label1.TabIndex = 1;
            label1.Text = "LOGIN";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(110, 115);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 2;
            label2.Text = "Username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(110, 177);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 3;
            label3.Text = "Password";
            // 
            // textBoxUsername
            // 
            textBoxUsername.Location = new Point(198, 112);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(125, 27);
            textBoxUsername.TabIndex = 4;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(198, 174);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(125, 27);
            textBoxPassword.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(345, 289);
            label4.Name = "label4";
            label4.Size = new Size(23, 20);
            label4.TabIndex = 6;
            label4.Text = "or";
            // 
            // buttonCreateAccount
            // 
            buttonCreateAccount.Location = new Point(390, 274);
            buttonCreateAccount.Name = "buttonCreateAccount";
            buttonCreateAccount.Size = new Size(94, 51);
            buttonCreateAccount.TabIndex = 7;
            buttonCreateAccount.Text = "Create account";
            buttonCreateAccount.UseVisualStyleBackColor = true;
            buttonCreateAccount.Click += buttonCreateAccount_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(508, 370);
            Controls.Add(buttonCreateAccount);
            Controls.Add(label4);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxUsername);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(buttonLogin);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonLogin;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBoxUsername;
        private TextBox textBoxPassword;
        private Label label4;
        private Button buttonCreateAccount;
    }
}
