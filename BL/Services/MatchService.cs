using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Models;
using BL.RepositoryInterfaces;

namespace BL.Services
{
    public class MatchService
    {
        private readonly IMatchRepository _matchRepository;

        public MatchService(IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
        }

        public Match createMatch(int tournamentId, int homeTeamId, int guestTeamId, int homeGoals, int guestGoals)
        {
            Match match = new Match(tournamentId, homeTeamId, guestTeamId, homeGoals, guestGoals);
            _matchRepository.create(match);

            return match;
        }

        public Match getMatch(int id)
        {
            Match match = _matchRepository.getById(id);
            if (match == null)
            {
                throw new Exception("Матча с таким id не существует.");
            }

            return match;
        }

        public void deleteMatch(int id)
        {
            _matchRepository.delete(id);
        }

        public void updateMatch(int id, int homeGoals, int guestGoals)
        {
            Match match = _matchRepository.getById(id);
            if (match != null)
            {
                Match newMatch = new Match(match.TournamentId, match.HomeTeamId, match.GuestTeamId, homeGoals, guestGoals, id: match.Id);
                _matchRepository.update(newMatch);
            }
            else
            {
                throw new Exception("Матча с таким id не существует.");
            }
        }
    }
}
