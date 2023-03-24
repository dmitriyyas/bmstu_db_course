namespace UI.WinFormViews
{
    partial class WinFormMainView
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
            this.ConfirmLogInButton = new System.Windows.Forms.Button();
            this.LogInGroupBox = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LogInPasswordTextBox = new System.Windows.Forms.TextBox();
            this.LogInLogintextBox = new System.Windows.Forms.TextBox();
            this.RegisterGroupBox = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RegLoginTextBox = new System.Windows.Forms.TextBox();
            this.RegPasswordTextBox = new System.Windows.Forms.TextBox();
            this.RegConfirmPasswordTextBox = new System.Windows.Forms.TextBox();
            this.ConfirmRegisterButton = new System.Windows.Forms.Button();
            this.StartGroupBox = new System.Windows.Forms.GroupBox();
            this.StartRegisterButton = new System.Windows.Forms.Button();
            this.StartLogInButton = new System.Windows.Forms.Button();
            this.LogInGroupBox.SuspendLayout();
            this.RegisterGroupBox.SuspendLayout();
            this.StartGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConfirmLogInButton
            // 
            this.ConfirmLogInButton.Location = new System.Drawing.Point(130, 144);
            this.ConfirmLogInButton.Name = "ConfirmLogInButton";
            this.ConfirmLogInButton.Size = new System.Drawing.Size(94, 29);
            this.ConfirmLogInButton.TabIndex = 0;
            this.ConfirmLogInButton.Text = "Войти";
            this.ConfirmLogInButton.UseVisualStyleBackColor = true;
            // 
            // LogInGroupBox
            // 
            this.LogInGroupBox.Controls.Add(this.label7);
            this.LogInGroupBox.Controls.Add(this.label6);
            this.LogInGroupBox.Controls.Add(this.label5);
            this.LogInGroupBox.Controls.Add(this.LogInPasswordTextBox);
            this.LogInGroupBox.Controls.Add(this.LogInLogintextBox);
            this.LogInGroupBox.Controls.Add(this.ConfirmLogInButton);
            this.LogInGroupBox.Location = new System.Drawing.Point(27, 47);
            this.LogInGroupBox.Name = "LogInGroupBox";
            this.LogInGroupBox.Size = new System.Drawing.Size(378, 245);
            this.LogInGroupBox.TabIndex = 1;
            this.LogInGroupBox.TabStop = false;
            this.LogInGroupBox.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(145, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "Вход";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(59, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Пароль:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(59, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Логин:";
            // 
            // LogInPasswordTextBox
            // 
            this.LogInPasswordTextBox.Location = new System.Drawing.Point(174, 87);
            this.LogInPasswordTextBox.Name = "LogInPasswordTextBox";
            this.LogInPasswordTextBox.Size = new System.Drawing.Size(179, 27);
            this.LogInPasswordTextBox.TabIndex = 2;
            // 
            // LogInLogintextBox
            // 
            this.LogInLogintextBox.Location = new System.Drawing.Point(174, 44);
            this.LogInLogintextBox.Name = "LogInLogintextBox";
            this.LogInLogintextBox.Size = new System.Drawing.Size(179, 27);
            this.LogInLogintextBox.TabIndex = 1;
            // 
            // RegisterGroupBox
            // 
            this.RegisterGroupBox.Controls.Add(this.label4);
            this.RegisterGroupBox.Controls.Add(this.label3);
            this.RegisterGroupBox.Controls.Add(this.label2);
            this.RegisterGroupBox.Controls.Add(this.label1);
            this.RegisterGroupBox.Controls.Add(this.RegLoginTextBox);
            this.RegisterGroupBox.Controls.Add(this.RegPasswordTextBox);
            this.RegisterGroupBox.Controls.Add(this.RegConfirmPasswordTextBox);
            this.RegisterGroupBox.Controls.Add(this.ConfirmRegisterButton);
            this.RegisterGroupBox.Location = new System.Drawing.Point(27, 47);
            this.RegisterGroupBox.Name = "RegisterGroupBox";
            this.RegisterGroupBox.Size = new System.Drawing.Size(384, 245);
            this.RegisterGroupBox.TabIndex = 2;
            this.RegisterGroupBox.TabStop = false;
            this.RegisterGroupBox.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(145, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Регистрация";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Подтвердите пароль:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Пароль:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Логин:";
            // 
            // RegLoginTextBox
            // 
            this.RegLoginTextBox.Location = new System.Drawing.Point(174, 48);
            this.RegLoginTextBox.Name = "RegLoginTextBox";
            this.RegLoginTextBox.Size = new System.Drawing.Size(179, 27);
            this.RegLoginTextBox.TabIndex = 3;
            // 
            // RegPasswordTextBox
            // 
            this.RegPasswordTextBox.Location = new System.Drawing.Point(174, 91);
            this.RegPasswordTextBox.Name = "RegPasswordTextBox";
            this.RegPasswordTextBox.Size = new System.Drawing.Size(179, 27);
            this.RegPasswordTextBox.TabIndex = 2;
            // 
            // RegConfirmPasswordTextBox
            // 
            this.RegConfirmPasswordTextBox.Location = new System.Drawing.Point(174, 133);
            this.RegConfirmPasswordTextBox.Name = "RegConfirmPasswordTextBox";
            this.RegConfirmPasswordTextBox.Size = new System.Drawing.Size(179, 27);
            this.RegConfirmPasswordTextBox.TabIndex = 1;
            // 
            // ConfirmRegisterButton
            // 
            this.ConfirmRegisterButton.Location = new System.Drawing.Point(81, 179);
            this.ConfirmRegisterButton.Name = "ConfirmRegisterButton";
            this.ConfirmRegisterButton.Size = new System.Drawing.Size(179, 29);
            this.ConfirmRegisterButton.TabIndex = 0;
            this.ConfirmRegisterButton.Text = "Зарегистрироваться";
            this.ConfirmRegisterButton.UseVisualStyleBackColor = true;
            // 
            // StartGroupBox
            // 
            this.StartGroupBox.Controls.Add(this.StartRegisterButton);
            this.StartGroupBox.Controls.Add(this.StartLogInButton);
            this.StartGroupBox.Location = new System.Drawing.Point(15, 49);
            this.StartGroupBox.Name = "StartGroupBox";
            this.StartGroupBox.Size = new System.Drawing.Size(407, 251);
            this.StartGroupBox.TabIndex = 3;
            this.StartGroupBox.TabStop = false;
            // 
            // StartRegisterButton
            // 
            this.StartRegisterButton.Location = new System.Drawing.Point(122, 89);
            this.StartRegisterButton.Name = "StartRegisterButton";
            this.StartRegisterButton.Size = new System.Drawing.Size(162, 29);
            this.StartRegisterButton.TabIndex = 1;
            this.StartRegisterButton.Text = "Зарегистрироваться";
            this.StartRegisterButton.UseVisualStyleBackColor = true;
            this.StartRegisterButton.Click += new System.EventHandler(this.StartRegisterButton_Click);
            // 
            // StartLogInButton
            // 
            this.StartLogInButton.Location = new System.Drawing.Point(122, 42);
            this.StartLogInButton.Name = "StartLogInButton";
            this.StartLogInButton.Size = new System.Drawing.Size(162, 29);
            this.StartLogInButton.TabIndex = 0;
            this.StartLogInButton.Text = "Войти";
            this.StartLogInButton.UseVisualStyleBackColor = true;
            this.StartLogInButton.Click += new System.EventHandler(this.StartLogInButton_Click);
            // 
            // WinFormMainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 450);
            this.Controls.Add(this.StartGroupBox);
            this.Controls.Add(this.LogInGroupBox);
            this.Controls.Add(this.RegisterGroupBox);
            this.Name = "WinFormMainView";
            this.Text = "WinFormMainView";
            this.LogInGroupBox.ResumeLayout(false);
            this.LogInGroupBox.PerformLayout();
            this.RegisterGroupBox.ResumeLayout(false);
            this.RegisterGroupBox.PerformLayout();
            this.StartGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button ConfirmLogInButton;
        private GroupBox LogInGroupBox;
        private GroupBox RegisterGroupBox;
        private Button ConfirmRegisterButton;
        private Label label1;
        private TextBox RegLoginTextBox;
        private TextBox RegPasswordTextBox;
        private TextBox RegConfirmPasswordTextBox;
        private Label label3;
        private Label label2;
        private Label label4;
        private TextBox LogInPasswordTextBox;
        private TextBox LogInLogintextBox;
        private Label label7;
        private Label label6;
        private Label label5;
        private GroupBox StartGroupBox;
        private Button StartRegisterButton;
        private Button StartLogInButton;
    }
}