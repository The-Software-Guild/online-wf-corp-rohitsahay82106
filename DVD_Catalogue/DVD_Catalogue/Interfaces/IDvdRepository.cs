using DVD.Models.Tables;
using DVD_Catalogue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVD.Data.Interfaces
{
    public interface IDvdRepository
    {
        void AddNewDVD(JSONDvdModel Dvd);
        void UpdateDVD(JSONDvdModel Dvd);
        void DeleteDVD(int id);
        JSONDvdModel GetDvdById(int id);
        IEnumerable<JSONDvdModel> GetAllDvds();
        IEnumerable<JSONDvdModel> GetDvdByTitle(string title);
        IEnumerable<JSONDvdModel> GetDvdByYear(short year);
        IEnumerable<JSONDvdModel> GetDvdByDirector(string director);
        IEnumerable<JSONDvdModel> GetDvdByRating(string rating);

    }
}
