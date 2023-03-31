namespace UI.WinFormViews
{
    partial class WinFormTournamentView
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
            this.label1 = new System.Windows.Forms.Label();
            this.TournamentsDataGridView = new System.Windows.Forms.DataGridView();
            this.TournamentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateTournamentButton = new System.Windows.Forms.Button();
            this.TournamentProfileGroupBox = new System.Windows.Forms.GroupBox();
            this.DeleteTournamentButton = new System.Windows.Forms.Button();
            this.UserLinkLabel = new System.Windows.Forms.LinkLabel();
            this.CountryLinkLabel = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.MatchesDataGridView = new System.Windows.Forms.DataGridView();
            this.ShowMatchesButton = new System.Windows.Forms.Button();
            this.ShowTableButton = new System.Windows.Forms.Button();
            this.TableDataGridView = new System.Windows.Forms.DataGridView();
            this.TeamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Games = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Wins = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Draws = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Loses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GoalsScored = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GoalsConceded = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Points = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddTournamentGroupBox = new System.Windows.Forms.GroupBox();
            this.ConfirmAddTournamentButton = new System.Windows.Forms.Button();
            this.DeleteTeamButton = new System.Windows.Forms.Button();
            this.AddTeamButton = new System.Windows.Forms.Button();
            this.TeamComboBox = new System.Windows.Forms.ComboBox();
            this.TeamDataGridView = new System.Windows.Forms.DataGridView();
            this.TournamentTeamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.CountryComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TournamentsDataGridView)).BeginInit();
            this.TournamentProfileGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MatchesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableDataGridView)).BeginInit();
            this.AddTournamentGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TeamDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(156, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Турниры";
            // 
            // TournamentsDataGridView
            // 
            this.TournamentsDataGridView.AllowUserToAddRows = false;
            this.TournamentsDataGridView.AllowUserToDeleteRows = false;
            this.TournamentsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TournamentsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TournamentName,
            this.CountryName,
            this.UserName});
            this.TournamentsDataGridView.Location = new System.Drawing.Point(12, 53);
            this.TournamentsDataGridView.Name = "TournamentsDataGridView";
            this.TournamentsDataGridView.ReadOnly = true;
            this.TournamentsDataGridView.RowHeadersVisible = false;
            this.TournamentsDataGridView.RowHeadersWidth = 51;
            this.TournamentsDataGridView.RowTemplate.Height = 29;
            this.TournamentsDataGridView.Size = new System.Drawing.Size(378, 574);
            this.TournamentsDataGridView.TabIndex = 1;
            this.TournamentsDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TournamentsDataGridView_CellClick);
            // 
            // TournamentName
            // 
            this.TournamentName.HeaderText = "Название";
            this.TournamentName.MinimumWidth = 6;
            this.TournamentName.Name = "TournamentName";
            this.TournamentName.ReadOnly = true;
            this.TournamentName.Width = 125;
            // 
            // CountryName
            // 
            this.CountryName.HeaderText = "Страна";
            this.CountryName.MinimumWidth = 6;
            this.CountryName.Name = "CountryName";
            this.CountryName.ReadOnly = true;
            this.CountryName.Width = 125;
            // 
            // UserName
            // 
            this.UserName.HeaderText = "Создатель";
            this.UserName.MinimumWidth = 6;
            this.UserName.Name = "UserName";
            this.UserName.ReadOnly = true;
            this.UserName.Width = 125;
            // 
            // CreateTournamentButton
            // 
            this.CreateTournamentButton.Location = new System.Drawing.Point(115, 633);
            this.CreateTournamentButton.Name = "CreateTournamentButton";
            this.CreateTournamentButton.Size = new System.Drawing.Size(161, 29);
            this.CreateTournamentButton.TabIndex = 2;
            this.CreateTournamentButton.Text = "Создать турнир";
            this.CreateTournamentButton.UseVisualStyleBackColor = true;
            this.CreateTournamentButton.Visible = false;
            this.CreateTournamentButton.Click += new System.EventHandler(this.CreateTournamentButton_Click);
            // 
            // TournamentProfileGroupBox
            // 
            this.TournamentProfileGroupBox.Controls.Add(this.DeleteTournamentButton);
            this.TournamentProfileGroupBox.Controls.Add(this.UserLinkLabel);
            this.TournamentProfileGroupBox.Controls.Add(this.CountryLinkLabel);
            this.TournamentProfileGroupBox.Controls.Add(this.label3);
            this.TournamentProfileGroupBox.Controls.Add(this.label2);
            this.TournamentProfileGroupBox.Controls.Add(this.NameLabel);
            this.TournamentProfileGroupBox.Controls.Add(this.ShowMatchesButton);
            this.TournamentProfileGroupBox.Controls.Add(this.ShowTableButton);
            this.TournamentProfileGroupBox.Controls.Add(this.TableDataGridView);
            this.TournamentProfileGroupBox.Controls.Add(this.MatchesDataGridView);
            this.TournamentProfileGroupBox.Location = new System.Drawing.Point(442, 21);
            this.TournamentProfileGroupBox.Name = "TournamentProfileGroupBox";
            this.TournamentProfileGroupBox.Size = new System.Drawing.Size(733, 641);
            this.TournamentProfileGroupBox.TabIndex = 3;
            this.TournamentProfileGroupBox.TabStop = false;
            this.TournamentProfileGroupBox.Visible = false;
            // 
            // DeleteTournamentButton
            // 
            this.DeleteTournamentButton.Location = new System.Drawing.Point(316, 32);
            this.DeleteTournamentButton.Name = "DeleteTournamentButton";
            this.DeleteTournamentButton.Size = new System.Drawing.Size(137, 29);
            this.DeleteTournamentButton.TabIndex = 9;
            this.DeleteTournamentButton.Text = "Удалить турнир";
            this.DeleteTournamentButton.UseVisualStyleBackColor = true;
            this.DeleteTournamentButton.Visible = false;
            this.DeleteTournamentButton.Click += new System.EventHandler(this.DeleteTournamentButton_Click);
            // 
            // UserLinkLabel
            // 
            this.UserLinkLabel.AutoSize = true;
            this.UserLinkLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UserLinkLabel.Location = new System.Drawing.Point(136, 137);
            this.UserLinkLabel.Name = "UserLinkLabel";
            this.UserLinkLabel.Size = new System.Drawing.Size(78, 28);
            this.UserLinkLabel.TabIndex = 4;
            this.UserLinkLabel.TabStop = true;
            this.UserLinkLabel.Text = "NoUser";
            this.UserLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.UserLinkLabel_LinkClicked);
            // 
            // CountryLinkLabel
            // 
            this.CountryLinkLabel.AutoSize = true;
            this.CountryLinkLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CountryLinkLabel.Location = new System.Drawing.Point(107, 92);
            this.CountryLinkLabel.Name = "CountryLinkLabel";
            this.CountryLinkLabel.Size = new System.Drawing.Size(109, 28);
            this.CountryLinkLabel.TabIndex = 3;
            this.CountryLinkLabel.TabStop = true;
            this.CountryLinkLabel.Text = "NoCountry";
            this.CountryLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.CountryLinkLabel_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(21, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 28);
            this.label3.TabIndex = 2;
            this.label3.Text = "Создатель:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(21, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Страна:";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.NameLabel.Location = new System.Drawing.Point(21, 23);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(245, 46);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "NoTournament";
            // 
            // MatchesDataGridView
            // 
            this.MatchesDataGridView.AllowUserToAddRows = false;
            this.MatchesDataGridView.AllowUserToDeleteRows = false;
            this.MatchesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MatchesDataGridView.Location = new System.Drawing.Point(12, 212);
            this.MatchesDataGridView.Name = "MatchesDataGridView";
            this.MatchesDataGridView.ReadOnly = true;
            this.MatchesDataGridView.RowHeadersWidth = 125;
            this.MatchesDataGridView.RowTemplate.Height = 29;
            this.MatchesDataGridView.Size = new System.Drawing.Size(715, 423);
            this.MatchesDataGridView.TabIndex = 8;
            this.MatchesDataGridView.Visible = false;
            this.MatchesDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MatchesDataGridView_CellClick);
            // 
            // ShowMatchesButton
            // 
            this.ShowMatchesButton.Location = new System.Drawing.Point(21, 177);
            this.ShowMatchesButton.Name = "ShowMatchesButton";
            this.ShowMatchesButton.Size = new System.Drawing.Size(149, 29);
            this.ShowMatchesButton.TabIndex = 6;
            this.ShowMatchesButton.Text = "Показать матчи";
            this.ShowMatchesButton.UseVisualStyleBackColor = true;
            this.ShowMatchesButton.Click += new System.EventHandler(this.ShowMatchesButton_Click);
            // 
            // ShowTableButton
            // 
            this.ShowTableButton.Location = new System.Drawing.Point(21, 177);
            this.ShowTableButton.Name = "ShowTableButton";
            this.ShowTableButton.Size = new System.Drawing.Size(149, 29);
            this.ShowTableButton.TabIndex = 7;
            this.ShowTableButton.Text = "Показать таблицу";
            this.ShowTableButton.UseVisualStyleBackColor = true;
            this.ShowTableButton.Visible = false;
            this.ShowTableButton.Click += new System.EventHandler(this.ShowTableButton_Click);
            // 
            // TableDataGridView
            // 
            this.TableDataGridView.AllowUserToAddRows = false;
            this.TableDataGridView.AllowUserToDeleteRows = false;
            this.TableDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TableDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TeamName,
            this.Games,
            this.Wins,
            this.Draws,
            this.Loses,
            this.GoalsScored,
            this.GoalsConceded,
            this.Points});
            this.TableDataGridView.Location = new System.Drawing.Point(12, 212);
            this.TableDataGridView.Name = "TableDataGridView";
            this.TableDataGridView.ReadOnly = true;
            this.TableDataGridView.RowHeadersVisible = false;
            this.TableDataGridView.RowHeadersWidth = 51;
            this.TableDataGridView.RowTemplate.Height = 29;
            this.TableDataGridView.Size = new System.Drawing.Size(715, 423);
            this.TableDataGridView.TabIndex = 5;
            this.TableDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TableDataGridView_CellClick);
            // 
            // TeamName
            // 
            this.TeamName.HeaderText = "Название";
            this.TeamName.MinimumWidth = 6;
            this.TeamName.Name = "TeamName";
            this.TeamName.ReadOnly = true;
            this.TeamName.Width = 110;
            // 
            // Games
            // 
            this.Games.HeaderText = "Игры";
            this.Games.MinimumWidth = 6;
            this.Games.Name = "Games";
            this.Games.ReadOnly = true;
            this.Games.Width = 55;
            // 
            // Wins
            // 
            this.Wins.HeaderText = "Победы";
            this.Wins.MinimumWidth = 6;
            this.Wins.Name = "Wins";
            this.Wins.ReadOnly = true;
            this.Wins.Width = 70;
            // 
            // Draws
            // 
            this.Draws.HeaderText = "Ничьи";
            this.Draws.MinimumWidth = 6;
            this.Draws.Name = "Draws";
            this.Draws.ReadOnly = true;
            this.Draws.Width = 65;
            // 
            // Loses
            // 
            this.Loses.HeaderText = "Поражения";
            this.Loses.MinimumWidth = 6;
            this.Loses.Name = "Loses";
            this.Loses.ReadOnly = true;
            this.Loses.Width = 125;
            // 
            // GoalsScored
            // 
            this.GoalsScored.HeaderText = "Забито";
            this.GoalsScored.MinimumWidth = 6;
            this.GoalsScored.Name = "GoalsScored";
            this.GoalsScored.ReadOnly = true;
            this.GoalsScored.Width = 60;
            // 
            // GoalsConceded
            // 
            this.GoalsConceded.HeaderText = "Пропущено";
            this.GoalsConceded.MinimumWidth = 6;
            this.GoalsConceded.Name = "GoalsConceded";
            this.GoalsConceded.ReadOnly = true;
            this.GoalsConceded.Width = 125;
            // 
            // Points
            // 
            this.Points.HeaderText = "Очки";
            this.Points.MinimumWidth = 6;
            this.Points.Name = "Points";
            this.Points.ReadOnly = true;
            this.Points.Width = 60;
            // 
            // AddTournamentGroupBox
            // 
            this.AddTournamentGroupBox.Controls.Add(this.ConfirmAddTournamentButton);
            this.AddTournamentGroupBox.Controls.Add(this.DeleteTeamButton);
            this.AddTournamentGroupBox.Controls.Add(this.AddTeamButton);
            this.AddTournamentGroupBox.Controls.Add(this.TeamComboBox);
            this.AddTournamentGroupBox.Controls.Add(this.TeamDataGridView);
            this.AddTournamentGroupBox.Controls.Add(this.label7);
            this.AddTournamentGroupBox.Controls.Add(this.CountryComboBox);
            this.AddTournamentGroupBox.Controls.Add(this.label6);
            this.AddTournamentGroupBox.Controls.Add(this.NameTextBox);
            this.AddTournamentGroupBox.Controls.Add(this.label5);
            this.AddTournamentGroupBox.Controls.Add(this.label4);
            this.AddTournamentGroupBox.Location = new System.Drawing.Point(433, 21);
            this.AddTournamentGroupBox.Name = "AddTournamentGroupBox";
            this.AddTournamentGroupBox.Size = new System.Drawing.Size(710, 649);
            this.AddTournamentGroupBox.TabIndex = 4;
            this.AddTournamentGroupBox.TabStop = false;
            this.AddTournamentGroupBox.Visible = false;
            // 
            // ConfirmAddTournamentButton
            // 
            this.ConfirmAddTournamentButton.Location = new System.Drawing.Point(190, 527);
            this.ConfirmAddTournamentButton.Name = "ConfirmAddTournamentButton";
            this.ConfirmAddTournamentButton.Size = new System.Drawing.Size(272, 29);
            this.ConfirmAddTournamentButton.TabIndex = 10;
            this.ConfirmAddTournamentButton.Text = "Создать турнир";
            this.ConfirmAddTournamentButton.UseVisualStyleBackColor = true;
            this.ConfirmAddTournamentButton.Click += new System.EventHandler(this.ConfirmAddTournamentButton_Click);
            // 
            // DeleteTeamButton
            // 
            this.DeleteTeamButton.Location = new System.Drawing.Point(177, 291);
            this.DeleteTeamButton.Name = "DeleteTeamButton";
            this.DeleteTeamButton.Size = new System.Drawing.Size(151, 29);
            this.DeleteTeamButton.TabIndex = 9;
            this.DeleteTeamButton.Text = "Удалить команду";
            this.DeleteTeamButton.UseVisualStyleBackColor = true;
            this.DeleteTeamButton.Click += new System.EventHandler(this.DeleteTeamButton_Click);
            // 
            // AddTeamButton
            // 
            this.AddTeamButton.Location = new System.Drawing.Point(177, 246);
            this.AddTeamButton.Name = "AddTeamButton";
            this.AddTeamButton.Size = new System.Drawing.Size(151, 29);
            this.AddTeamButton.TabIndex = 8;
            this.AddTeamButton.Text = "Добавить команду";
            this.AddTeamButton.UseVisualStyleBackColor = true;
            this.AddTeamButton.Click += new System.EventHandler(this.AddTeamButton_Click);
            // 
            // TeamComboBox
            // 
            this.TeamComboBox.FormattingEnabled = true;
            this.TeamComboBox.Location = new System.Drawing.Point(177, 212);
            this.TeamComboBox.Name = "TeamComboBox";
            this.TeamComboBox.Size = new System.Drawing.Size(151, 28);
            this.TeamComboBox.TabIndex = 7;
            // 
            // TeamDataGridView
            // 
            this.TeamDataGridView.AllowUserToAddRows = false;
            this.TeamDataGridView.AllowUserToDeleteRows = false;
            this.TeamDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TeamDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TournamentTeamName});
            this.TeamDataGridView.Location = new System.Drawing.Point(334, 212);
            this.TeamDataGridView.MultiSelect = false;
            this.TeamDataGridView.Name = "TeamDataGridView";
            this.TeamDataGridView.ReadOnly = true;
            this.TeamDataGridView.RowHeadersVisible = false;
            this.TeamDataGridView.RowHeadersWidth = 51;
            this.TeamDataGridView.RowTemplate.Height = 29;
            this.TeamDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.TeamDataGridView.Size = new System.Drawing.Size(128, 274);
            this.TeamDataGridView.TabIndex = 6;
            // 
            // TournamentTeamName
            // 
            this.TournamentTeamName.HeaderText = "Название";
            this.TournamentTeamName.MinimumWidth = 6;
            this.TournamentTeamName.Name = "TournamentTeamName";
            this.TournamentTeamName.ReadOnly = true;
            this.TournamentTeamName.Width = 125;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(297, 167);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "Команды";
            // 
            // CountryComboBox
            // 
            this.CountryComboBox.FormattingEnabled = true;
            this.CountryComboBox.Location = new System.Drawing.Point(297, 114);
            this.CountryComboBox.Name = "CountryComboBox";
            this.CountryComboBox.Size = new System.Drawing.Size(165, 28);
            this.CountryComboBox.Sorted = true;
            this.CountryComboBox.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(190, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "Страна:";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(297, 65);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(165, 27);
            this.NameTextBox.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(190, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "Название:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(281, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(181, 28);
            this.label4.TabIndex = 0;
            this.label4.Text = "Создание турнира";
            // 
            // WinFormTournamentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 674);
            this.Controls.Add(this.CreateTournamentButton);
            this.Controls.Add(this.TournamentsDataGridView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TournamentProfileGroupBox);
            this.Controls.Add(this.AddTournamentGroupBox);
            this.Name = "WinFormTournamentView";
            this.Text = "WinFormTournamentView";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WinFormTournamentView_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.TournamentsDataGridView)).EndInit();
            this.TournamentProfileGroupBox.ResumeLayout(false);
            this.TournamentProfileGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MatchesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TableDataGridView)).EndInit();
            this.AddTournamentGroupBox.ResumeLayout(false);
            this.AddTournamentGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TeamDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private DataGridView TournamentsDataGridView;
        private DataGridViewTextBoxColumn TournamentName;
        private DataGridViewTextBoxColumn CountryName;
        private DataGridViewTextBoxColumn UserName;
        private Button CreateTournamentButton;
        private GroupBox TournamentProfileGroupBox;
        private DataGridView TableDataGridView;
        private LinkLabel UserLinkLabel;
        private LinkLabel CountryLinkLabel;
        private Label label3;
        private Label label2;
        private Label NameLabel;
        private Button ShowMatchesButton;
        private DataGridView MatchesDataGridView;
        private Button ShowTableButton;
        private GroupBox AddTournamentGroupBox;
        private Button ConfirmAddTournamentButton;
        private Button DeleteTeamButton;
        private Button AddTeamButton;
        private ComboBox TeamComboBox;
        private DataGridView TeamDataGridView;
        private DataGridViewTextBoxColumn TournamentTeamName;
        private Label label7;
        private ComboBox CountryComboBox;
        private Label label6;
        private TextBox NameTextBox;
        private Label label5;
        private Label label4;
        private DataGridViewTextBoxColumn TeamName;
        private DataGridViewTextBoxColumn Games;
        private DataGridViewTextBoxColumn Wins;
        private DataGridViewTextBoxColumn Draws;
        private DataGridViewTextBoxColumn Loses;
        private DataGridViewTextBoxColumn GoalsScored;
        private DataGridViewTextBoxColumn GoalsConceded;
        private DataGridViewTextBoxColumn Points;
        private Button DeleteTournamentButton;
    }
}