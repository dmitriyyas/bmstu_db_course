namespace UI.WinFormViews
{
    partial class WinFormMatchView
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
            this.HomeLinkLabel = new System.Windows.Forms.LinkLabel();
            this.GuestLinkLabel = new System.Windows.Forms.LinkLabel();
            this.HomeGoalsTextBox = new System.Windows.Forms.TextBox();
            this.GuestGoalsTextBox = new System.Windows.Forms.TextBox();
            this.CreateMatchButton = new System.Windows.Forms.Button();
            this.UpdateMatchButton = new System.Windows.Forms.Button();
            this.DeleteMatchButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // HomeLinkLabel
            // 
            this.HomeLinkLabel.AutoSize = true;
            this.HomeLinkLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HomeLinkLabel.Location = new System.Drawing.Point(247, 20);
            this.HomeLinkLabel.Name = "HomeLinkLabel";
            this.HomeLinkLabel.Size = new System.Drawing.Size(169, 46);
            this.HomeLinkLabel.TabIndex = 0;
            this.HomeLinkLabel.TabStop = true;
            this.HomeLinkLabel.Text = "linkLabel1";
            this.HomeLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.HomeLinkLabel_LinkClicked);
            // 
            // GuestLinkLabel
            // 
            this.GuestLinkLabel.AutoSize = true;
            this.GuestLinkLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GuestLinkLabel.Location = new System.Drawing.Point(247, 84);
            this.GuestLinkLabel.Name = "GuestLinkLabel";
            this.GuestLinkLabel.Size = new System.Drawing.Size(169, 46);
            this.GuestLinkLabel.TabIndex = 1;
            this.GuestLinkLabel.TabStop = true;
            this.GuestLinkLabel.Text = "linkLabel2";
            this.GuestLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.GuestLinkLabel_LinkClicked);
            // 
            // HomeGoalsTextBox
            // 
            this.HomeGoalsTextBox.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HomeGoalsTextBox.Location = new System.Drawing.Point(113, 14);
            this.HomeGoalsTextBox.Name = "HomeGoalsTextBox";
            this.HomeGoalsTextBox.Size = new System.Drawing.Size(81, 52);
            this.HomeGoalsTextBox.TabIndex = 2;
            // 
            // GuestGoalsTextBox
            // 
            this.GuestGoalsTextBox.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GuestGoalsTextBox.Location = new System.Drawing.Point(113, 84);
            this.GuestGoalsTextBox.Name = "GuestGoalsTextBox";
            this.GuestGoalsTextBox.Size = new System.Drawing.Size(81, 52);
            this.GuestGoalsTextBox.TabIndex = 3;
            // 
            // CreateMatchButton
            // 
            this.CreateMatchButton.Location = new System.Drawing.Point(197, 155);
            this.CreateMatchButton.Name = "CreateMatchButton";
            this.CreateMatchButton.Size = new System.Drawing.Size(132, 29);
            this.CreateMatchButton.TabIndex = 5;
            this.CreateMatchButton.Text = "Создать матч";
            this.CreateMatchButton.UseVisualStyleBackColor = true;
            this.CreateMatchButton.Visible = false;
            this.CreateMatchButton.Click += new System.EventHandler(this.CreateMatchButton_Click);
            // 
            // UpdateMatchButton
            // 
            this.UpdateMatchButton.Location = new System.Drawing.Point(113, 192);
            this.UpdateMatchButton.Name = "UpdateMatchButton";
            this.UpdateMatchButton.Size = new System.Drawing.Size(132, 29);
            this.UpdateMatchButton.TabIndex = 6;
            this.UpdateMatchButton.Text = "Сохранить матч";
            this.UpdateMatchButton.UseVisualStyleBackColor = true;
            this.UpdateMatchButton.Visible = false;
            this.UpdateMatchButton.Click += new System.EventHandler(this.UpdateMatchButton_Click);
            // 
            // DeleteMatchButton
            // 
            this.DeleteMatchButton.Location = new System.Drawing.Point(284, 192);
            this.DeleteMatchButton.Name = "DeleteMatchButton";
            this.DeleteMatchButton.Size = new System.Drawing.Size(132, 29);
            this.DeleteMatchButton.TabIndex = 7;
            this.DeleteMatchButton.Text = "Удалить матч";
            this.DeleteMatchButton.UseVisualStyleBackColor = true;
            this.DeleteMatchButton.Visible = false;
            this.DeleteMatchButton.Click += new System.EventHandler(this.DeleteMatchButton_Click);
            // 
            // WinFormMatchView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 246);
            this.Controls.Add(this.DeleteMatchButton);
            this.Controls.Add(this.UpdateMatchButton);
            this.Controls.Add(this.CreateMatchButton);
            this.Controls.Add(this.GuestGoalsTextBox);
            this.Controls.Add(this.HomeGoalsTextBox);
            this.Controls.Add(this.GuestLinkLabel);
            this.Controls.Add(this.HomeLinkLabel);
            this.Name = "WinFormMatchView";
            this.Text = "Матч";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WinFormMatchView_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LinkLabel HomeLinkLabel;
        private LinkLabel GuestLinkLabel;
        private TextBox HomeGoalsTextBox;
        private TextBox GuestGoalsTextBox;
        private Button CreateMatchButton;
        private Button UpdateMatchButton;
        private Button DeleteMatchButton;
    }
}