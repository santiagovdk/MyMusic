﻿using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace DataAccess.BandDataAccess
{
    public class clsBandRead
    {
        private SqlConnection conn = new clsConnection().getPort();

        public void validateHashTag(clsInfoBand pclsInfoBand, ref clsResponse pclsResponse)
        {

            try
            {

                SqlCommand cmd = new SqlCommand("myFan.SP_ExistsHashtag", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@Hashtag", System.Data.SqlDbType.VarChar).Value = pclsInfoBand.Hashtag;
                conn.Open();
                SqlDataReader result = cmd.ExecuteReader();
                result.Read();
                Console.WriteLine("entre");
                if (result.HasRows==true) {
                    if (result["Hagstag"].ToString().Equals("True"))
                    {
                        pclsResponse.Code = 0;
                        pclsResponse.Message = "Done";
                        pclsResponse.Success = true;
                    }
                    else
                    {
                        pclsResponse.Code = 3;
                        pclsResponse.Message = "Incorrect HashTag";
                        pclsResponse.Success = false;
                    }

                }
                else
                {
                    pclsResponse.Code = 3;
                    pclsResponse.Message = "Incorrect HashTag";
                    pclsResponse.Success = false;
                }
            }
            catch (SqlException ex)
            {
                pclsResponse.Code = 1;
                pclsResponse.Success = false;
                pclsResponse.Message = ex.Message;
            }
            catch (Exception ex)
            {
                pclsResponse.Code = 2;
                pclsResponse.Success = false;
                pclsResponse.Message = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        public void getBandInfo(ref clsInfoBand pclsInfoBand, ref clsResponse pclsResponse, int pintUserID)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("myFan.SP_GetBandProfile", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@UserCode", System.Data.SqlDbType.Int).Value = pintUserID;
                conn.Open();
                SqlDataReader result = cmd.ExecuteReader();
                while (result.Read())
                {
                    pclsInfoBand.Username = result["LoginName"].ToString();
                    pclsInfoBand.Name = result["NombreBanda"].ToString();
                    pclsInfoBand.Country = result["Pais"].ToString();
                    pclsInfoBand.Hashtag = result["Hashtag"].ToString();
                    pclsInfoBand.Biography = result["Biografia"].ToString();
                    DateTime dat = Convert.ToDateTime(result["AnoCreacion"].ToString(), CultureInfo.InvariantCulture);
                    pclsInfoBand.DateCreation =  dat.ToString("yyyy")+"-" + dat.ToString("MM")+'-'+ dat.ToString("dd");

                }

                pclsResponse.Code = 0;
                pclsResponse.Message = "Done";
                pclsResponse.Success = true;
            }
            catch (SqlException ex)
            {
                pclsResponse.Code = 1;
                pclsResponse.Success = false;
                pclsResponse.Message = ex.Message;
            }
            catch (Exception ex)
            {
                pclsResponse.Code = 2;
                pclsResponse.Success = false;
                pclsResponse.Message = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        public void getMembersInfo(ref clsInfoBand pclsInfoBand, ref clsResponse pclsResponse, int pintUserID)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("myFan.SP_GetMemberBand", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@intCodBand", System.Data.SqlDbType.Int).Value = 0;
                cmd.Parameters.Add("@intCodUser", System.Data.SqlDbType.Int).Value = pintUserID;
                conn.Open();
                SqlDataReader result = cmd.ExecuteReader();
                List<String> members = new List<string>();

                while (result.Read())
                {
                    members.Add(result["Nombre"].ToString());

                }

                pclsInfoBand.Members = members;
                pclsResponse.Code = 0;
                pclsResponse.Message = "Done";
                pclsResponse.Success = true;
            }
            catch (SqlException ex)
            {
                pclsResponse.Code = 1;
                pclsResponse.Success = false;
                pclsResponse.Message = ex.Message;
            }
            catch (Exception ex)
            {
                pclsResponse.Code = 2;
                pclsResponse.Success = false;
                pclsResponse.Message = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        public void getGenresBand(ref clsInfoBand pclsInfoBand, ref clsResponse pclsResponse, int pintUserCode)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("myFan.SP_GetGenresByUser", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@intUserCode", System.Data.SqlDbType.Int).Value = pintUserCode;
                conn.Open();
                SqlDataReader result = cmd.ExecuteReader();
                List<String> tmpGenres = new List<string>();
                List<int> tmpCodGenres = new List<int>();
                while (result.Read())
                {
                    tmpGenres.Add(result["DescripcionGenero"].ToString());
                    tmpCodGenres.Add(Convert.ToInt32(result["CodigoGenero"].ToString()));
                }
                pclsInfoBand.Genres = tmpGenres;
                pclsInfoBand.CodGenres = tmpCodGenres;
                pclsResponse.Code = 0;
                pclsResponse.Message = "Done";
                pclsResponse.Success = true;
            }
            catch (SqlException ex)
            {
                pclsResponse.Code = 1;
                pclsResponse.Success = false;
                pclsResponse.Message = ex.Message;
            }
            catch (Exception ex)
            {
                pclsResponse.Code = 2;
                pclsResponse.Success = false;
                pclsResponse.Message = ex.Message;
            }
            finally
            {
                conn.Close();
            }

        }

        public void getAlbums(ref clsDisksBlock pclsDisksBlock, ref clsResponse pclsResponse, int pintUserCode, int pintOffset, int pintLimit)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("myFan.SP_GetDiscsByBand", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@intCodeUser", System.Data.SqlDbType.Int).Value = pintUserCode;
                cmd.Parameters.Add("@intCodeBand", System.Data.SqlDbType.Int).Value = 0;
                cmd.Parameters.Add("@intOffset", System.Data.SqlDbType.Int).Value = pintOffset;
                cmd.Parameters.Add("@intRows", System.Data.SqlDbType.Int).Value = pintLimit;
                conn.Open();
                SqlDataReader result = cmd.ExecuteReader();
                List<clsSimpleInfo> disks = new List<clsSimpleInfo>();

                while (result.Read())
                {
                    clsSimpleInfo tmp = new clsSimpleInfo();
                    tmp.Name = (result["Descripcion"].ToString());
                    DateTime dat = Convert.ToDateTime(result["dtFechaPublicacion"].ToString());
                    tmp.DateCreation = dat.ToString("yyyy");
                    tmp.Id = Convert.ToInt32(result["DiscCode"].ToString());
                    disks.Add(tmp);
                }
                pclsDisksBlock.Disks = disks;

                pclsResponse.Code = 0;
                pclsResponse.Message = "Done";
                pclsResponse.Success = true;
            }
            catch (SqlException ex)
            {
                pclsResponse.Code = 1;
                pclsResponse.Success = false;
                pclsResponse.Message = ex.Message;
            }
            catch (Exception ex)
            {
                pclsResponse.Code = 2;
                pclsResponse.Success = false;
                pclsResponse.Message = ex.Message;
            }
            finally
            {
                conn.Close();
            }

        }

        public List<clsPublication> getWallBand(ref clsResponse pclsResponse, int pintUserID, int pintOffset, int pintLimit)
        {
            List<clsPublication> Wall = new List<clsPublication>();
            try
            {
                SqlCommand cmd = new SqlCommand("myFan.SP_GetNewsEventsWallByBand", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@intOffset", System.Data.SqlDbType.Int).Value = pintOffset;
                cmd.Parameters.Add("@intRows", System.Data.SqlDbType.Int).Value = pintLimit;
                cmd.Parameters.Add("@intCodeUser", System.Data.SqlDbType.Int).Value = pintUserID;
                conn.Open();
                SqlDataReader result = cmd.ExecuteReader();




                while (result.Read())
                {
                    clsPublication tmp = new clsPublication();
                    tmp.Title = result["Nombre"].ToString();
                    tmp.Content = result["Descripcion"].ToString();
                    DateTime dat = Convert.ToDateTime(result["Fecha"].ToString());
                    tmp.Date = dat.ToString("yyyy-MM-dd");
                    tmp.Type = Convert.ToInt32(result["Tipo"].ToString());
                    tmp.Id = Convert.ToInt32(result["Codigo"].ToString());
                    Wall.Add(tmp);
                }



                pclsResponse.Code = 0;
                pclsResponse.Message = "Done";
                pclsResponse.Success = true;
            }
            catch (SqlException ex)
            {
                pclsResponse.Code = 1;
                pclsResponse.Success = false;
                pclsResponse.Message = ex.Message;
            }
            catch (Exception ex)
            {
                pclsResponse.Code = 2;
                pclsResponse.Success = false;
                pclsResponse.Message = ex.Message;
            }
            finally
            {
                conn.Close();
            }


            return Wall;
        }

        public void getAllBandReviews(ref List<clsReview> pclsReviews, ref clsResponse pclsResponse, int pintBandCode)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("myFan.SP_GetAllReviewBands", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@intCodBand", System.Data.SqlDbType.Int).Value = pintBandCode;
                
                conn.Open();
                SqlDataReader result = cmd.ExecuteReader();
                
                List<clsReview> reviews = new List<clsReview>();
                while (result.Read())
                {
                    clsReview tmp = new clsReview();
                    tmp.Author = (result["strNombre"].ToString());
                    tmp.Calification = (result["Calificacion"].ToString());
                    tmp.Comment = (result["Comentario"].ToString());
                    reviews.Add(tmp);

                }
                pclsReviews = reviews;
                pclsResponse.Code = 0;
                pclsResponse.Message = "Done";
                pclsResponse.Success = true;
            }
            catch (SqlException ex)
            {
                pclsResponse.Code = 1;
                pclsResponse.Success = false;
                pclsResponse.Message = ex.Message;
            }
            catch (Exception ex)
            {
                pclsResponse.Code = 2;
                pclsResponse.Success = false;
                pclsResponse.Message = ex.Message;
            }
            finally
            {
                conn.Close();
            }

        }

        public int getCalificationBand(ref clsResponse pclsResponse, int pintBandCode)
        {
            int tmp = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("myFan.SP_GlobalCalificationBand", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@intCodBand", System.Data.SqlDbType.Int).Value = pintBandCode;
                conn.Open();
                SqlDataReader result = cmd.ExecuteReader();
                while (result.Read())
                {

                    tmp = Convert.ToInt32(result["Calificacion"].ToString());
                    
                }
 
                pclsResponse.Code = 0;
                pclsResponse.Message = "Done";
                pclsResponse.Success = true;
            }
            catch (SqlException ex)
            {
                pclsResponse.Code = 1;
                pclsResponse.Success = false;
                pclsResponse.Message = ex.Message;
            }
            catch (Exception ex)
            {
                pclsResponse.Code = 2;
                pclsResponse.Success = false;
                pclsResponse.Message = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return tmp;
        }

        public int getFollowersBand(ref clsResponse pclsResponse, int pintBandCode)
        {
            int tmp = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("myFan.SP_GlobalFollowersBand", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@intCodBand", System.Data.SqlDbType.Int).Value = pintBandCode;
                conn.Open();
                SqlDataReader result = cmd.ExecuteReader();
                while (result.Read())
                {

                    tmp = Convert.ToInt32(result["Seguidores"].ToString());

                }

                pclsResponse.Code = 0;
                pclsResponse.Message = "Done";
                pclsResponse.Success = true;
            }
            catch (SqlException ex)
            {
                pclsResponse.Code = 1;
                pclsResponse.Success = false;
                pclsResponse.Message = ex.Message;
            }
            catch (Exception ex)
            {
                pclsResponse.Code = 2;
                pclsResponse.Success = false;
                pclsResponse.Message = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return tmp;
        }

        public string getHashTag(ref clsResponse pclsResponse, int pintBandCode)
        {
            string tmp = "";
            try
            {
                SqlCommand cmd = new SqlCommand("myFan.SP_getHashTag", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@intUserCodeBand", System.Data.SqlDbType.Int).Value = pintBandCode;
                conn.Open();
                SqlDataReader result = cmd.ExecuteReader();
                while (result.Read())
                {

                    tmp = result["hastag"].ToString();

                }

                pclsResponse.Code = 0;
                pclsResponse.Message = "Done";
                pclsResponse.Success = true;
            }
            catch (SqlException ex)
            {
                pclsResponse.Code = 1;
                pclsResponse.Success = false;
                pclsResponse.Message = ex.Message;
            }
            catch (Exception ex)
            {
                pclsResponse.Code = 2;
                pclsResponse.Success = false;
                pclsResponse.Message = ex.Message;
            }
            finally
            {
                conn.Close();
            }
            return tmp;
        }


    }
}
