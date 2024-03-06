using Application.Global_Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.ChangePassword
{
    public partial class Password_Change
    {
        public class Command: IRequest<BaseResponse>
        {
            public string NewPassword { get; set; }
            public string OldPassword { get; set; }
            public BaseQueryModel BaseQueryModel { get; set; }
        }
    }
}
