namespace UI.WinFormViews
{
    partial class WinFormTeamView
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
            this.TeamDataGridView = new System.Windows.Forms.DataGridView();
            this.TeamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddTeamButton = new System.Windows.Forms.Button();
            this.TeamProfileGroupBox = new System.Windows.Forms.GroupBox();
            this.TournamentDataGridView = new System.Windows.Forms.DataGridView();
            this.TournamentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.TeamCountryLinkLabel = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.TeamNameLabel = new System.Windows.Forms.Label();
            this.AddTeamGroupBox = new System.Windows.Forms.GroupBox();
            this.ConfirmAddTeamButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.CountryComboBox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TeamDataGridView)).BeginInit();
            this.TeamProfileGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TournamentDataGridView)).BeginInit();
            this.AddTeamGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Команды";
            // 
            // TeamDataGridView
            // 
            this.TeamDataGridView.AllowUserToAddRows = false;
            this.TeamDataGridView.AllowUserToDeleteRows = false;
            this.TeamDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TeamDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TeamName,
            this.CountryName});
            this.TeamDataGridView.Location = new System.Drawing.Point(12, 61);
            this.TeamDataGridView.Name = "TeamDataGridView";
            this.TeamDataGridView.ReadOnly = true;
            this.TeamDataGridView.RowHeadersVisible = false;
            this.TeamDataGridView.RowHeadersWidth = 51;
            this.TeamDataGridView.RowTemplate.Height = 29;
            this.TeamDataGridView.Size = new System.Drawing.Size(254, 345);
            this.TeamDataGridView.TabIndex = 1;
            this.TeamDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TeamDataGridView_CellClick);
            // 
            // TeamName
            // 
            this.TeamName.HeaderText = "Название";
            this.TeamName.MinimumWidth = 6;
            this.TeamName.Name = "TeamName";
            this.TeamName.ReadOnly = true;
            this.TeamName.Width = 125;
            // 
            // CountryName
            // 
            this.CountryName.HeaderText = "Страна";
            this.CountryName.MinimumWidth = 6;
            this.CountryName.Name = "CountryName";
            this.CountryName.ReadOnly = true;
            this.CountryName.Width = 125;
            // 
            // AddTeamButton
            // 
            this.AddTeamButton.Location = new System.Drawing.Point(12, 412);
            this.AddTeamButton.Name = "AddTeamButton";
            this.AddTeamButton.Size = new System.Drawing.Size(254, 29);
            this.AddTeamButton.TabIndex = 2;
            this.AddTeamButton.Text = "Создать команду";
            this.AddTeamButton.UseVisualStyleBackColor = true;
            this.AddTeamButton.Visible = false;
            this.AddTeamButton.Click += new System.EventHandler(this.AddTeamButton_Click);
            // 
            // TeamProfileGroupBox
            // 
            this.TeamProfileGroupBox.Controls.Add(this.TournamentDataGridView);
            this.TeamProfileGroupBox.Controls.Add(this.label3);
            this.TeamProfileGroupBox.Controls.Add(this.TeamCountryLinkLabel);
            this.TeamProfileGroupBox.Controls.Add(this.label2);
            this.TeamProfileGroupBox.Controls.Add(this.TeamNameLabel);
            this.TeamProfileGroupBox.Location = new System.Drawing.Point(341, 23);
            this.TeamProfileGroupBox.Name = "TeamProfileGroupBox";
            this.TeamProfileGroupBox.Size = new System.Drawing.Size(423, 418);
            this.TeamProfileGroupBox.TabIndex = 3;
            this.TeamProfileGroupBox.TabStop = false;
            this.TeamProfileGroupBox.Visible = false;
            // 
            // TournamentDataGridView
            // 
            this.TournamentDataGridView.AllowUserToAddRows = false;
            this.TournamentDataGridView.AllowUserToDeleteRows = false;
            this.TournamentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TournamentDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TournamentName});
            this.TournamentDataGridView.Location = new System.Drawing.Point(23, 176);
            this.TournamentDataGridView.Name = "TournamentDataGridView";
            this.TournamentDataGridView.ReadOnly = true;
            this.TournamentDataGridView.RowHeadersVisible = false;
            this.TournamentDataGridView.RowHeadersWidth = 51;
            this.TournamentDataGridView.RowTemplate.Height = 29;
            this.TournamentDataGridView.Size = new System.Drawing.Size(129, 239);
            this.TournamentDataGridView.TabIndex = 4;
            this.TournamentDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TournamentDataGridView_CellClick);
            // 
            // TournamentName
            // 
            this.TournamentName.HeaderText = "Название";
            this.TournamentName.MinimumWidth = 6;
            this.TournamentName.Name = "TournamentName";
            this.TournamentName.ReadOnly = true;
            this.TournamentName.Width = 125;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(23, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 28);
            this.label3.TabIndex = 3;
            this.label3.Text = "Турниры";
            // 
            // TeamCountryLinkLabel
            // 
            this.TeamCountryLinkLabel.AutoSize = true;
            this.TeamCountryLinkLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TeamCountryLinkLabel.Location = new System.Drawing.Point(109, 85);
            this.TeamCountryLinkLabel.Name = "TeamCountryLinkLabel";
            this.TeamCountryLinkLabel.Size = new System.Drawing.Size(109, 28);
            this.TeamCountryLinkLabel.TabIndex = 2;
            this.TeamCountryLinkLabel.TabStop = true;
            this.TeamCountryLinkLabel.Text = "NoCountry";
            this.TeamCountryLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.TeamCountryLinkLabel_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(23, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Страна:";
            // 
            // TeamNameLabel
            // 
            this.TeamNameLabel.AutoSize = true;
            this.TeamNameLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TeamNameLabel.Location = new System.Drawing.Point(23, 23);
            this.TeamNameLabel.Name = "TeamNameLabel";
            this.TeamNameLabel.Size = new System.Drawing.Size(144, 46);
            this.TeamNameLabel.TabIndex = 0;
            this.TeamNameLabel.Text = "NoTeam";
            // 
            // AddTeamGroupBox
            // 
            this.AddTeamGroupBox.Controls.Add(this.ConfirmAddTeamButton);
            this.AddTeamGroupBox.Controls.Add(this.label6);
            this.AddTeamGroupBox.Controls.Add(this.CountryComboBox);
            this.AddTeamGroupBox.Controls.Add(this.label5);
            this.AddTeamGroupBox.Controls.Add(this.NameTextBox);
            this.AddTeamGroupBox.Controls.Add(this.label4);
            this.AddTeamGroupBox.Location = new System.Drawing.Point(332, 29);
            this.AddTeamGroupBox.Name = "AddTeamGroupBox";
            this.AddTeamGroupBox.Size = new System.Drawing.Size(439, 422);
            this.AddTeamGroupBox.TabIndex = 4;
            this.AddTeamGroupBox.TabStop = false;
            this.AddTeamGroupBox.Visible = false;
            // 
            // ConfirmAddTeamButton
            // 
            this.ConfirmAddTeamButton.Location = new System.Drawing.Point(143, 180);
            this.ConfirmAddTeamButton.Name = "ConfirmAddTeamButton";
            this.ConfirmAddTeamButton.Size = new System.Drawing.Size(151, 29);
            this.ConfirmAddTeamButton.TabIndex = 5;
            this.ConfirmAddTeamButton.Text = "Создать команду";
            this.ConfirmAddTeamButton.UseVisualStyleBackColor = true;
            this.ConfirmAddTeamButton.Click += new System.EventHandler(this.ConfirmAddTeamButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Страна:";
            // 
            // CountryComboBox
            // 
            this.CountryComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CountryComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CountryComboBox.FormattingEnabled = true;
            this.CountryComboBox.Location = new System.Drawing.Point(143, 128);
            this.CountryComboBox.Name = "CountryComboBox";
            this.CountryComboBox.Size = new System.Drawing.Size(151, 28);
            this.CountryComboBox.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Название:";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(143, 66);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(151, 27);
            this.NameTextBox.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(143, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 28);
            this.label4.TabIndex = 0;
            this.label4.Text = "Создать команду";
            // 
            // WinFormTeamView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AddTeamButton);
            this.Controls.Add(this.TeamDataGridView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddTeamGroupBox);
            this.Controls.Add(this.TeamProfileGroupBox);
            this.Name = "WinFormTeamView";
            this.Text = "WinFormTeamView";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WinFormTeamView_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.TeamDataGridView)).EndInit();
            this.TeamProfileGroupBox.ResumeLayout(false);
            this.TeamProfileGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TournamentDataGridView)).EndInit();
            this.AddTeamGroupBox.ResumeLayout(false);
            this.AddTeamGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private DataGridView TeamDataGridView;
        private Button AddTeamButton;
        private GroupBox TeamProfileGroupBox;
        private Label label2;
        private Label TeamNameLabel;
        private Label label3;
        private LinkLabel TeamCountryLinkLabel;
        private DataGridViewTextBoxColumn TeamName;
        private DataGridViewTextBoxColumn CountryName;
        private DataGridView TournamentDataGridView;
        private DataGridViewTextBoxColumn TournamentName;
        private GroupBox AddTeamGroupBox;
        private TextBox NameTextBox;
        private Label label4;
        private Label label6;
        private ComboBox CountryComboBox;
        private Label label5;
        private Button ConfirmAddTeamButton;
    }
}