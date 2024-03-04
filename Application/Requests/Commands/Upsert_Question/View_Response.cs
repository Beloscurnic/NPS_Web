using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Enums;

namespace Application.Requests.Commands.Upsert_Question
{
    public partial class Question_Upsert
    {
        public class View_Response
        {
            public int? QuestionID { get; set; }
            public int Key { get; set; }
            public TypeQuestion TypeQuestion { get; set; }
            public string? Name_Question { get; set; }
            public int? OprostnikID { get; set; }
        }
    }
}
