using Application.Global_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Commands.Upsert_GroupQuestionnaire
{
    public partial class GroupQuestionnaire_Upsert
    {
        public class View_Response : BaseResponse
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int? CompanyOID { get; set; }
            public Guid? LincenseID { get; set; }
        }
    }
}
