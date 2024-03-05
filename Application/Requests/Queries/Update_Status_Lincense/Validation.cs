using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Update_Status_Lincense
{
    public partial class Status_Lincense_Update {
        public class Validation : AbstractValidator<Query>
        {
            public Validation()
            {
                RuleFor(x => x.License_Status)
                   .IsInEnum()
                   .WithMessage("License_Status должен быть допустимым значением перечисления LicenseStatus.");

                RuleFor(x => x.ID)
                  .NotEmpty().WithMessage("ID не может быть пустым.")
                  .Must(id => Guid.TryParse(id.ToString(), out _)).WithMessage("ID должен быть в формате GUID.");
            }
        }
    }
}
