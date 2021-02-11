using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            if (DateTime.Now.Hour == 19)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        public IResult Update(Brand brand)
        {
            if (DateTime.Now.Hour == 19)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }

            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }

        public IResult Delete(Brand brand)
        {
            if (DateTime.Now.Hour == 19)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }

            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            if (DateTime.Now.Hour == 19)
            {
                return new ErrorDataResult<List<Brand>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.BrandAdded);
        }

        public IDataResult<Brand> GetById(int id)
        {
            if (DateTime.Now.Hour == 19)
            {
                return new ErrorDataResult<Brand>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == id), Messages.BrandFound);
        }

        
    }
}
