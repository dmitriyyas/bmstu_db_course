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
    public partial class WinFormCountryView : Form, ICountryView
    {
        private IEnumerable<Country> _countries;
        private Country _countryProfile;
        private IEnumerable<Team> _countryTeams;
        private IEnumerable<Tournament> _countryTournaments;
        public WinFormCountryView()
        {
            InitializeComponent();
        }

        public IEnumerable<Country> Countries 
        { 
            get => _countries;
            set  
            {
                _countries = value;
                CountryDataGridView.Rows.Clear();
                foreach (var country in _countries)
                {
                    CountryDataGridView.Rows.Add(country.Name, country.Confederation);
                }
            } 
        }
        public Country CountryProfile 
        { 
            get => _countryProfile;
            set 
            {
                _countryProfile = value;
                CountryNameLabel.Text = _countryProfile.Name;
                ConfederationLabel.Text= _countryProfile.Confederation;
            } 
        }
        public IEnumerable<Team> CountryTeams 
        { 
            get => _countryTeams;
            set
            {
                _countryTeams = value;
                TeamDataGridView.Rows.Clear();
                foreach(var team in _countryTeams)
                {
                    TeamDataGridView.Rows.Add(team.Name);
                }
            }
        }
        public IEnumerable<Tournament> CountryTournaments 
        { 
            get => _countryTournaments;
            set
            {
                _countryTournaments = value;
                TournamentDataGridView.Rows.Clear();
                foreach (var tournament in _countryTournaments)
                {
                    TournamentDataGridView.Rows.Add(tournament.Name);
                }
            }
        }
        public bool CountryProfileVisible 
        { 
            get => CountryProfileGroupBox.Visible; 
            set => CountryProfileGroupBox.Visible = value;
        }
        public bool AddCountryVisible { get => AddCountryButton.Visible; set => AddCountryButton.Visible = value; }
        public bool AddCountryGroupBoxVisible
        {
            get => AddCountryGroupBox.Visible;
            set
            {
                AddCountryGroupBox.Visible = value;
                if (!value)
                {
                    NameTextBox.Text = "";
                    ConfTextBox.Text = "";
                }
            }
        }
        public string NewCountryName { get => NameTextBox.Text; set => NameTextBox.Text = value; }
        public string NewCountryConfederation { get => ConfTextBox.Text; set => ConfTextBox.Text = value; }

        public event EventHandler<TeamClickedEventArgs> TeamClicked;
        public event EventHandler<TournamentClickedEventArgs> TournamentClicked;
        public event EventHandler<CountryClickedEventArgs> CountryClicked;
        public event EventHandler AddCountryClicked;
        public event EventHandler ConfirmAddCountryClicked;
        public event EventHandler CountryFormClosed;

        private void WinFormCountryView_FormClosing(object sender, FormClosingEventArgs e)
        {
            CountryFormClosed?.Invoke(this, e);
        }

        private void CountryDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CountryDataGridView.Columns[e.ColumnIndex].Name == "CountryName")
            {
                string name = (string)CountryDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                CountryClicked?.Invoke(this, new CountryClickedEventArgs { country = Countries.FirstOrDefault(c => c.Name == name) });
            }
        }

        private void AddCountryButton_Click(object sender, EventArgs e)
        {
            AddCountryClicked?.Invoke(this, e);
        }

        private void ConfirmAddCountryButton_Click(object sender, EventArgs e)
        {
            ConfirmAddCountryClicked?.Invoke(this, e);
        }

        private void TeamDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string name = (string)TeamDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            TeamClicked?.Invoke(this, new TeamClickedEventArgs { team = CountryTeams.FirstOrDefault(t => t.Name == name) });
        }

        private void TournamentDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string name = (string)TournamentDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            TournamentClicked?.Invoke(this, new TournamentClickedEventArgs { tournament = CountryTournaments.FirstOrDefault(t => t.Name == name) });
        }
    }
}
