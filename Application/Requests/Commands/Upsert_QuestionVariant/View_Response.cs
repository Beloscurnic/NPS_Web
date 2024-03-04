using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.Upsert_QuestionVariant
{
    public partial class QuestionVariant_Upsert
    {
        public class View_Response
        {
            public int Questions_VariantID { get; set; }
            public int Key { get; set; }
            public bool IsDeleted { get; set; }
            public string Name { get; set; }
            public int? QuestionID { get; set; }
        }
    }
}
