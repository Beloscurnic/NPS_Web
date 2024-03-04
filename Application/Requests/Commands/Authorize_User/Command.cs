using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.Authorize_User
{
    public partial class User_Authorize
    {
        public class Command : IRequest<AuthResponse>
        {
            public string Email { get; set; }
            public string Password { get; set; }
            public Command(string email, string password)
            {
                Email = email;
                Password = password;
            }
        }
    }
}
