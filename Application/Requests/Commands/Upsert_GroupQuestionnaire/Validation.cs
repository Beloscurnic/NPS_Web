using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.Upsert_GroupQuestionnaire
{
    public partial class GroupQuestionnaire_Upsert
    {
        public class Validation : AbstractValidator<Command>
        {
            public Validation()
            {
                RuleFor(i => i.Name).NotEmpty().WithMessage("Name группы не может быть пустым.");
            }
        }
    }
}
