using Application.Global_Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Delet_GroupQuestionnaire
{
    public partial class GroupQuestionnaire_Delet
    {
        public class Query : IRequest<ResponseModel>
        {
            public int ID_GroupQuestionnaire { get; set; }
            public BaseQueryModel BaseQueryModel { get; set; }
        }
    }
}
