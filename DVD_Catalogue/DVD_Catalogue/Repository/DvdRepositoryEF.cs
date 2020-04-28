using DVD.Data.Interfaces;
using DVD.Models.Tables;
using DVD_Catalogue.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVD.Data.Repository
{
    public class DvdRepositoryEF : IDvdRepository
    {
        private DvdCatalogEntity repo = new DvdCatalogEntity();

        public void AddNewDVD(JSONDvdModel Dvd)
        {
            Dvd newDvd = new Dvd();

            bool _ValidRating = false;
            foreach (Rating r in repo.Rating)
            {
                if (r.RatingId == Dvd.rating)
                {
                    _ValidRating = true;
                    break;
                }
            }

            if (_ValidRating)
            {
                newDvd.Title = Dvd.title;
                newDvd.ReleaseYear = Dvd.releaseYear;
                newDvd.RatingId = Dvd.rating;
                newDvd.Director = Dvd.director;
                newDvd.Notes = Dvd.notes;

                repo.Dvd.Add(newDvd);
                repo.SaveChanges();
                Dvd.dvdId = newDvd.DvdId;
            }

        }

        public void DeleteDVD(int id)
        {
            var dvd = repo.Dvd.FirstOrDefault(d => d.DvdId == id);
            if (dvd != null)
            {
                repo.Dvd.Remove(dvd);
                repo.SaveChanges();
            }

        }

        public IEnumerable<JSONDvdModel> GetAllDvds()
        {
            List<JSONDvdModel> AllDvds = new List<JSONDvdModel>();
            
            foreach (Dvd d in repo.Dvd)
            {
                JSONDvdModel dvd = new JSONDvdModel();
                dvd.dvdId = d.DvdId;
                dvd.title = d.Title;
                dvd.rating = d.RatingId;
                dvd.director = d.Director;
                dvd.releaseYear = d.ReleaseYear;
                dvd.notes = d.Notes;
                AllDvds.Add(dvd);
            }

            return AllDvds;
        }

        public IEnumerable<JSONDvdModel> GetDvdByDirector(string director)
        {
            
            var result = from d in repo.Dvd
                         where d.Director.Contains(director)
                         select new JSONDvdModel()
                         {
                             dvdId = d.DvdId,
                             title = d.Title,
                             releaseYear = d.ReleaseYear,
                             rating = d.RatingId,
                             director = d.Director,
                             notes = d.Notes
                         };


            return result;
        }

        public JSONDvdModel GetDvdById(int id)
        {
            var result = (from d in repo.Dvd
                          where d.DvdId == id
                          select new JSONDvdModel()
                          {
                              dvdId = d.DvdId,
                              title = d.Title,
                              releaseYear = d.ReleaseYear,
                              rating = d.RatingId,
                              director = d.Director,
                              notes = d.Notes
                          }).FirstOrDefault();


            return result;
        }

        public IEnumerable<JSONDvdModel> GetDvdByRating(string rating)
        {
            var result = from d in repo.Dvd
                         where d.RatingId == rating
                         select new JSONDvdModel()
                         {
                             dvdId = d.DvdId,
                             title = d.Title,
                             releaseYear = d.ReleaseYear,
                             rating = d.RatingId,
                             director = d.Director,
                             notes = d.Notes
                         };


            return result;
        }

        public IEnumerable<JSONDvdModel> GetDvdByTitle(string title)
        {
            var result = from d in repo.Dvd
                         where d.Title.Contains(title)
                         select new JSONDvdModel()
                         {
                             dvdId = d.DvdId,
                             title = d.Title,
                             releaseYear = d.ReleaseYear,
                             rating = d.RatingId,
                             director = d.Director,
                             notes = d.Notes
                         };


            return result;
        }

        public IEnumerable<JSONDvdModel> GetDvdByYear(short year)
        {
            var result = from d in repo.Dvd
                         where d.ReleaseYear==year
                         select new JSONDvdModel()
                         {
                             dvdId = d.DvdId,
                             title = d.Title,
                             releaseYear = d.ReleaseYear,
                             rating = d.RatingId,
                             director = d.Director,
                             notes = d.Notes
                         };


            return result;
        }

        public void UpdateDVD(JSONDvdModel Dvd)
        {
            Dvd newDvd = new Dvd();

            bool _ValidRating = false;
            foreach (Rating r in repo.Rating)
            {
                if (r.RatingId == Dvd.rating)
                {
                    _ValidRating = true;
                    break;
                }
            }

            if (_ValidRating)
            {
                newDvd.DvdId = Dvd.dvdId;
                newDvd.Title = Dvd.title;
                newDvd.ReleaseYear = Dvd.releaseYear;
                newDvd.RatingId = Dvd.rating;
                newDvd.Director = Dvd.director;
                newDvd.Notes = Dvd.notes;

                repo.Entry(newDvd).State = EntityState.Modified;
                repo.SaveChanges();
                Dvd.dvdId = newDvd.DvdId;
            }
        }
    }
}
