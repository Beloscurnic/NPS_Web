using Application.Global_Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.GetProfileInfo
{
    public partial class ProfileInfo_Get
    {
        public class Query: IRequest<View_Model>
        {
            public BaseQueryModel BaseQueryModel { get; set; }
        }
    }
}
