using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> { new Car { CarId = 1, ColorId = 1, BrandId = 2, DailyPrice = 150, ModelYear = "2018", Description = "Hatchback" },
                                    new Car { CarId = 2, ColorId = 2, BrandId = 3, DailyPrice = 200, ModelYear = "2019", Description = "SUV" },
                                    new Car { CarId = 3, ColorId = 3, BrandId = 4, DailyPrice = 250, ModelYear = "2020", Description = "Hatchback" },
                                    new Car { CarId = 4, ColorId = 4, BrandId = 1, DailyPrice = 300, ModelYear = "2021", Description = "SUV" },
                                    new Car { CarId = 5, ColorId = 2, BrandId = 5, DailyPrice = 400, ModelYear = "2021", Description = "Hatchback" }};
        }

        public void Add(Car entity)
        {
            _cars.Add(entity);
        }

        public void Delete(Car entity)
        {
            var carToDelete = _cars.SingleOrDefault(c => c.CarId == entity.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            var findCarByFilter = _cars.FirstOrDefault(filter.Compile());
            return findCarByFilter;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }

        public Car GetByColorId(int id)
        {
            var findCar = _cars.SingleOrDefault(c => c.ColorId == id);
            return findCar;
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailsByBrandId(int brandId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailsByBrandIdAndColorId(int brandId, int colorId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailsByColorId(int colorId)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetailsById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Car entity)
        {
            var carToUpdate = _cars.SingleOrDefault(c => c.CarId == entity.CarId);
            carToUpdate.ColorId = entity.ColorId;
            carToUpdate.BrandId = entity.BrandId;
            carToUpdate.DailyPrice = entity.DailyPrice;
            carToUpdate.ModelYear = entity.ModelYear;
            carToUpdate.Description = entity.Description;
        }
    }
}
