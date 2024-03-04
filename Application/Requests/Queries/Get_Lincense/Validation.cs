using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_Lincense
{
    public partial class Lincense
    {
        public class Validation : AbstractValidator<Query>
        {
            public Validation()
            {
                RuleFor(x => x.ID)
                .NotEmpty().WithMessage("LincenseID не может быть пустым.")
                .Must(id => Guid.TryParse(id.ToString(), out _)).WithMessage("LincenseID должен быть в формате GUID.");
            }
        }
    }
}
