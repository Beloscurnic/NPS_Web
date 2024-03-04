using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.Upsert_Question
{
    public partial class Question_Upsert
    {
        public class Validation : AbstractValidator<Command>
        {
            public Validation()
            {
                RuleFor(x => x.OprostnikID)
                    .NotNull().WithMessage("OprostnikID не может быть пустым.");
                RuleForEach(command => command.Commands).SetValidator(new CommandValidation());

            }
        }
        public class CommandValidation : AbstractValidator<CommandQuestion>
        {
            public CommandValidation()
            {
                RuleFor(x => x.Insert_before)
              .NotNull().WithMessage("Insert_before не может быть пустым.");

                RuleFor(x => x.IsDeleted)
                    .IsInEnum().WithMessage("IsDeleted должен быть допустимым значением перечисления Status_Question.");

                RuleFor(x => x.TypeQuestion)
                    .IsInEnum().WithMessage("TypeQuestion должен быть допустимым значением перечисления TypeQuestion.");
            }
        }
    }
}
