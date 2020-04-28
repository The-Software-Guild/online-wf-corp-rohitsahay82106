using DVD.Data;
using DVD.Data.Interfaces;
using DVD_Catalogue.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DVD_Catalogue.Repository
{
    public class DvdRepositoryADO : IDvdRepository
    {
        public void AddNewDVD(JSONDvdModel Dvd)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("AddNewDVD", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@title", Dvd.title);
                cmd.Parameters.AddWithValue("@director", Dvd.director);
                cmd.Parameters.AddWithValue("@releaseYear", Dvd.releaseYear);
                cmd.Parameters.AddWithValue("@rating", Dvd.rating);
                cmd.Parameters.AddWithValue("@notes", Dvd.notes);
                SqlParameter outPutParameter = new SqlParameter();
                outPutParameter.ParameterName = "@dvdId";
                outPutParameter.SqlDbType = SqlDbType.Int;
                outPutParameter.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outPutParameter);

                cn.Open();
                cmd.ExecuteNonQuery();
                Dvd.dvdId = (int)outPutParameter.Value;
                
            }
        }

        public void DeleteDVD(int id)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("DeleteDvd", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@dvdId", id);
                
                cn.Open();
                cmd.ExecuteNonQuery();

            }
        }

        public IEnumerable<JSONDvdModel> GetAllDvds()
        {
            List<JSONDvdModel> AllDvds = new List<JSONDvdModel>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetAllDvds", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                using(SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        JSONDvdModel row = new JSONDvdModel();
                        row.dvdId = (int)dr["DvdId"];
                        row.title = dr["Title"].ToString();
                        row.director = dr["Director"].ToString();
                        row.releaseYear = (short)dr["ReleaseYear"];
                        row.rating = dr["RatingId"].ToString();
                        row.notes = dr["Notes"].ToString();
                        AllDvds.Add(row);
                    }
                }
            }

            return AllDvds;
        }

        public IEnumerable<JSONDvdModel> GetDvdByDirector(string director)
        {
            List<JSONDvdModel> AllDvds = new List<JSONDvdModel>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetDvdsByDirector", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@director", director);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        JSONDvdModel row = new JSONDvdModel();
                        row.dvdId = (int)dr["DvdId"];
                        row.title = dr["Title"].ToString();
                        row.director = dr["Director"].ToString();
                        row.releaseYear = (short)dr["ReleaseYear"];
                        row.rating = dr["RatingId"].ToString();
                        row.notes = dr["Notes"].ToString();
                        AllDvds.Add(row);
                    }
                }
            }

            return AllDvds;
        }

        public JSONDvdModel GetDvdById(int id)
        {
            JSONDvdModel dvd = new JSONDvdModel();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetDvdsById", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        dvd.dvdId = (int)dr["DvdId"];
                        dvd.title = dr["Title"].ToString();
                        dvd.director = dr["Director"].ToString();
                        dvd.releaseYear = (short)dr["ReleaseYear"];
                        dvd.rating = dr["RatingId"].ToString();
                        dvd.notes = dr["Notes"].ToString();
                        
                    }
                }
            }

            return dvd;
        }

        public IEnumerable<JSONDvdModel> GetDvdByRating(string rating)
        {
            List<JSONDvdModel> AllDvds = new List<JSONDvdModel>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetDvdsByRating", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@rating", rating);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        JSONDvdModel row = new JSONDvdModel();
                        row.dvdId = (int)dr["DvdId"];
                        row.title = dr["Title"].ToString();
                        row.director = dr["Director"].ToString();
                        row.releaseYear = (short)dr["ReleaseYear"];
                        row.rating = dr["RatingId"].ToString();
                        row.notes = dr["Notes"].ToString();
                        AllDvds.Add(row);
                    }
                }
            }

            return AllDvds;
        }

        public IEnumerable<JSONDvdModel> GetDvdByTitle(string title)
        {
            List<JSONDvdModel> AllDvds = new List<JSONDvdModel>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetDvdsByTitle", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@title", title);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        JSONDvdModel row = new JSONDvdModel();
                        row.dvdId = (int)dr["DvdId"];
                        row.title = dr["Title"].ToString();
                        row.director = dr["Director"].ToString();
                        row.releaseYear = (short)dr["ReleaseYear"];
                        row.rating = dr["RatingId"].ToString();
                        row.notes = dr["Notes"].ToString();
                        AllDvds.Add(row);
                    }
                }
            }

            return AllDvds;
        }

        public IEnumerable<JSONDvdModel> GetDvdByYear(short year)
        {
            List<JSONDvdModel> AllDvds = new List<JSONDvdModel>();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("GetDvdsByReleaseYear", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@releaseYear", year);
                cn.Open();
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        JSONDvdModel row = new JSONDvdModel();
                        row.dvdId = (int)dr["DvdId"];
                        row.title = dr["Title"].ToString();
                        row.director = dr["Director"].ToString();
                        row.releaseYear = (short)dr["ReleaseYear"];
                        row.rating = dr["RatingId"].ToString();
                        row.notes = dr["Notes"].ToString();
                        AllDvds.Add(row);
                    }
                }
            }

            return AllDvds;
        }

        public void UpdateDVD(JSONDvdModel Dvd)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("UpdateDvd", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@dvdId", Dvd.dvdId);
                cmd.Parameters.AddWithValue("@title", Dvd.title);
                cmd.Parameters.AddWithValue("@director", Dvd.director);
                cmd.Parameters.AddWithValue("@releaseYear", Dvd.releaseYear);
                cmd.Parameters.AddWithValue("@rating", Dvd.rating);
                cmd.Parameters.AddWithValue("@notes", Dvd.notes);
                
                cn.Open();
                cmd.ExecuteNonQuery();
                
            }
        }
    }
}