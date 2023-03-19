using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Models;
using BL.RepositoryInterfaces;

namespace BL.Services
{
    public class TeamService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly ITournamentRepository _tournamentRepository;

        public TeamService(ITeamRepository teamRepository, ITournamentRepository tournamentRepository)
        {
            _teamRepository = teamRepository;
            _tournamentRepository = tournamentRepository;
        }

        public Team createTeam(string name, int countryId)
        {
            Team team = _teamRepository.getByName(name);
            if (team == null)
            {
                team = new Team(name, countryId);
                _teamRepository.create(team);
            }
            else
            {
                throw new Exception("Команда с таким названием уже существует.");
            }
            
            return team;
        }

        public Team getTeam(int id)
        {
            Team team = _teamRepository.getById(id);
            if (team == null)
            {
                throw new Exception("Команды с таким id не существует.");
            }

            return team;
        }

        public IEnumerable<Team> getAllTeams()
        {
            return _teamRepository.getAll();
        }

        public IEnumerable<Tournament> getTeamTournaments(int id)
        {
            return _tournamentRepository.getByTeam(id);
        }
    }
}
