using Application.Global_Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_List_QuestionVariant
{
    public partial class List_QuestionVariant_Get
    {
        public class Query :IRequest<View_List_Model>
        {
            public int QuestionID { get; set; }
            public BaseQueryModel BaseQueryModel { get; set; }
        }
    }
}
