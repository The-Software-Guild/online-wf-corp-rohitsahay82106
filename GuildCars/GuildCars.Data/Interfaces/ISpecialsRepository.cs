using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Interfaces
{
    public interface ISpecialsRepository
    {
        void AddNewSpecials(Specials specials);
        IEnumerable<Specials> GetAllSpecials();
        void DeleteSpecials(int id);

    }
}
