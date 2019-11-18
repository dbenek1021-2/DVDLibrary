using DVDLibrary.Models;
using DVDLibrary.Models.Interfaces;
using DVDLibrary.Models.Mapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Data.Repositories
{
    public class DVDRepoADO : IDVDRepo
    {
        private string _connString = ConfigurationManager.ConnectionStrings["DVDLibrary"].ConnectionString;

        /// <summary>
        /// 1) I created a connection string (in Web.config)
        /// 2) I assigned my connection string (_connString) to the connection (conn.ConnectionString = _connString;)
        /// 3) I created a command object & bound it to the connection object (command.Connection = conn;)
        /// 4) I assigned my SQL to execute to the command object
        /// 5) I opened the connection & called it to execute
        /// 6) The using statement closes the connection after everything in the using statement has run
        /// 
        /// </summary>
        /// <param name="director"></param>
        public void AddDirector(string director)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _connString;
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "CreateDirector";
                command.Parameters.AddWithValue("DirectorName", director);

                conn.Open();
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rating"></param>
        public void AddRating(string rating)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _connString;
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "CreateRating";
                command.Parameters.AddWithValue("RatingName", rating);

                conn.Open();
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _connString;
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "DeleteDVD";
                command.Parameters.AddWithValue("DVDId", id);

                conn.Open();
                command.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dvd"></param>
        /// <param name="id"></param>
        public void Edit(DVD dvd, int id)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand command = new SqlCommand("EditDVD", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("DVDId", id);
                command.Parameters.AddWithValue("Title", dvd.title);
                command.Parameters.AddWithValue("RatingId", dvd.rating.ratingId);
                command.Parameters.AddWithValue("DirectorId", dvd.director.directorId);
                command.Parameters.AddWithValue("ReleaseYear", dvd.releaseYear);
                command.Parameters.AddWithValue("Notes", dvd.notes);

                conn.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<DVD> GetAll()
        {
            List<DVD> dvds = new List<DVD>();

            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand command = new SqlCommand("GetAllDVDs", conn);
                command.CommandType = CommandType.StoredProcedure;

                conn.Open();
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        dvds.Add(MapData.Dvd(dr));
                    }
                }
            }
            return dvds;
        }

        public List<DVD> GetByDirector(string director)
        {
            List<DVD> dvds = new List<DVD>();

            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand command = new SqlCommand("GetDVDByDirector", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("DirectorName", director);

                conn.Open();
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        dvds.Add(MapData.Dvd(dr));
                    }
                }
            }
            return dvds;
        }

        public DVD GetById(int id)
        {
            DVD dvd = new DVD();

            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand command = new SqlCommand("GetDVDById", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("DVDId", id);

                conn.Open();
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        dvd = MapData.Dvd(dr);
                    }
                }
            }
            return dvd;
        }

        public List<DVD> GetByRating(string rating)
        {
            List<DVD> dvds = new List<DVD>();

            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand command = new SqlCommand("GetDVDByRating", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("RatingName", rating);

                conn.Open();
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        dvds.Add(MapData.Dvd(dr));
                    }
                }
            }
            return dvds;
        }

        public List<DVD> GetByReleaseYear(int year)
        {
            List<DVD> dvds = new List<DVD>();

            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand command = new SqlCommand("GetDVDByReleaseYear", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("ReleaseYear", year);

                conn.Open();
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        dvds.Add(MapData.Dvd(dr));
                    }
                }
            }
            return dvds;
        }

        public List<DVD> GetByTitle(string title)
        {
            List<DVD> dvds = new List<DVD>();

            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand command = new SqlCommand("GetDVDByTitle", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("Title", title);

                conn.Open();
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        dvds.Add(MapData.Dvd(dr));
                    }
                }
            }
            return dvds;
        }

        public Director NewDirector(string director)
        {
            Director newDirector = new Director();
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand command = new SqlCommand("GetDirectorByName", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("DirectorName", director);

                conn.Open();
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        newDirector.directorId = int.Parse(dr["DirectorId"].ToString());
                        newDirector.directorName = dr["DirectorName"].ToString();
                    }
                }
            }
            return newDirector;
        }

        public int NewDVD(DVD newDvd)
        {
            int dvdId = 0;
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand command = new SqlCommand("CreateDVD", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("Title", newDvd.title);
                command.Parameters.AddWithValue("RatingId", newDvd.rating.ratingId);
                command.Parameters.AddWithValue("DirectorId", newDvd.director.directorId);
                command.Parameters.AddWithValue("ReleaseYear", newDvd.releaseYear);
                command.Parameters.AddWithValue("Notes", newDvd.notes);

                conn.Open();
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        dvdId = int.Parse(dr["DVDId"].ToString());
                    }
                }
            }
            return dvdId;
        }

        public Rating NewRating(string rating)
        {
            Rating newRating = new Rating();
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand command = new SqlCommand("GetRatingByName", conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("RatingName", rating);

                conn.Open();
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        newRating.ratingId = int.Parse(dr["RatingId"].ToString());
                        newRating.ratingName = dr["RatingName"].ToString();
                    }
                }
            }
            return newRating;
        }

        public DVD showDVDDetails(int id)
        {
            DVD dvd = new DVD();
            dvd = GetById(id);
            return dvd;
        }
    }
}
