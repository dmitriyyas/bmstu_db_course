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
using System.Diagnostics;

namespace UI.WinFormViews
{
    public partial class WinFormTournamentView : Form, ITournamentView
    {
        private IEnumerable<Tournament> _tournaments;
        private Tournament _tournamentProfile;
        private IEnumerable<Country> _countries;
        private IEnumerable<Match> _tournamentMatches;
        private List<Team> _newTournamentTeams = new List<Team>();
        private IEnumerable<TeamStatistics> _table;
        private IEnumerable<Team> _teams;
        private IEnumerable<Team> _tournamentTeams;
        public WinFormTournamentView()
        {
            InitializeComponent();
        }

        public IEnumerable<Tournament> Tournaments 
        { 
            get => _tournaments;
            set
            {
                _tournaments = value.OrderBy(t => t.Name);
                TournamentsDataGridView.Rows.Clear();
                foreach(var tournament in _tournaments)
                {
                    var country = Countries.FirstOrDefault(c => c.Id == tournament.CountryId);
                    var user = Users.FirstOrDefault(u => u.Id == tournament.UserId);
                    TournamentsDataGridView.Rows.Add(tournament.Name, country?.Name, user?.Login);
                }
            }
        }
        public Tournament TournamentProfile 
        { 
            get => _tournamentProfile;
            set
            {
                _tournamentProfile = value;
                NameLabel.Text = value.Name;
                CountryLinkLabel.Text = Countries.FirstOrDefault(c => c.Id == value.CountryId)?.Name;
                UserLinkLabel.Text = Users.FirstOrDefault(u => u.Id == value.UserId)?.Login;
            } 
        }
        public IEnumerable<Team> TournamentTeams { get => _tournamentTeams; set => _tournamentTeams = value.OrderBy(t => t.Name); }
        public IEnumerable<Country> Countries
        {
            get => _countries;
            set
            {
                _countries = value.OrderBy(t => t.Name);
                CountryComboBox.Items.Clear();
                foreach(var country in _countries)
                {
                    CountryComboBox.Items.Add(country.Name);
                }
            }
        }
        public IEnumerable<Match> TournamentMatches
        {
            get => _tournamentMatches;
            set
            {
                _tournamentMatches = value;
                MatchesDataGridView.Rows.Clear();
                MatchesDataGridView.Columns.Clear();
                foreach (var team in TournamentTeams)
                {
                    MatchesDataGridView.Columns.Add(team.Name, team.Name);
                    int index = MatchesDataGridView.Rows.Add();
                    MatchesDataGridView.Rows[index].HeaderCell.Value = team.Name;
                }
                foreach (var match in value)
                {
                    string homeTeam = TournamentTeams.FirstOrDefault(t => t.Id == match.HomeTeamId).Name;
                    string guestTeam = TournamentTeams.FirstOrDefault(t => t.Id == match.GuestTeamId).Name;
                    int column = MatchesDataGridView.Columns[guestTeam].Index;
                    int row = MatchesDataGridView.Columns[homeTeam].Index;
                    MatchesDataGridView.Rows[row].Cells[column].Value = $"{match.HomeGoals}:{match.GuestGoals}";
                }
                for (int i = 0; i < MatchesDataGridView.Rows.Count; i++)
                {
                    MatchesDataGridView.Rows[i].Cells[i].Value = "---";
                }
                foreach (DataGridViewColumn col in MatchesDataGridView.Columns)
                {
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
        }
        public IEnumerable<User> Users { get; set; }
        public bool TournamentProfileVisible { get => TournamentProfileGroupBox.Visible; set => TournamentProfileGroupBox.Visible = value; }
        public bool AddTournamentGroupBoxVisible { get => AddTournamentGroupBox.Visible; set => AddTournamentGroupBox.Visible = value; }
        public bool AddTournamentVisible { get => CreateTournamentButton.Visible; set => CreateTournamentButton.Visible = value; }
        public bool MatchesVisible 
        {
            get
            {
                return MatchesDataGridView.Visible;
            }
            set 
            {
                MatchesDataGridView.Visible = value;
                ShowTableButton.Visible = value;
            }  
        }
        public bool TableVisible 
        {
            get
            {
                return TableDataGridView.Visible;
            }
            set
            {
                TableDataGridView.Visible = value;
                ShowMatchesButton.Visible = value;
            }
        }

        public bool DeleteTournamentVisible { get => DeleteTournamentButton.Visible; set => DeleteTournamentButton.Visible = value; }
        public string NewTournamentName { get => NameTextBox.Text; set => NameTextBox.Text = value; }
        public string NewTournamentCountry { get => CountryComboBox.Text; set => CountryComboBox.Text = value; }

        public string NewTeamName { get => TeamComboBox.Text; set => TeamComboBox.Text = value; }

        public string? SelectedTeamName { get => TeamDataGridView.SelectedCells?[0].Value.ToString(); }
        public List<Team> NewTournamentTeams
        {
            get => _newTournamentTeams;
            set
            {
                _newTournamentTeams = value;
                TeamDataGridView.Rows.Clear();
                foreach(var team in value)
                {
                    TeamDataGridView.Rows.Add(team.Name);
                }
            }
        }
        public IEnumerable<TeamStatistics> Table
        {
            get => _table;
            set 
            { 
                _table = value;
                TableDataGridView.Rows.Clear();
                int i = 1;
                foreach (var row in _table)
                {
                    TableDataGridView.Rows.Add(i, row.Name, row.Matches, row.Wins, row.Draws, row.Loses, row.GoalsScored, row.GoalsConceded, row.Points);
                    ++i;
                }
            }
        }

        public IEnumerable<Team> Teams
        {
            get => _teams;
            set
            {
                _teams = value.OrderBy(t => t.Name);
                TeamComboBox.Items.Clear();
                foreach (var team in _teams)
                {
                    TeamComboBox.Items.Add(team.Name);
                }
            }
        }
        public event EventHandler<TournamentClickedEventArgs> TournamentClicked;
        public event EventHandler<CountryClickedEventArgs> CountryClicked;
        public event EventHandler<UserClickedEventArgs> UserClicked;
        public event EventHandler<MatchClickedEventArgs> MatchClicked;
        public event EventHandler<TeamClickedEventArgs> TeamClicked;
        public event EventHandler<NotExistedMatchEventArgs> NotExistedMatchClicked;
        public event EventHandler AddTournamentClicked;
        public event EventHandler DeleteTournamentClicked;
        public event EventHandler ConfirmTournamentClicked;
        public event EventHandler AddTeamToNewClicked;
        public event EventHandler DeleteTeamFromNewClicked;
        public event EventHandler TournamentFormClosed;
        public event EventHandler ShowMatchesClicked;
        public event EventHandler ShowTableClicked;

        private void WinFormTournamentView_FormClosing(object sender, FormClosingEventArgs e)
        {
            TournamentFormClosed?.Invoke(this, new EventArgs());
        }

        private void ConfirmAddTournamentButton_Click(object sender, EventArgs e)
        {
            ConfirmTournamentClicked?.Invoke(this, new EventArgs());
        }

        private void DeleteTeamButton_Click(object sender, EventArgs e)
        {
            DeleteTeamFromNewClicked?.Invoke(this, new EventArgs());
        }

        private void AddTeamButton_Click(object sender, EventArgs e)
        {
            AddTeamToNewClicked?.Invoke(this, new EventArgs());
        }

        private void CreateTournamentButton_Click(object sender, EventArgs e)
        {
            AddTournamentClicked?.Invoke(this, new EventArgs());
        }

        private void ShowMatchesButton_Click(object sender, EventArgs e)
        {
            ShowMatchesClicked?.Invoke(this, new EventArgs());
        }

        private void ShowTableButton_Click(object sender, EventArgs e)
        {
            ShowTableClicked?.Invoke(this, new EventArgs());
        }

        private void CountryLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CountryClicked?.Invoke(this, new CountryClickedEventArgs { country = Countries.FirstOrDefault(c => c.Name == CountryLinkLabel.Text) });
        }

        private void UserLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UserClicked?.Invoke(this, new UserClickedEventArgs { user = Users.FirstOrDefault(u => u.Login == UserLinkLabel.Text) });
        }

