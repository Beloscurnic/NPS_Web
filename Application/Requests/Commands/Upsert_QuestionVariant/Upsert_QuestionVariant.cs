using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.Upsert_QuestionVariant
{
    public partial class QuestionVariant_Upsert
    {
        public class Upsert_QuestionVariant
        {
            public IList<Command> QuestionVariant_Commands { get; set; }
            public int? QuestionID { get; set; }
            public int? OprostnikID { get; set; }
            public string Token { get; set; }
        }
    }

}
