using Application.Global_Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_GroupQuestionnaire
{
    public partial class GroupQuestionnaire_Get
    {
        public class Query:IRequest<View_Model_GroupQuestionnaire>
        {
            public Guid LincenseID { get; set; }
            public BaseQueryModel BaseQueryModel { get; set; }
        }
    }
}
