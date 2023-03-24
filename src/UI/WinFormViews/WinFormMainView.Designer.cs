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
            this.LogInLoginTextBox = new System.Windows.Forms.TextBox();
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
            this.LogOutGroupBox = new System.Windows.Forms.GroupBox();
            this.LogOutButton = new System.Windows.Forms.Button();
            this.CurrentUserLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ShowUsersButton = new System.Windows.Forms.Button();
            this.ShowCountriesButton = new System.Windows.Forms.Button();
            this.ShowTeamsButton = new System.Windows.Forms.Button();
            this.ShowTournamentsButton = new System.Windows.Forms.Button();
            this.RegisterBackButton = new System.Windows.Forms.Button();
            this.LogInBackButton = new System.Windows.Forms.Button();
            this.LogInGroupBox.SuspendLayout();
            this.RegisterGroupBox.SuspendLayout();
            this.StartGroupBox.SuspendLayout();
            this.LogOutGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConfirmLogInButton
            // 
            this.ConfirmLogInButton.Location = new System.Drawing.Point(147, 144);
            this.ConfirmLogInButton.Name = "ConfirmLogInButton";
            this.ConfirmLogInButton.Size = new System.Drawing.Size(94, 29);
            this.ConfirmLogInButton.TabIndex = 0;
            this.ConfirmLogInButton.Text = "Войти";
            this.ConfirmLogInButton.UseVisualStyleBackColor = true;
            this.ConfirmLogInButton.Click += new System.EventHandler(this.ConfirmLogInButton_Click);
            // 
            // LogInGroupBox
            // 
            this.LogInGroupBox.Controls.Add(this.LogInBackButton);
            this.LogInGroupBox.Controls.Add(this.label7);
            this.LogInGroupBox.Controls.Add(this.label6);
            this.LogInGroupBox.Controls.Add(this.label5);
            this.LogInGroupBox.Controls.Add(this.LogInPasswordTextBox);
            this.LogInGroupBox.Controls.Add(this.LogInLoginTextBox);
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
            this.LogInPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // LogInLoginTextBox
            // 
            this.LogInLoginTextBox.Location = new System.Drawing.Point(174, 44);
            this.LogInLoginTextBox.Name = "LogInLoginTextBox";
            this.LogInLoginTextBox.Size = new System.Drawing.Size(179, 27);
            this.LogInLoginTextBox.TabIndex = 1;
            // 
            // RegisterGroupBox
            // 
            this.RegisterGroupBox.Controls.Add(this.RegisterBackButton);
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
            this.RegPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // RegConfirmPasswordTextBox
            // 
            this.RegConfirmPasswordTextBox.Location = new System.Drawing.Point(174, 133);
            this.RegConfirmPasswordTextBox.Name = "RegConfirmPasswordTextBox";
            this.RegConfirmPasswordTextBox.Size = new System.Drawing.Size(179, 27);
            this.RegConfirmPasswordTextBox.TabIndex = 1;
            this.RegConfirmPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // ConfirmRegisterButton
            // 
            this.ConfirmRegisterButton.Location = new System.Drawing.Point(105, 179);
            this.ConfirmRegisterButton.Name = "ConfirmRegisterButton";
            this.ConfirmRegisterButton.Size = new System.Drawing.Size(179, 29);
            this.ConfirmRegisterButton.TabIndex = 0;
            this.ConfirmRegisterButton.Text = "Зарегистрироваться";
            this.ConfirmRegisterButton.UseVisualStyleBackColor = true;
            this.ConfirmRegisterButton.Click += new System.EventHandler(this.ConfirmRegisterButton_Click);
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
            // LogOutGroupBox
            // 
            this.LogOutGroupBox.Controls.Add(this.LogOutButton);
            this.LogOutGroupBox.Controls.Add(this.CurrentUserLabel);
            this.LogOutGroupBox.Controls.Add(this.label8);
            this.LogOutGroupBox.Location = new System.Drawing.Point(9, 54);
            this.LogOutGroupBox.Name = "LogOutGroupBox";
            this.LogOutGroupBox.Size = new System.Drawing.Size(407, 240);
            this.LogOutGroupBox.TabIndex = 4;
            this.LogOutGroupBox.TabStop = false;
            this.LogOutGroupBox.Visible = false;
            // 
            // LogOutButton
            // 
            this.LogOutButton.Location = new System.Drawing.Point(163, 84);
            this.LogOutButton.Name = "LogOutButton";
            this.LogOutButton.Size = new System.Drawing.Size(94, 29);
            this.LogOutButton.TabIndex = 2;
            this.LogOutButton.Text = "Выйти";
            this.LogOutButton.UseVisualStyleBackColor = true;
            this.LogOutButton.Click += new System.EventHandler(this.LogOutButton_Click);
            // 
            // CurrentUserLabel
            // 
            this.CurrentUserLabel.AutoSize = true;
            this.CurrentUserLabel.Location = new System.Drawing.Point(228, 44);
            this.CurrentUserLabel.Name = "CurrentUserLabel";
            this.CurrentUserLabel.Size = new System.Drawing.Size(62, 20);
            this.CurrentUserLabel.TabIndex = 1;
            this.CurrentUserLabel.Text = "No User";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(123, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "Пользователь:";
            // 
            // ShowUsersButton
            // 
            this.ShowUsersButton.Location = new System.Drawing.Point(157, 306);
            this.ShowUsersButton.Name = "ShowUsersButton";
            this.ShowUsersButton.Size = new System.Drawing.Size(127, 29);
            this.ShowUsersButton.TabIndex = 5;
            this.ShowUsersButton.Text = "Пользователи";
            this.ShowUsersButton.UseVisualStyleBackColor = true;
            // 
            // ShowCountriesButton
            // 
            this.ShowCountriesButton.Location = new System.Drawing.Point(157, 341);
            this.ShowCountriesButton.Name = "ShowCountriesButton";
            this.ShowCountriesButton.Size = new System.Drawing.Size(127, 29);
            this.ShowCountriesButton.TabIndex = 6;
            this.ShowCountriesButton.Text = "Страны";
            this.ShowCountriesButton.UseVisualStyleBackColor = true;
            // 
            // ShowTeamsButton
            // 
            this.ShowTeamsButton.Location = new System.Drawing.Point(157, 376);
            this.ShowTeamsButton.Name = "ShowTeamsButton";
            this.ShowTeamsButton.Size = new System.Drawing.Size(127, 29);
            this.ShowTeamsButton.TabIndex = 7;
            this.ShowTeamsButton.Text = "Команды";
            this.ShowTeamsButton.UseVisualStyleBackColor = true;
            // 
            // ShowTournamentsButton
            // 
            this.ShowTournamentsButton.Location = new System.Drawing.Point(157, 411);
            this.ShowTournamentsButton.Name = "ShowTournamentsButton";
            this.ShowTournamentsButton.Size = new System.Drawing.Size(127, 29);
            this.ShowTournamentsButton.TabIndex = 8;
            this.ShowTournamentsButton.Text = "Турниры";
            this.ShowTournamentsButton.UseVisualStyleBackColor = true;
            // 
            // RegisterBackButton
            // 
            this.RegisterBackButton.Location = new System.Drawing.Point(147, 212);
            this.RegisterBackButton.Name = "RegisterBackButton";
            this.RegisterBackButton.Size = new System.Drawing.Size(94, 29);
            this.RegisterBackButton.TabIndex = 8;
            this.RegisterBackButton.Text = "Назад";
            this.RegisterBackButton.UseVisualStyleBackColor = true;
            this.RegisterBackButton.Click += new System.EventHandler(this.RegisterBackButton_Click);
            // 
            // LogInBackButton
            // 
            this.LogInBackButton.Location = new System.Drawing.Point(145, 179);
            this.LogInBackButton.Name = "LogInBackButton";
            this.LogInBackButton.Size = new System.Drawing.Size(94, 29);
            this.LogInBackButton.TabIndex = 6;
            this.LogInBackButton.Text = "Назад";
            this.LogInBackButton.UseVisualStyleBackColor = true;
            this.LogInBackButton.Click += new System.EventHandler(this.LogInBackButton_Click);
            // 
            // WinFormMainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 475);
            this.Controls.Add(this.ShowTournamentsButton);
            this.Controls.Add(this.ShowTeamsButton);
            this.Controls.Add(this.ShowCountriesButton);
            this.Controls.Add(this.ShowUsersButton);
            this.Controls.Add(this.LogInGroupBox);
            this.Controls.Add(this.RegisterGroupBox);
            this.Controls.Add(this.LogOutGroupBox);
            this.Controls.Add(this.StartGroupBox);
            this.Name = "WinFormMainView";
            this.Text = "Меню";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WinFormMainView_FormClosing);
            this.LogInGroupBox.ResumeLayout(false);
            this.LogInGroupBox.PerformLayout();
            this.RegisterGroupBox.ResumeLayout(false);
            this.RegisterGroupBox.PerformLayout();
            this.StartGroupBox.ResumeLayout(false);
            this.LogOutGroupBox.ResumeLayout(false);
            this.LogOutGroupBox.PerformLayout();
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
        private TextBox LogInLoginTextBox;
        private Label label7;
        private Label label6;
        private Label label5;
        private GroupBox StartGroupBox;
        private Button StartRegisterButton;
        private Button StartLogInButton;
        private GroupBox LogOutGroupBox;
        private Button LogOutButton;
        private Label CurrentUserLabel;
        private Label label8;
        private Button ShowUsersButton;
        private Button ShowCountriesButton;
        private Button ShowTeamsButton;
        private Button ShowTournamentsButton;
        private Button RegisterBackButton;
        private Button LogInBackButton;
    }
}