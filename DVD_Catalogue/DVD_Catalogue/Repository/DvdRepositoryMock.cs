using DVD.Data.Interfaces;
using DVD.Models.Tables;
using DVD_Catalogue.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVD.Data.Repository
{
    public class DvdRepositoryMock : IDvdRepository
    {
        private static Rating dvdRating1 = new Rating
        {
            RatingId = "PG",
            RatingDescription = "Parental Guidance"
        };
        private static Rating dvdRating2 = new Rating
        {
            RatingId = "PG-13",
            RatingDescription = "Parental Guidance and not suitable for kids below 13"
        };
        private static Rating dvdRating3 = new Rating
        {
            RatingId = "R",
            RatingDescription = "Restricted, not suitable for anyone below 18"
        };
        private static Rating dvdRating4 = new Rating
        {
            RatingId = "G",
            RatingDescription = "Suitable for audiences of all age"
        };
        private List<Rating> DvdRatings = new List<Rating>()
        {
            dvdRating1,dvdRating2,dvdRating3,dvdRating4
            
        };

        private static Dvd Dvd = new Dvd
        {
            DvdId = 1,
            Title = "Taare Zameen Par",
            ReleaseYear = 2015,
            Director = "Kalpana Yadav",
            RatingId = "PG",
            Notes = "Excellent movie for parents of school going kids"
            
        };
        private static Dvd Dvd1 = new Dvd
        {
            DvdId = 2,
            Title = "Jumanji",
            ReleaseYear = 1995,
            Director = "Steve Spielberg",
            RatingId = "PG",
            Notes = "Exciting family movie"

        };

        private static List<Dvd> DvdList = new List<Dvd>()
        {
            Dvd,
            Dvd1
        };

        public void AddNewDVD(JSONDvdModel dvd)
        {
            Dvd newDvd = new Dvd();

            DvdList.OrderBy(a => a.DvdId);
            int _highestOrderNumber = 0;
            bool _ValidRating = false;

            foreach (Dvd d in DvdList)
            {
                if (d.DvdId > _highestOrderNumber)
                {
                    _highestOrderNumber = d.DvdId;
                }
                
            }
            foreach (Rating r in DvdRatings)
            {
                if(r.RatingId == dvd.rating)
                {
                    _ValidRating = true;
                    break;
                }
            }

            if (_ValidRating)
            {
                dvd.dvdId = _highestOrderNumber + 1;

                newDvd.DvdId = dvd.dvdId;
                newDvd.Title = dvd.title;
                newDvd.ReleaseYear = dvd.releaseYear;
                newDvd.RatingId = dvd.rating;
                newDvd.Director = dvd.director;
                newDvd.Notes = dvd.notes;
                DvdList.Add(newDvd);
                
            }


        }
        
        public IEnumerable<JSONDvdModel> GetAllDvds()
        {
            List<JSONDvdModel> AllDvds = new List<JSONDvdModel>();
            DvdList.OrderBy(a => a.DvdId);
            foreach(Dvd d in DvdList)
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

        
        public void DeleteDVD(int id)
        {
            DvdList.OrderBy(a => a.DvdId);

            int _index = 0;
            foreach (Dvd d in DvdList)
            {
                if (d.DvdId == id)
                {
                    DvdList.RemoveAt(_index);
                    break;
                }

                _index++;
            }

        }

        
        public void UpdateDVD(JSONDvdModel Dvd)
        {
            DvdList.OrderBy(a => a.DvdId);

            int _index = 0;
            foreach (Dvd d in DvdList)
            {
                if (d.DvdId == Dvd.dvdId)
                {
                    DvdList.RemoveAt(_index);
                    break;
                }

                _index++;
            }

            Dvd newDvd = new Dvd();

            bool _ValidRating = false;
                        
            foreach (Rating r in DvdRatings)
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
                DvdList.Add(newDvd);

            }

        }

        JSONDvdModel IDvdRepository.GetDvdById(int id)
        {
            DvdList.OrderBy(a => a.DvdId);

            var result = (from d in DvdList
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

        IEnumerable<JSONDvdModel> IDvdRepository.GetDvdByTitle(string title)
        {
            DvdList.OrderBy(a => a.DvdId);
            var result = from d in DvdList
                         where (d.Title.IndexOf(title, StringComparison.OrdinalIgnoreCase) >= 0)
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

        IEnumerable<JSONDvdModel> IDvdRepository.GetDvdByYear(short year)
        {
            DvdList.OrderBy(a => a.DvdId);
            var result = from d in DvdList
                         where d.ReleaseYear == year
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

        IEnumerable<JSONDvdModel> IDvdRepository.GetDvdByDirector(string director)
        {
            DvdList.OrderBy(a => a.DvdId);
            var result = from d in DvdList
                         where (d.Director.IndexOf(director,StringComparison.OrdinalIgnoreCase) >= 0)
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

        IEnumerable<JSONDvdModel> IDvdRepository.GetDvdByRating(string rating)
        {
            DvdList.OrderBy(a => a.DvdId);
            var result = from d in DvdList
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
    }
}
