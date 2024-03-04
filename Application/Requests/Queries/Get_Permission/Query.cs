using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_Permission
{
    public partial class Permissions_Get
    {
        public class Query : IRequest<View_Model_Permissions>
        {

            public string Token { get; set; }
        }
    }
}
