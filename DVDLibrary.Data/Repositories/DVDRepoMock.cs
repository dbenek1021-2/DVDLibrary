using DVDLibrary.Models;
using DVDLibrary.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Data
{
    public class DVDRepoMock : IDVDRepo
    {
        private List<DVD> _dvds = new List<DVD>();

        public DVDRepoMock()
        {
            Director director0 = new Director() { directorId = 0, directorName = "Joss Whedon" };
            Director director1 = new Director() { directorId = 1, directorName = "JJ Abrams" };
            Rating rating1 = new Rating() { ratingId = 1, ratingName = "PG" };
            Rating rating2 = new Rating() { ratingId = 2, ratingName = "PG-13" };

            DVD dvd0 = new DVD() { dvdId = 0, title = "Something Whedon Did", releaseYear = 2015, rating = rating1, director = director0, notes = "Cool Movie" };
            DVD dvd1 = new DVD() { dvdId = 1, title = "Something Abrams Did", releaseYear = 2016, rating = rating2, director = director1, notes = "Also a Cool Movie" };
            DVD dvd2 = new DVD() { dvdId = 2, title = "Something Whedon Did", releaseYear = 2017, rating = rating2, director = director0, notes = "Semi Cool Movie" };

            _dvds.Add(dvd0);
            _dvds.Add(dvd1);
            _dvds.Add(dvd2);
        }

        public void AddDirector(string director)
        {
            
        }

        public void AddRating(string rating)
        {
           
        }

        public void Delete(int id)
        {
            var dvdToDelete = _dvds.FirstOrDefault(d => d.dvdId == id);
            _dvds.Remove(dvdToDelete);
        }

        public void Edit(DVD dvd, int id)
        {
            var dvdToEdit = _dvds.FirstOrDefault(d => d.dvdId == id);
            dvdToEdit = dvd;
        }

        public List<DVD> GetAll()
        {
            return _dvds;
        }

        public List<DVD> GetByDirector(string director)
        {
            List<DVD> listByDirector = new List<DVD>();

            foreach (DVD dvd in _dvds)
            {
                if (dvd.director.directorName == director)
                {
                    listByDirector.Add(dvd);
                }
            }

            return listByDirector;
        }

        public DVD GetById(int id)
        {
            return _dvds.FirstOrDefault(d => d.dvdId == id);
        }

        public List<DVD> GetByRating(string rating)
        {
            List<DVD> listByRating = new List<DVD>();

            foreach (DVD dvd in _dvds)
            {
                if (dvd.rating.ratingName == rating)
                {
                    listByRating.Add(dvd);
                }
            }

            return listByRating;
        }

        public List<DVD> GetByReleaseYear(int year)
        {
            List<DVD> listByYear = new List<DVD>();

            foreach (DVD dvd in _dvds)
            {
                if (dvd.releaseYear == year)
                {
                    listByYear.Add(dvd);
                }
            }

            return listByYear;
        }

        public List<DVD> GetByTitle(string title)
        {
            List<DVD> listByTitle = new List<DVD>();

            foreach (DVD dvd in _dvds)
            {
                if (dvd.title == title)
                {
                    listByTitle.Add(dvd);
                }
            }

            return listByTitle;
        }

        public Director NewDirector(string director)
        {
            Director newDirector = new Director();

            int newnewDirectorId = 0;
            if (_dvds.Count > 0)
            {
                newnewDirectorId = _dvds.Select(d => d.director.directorId).Max();
            }
            newDirector.directorId = newnewDirectorId + 1;
            newDirector.directorName = director;

            return newDirector;
        }

        public int NewDVD(DVD newDvd)
        {
            int newDVDid = 0;
            if (_dvds.Count > 0)
            {
                newDVDid = _dvds.Select(d => d.dvdId).Max();
            }
            newDVDid++;
            newDvd.dvdId = newDVDid;
            _dvds.Add(newDvd);
            return newDVDid;
        }

        public Rating NewRating(string rating)
        {
            Rating newRating = new Rating();

            int newRatingId = 0;
            if (_dvds.Count > 0)
            {
                newRatingId = _dvds.Select(d => d.rating.ratingId).Max();
            }
            newRating.ratingId = newRatingId + 1;
            newRating.ratingName = rating;

            return newRating;
        }

        public DVD showDVDDetails(int id)
        {
            return _dvds.FirstOrDefault(d => d.dvdId == id);
        }
    }
}
