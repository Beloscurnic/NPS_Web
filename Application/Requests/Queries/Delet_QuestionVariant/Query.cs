using Application.Global_Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Delet_QuestionVariant
{
    public partial class QuestionVariant_Delet
    {
        public class Query : IRequest<ResponseModel>
        {
            public int QuestionVariantID { get; set; }
            public int OprostnikID { get; set; }
            public BaseQueryModel BaseQueryModel { get; set; }
        }
    }
}
