using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.Upsert_GroupQuestionnaire
{
    public class Upsert_GroupQuestionnaire
    {
        public int? GroupQuestionnaireID { get; set; }
        public string Name { get; set; }

        public Guid? LincenseID { get; set; }
        public string Token { get; set; }   
    }
}
