using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Models.Mapper
{
    public class MapData
    {
        /// <summary>
        /// Made a map class so I wouldn't have to repeat code
        /// when I'm getting a list back in my ADO repo
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static DVD Dvd(SqlDataReader dr)
        {
            DVD dvd = new DVD();
            dvd.dvdId = int.Parse(dr["DVDId"].ToString());
            dvd.title = dr["Title"].ToString();
            dvd.releaseYear = int.Parse(dr["ReleaseYear"].ToString());
            dvd.notes = dr["Notes"].ToString();

            Director director = new Director();
            director.directorId = int.Parse(dr["DirectorId"].ToString());
            director.directorName = dr["DirectorName"].ToString();

            Rating rating = new Rating();
            rating.ratingId = int.Parse(dr["RatingId"].ToString());
            rating.ratingName = dr["RatingName"].ToString();

            dvd.rating = rating;
            dvd.director = director;

            return dvd;

        }
    }
}
