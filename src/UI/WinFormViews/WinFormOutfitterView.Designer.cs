namespace UI.WinFormViews
{
    partial class WinFormOutfitterView
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
            this.OutfitterDataGridView = new System.Windows.Forms.DataGridView();
            this.OutfitterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OutfitterYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.AddOutfitterButton = new System.Windows.Forms.Button();
            this.OutfitterProfileGroupBox = new System.Windows.Forms.GroupBox();
            this.OutfitterYearLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TeamDataGridView = new System.Windows.Forms.DataGridView();
            this.TournamentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.OutfitterNameLabel = new System.Windows.Forms.Label();
            this.AddOutfitterGroupBox = new System.Windows.Forms.GroupBox();
            this.ConfirmAddOutfitterButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.YearTextBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.OutfitterDataGridView)).BeginInit();
            this.OutfitterProfileGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TeamDataGridView)).BeginInit();
            this.AddOutfitterGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // OutfitterDataGridView
            // 
            this.OutfitterDataGridView.AllowUserToAddRows = false;
            this.OutfitterDataGridView.AllowUserToDeleteRows = false;
            this.OutfitterDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OutfitterDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OutfitterName,
            this.OutfitterYear});
            this.OutfitterDataGridView.Location = new System.Drawing.Point(25, 66);
            this.OutfitterDataGridView.Name = "OutfitterDataGridView";
            this.OutfitterDataGridView.ReadOnly = true;
            this.OutfitterDataGridView.RowHeadersVisible = false;
            this.OutfitterDataGridView.RowHeadersWidth = 51;
            this.OutfitterDataGridView.RowTemplate.Height = 29;
            this.OutfitterDataGridView.Size = new System.Drawing.Size(279, 344);
            this.OutfitterDataGridView.TabIndex = 2;
            this.OutfitterDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OutfitterDataGridView_CellClick);
            // 
            // OutfitterName
            // 
            this.OutfitterName.HeaderText = "Название";
            this.OutfitterName.MinimumWidth = 6;
            this.OutfitterName.Name = "OutfitterName";
            this.OutfitterName.ReadOnly = true;
            this.OutfitterName.Width = 125;
            // 
            // OutfitterYear
            // 
            this.OutfitterYear.HeaderText = "Год основания";
            this.OutfitterYear.MinimumWidth = 6;
            this.OutfitterYear.Name = "OutfitterYear";
            this.OutfitterYear.ReadOnly = true;
            this.OutfitterYear.Width = 150;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Спонсоры";
            // 
            // AddOutfitterButton
            // 
            this.AddOutfitterButton.Location = new System.Drawing.Point(25, 416);
            this.AddOutfitterButton.Name = "AddOutfitterButton";
            this.AddOutfitterButton.Size = new System.Drawing.Size(279, 29);
            this.AddOutfitterButton.TabIndex = 4;
            this.AddOutfitterButton.Text = "Создать спонсора";
            this.AddOutfitterButton.UseVisualStyleBackColor = true;
            this.AddOutfitterButton.Visible = false;
            this.AddOutfitterButton.Click += new System.EventHandler(this.AddOutfitterButton_Click);
            // 
            // OutfitterProfileGroupBox
            // 
            this.OutfitterProfileGroupBox.Controls.Add(this.OutfitterYearLabel);
            this.OutfitterProfileGroupBox.Controls.Add(this.label4);
            this.OutfitterProfileGroupBox.Controls.Add(this.TeamDataGridView);
            this.OutfitterProfileGroupBox.Controls.Add(this.label3);
            this.OutfitterProfileGroupBox.Controls.Add(this.OutfitterNameLabel);
            this.OutfitterProfileGroupBox.Location = new System.Drawing.Point(342, 12);
            this.OutfitterProfileGroupBox.Name = "OutfitterProfileGroupBox";
            this.OutfitterProfileGroupBox.Size = new System.Drawing.Size(404, 433);
            this.OutfitterProfileGroupBox.TabIndex = 5;
            this.OutfitterProfileGroupBox.TabStop = false;
            this.OutfitterProfileGroupBox.Visible = false;
            // 
            // OutfitterYearLabel
            // 
            this.OutfitterYearLabel.AutoSize = true;
            this.OutfitterYearLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OutfitterYearLabel.Location = new System.Drawing.Point(175, 113);
            this.OutfitterYearLabel.Name = "OutfitterYearLabel";
            this.OutfitterYearLabel.Size = new System.Drawing.Size(75, 28);
            this.OutfitterYearLabel.TabIndex = 7;
            this.OutfitterYearLabel.Text = "NoYear";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(16, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 28);
            this.label4.TabIndex = 6;
            this.label4.Text = "Год основания:";
            // 
            // TeamDataGridView
            // 
            this.TeamDataGridView.AllowUserToAddRows = false;
            this.TeamDataGridView.AllowUserToDeleteRows = false;
            this.TeamDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TeamDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TournamentName});
            this.TeamDataGridView.Location = new System.Drawing.Point(16, 181);
            this.TeamDataGridView.Name = "TeamDataGridView";
            this.TeamDataGridView.ReadOnly = true;
            this.TeamDataGridView.RowHeadersVisible = false;
            this.TeamDataGridView.RowHeadersWidth = 51;
            this.TeamDataGridView.RowTemplate.Height = 29;
            this.TeamDataGridView.Size = new System.Drawing.Size(129, 239);
            this.TeamDataGridView.TabIndex = 5;
            this.TeamDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TeamDataGridView_CellClick);
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
            this.label3.Location = new System.Drawing.Point(16, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 28);
            this.label3.TabIndex = 4;
            this.label3.Text = "Команды";
            // 
            // OutfitterNameLabel
            // 
            this.OutfitterNameLabel.AutoSize = true;
            this.OutfitterNameLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OutfitterNameLabel.Location = new System.Drawing.Point(16, 51);
            this.OutfitterNameLabel.Name = "OutfitterNameLabel";
            this.OutfitterNameLabel.Size = new System.Drawing.Size(195, 46);
            this.OutfitterNameLabel.TabIndex = 1;
            this.OutfitterNameLabel.Text = "NoOutfitter";
            // 
            // AddOutfitterGroupBox
            // 
            this.AddOutfitterGroupBox.Controls.Add(this.ConfirmAddOutfitterButton);
            this.AddOutfitterGroupBox.Controls.Add(this.label7);
            this.AddOutfitterGroupBox.Controls.Add(this.label6);
            this.AddOutfitterGroupBox.Controls.Add(this.YearTextBox);
            this.AddOutfitterGroupBox.Controls.Add(this.NameTextBox);
            this.AddOutfitterGroupBox.Controls.Add(this.label5);
            this.AddOutfitterGroupBox.Location = new System.Drawing.Point(328, 25);
            this.AddOutfitterGroupBox.Name = "AddOutfitterGroupBox";
            this.AddOutfitterGroupBox.Size = new System.Drawing.Size(460, 433);
            this.AddOutfitterGroupBox.TabIndex = 6;
            this.AddOutfitterGroupBox.TabStop = false;
            this.AddOutfitterGroupBox.Visible = false;
            // 
            // ConfirmAddOutfitterButton
            // 
            this.ConfirmAddOutfitterButton.Location = new System.Drawing.Point(147, 178);
            this.ConfirmAddOutfitterButton.Name = "ConfirmAddOutfitterButton";
            this.ConfirmAddOutfitterButton.Size = new System.Drawing.Size(171, 29);
            this.ConfirmAddOutfitterButton.TabIndex = 10;
            this.ConfirmAddOutfitterButton.Text = "Создать спонсора";
            this.ConfirmAddOutfitterButton.UseVisualStyleBackColor = true;
            this.ConfirmAddOutfitterButton.Click += new System.EventHandler(this.ConfirmAddOutfitterButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(44, 143);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 20);
            this.label7.TabIndex = 9;
            this.label7.Text = "Год основания:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Название:";
            // 
            // YearTextBox
            // 
            this.YearTextBox.Location = new System.Drawing.Point(171, 136);
            this.YearTextBox.Name = "YearTextBox";
            this.YearTextBox.Size = new System.Drawing.Size(125, 27);
            this.YearTextBox.TabIndex = 7;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(171, 77);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(125, 27);
            this.NameTextBox.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(144, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(177, 28);
            this.label5.TabIndex = 1;
            this.label5.Text = "Создать спонсора";
            // 
            // WinFormOutfitterView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 464);
            this.Controls.Add(this.AddOutfitterButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OutfitterDataGridView);
            this.Controls.Add(this.OutfitterProfileGroupBox);
            this.Controls.Add(this.AddOutfitterGroupBox);
            this.Name = "WinFormOutfitterView";
            this.Text = "Спонсоры";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WinFormOutfitterView_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.OutfitterDataGridView)).EndInit();
            this.OutfitterProfileGroupBox.ResumeLayout(false);
            this.OutfitterProfileGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TeamDataGridView)).EndInit();
            this.AddOutfitterGroupBox.ResumeLayout(false);
            this.AddOutfitterGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView OutfitterDataGridView;
        private DataGridViewTextBoxColumn OutfitterName;
        private DataGridViewTextBoxColumn OutfitterYear;
        private Label label1;
        private Button AddOutfitterButton;
        private GroupBox OutfitterProfileGroupBox;
        private Label OutfitterNameLabel;
        private Label label3;
        private DataGridView TeamDataGridView;
        private DataGridViewTextBoxColumn TournamentName;
        private GroupBox AddOutfitterGroupBox;
        private Label OutfitterYearLabel;
        private Label label4;
        private Label label5;
        private Button ConfirmAddOutfitterButton;
        private Label label7;
        private Label label6;
        private TextBox YearTextBox;
        private TextBox NameTextBox;
    }
}