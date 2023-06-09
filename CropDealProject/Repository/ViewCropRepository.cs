﻿using CropDealProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CropDealProject.Repository
{
    public class ViewCropRepository : IViewCropRepository
    {
        private readonly CropDealDataBaseContext _dbContext;
        public ViewCropRepository(CropDealDataBaseContext dbContext) => this._dbContext = dbContext;

        #region ViewCropsAd
        public List<ViewCrop> ViewCrops()
        {
            try
            {

                var command = (from a in _dbContext.CropOnSales
                               join b in _dbContext.Crops on a.CropId equals b.CropId
                               join c in _dbContext.UserProfiles on a.FarmerId equals c.UserId
                               select new ViewCrop()
                               {
                                   CropSaleId = a.CropSaleId,
                                   CropName = a.CropName,
                                   CropType = a.CropType,
                                   CropQty = a.CropQty,
                                   CropPrice = a.CropPrice,
                                   FarmerId = a.FarmerId,
                                   //CropImage = b.CropImage,
                                   FarmerAddress = c.UserAddress,
                                   FarmerName = c.UserName,
                                   FarmerPhoneNo = c.UserPhoneNo
                               });

                List<ViewCrop> list1 = command.ToList();


                return list1;
            }
            catch
            {
                return null;
            }



        }
        #endregion
    }
}
