namespace UI.WinFormViews
{
    partial class WinFormUserView
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
            this.UsersDataGridView = new System.Windows.Forms.DataGridView();
            this.Login = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Права = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.UserProfileGroupBox = new System.Windows.Forms.GroupBox();
            this.TournamentsDataGridView = new System.Windows.Forms.DataGridView();
            this.TournamentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChangePermsButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.PermsLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LoginLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.UsersDataGridView)).BeginInit();
            this.UserProfileGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TournamentsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // UsersDataGridView
            // 
            this.UsersDataGridView.AllowUserToAddRows = false;
            this.UsersDataGridView.AllowUserToDeleteRows = false;
            this.UsersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UsersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Login,
            this.Права});
            this.UsersDataGridView.Location = new System.Drawing.Point(12, 42);
            this.UsersDataGridView.Name = "UsersDataGridView";
            this.UsersDataGridView.ReadOnly = true;
            this.UsersDataGridView.RowHeadersVisible = false;
            this.UsersDataGridView.RowHeadersWidth = 51;
            this.UsersDataGridView.RowTemplate.Height = 29;
            this.UsersDataGridView.Size = new System.Drawing.Size(253, 457);
            this.UsersDataGridView.TabIndex = 0;
            this.UsersDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.UsersDataGridView_CellClick);
            // 
            // Login
            // 
            this.Login.HeaderText = "Логин";
            this.Login.MinimumWidth = 6;
            this.Login.Name = "Login";
            this.Login.ReadOnly = true;
            this.Login.Width = 125;
            // 
            // Права
            // 
            this.Права.HeaderText = "Perms";
            this.Права.MinimumWidth = 6;
            this.Права.Name = "Права";
            this.Права.ReadOnly = true;
            this.Права.Width = 125;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Пользователи";
            // 
            // UserProfileGroupBox
            // 
            this.UserProfileGroupBox.Controls.Add(this.TournamentsDataGridView);
            this.UserProfileGroupBox.Controls.Add(this.ChangePermsButton);
            this.UserProfileGroupBox.Controls.Add(this.label3);
            this.UserProfileGroupBox.Controls.Add(this.PermsLabel);
            this.UserProfileGroupBox.Controls.Add(this.label2);
            this.UserProfileGroupBox.Controls.Add(this.LoginLabel);
            this.UserProfileGroupBox.Location = new System.Drawing.Point(296, 19);
            this.UserProfileGroupBox.Name = "UserProfileGroupBox";
            this.UserProfileGroupBox.Size = new System.Drawing.Size(464, 486);
            this.UserProfileGroupBox.TabIndex = 2;
            this.UserProfileGroupBox.TabStop = false;
            this.UserProfileGroupBox.Visible = false;
            // 
            // TournamentsDataGridView
            // 
            this.TournamentsDataGridView.AllowUserToAddRows = false;
            this.TournamentsDataGridView.AllowUserToDeleteRows = false;
            this.TournamentsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TournamentsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TournamentName});
            this.TournamentsDataGridView.Location = new System.Drawing.Point(37, 202);
            this.TournamentsDataGridView.Name = "TournamentsDataGridView";
            this.TournamentsDataGridView.ReadOnly = true;
            this.TournamentsDataGridView.RowHeadersVisible = false;
            this.TournamentsDataGridView.RowHeadersWidth = 51;
            this.TournamentsDataGridView.RowTemplate.Height = 29;
            this.TournamentsDataGridView.Size = new System.Drawing.Size(123, 278);
            this.TournamentsDataGridView.TabIndex = 5;
            this.TournamentsDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TournamentsDataGridView_CellClick);
            // 
            // TournamentName
            // 
            this.TournamentName.HeaderText = "Название";
            this.TournamentName.MinimumWidth = 6;
            this.TournamentName.Name = "TournamentName";
            this.TournamentName.ReadOnly = true;
            this.TournamentName.Width = 120;
            // 
            // ChangePermsButton
            // 
            this.ChangePermsButton.Location = new System.Drawing.Point(202, 88);
            this.ChangePermsButton.Name = "ChangePermsButton";
            this.ChangePermsButton.Size = new System.Drawing.Size(214, 29);
            this.ChangePermsButton.TabIndex = 4;
            this.ChangePermsButton.Text = "Сделать администратором";
            this.ChangePermsButton.UseVisualStyleBackColor = true;
            this.ChangePermsButton.Visible = false;
            this.ChangePermsButton.Click += new System.EventHandler(this.ChangePermsButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(28, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 28);
            this.label3.TabIndex = 3;
            this.label3.Text = "Турниры";
            // 
            // PermsLabel
            // 
            this.PermsLabel.AutoSize = true;
            this.PermsLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PermsLabel.Location = new System.Drawing.Point(95, 88);
            this.PermsLabel.Name = "PermsLabel";
            this.PermsLabel.Size = new System.Drawing.Size(91, 28);
            this.PermsLabel.TabIndex = 2;
            this.PermsLabel.Text = "NoPerms";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(28, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Права:";
            // 
            // LoginLabel
            // 
            this.LoginLabel.AutoSize = true;
            this.LoginLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LoginLabel.Location = new System.Drawing.Point(28, 23);
            this.LoginLabel.Name = "LoginLabel";
            this.LoginLabel.Size = new System.Drawing.Size(132, 46);
            this.LoginLabel.TabIndex = 0;
            this.LoginLabel.Text = "NoUser";
            // 
            // WinFormUserView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 517);
            this.Controls.Add(this.UserProfileGroupBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UsersDataGridView);
            this.Name = "WinFormUserView";
            this.Text = "WinFormUserView";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WinFormUserView_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.UsersDataGridView)).EndInit();
            this.UserProfileGroupBox.ResumeLayout(false);
            this.UserProfileGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TournamentsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView UsersDataGridView;
        private DataGridViewTextBoxColumn Login;
        private DataGridViewTextBoxColumn Права;
        private Label label1;
        private GroupBox UserProfileGroupBox;
        private DataGridView TournamentsDataGridView;
        private Button ChangePermsButton;
        private Label label3;
        private Label PermsLabel;
        private Label label2;
        private Label LoginLabel;
        private DataGridViewTextBoxColumn TournamentName;
    }
}