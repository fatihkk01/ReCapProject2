using Business.Abstract;
using Business.Constans;
using Core.Utilities.Business;
using Core.Utilities.FileOperations;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IResult Add(ImageFile imageFile, CarImage carImage)
        {

            try
            {
                if (imageFile.file.Length > 0)
                {
                    IResult result = BusinessRules.Run(CheckIfImageCount(carImage));

                    if (result != null)
                    {
                        return result;
                    }

                    string _currentDirectory = Environment.CurrentDirectory + "\\wwwroot";
                    string _folderName = "\\images\\";
                    string path = _currentDirectory + _folderName;

                    var fileExtension = Path.GetExtension(imageFile.file.FileName);
                    var imageGuidName = Guid.NewGuid().ToString("D") + fileExtension;



                    var fileExtensionResult = ImageOperations.CheckImageFileExtension(fileExtension);

                    if (!fileExtensionResult.Success)
                    {
                        return fileExtensionResult;
                    }

                    ImageOperations.CheckIsExıstsDirectory(path);

                    ImageOperations.CreateImageFile(path + imageGuidName, imageFile.file);

                    carImage.ImagePath = _folderName + imageGuidName;

                    _carImageDal.Add(carImage);
                    return new SuccessResult(Messages.CarImageAdded);
                }

                return new ErrorResult(Messages.CarImageNull);

            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }


        }

        public IResult Update(ImageFile imageFile, CarImage carImage)
        {
            string _currentDirectory = Environment.CurrentDirectory + "\\wwwroot";
            string _folderName = "\\images\\";
            string path = _currentDirectory + _folderName;

            var updatedImageFile = _carImageDal.Get(ui => ui.Id == carImage.Id);

            if (updatedImageFile == null)
            {
                return new ErrorResult("Silmek istediğiniz id ded bir araba resmi mevcut değil");
            }

            var deleteResult = ImageOperations.DeleteImageFile(_currentDirectory + updatedImageFile.ImagePath);

            if (!deleteResult.Success)
            {
                return deleteResult;
            }

            var fileExtension = Path.GetExtension(imageFile.file.FileName);
            var imageGuidName = Guid.NewGuid().ToString("D") + fileExtension;

            var fileExtensionResult = ImageOperations.CheckImageFileExtension(fileExtension);

            if (!fileExtensionResult.Success)
            {
                return fileExtensionResult;
            }

            ImageOperations.CheckIsExıstsDirectory(path);

            ImageOperations.CreateImageFile(path + imageGuidName, imageFile.file);

            carImage.ImagePath = _folderName + imageGuidName;

            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }


        public IResult Delete(CarImage carImage)
        {
            string _currentDirectory = Environment.CurrentDirectory + "\\wwwroot";

            var deletedImageFile = _carImageDal.Get(di => di.Id == carImage.Id);

            if (deletedImageFile == null)
            {
                return new ErrorResult("Araba resmi mevcut değil");
            }

            IResult result = ImageOperations.DeleteImageFile(_currentDirectory + deletedImageFile.ImagePath);

            if (!result.Success)
            {
                return result;
            }

            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);

        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.CarImagesListed);
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId);

            string path = Environment.CurrentDirectory + "\\wwwroot\\" + "images\\" + "default.jpg";

            if (!result.Any())
            {
                result = new List<CarImage> { new CarImage { CarId = carId, Date=DateTime.Now, ImagePath= path,} };
            }

            return new SuccessDataResult<List<CarImage>>(result, Messages.CarImagesListed);
        }

        public IDataResult<CarImage> GetById(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == id), Messages.CarImagesListed);
        }



        private IResult CheckIfImageCount(CarImage carImage)
        {
            var result = _carImageDal.GetAll(ci => ci.CarId == carImage.CarId);

            if (result.Count >= 5)
            {
                return new ErrorResult(Messages.CarImageCountError);
            }
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IDataResult<List<CarImageDto>> GetCarImageByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImageDto>>(_carImageDal.GetCarImageByCarId(carId), Messages.CarImagesListed);
        }
    }
}
