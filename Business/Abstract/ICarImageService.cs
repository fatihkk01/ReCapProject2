using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<List<CarImage>> GetByCarId(int carId);
        IDataResult<CarImage> GetById(int id);
        IDataResult<List<CarImageDto>> GetCarImageByCarId(int carId);
        IResult Add(ImageFile imageFile,CarImage carImage);
        IResult Update(ImageFile imageFile,CarImage carImage);
        IResult Delete(CarImage carImage);
    }
}
