using BL.Models;
using BL.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class OutfitterService
    {
        private readonly IOutfitterRepository _outfitterRepository;
        private readonly ITeamRepository _teamRepository;

        public OutfitterService(IOutfitterRepository outfitterRepository, ITeamRepository teamRepository)
        {
            _outfitterRepository = outfitterRepository;
            _teamRepository = teamRepository;
        }

        public Outfitter createOutfitter(string name, int year)
        {
            Outfitter outfitter = _outfitterRepository.getByName(name);
            if (outfitter == null)
            {
                outfitter = new Outfitter(name, year);
                _outfitterRepository.create(outfitter);
            }
            else
            {
                throw new Exception("Спонсор с таким названием уже существует.");
            }

            return outfitter;
        }

        public Outfitter getOutfitter(int id)
        {
            Outfitter outfitter = _outfitterRepository.getById(id);
            if (outfitter == null)
            {
                throw new Exception("Спонсора с таким id не существует.");
            }

            return outfitter;
        }

        public IEnumerable<Outfitter> getAllOutfitters()
        {
            return _outfitterRepository.getAll();
        }

        public IEnumerable<Team> getOutfitterTeams(int id)
        {
            return _teamRepository.getByOutfitter(id);
        }
    }
}
