using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Oprostnik
    {
        public int OprostnikID { get; set; }

        public DateTime DataCreat_Oprostnik { get; set; }
        public DateTime? DataModified_Oprostnik { get; set; }
        public  IList<Question>? Question_List { get; set; }
        public  IList<Response>? Responses { get; set; }

        public int? GroupQuestionnaireID { get; set; }
        public virtual GroupQuestionnaire? Group_Questionnaire { get; set; }
    }
}
