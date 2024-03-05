using Application.Global_Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Delet_Response
{
    public partial class Response_Delet
    {
        public class Query:  IRequest<ResponseModel>
        {
            public int Response_ID { get; set; }
            public BaseQueryModel BaseQueryModel { get; set; }
        }

    }
}
