using DVD.Data.Interfaces;
using DVD.Models.Tables;
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

        private List<Dvd> DvdList = new List<Dvd>()
        {
            Dvd,
            Dvd1
        };

        public void AddNewDVD(Dvd dvd)
        {
            DvdList.OrderBy(a => a.DvdId);
            int _highestOrderNumber = 0;
            bool _ValidRating = false;

            foreach (Dvd d in DvdList)
            {
                _highestOrderNumber = d.DvdId;
            }
            foreach (Rating r in DvdRatings)
            {
                if(r.RatingId == dvd.RatingId)
                {
                    _ValidRating = true;
                    break;
                }
            }

            if (_ValidRating)
            {
                dvd.DvdId = _highestOrderNumber + 1;
                DvdList.Add(dvd);

            }


        }
        
        public IEnumerable<Dvd> GetAllDvds()
        {
            List<Dvd> AllDvds = new List<Dvd>();
            DvdList.OrderBy(a => a.DvdId);
            foreach(Dvd d in DvdList)
            {
                AllDvds.Add(d);
            }

            return AllDvds;
        }

        public void UpdateDVD(Dvd Dvd)
        {
            throw new NotImplementedException();
        }

        public void DeleteDVD(int id)
        {
            throw new NotImplementedException();
        }

        public Dvd GetDvdById(int id)
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

        public Dvd GetDvdByDirector(string director)
        {
            throw new NotImplementedException();
        }

        public Dvd GetDvdByRating(string rating)
        {
            throw new NotImplementedException();
        }
    }
}
