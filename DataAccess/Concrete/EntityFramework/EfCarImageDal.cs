using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarImageDal : EfEntityRepositoryBase<CarImage, NewReCapDbContext>, ICarImageDal
    {
        public List<CarImageDto> GetCarImageByCarId(int carId)
        {
            using(NewReCapDbContext context = new NewReCapDbContext())
            {
                var result = from ci in context.CarImages
                             join c in context.Cars
                             on ci.CarId equals c.CarId
                             where ci.CarId == carId
                             select new CarImageDto { ImagePath = ci.ImagePath };

                return result.ToList();
            }
        }
    }
}
