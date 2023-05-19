using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Models;
using BL.RepositoryInterfaces;

namespace BL.Services
{
    public class TournamentService
    {
        private readonly ITournamentRepository _tournamentRepository;
        private readonly ITeamRepository _teamRepository;
        private readonly IMatchRepository _matchRepository;
        private readonly ITeamTournamentRepository _teamTournamentRepository;

        public TournamentService(ITournamentRepository tournamentRepository, ITeamRepository teamRepository, IMatchRepository matchRepository, ITeamTournamentRepository teamTournamentRepository)
        {
            _tournamentRepository = tournamentRepository;
            _teamRepository = teamRepository;
            _matchRepository = matchRepository;
            _teamTournamentRepository = teamTournamentRepository;
        }

        public Tournament createTournament(string name, User user, Country country, IEnumerable<Team> teams)
        {
            Tournament tournament = _tournamentRepository.getByName(name);
            if (tournament == null)
            {
                tournament = user.createTournament(name, country);
                _tournamentRepository.create(tournament);
                try
                {
                    foreach(var team in teams) 
                    {
                        addTeamToTournament(team.Id, tournament.Id);
                    }
                }
                catch(Exception ex) 
                {
                    deleteTournament(tournament.Id);
                    throw new Exception("Не удалось создать турнир.");
                }
    
            }
            else
            {
                throw new Exception("Турнир с таким названием уже есть.");
            }

            return tournament;
        }

        public Tournament getTournament(int id)
        {
            Tournament tournament = _tournamentRepository.getById(id);
            if (tournament == null)
            {
                throw new Exception("Турнира с таким id нет.");
            }

            return tournament;
        }

        public void addTeamToTournament(int teamId, int tournamentId)
        {
            TeamTournament teamTournament = _teamTournamentRepository.get(teamId, tournamentId);
            if (teamTournament == null)
            {
                teamTournament = new TeamTournament(teamId, tournamentId);
                _teamTournamentRepository.create(teamTournament);
            }
            else
            {
                throw new Exception("Такая команда уже участвует в этом турнире.");
            }
        }

        public void deleteTournament(int id)
        {
            _tournamentRepository.delete(id);
        }

        public IEnumerable<Tournament> getAllTournaments()
        {
            return _tournamentRepository.getAll();
        }

        public IEnumerable<Match> getTournamentMatches(int id)
        {
            return _matchRepository.getByTournament(id);
        }

        public IEnumerable<Team> getTournamentTeams(int id)
        {
            return _teamRepository.getByTournament(id);
        }

        public IEnumerable<TeamStatistics> getTournamentTable(int tournamentId)
        {
            List<TeamStatistics> table = new List<TeamStatistics>();
            IEnumerable<Team> teams = getTournamentTeams(tournamentId);
            foreach(var team in teams)
            {
                TeamStatistics statistics = new TeamStatistics(team.Name);
                IEnumerable<Match> matches = _matchRepository.getByHostTeam(team.Id, tournamentId);
                foreach(var match in matches)
                {
                    statistics.Matches += 1;
                    statistics.GoalsScored += match.HomeGoals;
                    statistics.GoalsConceded += match.GuestGoals;
                    if (match.HomeGoals > match.GuestGoals)
                    {
                        statistics.Wins += 1;
                        statistics.Points += 3;
                    }
                    else if (match.HomeGoals == match.GuestGoals)
                    {
                        statistics.Draws += 1;
                        statistics.Points += 1;
                    }
                    else
                    {
                        statistics.Loses += 1;
                    }
                }

                matches = _matchRepository.getByGuestTeam(team.Id, tournamentId);
                foreach (var match in matches)
                {
                    statistics.Matches += 1;
                    statistics.GoalsScored += match.GuestGoals;
                    statistics.GoalsConceded += match.HomeGoals;
                    if (match.HomeGoals < match.GuestGoals)
                    {
                        statistics.Wins += 1;
                        statistics.Points += 3;
                    }
                    else if (match.HomeGoals == match.GuestGoals)
                    {
                        statistics.Draws += 1;
                        statistics.Points += 1;
                    }
                    else
                    {
                        statistics.Loses += 1;
                    }
                }

                table.Add(statistics);
            }

            table.Sort((y, x) =>
            {
                if (x.Points != y.Points)
                {
                    return x.Points.CompareTo(y.Points);
                }

                int xDiff = x.GoalsScored - x.GoalsConceded;
                int yDiff = y.GoalsScored - y.GoalsConceded;
                if (xDiff != yDiff)
                {
                    return xDiff.CompareTo(yDiff);
                }

                if (x.Wins!= y.Wins)
                {
                    return x.Wins.CompareTo(y.Wins);
                }

                return 0;
            });

            return table;
        }
    }
}
