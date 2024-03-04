using Application.Global_Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.Delet_Lincense
{
    public partial class Lincense_Delet
    {
        public class Query : IRequest<ResponseModel>
        {
            public Guid ID { get; set; }
            public BaseQueryModel BaseQueryModel { get; set; }  
        }
    }
}

