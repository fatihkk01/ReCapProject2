using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
            if (DateTime.Now.Hour == 19)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }

            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color color)
        {
            if (DateTime.Now.Hour == 19)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }

            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }

        public IResult Delete(Color color)
        {
            if (DateTime.Now.Hour == 19)
            {
                return new ErrorResult(Messages.MaintenanceTime);
            }

            _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {

            if (DateTime.Now.Hour == 19)
            {
                return new ErrorDataResult<List<Color>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(),Messages.ColorsListed);
        }

        public IDataResult<Color> GetById(int id)
        {
            if (DateTime.Now.Hour == 19)
            {
                return new ErrorDataResult<Color>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<Color>(_colorDal.Get(c=>c.ColorId == id),Messages.ColorFound);
        }

       
    }
}
