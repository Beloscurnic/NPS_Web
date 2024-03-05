using Application.Global_Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Delet_Answert
{
    public partial class Answert_Delet
    {
        public class Query: IRequest<ResponseModel>
        {
            public int AnswertId { get; set; }
            public BaseQueryModel BaseQueryModel { get; set; }
        }
    }
}
