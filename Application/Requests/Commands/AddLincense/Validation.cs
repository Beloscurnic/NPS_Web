using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.AddLincense
{
    public partial class Lincense_Add
    {
        public class Validation: AbstractValidator<Command>
        {
            public Validation()
            {
                RuleFor(c => c.CompanyOID)
                    .NotEmpty().WithMessage("CompanyOID не может быть пустым.")
                    .GreaterThan(0).WithMessage("CompanyOID должен быть больше нуля.");

                RuleFor(c => c.Device_Name)
                    .NotEmpty().WithMessage("Device_Name не может быть пустым.");

                RuleFor(x => x.License_Status)
                    .IsInEnum().WithMessage("License_Status должен быть допустимым значением перечисления LicenseStatus.");
                RuleFor(x => x.Lincense_Activated)
                    .NotEmpty().WithMessage("Lincense_Activated не может быть пустым.")
                    .LessThanOrEqualTo(DateTime.Now).WithMessage("Lincense_Activated не может быть в будущем.");
            }
        }
    }

}
