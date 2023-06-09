﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.RepositoryInterfaces;
using BL.Models;

namespace DataAccess.Repositories
{
    public class MatchRepository : IMatchRepository
    {
        private readonly IDbContextFactory _dbContextFactory;

        public MatchRepository(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public void create(Match match)
        {
            try
            {
                using var dbContext = _dbContextFactory.getDbContext();
                if (dbContext.Matches.Count() > 0)
                    match.Id = dbContext.Matches.Select(x => x.Id).Max() + 1;
                else
                    match.Id = 1;

                dbContext.Matches.Add(match);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при добавлении матча.");
            }
        }

        public void delete(int id)
        {
            try
            {
                var dbContext = _dbContextFactory.getDbContext();

                var match = dbContext.Matches.FirstOrDefault(t => t.Id == id);
                if (match == null)
                {
                    throw new Exception();
                }
                dbContext.Matches.Remove(match);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при удалении матча.");
            }
        }

        public IEnumerable<Match> getByGuestTeam(int teamId, int tournamentId)
        {
            using var dbContext = _dbContextFactory.getDbContext();

            return dbContext.Matches.Where(m => m.GuestTeamId == teamId && m.TournamentId == tournamentId).ToList();
        }

        public IEnumerable<Match> getByHostTeam(int teamId, int tournamentId)
        {
            using var dbContext = _dbContextFactory.getDbContext();

            return dbContext.Matches.Where(m => m.HomeTeamId == teamId && m.TournamentId == tournamentId).ToList();
        }

        public Match getById(int id)
        {
            using var dbContext = _dbContextFactory.getDbContext();

            return dbContext.Matches.FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<Match> getByTournament(int tournamentId)
        {
            using var dbContext = _dbContextFactory.getDbContext();

            return dbContext.Matches.Where(m => m.TournamentId == tournamentId).ToList();
        }

        public void update(Match match)
        {
            try
            {
                using var dbContext = _dbContextFactory.getDbContext();

                dbContext.Matches.Update(match);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при обновлении матча.");
            }
        }
    }
}
