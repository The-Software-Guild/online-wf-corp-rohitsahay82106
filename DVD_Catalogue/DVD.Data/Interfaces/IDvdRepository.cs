using DVD.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVD.Data.Interfaces
{
    public interface IDvdRepository
    {
        void AddNewDVD(Dvd Dvd);
        void UpdateDVD(Dvd Dvd);
        void DeleteDVD(int id);
        Dvd GetDvdById(int id);
        IEnumerable<Dvd> GetAllDvds();
        Dvd GetDvdByTitle(string title);
        Dvd GetDvdByYear(short year);
        Dvd GetDvdByDirector(string director);
        Dvd GetDvdByRating(string rating);

    }
}
