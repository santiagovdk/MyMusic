﻿using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.BandDataAccess
{
    public class clsBandDA
    {
        clsBandWrite BandWrite = new clsBandWrite();
        clsBandRead BandRead = new clsBandRead();


        public clsInfoBand createBand(clsInfoBand pclsInfoBand, ref clsResponse pclsResponse)
        {
            try
            {
                return BandWrite.createBand(pclsInfoBand, ref pclsResponse);
            }
            catch
            {
                pclsResponse.Code = 007;
                pclsResponse.Success = false;
                pclsResponse.Message = "Internal Error";
                return pclsInfoBand;// cambiar x error
            }
        }
        public void validateHashTag(clsInfoBand pclsInfoBand, ref clsResponse pclsResponse)
        {
            try
            {
                BandRead.validateHashTag(pclsInfoBand, ref pclsResponse);
            }
            catch
            {
                pclsResponse.Code = 007;
                pclsResponse.Success = false;
                pclsResponse.Message = "Internal Error";
            }
        }
        public void getBandInfo(ref clsInfoBand pclsInfoBand, ref clsResponse pclsResponse, int pintUserID)
        {
            BandRead.getBandInfo(ref pclsInfoBand, ref pclsResponse, pintUserID);
        }
        public void getMembersInfo(ref clsInfoBand pclsInfoBand, ref clsResponse pclsResponse, int pintUserID)
        {
            BandRead.getMembersInfo(ref pclsInfoBand, ref pclsResponse, pintUserID);
        }
        public void getGenresBand(ref clsInfoBand pclsInfoBand, ref clsResponse pclsResponse, int pintUserCode)
        {
            BandRead.getGenresBand(ref pclsInfoBand, ref pclsResponse, pintUserCode);
        }
    }
}
