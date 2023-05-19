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
using UI.Events;
using UI.ViewInterfaces;

namespace UI.WinFormViews
{
    public partial class WinFormTeamView : Form, ITeamView
    {
        private IEnumerable<Team> _teams;
        private Team _teamProfile;
        private IEnumerable<Tournament> _teamTournaments;
        private IEnumerable<Country> _countries;
        private IEnumerable<Outfitter> _outfitters;
        public WinFormTeamView()
        {
            InitializeComponent();
        }

        public IEnumerable<Team> Teams
        {
            get => _teams;
            set
            {
                _teams = value.OrderBy(t => t.Name);
                TeamDataGridView.Rows.Clear();
                foreach(var team in _teams)
                {
                    string? country = Countries.FirstOrDefault(c => c.Id == team.CountryId)?.Name;
                    TeamDataGridView.Rows.Add(team.Name, country);
                }
            }
        }
        public Team TeamProfile
        {
            get => _teamProfile;
            set
            {
                _teamProfile = value;
                TeamNameLabel.Text = value.Name;
                TeamCountryLinkLabel.Text = Countries.FirstOrDefault(c => c.Id == _teamProfile.CountryId)?.Name;
                if (value.OutfitterId != null)
                {
                    TeamOutfitterLinkLabel.Text = Outfitters.FirstOrDefault(o => o.Id == _teamProfile.OutfitterId)?.Name;
                }
                else
                    TeamOutfitterLinkLabel.Text = "";
            }
        }
        public IEnumerable<Tournament> TeamTournaments
        {
            get => _teamTournaments;
            set
            {
                _teamTournaments = value.OrderBy(t => t.Name);
                TournamentDataGridView.Rows.Clear();
                foreach(var tournament in _teamTournaments)
                {
                    TournamentDataGridView.Rows.Add(tournament.Name);
                }
            }
        }
        public IEnumerable<Country> Countries
        {
            get => _countries;
            set
            {
                _countries = value.OrderBy(t => t.Name);
                CountryComboBox.Items.Clear();
                foreach (var country in _countries)
                {
                    CountryComboBox.Items.Add(country.Name);
                }
            }
        }

        public IEnumerable<Outfitter> Outfitters
        {
            get => _outfitters;
            set
            {
                _outfitters = value.OrderBy(t => t.Name);
                OutfitterComboBox.Items.Clear();
                foreach (var outfitter in _outfitters)
                {
                    OutfitterComboBox.Items.Add(outfitter.Name);
                }
            }
        }

        public bool TeamProfileVisible { get => TeamProfileGroupBox.Visible; set => TeamProfileGroupBox.Visible = value; }
        public bool AddTeamGroupBoxVisible { get => AddTeamGroupBox.Visible; set => AddTeamGroupBox.Visible = value; }
        public bool AddTeamVisible { get => AddTeamButton.Visible; set => AddTeamButton.Visible = value; }
        public string NewTeamName { get => NameTextBox.Text; set => NameTextBox.Text = value; }
        public string NewTeamCountry { get => CountryComboBox.Text; set => CountryComboBox.Text = value; }
        public string NewTeamOutfitter { get => OutfitterComboBox.Text; set => OutfitterComboBox.Text = value; }

        public event EventHandler<TeamClickedEventArgs> TeamClicked;
        public event EventHandler<TournamentClickedEventArgs> TournamentClicked;
        public event EventHandler<CountryClickedEventArgs> CountryClicked;
        public event EventHandler<OutfitterClickedEventArgs> OutfitterClicked;
        public event EventHandler AddTeamClicked;
        public event EventHandler ConfirmTeamClicked;
        public event EventHandler TeamFormClosed;
        

        private void AddTeamButton_Click(object sender, EventArgs e)
        {
            AddTeamClicked.Invoke(this, e);
        }

        private void TeamCountryLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CountryClicked.Invoke(this, new CountryClickedEventArgs { country = Countries.FirstOrDefault(c => c.Name == TeamCountryLinkLabel.Text) });
        }

        private void TournamentDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string name = (string)TournamentDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            TournamentClicked.Invoke(this, new TournamentClickedEventArgs { tournament = TeamTournaments.FirstOrDefault(t => t.Name == name) });
        }

        private void TeamDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (TeamDataGridView.Columns[e.ColumnIndex].Name == "TeamName")
            {
                string name = (string)TeamDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                TeamClicked.Invoke(this, new TeamClickedEventArgs { team = Teams.FirstOrDefault(t => t.Name == name) });
            }
            else
            {
                string name = (string)TeamDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                CountryClicked.Invoke(this, new CountryClickedEventArgs { country = Countries.FirstOrDefault(c => c.Name == name) });
            }
        }

        private void ConfirmAddTeamButton_Click(object sender, EventArgs e)
        {
            ConfirmTeamClicked.Invoke(this, e);
        }

        private void WinFormTeamView_FormClosing(object sender, FormClosingEventArgs e)
        {
            TeamFormClosed?.Invoke(this, new EventArgs());
        }

        private void TeamOutfitterLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OutfitterClicked.Invoke(this, new OutfitterClickedEventArgs { outfitter = Outfitters.FirstOrDefault(c => c.Name == TeamOutfitterLinkLabel.Text) });
        }
    }
}
