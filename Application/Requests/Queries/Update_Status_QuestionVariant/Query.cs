using Application.Global_Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Update_Status_QuestionVariant
{
    public partial class Status_QuestionVariant_Update
    {
        public class Query:IRequest<View_Model>
        {
            public int QuestionVariant_ID { get; set; }
            public int Oprostnik_ID { get; set; }
            public BaseQueryModel BaseQueryModel { get; set; }
        }
    }
}
