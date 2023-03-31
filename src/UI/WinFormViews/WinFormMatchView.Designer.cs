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
            this.label1 = new System.Windows.Forms.Label();
            this.CreateMatchButton = new System.Windows.Forms.Button();
            this.UpdateMatchButton = new System.Windows.Forms.Button();
            this.DeleteMatchButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // HomeLinkLabel
            // 
            this.HomeLinkLabel.AutoSize = true;
            this.HomeLinkLabel.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.HomeLinkLabel.Location = new System.Drawing.Point(114, 59);
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
            this.GuestLinkLabel.Location = new System.Drawing.Point(496, 59);
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
            this.HomeGoalsTextBox.Location = new System.Drawing.Point(289, 53);
            this.HomeGoalsTextBox.Name = "HomeGoalsTextBox";
            this.HomeGoalsTextBox.Size = new System.Drawing.Size(81, 52);
            this.HomeGoalsTextBox.TabIndex = 2;
            // 
            // GuestGoalsTextBox
            // 
            this.GuestGoalsTextBox.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.GuestGoalsTextBox.Location = new System.Drawing.Point(409, 53);
            this.GuestGoalsTextBox.Name = "GuestGoalsTextBox";
            this.GuestGoalsTextBox.Size = new System.Drawing.Size(81, 52);
            this.GuestGoalsTextBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(376, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 46);
            this.label1.TabIndex = 4;
            this.label1.Text = ":";
            // 
            // CreateMatchButton
            // 
            this.CreateMatchButton.Location = new System.Drawing.Point(322, 153);
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
            this.UpdateMatchButton.Location = new System.Drawing.Point(238, 190);
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
            this.DeleteMatchButton.Location = new System.Drawing.Point(409, 190);
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
            this.ClientSize = new System.Drawing.Size(800, 246);
            this.Controls.Add(this.DeleteMatchButton);
            this.Controls.Add(this.UpdateMatchButton);
            this.Controls.Add(this.CreateMatchButton);
            this.Controls.Add(this.label1);
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
        private Label label1;
        private Button CreateMatchButton;
        private Button UpdateMatchButton;
        private Button DeleteMatchButton;
    }
}