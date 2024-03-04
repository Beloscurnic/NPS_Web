using Application.Global_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.Upsert_Oprostnik
{
    public partial class Oprostnik_Upsert
    {
        public class View_Response: BaseResponse
        {
            public int OprostnikID { get; set; }

            public DateTime DataCreat_Oprostnik { get; set; }
            public DateTime? DataModified_Oprostnik { get; set; }
            public int? GroupQuestionnaireID { get; set; }
        }
    }
}
