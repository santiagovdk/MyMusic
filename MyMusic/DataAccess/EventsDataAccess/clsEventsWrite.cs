﻿using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EventsDataAccess
{
    public class clsEventsWrite
    {
        private SqlConnection conn = new clsConnection().getPort();

        public int createnew(ref clsEvent pclsEvent, ref clsResponse pclsResponse, int pintUserCode)
        {
            int tmp = new int();
            try
            {
                SqlCommand cmd = new SqlCommand("myFan.SP_IngresarEvento", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@strNombre", System.Data.SqlDbType.VarChar).Value = pclsEvent.Title;
                cmd.Parameters.Add("@strDescripcion", System.Data.SqlDbType.VarChar).Value = pclsEvent.Description;
                cmd.Parameters.Add("@strUbicacion", System.Data.SqlDbType.VarChar).Value = pclsEvent.Location;
                cmd.Parameters.Add("@btEsConcierto", System.Data.SqlDbType.Bit).Value = pclsEvent.IsConcert;
                cmd.Parameters.Add("@strEstado", System.Data.SqlDbType.VarChar).Value = pclsEvent.State;
                cmd.Parameters.Add("@intCodUsuario", System.Data.SqlDbType.Int).Value = pintUserCode;
                cmd.Parameters.Add("@dtFechaHora", System.Data.SqlDbType.DateTime).Value = pclsEvent.Date + pclsEvent.Time;
                SqlParameter id = cmd.Parameters.Add("@intCodNoticia", SqlDbType.Int);
                id.Direction = ParameterDirection.Output; 
                 SqlParameter message = cmd.Parameters.Add("@strMessageError", SqlDbType.VarChar, 256);
                message.Direction = ParameterDirection.Output;
                SqlParameter cod = cmd.Parameters.Add("@strCodError", SqlDbType.VarChar, 4);
                cod.Direction = ParameterDirection.Output;
                conn.Open();
                cmd.ExecuteNonQuery();
                Console.Write("entre");
                tmp = Convert.ToInt32(id.Value.ToString());
                pclsResponse.Code = 0;
                pclsResponse.Message = "Done";
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
            return tmp;
        }
    }
}
