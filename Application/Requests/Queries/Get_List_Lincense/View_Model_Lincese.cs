using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domain.Enums;

namespace Application.Requests.Queries.Get_List_Lincense
{
    public partial class List_Lincense_Get
    {
        public class View_Model_Lincese
        {
            public Guid ID { get; set; }
            public int CompanyOID { get; set; }
            //public GroupQuestionnaire? Group_Questionnaire { get; set; }
            public string ActivationCode { get; set; }
            public DateTime Lincense_Activated { get; set; }
            public LicenseStatus License_Status { get; set; }
            public string? Device_Name { get; set; }
        }
    }
}
