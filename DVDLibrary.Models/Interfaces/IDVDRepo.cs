using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Models.Interfaces
{
    public interface IDVDRepo
    {
        List<DVD> GetAll();
        List<DVD> GetByDirector(string director);
        List<DVD> GetByRating(string rating);
        List<DVD> GetByReleaseYear(int year);
        List<DVD> GetByTitle(string title);

        DVD GetById(int id);
        void AddDirector(string director);
        void AddRating(string rating);
        int NewDVD(DVD newDvd);
        Director NewDirector(string director);
        Rating NewRating(string rating);
        void Edit(DVD dvd, int id);
        void Delete(int id);
        DVD showDVDDetails(int id);
    }
}
