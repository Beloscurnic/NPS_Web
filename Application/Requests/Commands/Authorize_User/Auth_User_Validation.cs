using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Requests.Commands.Authorize_User.User_Authorize;

namespace Application.Requests.Commands.Authorize_User
{
    
    public class Auth_User_Validation : AbstractValidator<Command>
    {
        public Auth_User_Validation() {
            RuleFor(x => x.Email)
                 .EmailAddress()
                 .NotNull();
            //     .WithName(Localization.Email);
            RuleFor(x => x.Password)
               .NotNull();
            //   .WithName(Localization.Password);
        }
    }
}
