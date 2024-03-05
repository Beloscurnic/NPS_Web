using Application.Global_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Enums;

namespace Application.Requests.Queries.Get_Answer
{
    public partial class Answer_Get
    {
        public class View_Model : ResponseModel
        {
            public int AnswerID { get; set; }
            public TypeQuestion TypeQuestion { get; set; }
            public string Response_Question { get; set; }
            public int ResponseID { get; set; }
            public int QuestionID { get; set; }
        }
    }
}
