﻿using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace DataAccess.FanDataAccess
{
    class clsFanWrite
    {
        private SqlConnection conn = new clsConnection().getPort();


        public clsInfoFan createFan(clsInfoFan pclsInfoFan, ref clsResponse pclsResponse)
         {
           
             try
             {                   
                 SqlCommand cmd = new SqlCommand("myFan.SP_CrearFanatico", conn);
                 cmd.CommandType = System.Data.CommandType.StoredProcedure;
                 cmd.Parameters.Add("@strLoginName", System.Data.SqlDbType.VarChar).Value = pclsInfoFan.Username;
                 cmd.Parameters.Add("@strNombre", System.Data.SqlDbType.VarChar).Value = pclsInfoFan.Name;
                 cmd.Parameters.Add("@strGeneros", System.Data.SqlDbType.VarChar).Value = String.Join(",",pclsInfoFan.Genres);
                 cmd.Parameters.Add("@dtFechaNacimiento", System.Data.SqlDbType.Date).Value = pclsInfoFan.Birthday;
                 cmd.Parameters.Add("@intPais", System.Data.SqlDbType.Int).Value = pclsInfoFan.Country;
                 cmd.Parameters.Add("@intSexo", System.Data.SqlDbType.Int).Value = pclsInfoFan.Gender;
                 cmd.Parameters.Add("@strSalt", System.Data.SqlDbType.VarChar).Value = pclsInfoFan.Salt;
                 cmd.Parameters.Add("@strSaltHashedPassword", System.Data.SqlDbType.VarChar).Value = pclsInfoFan.SaltHashed;
                 SqlParameter message = cmd.Parameters.Add("@strMessageError", SqlDbType.VarChar, 256);
                 message.Direction = ParameterDirection.Output;
                 SqlParameter cod = cmd.Parameters.Add("@strCodError", SqlDbType.VarChar, 4);
                 cod.Direction = ParameterDirection.Output;
                SqlParameter id = cmd.Parameters.Add("@intCodeUserReturn", SqlDbType.Int);
                id.Direction = ParameterDirection.Output;
                conn.Open();
                
                SqlDataReader result = cmd.ExecuteReader();
                Console.WriteLine("entre");
                pclsInfoFan.Id = Convert.ToInt32(id.Value);     
                       
                pclsResponse.Code = Convert.ToInt32(cod.Value.ToString());
                 pclsResponse.Message = message.Value.ToString();
                 pclsResponse.Success = true;

            }
             catch (SqlException ex)
             {
                pclsResponse.Code = 1;
                pclsResponse.Success = false;
                pclsResponse.Message = "Error while procesing your request.";
            }
             catch (Exception ex)
             {
                pclsResponse.Code = 2;
                pclsResponse.Success = false;
                pclsResponse.Message = "Unexpected error.";
            }
             finally
             {
                 conn.Close(); 
             }
             return pclsInfoFan;
         }

        public clsInfoFan updateFan(clsInfoFan pclsInfoFan, ref clsResponse pclsResponse)
        {
            try
            {

                SqlCommand cmd = new SqlCommand("myFan.SP_ActualizarFanatico", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@strLoginName", System.Data.SqlDbType.VarChar).Value = pclsInfoFan.Username;
                cmd.Parameters.Add("@strNombre", System.Data.SqlDbType.VarChar).Value = pclsInfoFan.Name;
                cmd.Parameters.Add("@strGeneros", System.Data.SqlDbType.VarChar).Value = String.Join(",", pclsInfoFan.Genres);
                cmd.Parameters.Add("@dtFechaNacimiento", System.Data.SqlDbType.Date).Value = pclsInfoFan.Birthday;
                cmd.Parameters.Add("@intPais", System.Data.SqlDbType.Int).Value = pclsInfoFan.Country;
                cmd.Parameters.Add("@intSexo", System.Data.SqlDbType.Int).Value = pclsInfoFan.Gender;
                SqlParameter message = cmd.Parameters.Add("@strMessageError", SqlDbType.VarChar, 256);
                message.Direction = ParameterDirection.Output;
                SqlParameter cod = cmd.Parameters.Add("@strCodError", SqlDbType.VarChar, 4);
                cod.Direction = ParameterDirection.Output;
                conn.Open();
                cmd.ExecuteNonQuery();
                pclsResponse.Code = Convert.ToInt32(cod.Value.ToString());
                pclsResponse.Message = message.Value.ToString();
                pclsResponse.Success = true;

            }
            catch (SqlException ex)
            {
                pclsResponse.Code = 1;
                pclsResponse.Success = false;
                pclsResponse.Message = "Error while procesing your request.";
            }
            catch (Exception ex)
            {
                pclsResponse.Code = 2;
                pclsResponse.Success = false;
                pclsResponse.Message = "Unexpected error.";
            }
            finally
            {
                conn.Close();
            }
            return pclsInfoFan;
        }
    

        public static void Main()
        {
            clsFanWrite a = new clsFanWrite();
            clsInfoFan b = new clsInfoFan();
            Serializer c = new Serializer();
            b.Username = "StivenBanano22232";
            b.Password = "aadfads23da";
            b.Name = "panoch232onocho";
            b.Genres = new List<string>(new string[] { "1","3","4" });
            b.Birthday = "1-2-2016";
            b.Country = "10";
            b.Gender = "1";
            b.Salt = "oo145232242o";
            b.SaltHashed = "jkjkj232";
            clsFanWrite d = new clsFanWrite();
            clsResponse f = new clsResponse();
            d.createFan(b,ref f);
            Console.WriteLine(c.Serialize(b));
            Console.WriteLine(f.Message);
            Console.ReadKey();
        }
    }
}
