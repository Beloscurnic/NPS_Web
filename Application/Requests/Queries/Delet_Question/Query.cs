using Application.Global_Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Delet_Question
{
    public partial class Question_Delet
    {
        public class Query: IRequest<ResponseModel>
        {
            public int IdQuestion { get; set; }
            public BaseQueryModel BaseQuery { get; set; }   
        }
    }
}
