using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, NewReCapDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (NewReCapDbContext context = new NewReCapDbContext())
            {
                var result = from c in context.Cars
                             join cs in context.Colors
                             on c.ColorId equals cs.ColorId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             select new CarDetailDto { CarId = c.CarId, ColorName = cs.ColorName, BrandName = b.BrandName, ModelYear = c.ModelYear, DailyPrice = c.DailyPrice, Description = c.Description };

                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsByBrandId(int brandId)
        {
            using (NewReCapDbContext context = new NewReCapDbContext())
            {
                var result = from c in context.Cars
                             join cs in context.Colors
                             on c.ColorId equals cs.ColorId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             where b.BrandId == brandId
                             select new CarDetailDto { CarId = c.CarId, ColorName = cs.ColorName, BrandName = b.BrandName, ModelYear = c.ModelYear, DailyPrice = c.DailyPrice, Description = c.Description };

                return result.ToList();
            }
        }

        public List<CarDetailDto> GetCarDetailsById(int id)
        {
            using (NewReCapDbContext context = new NewReCapDbContext())
            {
                var result = from c in context.Cars
                             join cs in context.Colors
                             on c.ColorId equals cs.ColorId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join ci in context.CarImages
                             on c.CarId equals ci.CarId
                             where c.CarId == id
                             select new CarDetailDto { CarId = c.CarId, ColorName = cs.ColorName, BrandName = b.BrandName, ModelYear = c.ModelYear, ImagePath=ci.ImagePath, DailyPrice = c.DailyPrice, Description = c.Description };

                return result.ToList();
            }
        }


        public List<CarDetailDto> GetCarDetailsByColorId(int colorId)
        {
            using (NewReCapDbContext context = new NewReCapDbContext())
            {
                var result = from c in context.Cars
                             join cs in context.Colors
                             on c.ColorId equals cs.ColorId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             where c.ColorId == colorId
                             select new CarDetailDto { CarId = c.CarId, ColorName = cs.ColorName, BrandName = b.BrandName, ModelYear = c.ModelYear, DailyPrice = c.DailyPrice, Description = c.Description };

                return result.ToList();
            }
        }

    }
}
