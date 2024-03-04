using Application.Global_Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Enums;

namespace Application.Requests.Queries.Update_Status_Question
{
    public partial class Status_Question_Update
    {
        public class Query :IRequest<View_Model> 
        {
            public int QuestionID { get; set; }
            public Status_Question Status_Question { get; set; }
            public BaseQueryModel BaseQueryModel { get; set; }
        }
    
    }
}
