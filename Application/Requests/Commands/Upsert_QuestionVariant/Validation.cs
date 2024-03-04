using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.Upsert_QuestionVariant
{
    public partial class QuestionVariant_Upsert
    {
        public class Validation : AbstractValidator<Command_List>
        {
            public Validation()
            {
                RuleForEach(command => command.QuestionVariant_Commands).SetValidator(new CommandValidation());

            }
        }
        public class CommandValidation : AbstractValidator<Command>
        {
            public CommandValidation()
            {
                //RuleFor(command => command.QuestionID).NotEmpty();
                //RuleFor(command => command.TypeQuestion).NotEmpty();
                //RuleFor(command => command.Name_Question).NotEmpty();
            }
        }
    }
}
