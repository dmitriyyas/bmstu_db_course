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
    public partial class WinFormUserView : Form, IUserView
    {
        public WinFormUserView()
        {
            InitializeComponent();
        }

        private IEnumerable<User> _users;
        private User _userProfile;
        private IEnumerable<Tournament> _userTournaments;

        public IEnumerable<User> Users 
        {   
            get => _users;
            
            set 
            {
                _users = value;
                UsersDataGridView.Rows.Clear();
                foreach (var user in value)
                {
                    UsersDataGridView.Rows.Add(user.Login, user.Permission);
                }
            }
        }
        public User UserProfile 
        {   
            get => _userProfile; 

            set 
            {
                _userProfile = value;
                LoginLabel.Text = value.Login;
                PermsLabel.Text = value.Permission;
            }
        }
        public IEnumerable<Tournament> UserTournaments 
        {   
            get => _userTournaments; 
            
            set 
            {
                _userTournaments = value;
                TournamentsDataGridView.Rows.Clear();
                foreach (var tournament in value)
                {
                    TournamentsDataGridView.Rows.Add(tournament.Name);
                }
            }
        }

        public bool UserProfileVisible { get => UserProfileGroupBox.Visible; set => UserProfileGroupBox.Visible = value; }
        public bool ChangePermsVisible { get => ChangePermsButton.Visible; set => ChangePermsButton.Visible = value; }


        public event EventHandler ChangePermsClicked;
        public event EventHandler UserFormClosed;
        public event EventHandler<UserClickedEventArgs> UserClicked;
        public event EventHandler<TournamentClickedEventArgs> TournamentClicked;

        private void ChangePermsButton_Click(object sender, EventArgs e)
        {
            ChangePermsClicked.Invoke(this, new EventArgs());
        }

        private void WinFormUserView_FormClosing(object sender, FormClosingEventArgs e)
        {
            UserFormClosed.Invoke(this, new EventArgs());
        }

        private void UsersDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (UsersDataGridView.Columns[e.ColumnIndex].Name == "Login")
            {
                string login = (string)UsersDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                UserClicked?.Invoke(this, new UserClickedEventArgs { user = Users.FirstOrDefault(u => u.Login == login) });
            }
        }

        private void TournamentsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string name = (string)TournamentsDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            TournamentClicked?.Invoke(this, new TournamentClickedEventArgs { tournament = UserTournaments.FirstOrDefault(t => t.Name == name) });
        }
    }
}
