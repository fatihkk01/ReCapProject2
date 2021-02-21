using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {

        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty().WithMessage("Ad boş geçilemez");
            RuleFor(u => u.LastName).NotEmpty().WithMessage("Soyad boş geçilemez");
            RuleFor(u => u.Email).NotEmpty().WithMessage("Email boş geçilemez");
            RuleFor(u => u.Password).NotEmpty().WithMessage("Şifre boş geçilemez");
            RuleFor(u => u.Password).Must(MinLength).WithMessage("Şifre en az 8 karakter olmalıdır");
        }

        private bool MinLength(string arg)
        {
            if (arg.Length < 8)
            {
                return false;
            }

            return true;
        }
    }
}
