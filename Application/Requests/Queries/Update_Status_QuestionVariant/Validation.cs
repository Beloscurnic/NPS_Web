using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Update_Status_QuestionVariant
{
    public partial class Status_QuestionVariant_Update
    {
        public class Validation : AbstractValidator<Query>
        {
            public Validation()
            {
                RuleFor(x => x.QuestionVariant_ID)
                    .GreaterThan(0).WithMessage("QuestionVariant_ID должен быть больше нуля.");

                RuleFor(x => x.Oprostnik_ID)
                    .GreaterThan(0).WithMessage("Oprostnik_ID должен быть больше нуля.");
            }
        }
    }
}
