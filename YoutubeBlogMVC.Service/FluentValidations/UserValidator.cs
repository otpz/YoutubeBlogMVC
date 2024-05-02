using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeBlogMVC.Entity.Entities;

namespace YoutubeBlogMVC.Service.FluentValidations
{
    public class UserValidator: AbstractValidator<AppUser>
    {
        public UserValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50)
                .WithName("İsim");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(50)
                .WithName("Soyisim");

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .WithName("Email");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .MinimumLength(11)
                .EmailAddress()
                .WithName("Telefon No");
        }
    }
}
