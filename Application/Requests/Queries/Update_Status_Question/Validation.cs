using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Update_Status_Question
{
    public partial class Status_Question_Update
    {
        public class Validation : AbstractValidator<Query>
        {
            public Validation()
            {
                RuleFor(x => x.QuestionID)
                    .GreaterThan(0).WithMessage("QuestionID должен быть больше нуля.");

                RuleFor(x => x.Status_Question)
                    .IsInEnum().WithMessage("Status_Question должен быть допустимым значением перечисления Status_Question.");
            }
        }
    }
}
