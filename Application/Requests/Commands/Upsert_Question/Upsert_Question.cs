using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Requests.Commands.Upsert_Question.Question_Upsert;

namespace Application.Requests.Commands.Upsert_Question
{
    public partial class Question_Upsert
    {
        public class Upsert_Question
        {
            public IList<CommandQuestion> Commands { get; set; } = new List<CommandQuestion>();
            public int OprostnikID { get; set; }
            public string Token { get; set; }
        }
    }
}
