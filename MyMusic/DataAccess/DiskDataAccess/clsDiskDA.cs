﻿using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DiskDataAccess
{
    public class clsDiskDA
    {
        clsDiskRead DiskRead = new clsDiskRead();
        clsDiskWrite DiskWrite = new clsDiskWrite();

        public void getsongs(ref clsDisk pclsDisk, ref clsResponse pclsResponse, int pintDiskCode)
        {
            DiskRead.getsongs(ref pclsDisk, ref pclsResponse, pintDiskCode);
        }
        public void getdiskinfo(ref clsDisk pclsDisk, ref clsResponse pclsResponse, int pintDiskCode)
        {
            DiskRead.getdiskinfo(ref pclsDisk, ref pclsResponse, pintDiskCode);
        }
        public void getdiskreviews(ref List<clsReview> pclsReviews, ref clsResponse pclsResponse, int pintDiskCode)
        {
            DiskRead.getdiskreviews(ref pclsReviews, ref pclsResponse, pintDiskCode);
        }
    }
}
