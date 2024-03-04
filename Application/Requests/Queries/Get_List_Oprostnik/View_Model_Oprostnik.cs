using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_List_Oprostnik
{
    public partial class List_Oprostnik_Get
    {
        public class View_Model_Oprostnik
        {
            public int OprostnikID { get; set; }
            public DateTime DataCreat_Oprostnik { get; set; }
            public DateTime? DataModified_Oprostnik { get; set; }
            public int? GroupQuestionnaireID { get; set; }
        }
    }
}
