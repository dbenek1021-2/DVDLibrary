using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Models
{
    public class DVDView
    {
        public DVDView(){}

        public DVDView(DVD dvd)
        {
            dvdId = dvd.dvdId;
            title = dvd.title;
            realeaseYear = dvd.releaseYear;
            rating = dvd.rating.ratingName;
            director = dvd.director.directorName;
            notes = dvd.notes;

        }

        public int dvdId { get; set; }
        public string title { get; set; }
        public int realeaseYear { get; set; }
        public string rating { get; set; }
        public string director { get; set; }
        public string notes { get; set; }
    }
}
