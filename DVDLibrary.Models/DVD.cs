using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Models
{
    public class DVD
    {
        public int dvdId { get; set; }
        public int directorId { get; set; }
        public int ratingId { get; set; }

        public string title { get; set; }
        public Director director { get; set; }
        public int releaseYear { get; set; }
        public Rating rating { get; set; }
        public string notes { get; set; }
    }
}
