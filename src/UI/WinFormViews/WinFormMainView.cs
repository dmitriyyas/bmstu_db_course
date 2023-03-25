using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Events;
using UI.ViewInterfaces;

namespace UI.WinFormViews
{
    public partial class WinFormMainView : Form, IMainFormView
    {
        public bool LogInGroupBoxVisible { get => LogInGroupBox.Visible; set => LogInGroupBox.Visible = value; }
        public bool RegisterGroupBoxVisible { get => RegisterGroupBox.Visible; set => RegisterGroupBox.Visible = value; }
        public bool StartGroupBoxVisible { get => StartGroupBox.Visible; set => StartGroupBox.Visible = value; }
        public bool LogOutGroupBoxVisible { get => LogOutGroupBox.Visible; set => LogOutGroupBox.Visible = value; }
        public string LogInLogin { get => LogInLoginTextBox.Text; set => LogInLoginTextBox.Text = value; }
        public string LogInPassword { get => LogInPasswordTextBox.Text; set => LogInPasswordTextBox.Text = value; }
        public string RegisterLogin { get => RegLoginTextBox.Text; set => RegLoginTextBox.Text = value; }
        public string RegisterPassword { get => RegPasswordTextBox.Text; set => RegPasswordTextBox.Text = value; }
        public string RegisterConfirmPassword { get => RegConfirmPasswordTextBox.Text; set => RegConfirmPasswordTextBox.Text = value; }
        public string CurrentUserLogin { set => CurrentUserLabel.Text = value; }

        public event EventHandler StartLogInClicked;
        public event EventHandler LogOutClicked;
        public event EventHandler StartRegisterClicked;
        public event EventHandler RegisterConfirmClicked;
        public event EventHandler LogInConfirmClicked;
        public event EventHandler MainFormClosed;
        public event EventHandler LogInBackClicked;
        public event EventHandler RegisterBackClicked;
        public event EventHandler<UserClickedEventArgs> UserClicked;
        public event EventHandler<CountryClickedEventArgs> CountryClicked;

        public WinFormMainView()
        {
            InitializeComponent();
        }

        private void StartLogInButton_Click(object sender, EventArgs e)
        {
            StartLogInClicked.Invoke(this, new EventArgs());
        }

        private void StartRegisterButton_Click(object sender, EventArgs e)
        {
            StartRegisterClicked.Invoke(this, new EventArgs());
        }

        private void ConfirmLogInButton_Click(object sender, EventArgs e)
        {
            LogInConfirmClicked.Invoke(this, new EventArgs());
        }

        private void ConfirmRegisterButton_Click(object sender, EventArgs e)
        {
            RegisterConfirmClicked.Invoke(this, new EventArgs());
        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            LogOutClicked.Invoke(this, new EventArgs());
        }

        private void WinFormMainView_FormClosing(object sender, FormClosingEventArgs e)
        {
            MainFormClosed.Invoke(this, new EventArgs());
        }

        private void RegisterBackButton_Click(object sender, EventArgs e)
        {
            RegisterBackClicked.Invoke(this, new EventArgs());
        }

        private void LogInBackButton_Click(object sender, EventArgs e)
        {
            LogInBackClicked.Invoke(this, new EventArgs());
        }

        private void ShowUsersButton_Click(object sender, EventArgs e)
        {
            UserClicked.Invoke(this, new UserClickedEventArgs());
        }

        private void ShowCountriesButton_Click(object sender, EventArgs e)
        {
            CountryClicked.Invoke(this, new CountryClickedEventArgs());
        }
    }
}
