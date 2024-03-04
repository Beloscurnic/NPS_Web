using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_List_QuestionVariant
{
    public partial class List_QuestionVariant_Get
    {
        public class View_Model
        {
            public int Questions_VariantID { get; set; }
            public int Key { get; set; }
            public bool IsDeleted { get; set; }
            public string Name { get; set; }
            public int? QuestionID { get; set; }
        }
    }
}
