using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.WinFormViews
{
    public partial class WinFormMainView : Form
    {
        public WinFormMainView()
        {
            InitializeComponent();
        }

        private void StartLogInButton_Click(object sender, EventArgs e)
        {
            LogInGroupBox.Visible = true;
            StartGroupBox.Visible = false;
        }

        private void StartRegisterButton_Click(object sender, EventArgs e)
        {
            RegisterGroupBox.Visible = true;
            StartGroupBox.Visible = false;
        }

        private void ConfirmLogInButton_Click(object sender, EventArgs e)
        {
            LogInGroupBox.Visible = false;
            LogOutGroupBox.Visible = true;
        }

        private void ConfirmRegisterButton_Click(object sender, EventArgs e)
        {
            RegisterGroupBox.Visible = false;
            LogOutGroupBox.Visible = true;
        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            LogOutGroupBox.Visible = false;
            StartGroupBox.Visible = true;
        }
    }
}
