using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Requests.Queries.Get_List_Response
{
    public partial class List_Response_Get
    {
        public class View_Model
        {
            public int ResponseID { get; set; }
            public int CompanyOID { get; set; }
            public DateTime? Data_Creat_Response { get; set; }
            public int OprostnikID { get; set; }
        }
    }
}