        private void TableDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (TableDataGridView.Columns[e.ColumnIndex].Name == "TeamName" && e.RowIndex != -1)
            {
                string name = (string)TableDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                TeamClicked?.Invoke(this, new TeamClickedEventArgs { team = TournamentTeams.FirstOrDefault(t => t.Name == name) });
            }
        }

        private void TournamentsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (TournamentsDataGridView.Columns[e.ColumnIndex].Name == "TournamentName")
            {
                string name = (string)TournamentsDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                TournamentClicked?.Invoke(this, new TournamentClickedEventArgs { tournament = Tournaments.FirstOrDefault(t => t.Name == name) });
            }
            else if (TournamentsDataGridView.Columns[e.ColumnIndex].Name == "CountryName")
            {
                string name = (string)TournamentsDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                CountryClicked?.Invoke(this, new CountryClickedEventArgs { country = Countries.FirstOrDefault(c => c.Name == name) });
            }
            else
            {
                string name = (string)TournamentsDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                UserClicked?.Invoke(this, new UserClickedEventArgs { user = Users.FirstOrDefault(u => u.Login == name) });
            }
        }

        private void MatchesDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex != -1)
            {
                string name = MatchesDataGridView.Columns[e.ColumnIndex].Name;
                TeamClicked?.Invoke(this, new TeamClickedEventArgs { team = TournamentTeams.FirstOrDefault(t => t.Name == name) });

            }
            else if (e.RowIndex != -1 && e.ColumnIndex == -1)
            {
                string name = (string)MatchesDataGridView.Rows[e.RowIndex].HeaderCell.Value;
                TeamClicked?.Invoke(this, new TeamClickedEventArgs { team = TournamentTeams.FirstOrDefault(t => t.Name == name) });
            }
            else if (e.ColumnIndex != e.RowIndex)
            {
                string hostName = (string)MatchesDataGridView.Rows[e.RowIndex].HeaderCell.Value;
                string guestName = MatchesDataGridView.Columns[e.ColumnIndex].Name;
                Team host = TournamentTeams.FirstOrDefault(t => t.Name == hostName);
                Team guest = TournamentTeams.FirstOrDefault(t => t.Name == guestName);
                var match = TournamentMatches.FirstOrDefault(t => t.HomeTeamId == host.Id && t.GuestTeamId == guest.Id);
                if (match != null)
                    MatchClicked?.Invoke(this, new MatchClickedEventArgs { match = match });
                else
                    NotExistedMatchClicked?.Invoke(this, new NotExistedMatchEventArgs { tournament = TournamentProfile, hostTeam = host, guestTeam = guest});
            }
        }

        private void DeleteTournamentButton_Click(object sender, EventArgs e)
        {
            DeleteTournamentClicked?.Invoke(this, e);
        }
    }
}
