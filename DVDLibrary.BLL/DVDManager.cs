using DVDLibrary.Models;
using DVDLibrary.Models.Interfaces;
using DVDLibrary.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.BLL
{
    public class DVDManager
    {
        private IDVDRepo _dvdRepo;

        public DVDManager(IDVDRepo dvdRepo)
        {
            _dvdRepo = dvdRepo;
        }

        public ListOfDVDResponse GetAll()
        {
            ListOfDVDResponse response = new ListOfDVDResponse();

            List<DVD> dvdList = _dvdRepo.GetAll();
            response.DVDs = new List<DVDView>();

            foreach (DVD dvd in dvdList)
            {
                DVDView dvdView = new DVDView(dvd);

                response.DVDs.Add(dvdView);
            }

            if (dvdList == null || dvdList.Count == 0)
            {
                response.Success = false;
                response.Message = "There are no DVDs to be listed.";
            }
            else
            {
                response.Success = true;
            }

            return response;
        }

        public DVDResponse GetById(int id)
        {
            DVDResponse response = new DVDResponse();
            var dvdById = _dvdRepo.GetById(id);

            if (dvdById == null)
            {
                response.Success = false;
                response.Message = "There are no DVDs with this id.";
            }
            else
            {
                response.Success = true;
                response.DVD = dvdById;
            }

            return response;
        }

        public ListOfDVDResponse GetByTitle(string title)
        {
            ListOfDVDResponse response = new ListOfDVDResponse();
            List<DVD> dvdList = _dvdRepo.GetByTitle(title);
            response.DVDs = new List<DVDView>();

            foreach (DVD dvd in dvdList)
            {
                DVDView listByTitle = new DVDView();
                listByTitle.dvdId = dvd.dvdId;
                listByTitle.title = dvd.title;
                listByTitle.director = dvd.director.directorName;
                listByTitle.rating = dvd.rating.ratingName;
                listByTitle.realeaseYear = dvd.releaseYear;
                listByTitle.notes = dvd.notes;

                response.DVDs.Add(listByTitle);

            }

            if (dvdList == null)
            {
                response.Success = false;
                response.Message = "There are no DVDs with this title.";
            }
            else
            {
                response.Success = true;
            }

            return response;
        }

        public ListOfDVDResponse GetByDirector(string director)
        {
            ListOfDVDResponse response = new ListOfDVDResponse();
            List<DVD> dvdList = _dvdRepo.GetByDirector(director);
            response.DVDs = new List<DVDView>();

            foreach (DVD dvd in dvdList)
            {
                DVDView listByDirector = new DVDView();
                listByDirector.dvdId = dvd.dvdId;
                listByDirector.title = dvd.title;
                listByDirector.director = dvd.director.directorName;
                listByDirector.rating = dvd.rating.ratingName;
                listByDirector.realeaseYear = dvd.releaseYear;
                listByDirector.notes = dvd.notes;

                response.DVDs.Add(listByDirector);

            }

            if (dvdList == null)
            {
                response.Success = false;
                response.Message = "There are no DVDs with this director name.";
            }
            else
            {
                response.Success = true;
            }

            return response;
        }

        public ListOfDVDResponse GetByRating(string rating)
        {
            ListOfDVDResponse response = new ListOfDVDResponse();
            List<DVD> dvdList = _dvdRepo.GetByRating(rating);
            response.DVDs = new List<DVDView>();

            foreach (DVD dvd in dvdList)
            {
                DVDView listByRating = new DVDView();
                listByRating.dvdId = dvd.dvdId;
                listByRating.title = dvd.title;
                listByRating.director = dvd.director.directorName;
                listByRating.rating = dvd.rating.ratingName;
                listByRating.realeaseYear = dvd.releaseYear;
                listByRating.notes = dvd.notes;

                response.DVDs.Add(listByRating);

            }

            if (dvdList == null)
            {
                response.Success = false;
                response.Message = "There are no DVDs with this director name.";
            }
            else
            {
                response.Success = true;
            }

            return response;
        }

        public ListOfDVDResponse GetByReleaseYear(int year)
        {
            ListOfDVDResponse response = new ListOfDVDResponse();
            List<DVD> dvdList = _dvdRepo.GetByReleaseYear(year);
            response.DVDs = new List<DVDView>();

            foreach (DVD dvd in dvdList)
            {
                DVDView listByYear = new DVDView();
                listByYear.dvdId = dvd.dvdId;
                listByYear.title = dvd.title;
                listByYear.director = dvd.director.directorName;
                listByYear.rating = dvd.rating.ratingName;
                listByYear.realeaseYear = dvd.releaseYear;
                listByYear.notes = dvd.notes;

                response.DVDs.Add(listByYear);

            }

            if (dvdList == null)
            {
                response.Success = false;
                response.Message = "There are no DVDs with this director name.";
            }
            else
            {
                response.Success = true;
            }

            return response;
        }

        public DVDResponse NewDVD(string title, string director, string rating, int releaseYear, string notes)
        {
            DVDResponse response = new DVDResponse();
            DVD dvd = new DVD();
            Director newDirector = _dvdRepo.NewDirector(director);
            Rating newRating = _dvdRepo.NewRating(rating);

            if(newDirector.directorName == null)
            {
                _dvdRepo.AddDirector(director);
                newDirector = _dvdRepo.NewDirector(director);
            }
            if(newRating.ratingName == null)
            {
                _dvdRepo.AddRating(rating);
                newRating = _dvdRepo.NewRating(rating);
            }

            if(notes == null)
            {
                dvd.notes = "";
            }
            if (title == null || title == "")
            {
                response.Success = false;
                response.Message = "You must enter a DVD title.";
            }
            if (rating == null || rating == "")
            {
                response.Success = false;
                response.Message = "You must enter a rating.";
            }

            else
            {
                response.Success = true;
                dvd.title = title;
                dvd.director = newDirector;
                dvd.rating = newRating;
                dvd.releaseYear = releaseYear;
                dvd.notes = notes;

                var newDVD = new DVDView(dvd);
                newDVD.dvdId = _dvdRepo.NewDVD(dvd);
                response.DVDView = newDVD;
            }
            return response;
        }

        public DVDResponse EditDVD(DVDView dvd, string director, string notes, string rating, int releaseYear, string title)
        {
            DVDResponse response = new DVDResponse();
            DVD dvdToEdit = _dvdRepo.GetById(dvd.dvdId);

            Director newDirector = _dvdRepo.NewDirector(director);
            if (newDirector.directorName == null)
            {
                _dvdRepo.AddDirector(director);
                newDirector = _dvdRepo.NewDirector(director);
            }
            if (dvdToEdit.directorId != newDirector.directorId)
            {
                dvdToEdit.director = newDirector;
            }

            Rating newRating = _dvdRepo.NewRating(rating);
            if (newRating.ratingName == null)
            {
                _dvdRepo.AddRating(rating);
                newRating = _dvdRepo.NewRating(rating);
            }
            if (dvdToEdit.ratingId != newRating.ratingId)
            {
                dvdToEdit.rating = newRating;
            }

            if (notes == null)
            {
                dvd.notes = "";
            }
            if (title == null || title == "")
            {
                response.Success = false;
                response.Message = "You must enter a DVD title.";
            }
            if (rating == null || rating == "")
            {
                response.Success = false;
                response.Message = "You must enter a rating.";
            }
            else
            {
                response.Success = true;
                dvdToEdit.title = title;
                dvdToEdit.releaseYear = releaseYear;
                dvdToEdit.notes = notes;
                _dvdRepo.Edit(dvdToEdit, dvdToEdit.dvdId);

                var editedDVD = new DVDView(dvdToEdit);
                response.DVDView = editedDVD;
            }
            return response;
        }

        public Response DeleteDVD(int id)
        {
            Response response = new Response();
            _dvdRepo.Delete(id);

            response.Success = true;
            response.Message = "DVD has been deleted.";
            return response;
        }

    }
}
