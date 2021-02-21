using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator : AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(c => c.ColorName).Must(MaxLength).WithMessage("Renk adı en fazla 15 karakter olabilir");
        }

        private bool MaxLength(string arg)
        {
            if (arg.Length > 15)
            {
                return false;
            }

            return true;
        }
    }
}
