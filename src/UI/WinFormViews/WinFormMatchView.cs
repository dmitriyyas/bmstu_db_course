using BL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.ViewInterfaces;
using UI.Events;


namespace UI.WinFormViews
{
    public partial class WinFormMatchView : Form, IMatchView
    {
        private Match _matchProfile;
        private Team _home;
        private Team _guest;
        public WinFormMatchView()
        {
            InitializeComponent();
        }

        public Match MatchProfile 
        { 
            get => _matchProfile;
            set
            {
                _matchProfile = value;
                HomeGoals = _matchProfile.HomeGoals.ToString();
                GuestGoals = _matchProfile.GuestGoals.ToString();
            }
        }

        public Tournament MatchTournament { get; set; }
        public Team Home
        {
            get => _home;
            set
            {
                _home = value;
                HomeLinkLabel.Text = Home.Name;
            }
        }
        public Team Guest
        {
            get => _guest;
            set
            {
                _guest = value;
                GuestLinkLabel.Text = Guest.Name;
            }
        }
        public string HomeGoals { get => HomeGoalsTextBox.Text; set => HomeGoalsTextBox.Text = value; }
        public string GuestGoals { get => GuestGoalsTextBox.Text; set => GuestGoalsTextBox.Text = value; }
        public bool GoalsEnabled
        {
            get => HomeGoalsTextBox.Enabled;
            set
            {
                HomeGoalsTextBox.Enabled = value;
                GuestGoalsTextBox.Enabled = value;
            }
        }
        public bool CreateMatchVisible { get => CreateMatchButton.Visible; set => CreateMatchButton.Visible = value; }
        public bool EditMatchVisible
        {
            get => UpdateMatchButton.Visible;
            set
            {
                UpdateMatchButton.Visible = value;
                DeleteMatchButton.Visible = value;
            }
        }

        public event EventHandler<TeamClickedEventArgs> TeamClicked;
        public event EventHandler MatchFormClosed;
        public event EventHandler CreateMatchClicked;
        public event EventHandler UpdateMatchClicked;
        public event EventHandler DeleteMatchClicked;

        private void WinFormMatchView_FormClosing(object sender, FormClosingEventArgs e)
        {
            MatchFormClosed?.Invoke(this, new EventArgs());
        }

        private void HomeLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TeamClicked?.Invoke(this, new TeamClickedEventArgs { team = _home });
        }

        private void GuestLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TeamClicked?.Invoke(this, new TeamClickedEventArgs { team = _guest });
        }

        private void CreateMatchButton_Click(object sender, EventArgs e)
        {
            CreateMatchClicked?.Invoke(sender, new EventArgs());
        }

        private void UpdateMatchButton_Click(object sender, EventArgs e)
        {
            UpdateMatchClicked?.Invoke(sender, new EventArgs());
        }

        private void DeleteMatchButton_Click(object sender, EventArgs e)
        {
            DeleteMatchClicked?.Invoke(this, new EventArgs());
        }
    }
}
