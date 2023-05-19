namespace UI.WinFormViews
{
    partial class WinFormCountryView
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
            this.CountryDataGridView = new System.Windows.Forms.DataGridView();
            this.CountryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountryConfederation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddCountryButton = new System.Windows.Forms.Button();
            this.CountryProfileGroupBox = new System.Windows.Forms.GroupBox();
            this.TournamentDataGridView = new System.Windows.Forms.DataGridView();
            this.TournamentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.TeamDataGridView = new System.Windows.Forms.DataGridView();
            this.TeamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.ConfederationLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CountryNameLabel = new System.Windows.Forms.Label();
            this.AddCountryGroupBox = new System.Windows.Forms.GroupBox();
            this.ConfirmAddCountryButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.ConfTextBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.CountryDataGridView)).BeginInit();
            this.CountryProfileGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TournamentDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeamDataGridView)).BeginInit();
            this.AddCountryGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(107, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Страны";
            // 
            // CountryDataGridView
            // 
            this.CountryDataGridView.AllowUserToAddRows = false;
            this.CountryDataGridView.AllowUserToDeleteRows = false;
            this.CountryDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CountryDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CountryName,
            this.CountryConfederation});
            this.CountryDataGridView.Location = new System.Drawing.Point(12, 62);
            this.CountryDataGridView.Name = "CountryDataGridView";
            this.CountryDataGridView.ReadOnly = true;
            this.CountryDataGridView.RowHeadersVisible = false;
            this.CountryDataGridView.RowHeadersWidth = 51;
            this.CountryDataGridView.RowTemplate.Height = 29;
            this.CountryDataGridView.Size = new System.Drawing.Size(254, 344);
            this.CountryDataGridView.TabIndex = 1;
            this.CountryDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CountryDataGridView_CellClick);
            // 
            // CountryName
            // 
            this.CountryName.HeaderText = "Название";
            this.CountryName.MinimumWidth = 6;
            this.CountryName.Name = "CountryName";
            this.CountryName.ReadOnly = true;
            this.CountryName.Width = 125;
            // 
            // CountryConfederation
            // 
            this.CountryConfederation.HeaderText = "Конфедерация";
            this.CountryConfederation.MinimumWidth = 6;
            this.CountryConfederation.Name = "CountryConfederation";
            this.CountryConfederation.ReadOnly = true;
            this.CountryConfederation.Width = 125;
            // 
            // AddCountryButton
            // 
            this.AddCountryButton.Location = new System.Drawing.Point(12, 412);
            this.AddCountryButton.Name = "AddCountryButton";
            this.AddCountryButton.Size = new System.Drawing.Size(254, 29);
            this.AddCountryButton.TabIndex = 2;
            this.AddCountryButton.Text = "Создать страну";
            this.AddCountryButton.UseVisualStyleBackColor = true;
            this.AddCountryButton.Visible = false;
            this.AddCountryButton.Click += new System.EventHandler(this.AddCountryButton_Click);
            // 
            // CountryProfileGroupBox
            // 
            this.CountryProfileGroupBox.Controls.Add(this.TournamentDataGridView);
            this.CountryProfileGroupBox.Controls.Add(this.label4);
            this.CountryProfileGroupBox.Controls.Add(this.TeamDataGridView);
            this.CountryProfileGroupBox.Controls.Add(this.label3);
            this.CountryProfileGroupBox.Controls.Add(this.ConfederationLabel);
            this.CountryProfileGroupBox.Controls.Add(this.label2);
            this.CountryProfileGroupBox.Controls.Add(this.CountryNameLabel);
            this.CountryProfileGroupBox.Location = new System.Drawing.Point(286, 23);
            this.CountryProfileGroupBox.Name = "CountryProfileGroupBox";
            this.CountryProfileGroupBox.Size = new System.Drawing.Size(425, 418);
            this.CountryProfileGroupBox.TabIndex = 3;
            this.CountryProfileGroupBox.TabStop = false;
            this.CountryProfileGroupBox.Visible = false;
            // 
            // TournamentDataGridView
            // 
            this.TournamentDataGridView.AllowUserToAddRows = false;
            this.TournamentDataGridView.AllowUserToDeleteRows = false;
            this.TournamentDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TournamentDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TournamentName});
            this.TournamentDataGridView.Location = new System.Drawing.Point(255, 173);
            this.TournamentDataGridView.Name = "TournamentDataGridView";
            this.TournamentDataGridView.ReadOnly = true;
            this.TournamentDataGridView.RowHeadersVisible = false;
            this.TournamentDataGridView.RowHeadersWidth = 51;
            this.TournamentDataGridView.RowTemplate.Height = 29;
            this.TournamentDataGridView.Size = new System.Drawing.Size(129, 239);
            this.TournamentDataGridView.TabIndex = 6;
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(255, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 28);
            this.label4.TabIndex = 5;
            this.label4.Text = "Турниры";
            // 
            // TeamDataGridView
            // 
            this.TeamDataGridView.AllowUserToAddRows = false;
            this.TeamDataGridView.AllowUserToDeleteRows = false;
            this.TeamDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TeamDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TeamName});
            this.TeamDataGridView.Location = new System.Drawing.Point(15, 173);
            this.TeamDataGridView.Name = "TeamDataGridView";
            this.TeamDataGridView.ReadOnly = true;
            this.TeamDataGridView.RowHeadersVisible = false;
            this.TeamDataGridView.RowHeadersWidth = 51;
            this.TeamDataGridView.RowTemplate.Height = 29;
            this.TeamDataGridView.Size = new System.Drawing.Size(129, 239);
            this.TeamDataGridView.TabIndex = 4;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(15, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 28);
            this.label3.TabIndex = 3;
            this.label3.Text = "Команды";
            // 
            // ConfederationLabel
            // 
            this.ConfederationLabel.AutoSize = true;
            this.ConfederationLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ConfederationLabel.Location = new System.Drawing.Point(174, 90);
            this.ConfederationLabel.Name = "ConfederationLabel";
            this.ConfederationLabel.Size = new System.Drawing.Size(80, 28);
            this.ConfederationLabel.TabIndex = 2;
            this.ConfederationLabel.Text = "NoConf";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(15, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Конфедерация:";
            // 
            // CountryNameLabel
            // 
            this.CountryNameLabel.AutoSize = true;
            this.CountryNameLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CountryNameLabel.Location = new System.Drawing.Point(15, 23);
            this.CountryNameLabel.Name = "CountryNameLabel";
            this.CountryNameLabel.Size = new System.Drawing.Size(184, 46);
            this.CountryNameLabel.TabIndex = 0;
            this.CountryNameLabel.Text = "NoCountry";
            // 
            // AddCountryGroupBox
            // 
            this.AddCountryGroupBox.Controls.Add(this.ConfirmAddCountryButton);
            this.AddCountryGroupBox.Controls.Add(this.label7);
            this.AddCountryGroupBox.Controls.Add(this.label6);
            this.AddCountryGroupBox.Controls.Add(this.ConfTextBox);
            this.AddCountryGroupBox.Controls.Add(this.NameTextBox);
            this.AddCountryGroupBox.Controls.Add(this.label5);
            this.AddCountryGroupBox.Location = new System.Drawing.Point(272, 23);
            this.AddCountryGroupBox.Name = "AddCountryGroupBox";
            this.AddCountryGroupBox.Size = new System.Drawing.Size(480, 418);
            this.AddCountryGroupBox.TabIndex = 4;
            this.AddCountryGroupBox.TabStop = false;
            this.AddCountryGroupBox.Visible = false;
            // 
            // ConfirmAddCountryButton
            // 
            this.ConfirmAddCountryButton.Location = new System.Drawing.Point(132, 173);
            this.ConfirmAddCountryButton.Name = "ConfirmAddCountryButton";
            this.ConfirmAddCountryButton.Size = new System.Drawing.Size(171, 29);
            this.ConfirmAddCountryButton.TabIndex = 5;
            this.ConfirmAddCountryButton.Text = "Создать страну";
            this.ConfirmAddCountryButton.UseVisualStyleBackColor = true;
            this.ConfirmAddCountryButton.Click += new System.EventHandler(this.ConfirmAddCountryButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 138);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "Конфедерация:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "Название:";
            // 
            // ConfTextBox
            // 
            this.ConfTextBox.Location = new System.Drawing.Point(156, 131);
            this.ConfTextBox.Name = "ConfTextBox";
            this.ConfTextBox.Size = new System.Drawing.Size(125, 27);
            this.ConfTextBox.TabIndex = 2;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(156, 72);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(125, 27);
            this.NameTextBox.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(143, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 28);
            this.label5.TabIndex = 0;
            this.label5.Text = "Создать страну";
            // 
            // WinFormCountryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AddCountryButton);
            this.Controls.Add(this.CountryDataGridView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddCountryGroupBox);
            this.Controls.Add(this.CountryProfileGroupBox);
            this.Name = "WinFormCountryView";
            this.Text = "Страны";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WinFormCountryView_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.CountryDataGridView)).EndInit();
            this.CountryProfileGroupBox.ResumeLayout(false);
            this.CountryProfileGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TournamentDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TeamDataGridView)).EndInit();
            this.AddCountryGroupBox.ResumeLayout(false);
            this.AddCountryGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private DataGridView CountryDataGridView;
        private DataGridViewTextBoxColumn CountryName;
        private DataGridViewTextBoxColumn CountryConfederation;
        private Button AddCountryButton;
        private GroupBox CountryProfileGroupBox;
        private Label CountryNameLabel;
        private DataGridView TournamentDataGridView;
        private DataGridViewTextBoxColumn TournamentName;
        private Label label4;
        private DataGridView TeamDataGridView;
        private DataGridViewTextBoxColumn TeamName;
        private Label label3;
        private Label ConfederationLabel;
        private Label label2;
        private GroupBox AddCountryGroupBox;
        private Button ConfirmAddCountryButton;
        private Label label7;
        private Label label6;
        private TextBox ConfTextBox;
        private TextBox NameTextBox;
        private Label label5;
    }
}