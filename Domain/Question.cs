using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Enums;

namespace Domain
{
    public class Question
    {

        public int QuestionID { get; set; }
        public int Key { get; set; }
        public Status_Question IsDeleted { get; set; }
        public TypeQuestion TypeQuestion { get; set; }
        public string? Name_Question { get; set; } //json
        public IList<Questions_Variant>? Questions_Variants { get; set; }

        public int? OprostnikID { get; set; }
        public virtual Oprostnik? Oprostnik { get; set; }
    }
}
