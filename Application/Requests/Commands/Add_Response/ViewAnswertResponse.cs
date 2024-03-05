using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Enums;

namespace Application.Requests.Commands.Add_Response
{
    public partial class Response_Add
    {
        public class ViewAnswertResponse
        {
            public int AnswerID { get; set; }

            public TypeQuestion TypeQuestion { get; set; }
            public string Response_Question { get; set; }
            public int ResponseID { get; set; }
            public int QuestionID { get; set; }
        }
    }

}