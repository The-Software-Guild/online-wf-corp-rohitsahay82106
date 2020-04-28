using DVD.Data.Interfaces;
using DVD.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVD.Data.Repository
{
    public class DvdRepositoryEF : IDvdRepository
    {
        public void AddNewDVD(Dvd Dvd)
        {
            var repo = new DvdCatalogEntity();

        }

        public void DeleteDVD(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Dvd> GetAllDvds()
        {
            throw new NotImplementedException();
        }

        public Dvd GetDvdByDirector(string director)
        {
            throw new NotImplementedException();
        }

        public Dvd GetDvdById(int id)
        {
            throw new NotImplementedException();
        }

        public Dvd GetDvdByRating(string rating)
        {
            throw new NotImplementedException();
        }

        public Dvd GetDvdByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public Dvd GetDvdByYear(short year)
        {
            throw new NotImplementedException();
        }

        public void UpdateDVD(Dvd Dvd)
        {
            throw new NotImplementedException();
        }
    }
}
