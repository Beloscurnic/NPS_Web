using Application.Global_Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.ChangeLanguage
{
    public partial class ChangeLanguage
    {
        public class Command :IRequest<BaseResponse>
        {
            public string Token { get; set; }
            public int Lang { get; set; }
        }
    }
}
