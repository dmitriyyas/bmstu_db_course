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
    public partial class WinFormOutfitterView : Form, IOutfitterView
    {
        private IEnumerable<Outfitter> _outfitters;
        private Outfitter _outfitterProfile;
        private IEnumerable<Team> _outfitterTeams;
        public WinFormOutfitterView()
        {
            InitializeComponent();
        }

        public IEnumerable<Outfitter> Outfitters
        {
            get => _outfitters;
            set
            {
                _outfitters = value.OrderBy(t => t.Name);
                OutfitterDataGridView.Rows.Clear();
                foreach (var outfitter in _outfitters)
                {
                    OutfitterDataGridView.Rows.Add(outfitter.Name, outfitter.Year);
                }
            }
        }
        public Outfitter OutfitterProfile
        {
            get => _outfitterProfile;
            set
            {
                _outfitterProfile = value;
                OutfitterNameLabel.Text = value.Name;
                OutfitterYearLabel.Text = value.Year.ToString();
            }
        }
        public IEnumerable<Team> OutfitterTeams
        {
            get => _outfitterTeams;
            set
            {
                _outfitterTeams = value.OrderBy(t => t.Name);
                TeamDataGridView.Rows.Clear();
                foreach (var team in _outfitterTeams)
                {
                    TeamDataGridView.Rows.Add(team.Name);
                }
            }
        }
        public bool OutfitterProfileVisible 
        { 
            get => OutfitterProfileGroupBox.Visible; 
            set => OutfitterProfileGroupBox.Visible = value; 
        }
        public bool AddOutfitterVisible 
        { 
            get => AddOutfitterButton.Visible; 
            set => AddOutfitterButton.Visible = value; 
        }
        public bool AddOutfitterGroupBoxVisible
        {
            get => AddOutfitterGroupBox.Visible;
            set => AddOutfitterGroupBox.Visible = value;
        }
        public string NewOutfitterName 
        { 
            get => NameTextBox.Text; 
            set => NameTextBox.Text = value; 
        }
        public string NewOutfitterYear 
        { 
            get => YearTextBox.Text; 
            set => YearTextBox.Text = value; 
        }

        public event EventHandler<OutfitterClickedEventArgs> OutfitterClicked;
        public event EventHandler<TeamClickedEventArgs> TeamClicked;
        public event EventHandler AddOutfitterClicked;
        public event EventHandler ConfirmAddOutfitterClicked;
        public event EventHandler OutfitterFormClosed;

        private void AddOutfitterButton_Click(object sender, EventArgs e)
        {
            AddOutfitterClicked.Invoke(this, e);
        }

        private void OutfitterDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (OutfitterDataGridView.Columns[e.ColumnIndex].Name == "OutfitterName")
            {
                string name = (string)OutfitterDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                OutfitterClicked.Invoke(this, new OutfitterClickedEventArgs { outfitter = Outfitters.FirstOrDefault(t => t.Name == name) });
            }
        }

        private void ConfirmAddOutfitterButton_Click(object sender, EventArgs e)
        {
            ConfirmAddOutfitterClicked.Invoke(this, e);
        }

        private void WinFormOutfitterView_FormClosing(object sender, FormClosingEventArgs e)
        {
            OutfitterFormClosed?.Invoke(this, new EventArgs());
        }

        private void TeamDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string name = (string)TeamDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            TeamClicked.Invoke(this, new TeamClickedEventArgs { team = OutfitterTeams.FirstOrDefault(t => t.Name == name) });
        }
    }
}
