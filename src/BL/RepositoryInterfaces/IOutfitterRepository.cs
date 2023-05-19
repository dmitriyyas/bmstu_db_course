using BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.RepositoryInterfaces
{
    public interface IOutfitterRepository
    {
        void create(Outfitter outfitter);

        Outfitter getById(int id);
        Outfitter getByName(string name);
        IEnumerable<Outfitter> getAll();
    }
}
